using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using GameDatabase.GameDatabase.Helpers;
using GameDatabase.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = EditorDatabase.Storage.JsonSerializer;

namespace GameDatabase
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            OppenedWindows = new Dictionary<string, Form>();

            closeConfrmationToolStripMenuItem.Checked = Settings.Default.ClosingConfirmation;

            ChangeSorting(Settings.Default.SortingType);
        }

        private void MainWindow_Load(object sender, EventArgs eventArgs)
        {
            OpenDatabase(Directory.GetCurrentDirectory());
        }

        private void OpenDatabase(string path)
        {
            if (string.IsNullOrEmpty(_lastDatabasePath))
            {
                _lastDatabasePath = path;
            }

            try
            {
                DatabaseTreeView.Nodes.Clear();
                CloseAllChilds();
                _database = new Database(new DatabaseStorage(path));
                BuildFilesTree(path, DatabaseTreeView.Nodes);
                _lastDatabasePath = path;
                BuildTemplates(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + e.StackTrace);
            }
        }

        private void BuildFilesTree(string path, TreeNodeCollection nodeCollection)
        {
            try
            {
                foreach (var directory in Directory.EnumerateDirectories(path))
                {
                    var name = directory.Substring(directory.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) + 1);
                    var node = nodeCollection.Add(directory, name);
                    node.Tag = "Folder";
                    BuildFilesTree(directory, node.Nodes);
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                    nodeCollection.Add(file, Helpers.FileName(file));
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void BuildTemplates(string _path)
        {
            createToolStripMenuItem.DropDownItems.Clear();
            createToolStripMenuItem.DropDownItems.Add(folderToolStripMenuItem);
            ToolStripMenuItem item = new ToolStripMenuItem("Templates");
            item.Name = "Templates";
            createToolStripMenuItem.DropDownItems.Add(item);
            item = new ToolStripMenuItem("");
            item.Enabled = false;
            createToolStripMenuItem.DropDownItems.Add(item);
            _templates = new Templates();
            _templates.Load(_path);
            foreach (SerializableTemplate template in _templates.Data)
            {
                var lastNode = createToolStripMenuItem;
                var name = template.Name;
                if (template.Name.Contains('/'))
                {
                    var path = template.Name.Split('/');
                    name = path.Last();
                    for (var i = 0; i < path.Length - 1; i++)
                    {
                        var findResult = lastNode.DropDownItems.Find(path[i], false);
                        ToolStripMenuItem curNode;
                        if (findResult.Length == 0 || (curNode = findResult[0] as ToolStripMenuItem) == null)
                        {
                            curNode = new ToolStripMenuItem(path[i]);
                            curNode.Name = path[i];
                            lastNode.DropDownItems.Add(curNode);
                        }

                        lastNode = curNode;
                    }
                }

                item = new ToolStripMenuItem(name);
                lastNode.DropDownItems.Add(item);
                item.Tag = item.Name = template.Name;
                item.Click += TemplateMenuItem_Click;
            }
        }

        private void DatabaseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowItemInfo(e.Node.Name);
        }

        private void DatabaseTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode node = DatabaseTreeView.GetNodeAt(p);
                if (node != null)
                {
                    DatabaseTreeView.SelectedNode = node;
                    ShowItemInfo(node.Name);
                    contextMenuStrip1.Show(this, p);
                }
            }
        }

        private Dictionary<string, string> ghostFiles = new Dictionary<string, string>();

        private void ShowItemInfo(string path)
        {
            try
            {
                ItemTypeText.Text = @"-";
                _selectedItem = new SerializableItem();
                EditButton.Enabled = false;

                if (Directory.Exists(path))
                {
                    ItemTypeText.Text = @"Directory";
                    structDataView1.Data = GetDirectoryInfo(path);
                    return;
                }

                string data;
                if (File.Exists(path))
                    data = File.ReadAllText(path);
                else
                    data = ghostFiles[path];
                var name = Helpers.FileName(path);
                var item = JsonConvert.DeserializeObject<SerializableItem>(data);
                item.FileName = name;
                if (item.ItemType == ItemType.Undefined)
                    return;

                ItemTypeText.Text = item.ItemType.ToString();
                _selectedItem = item;

                structDataView1.Database = _database;
                structDataView1.Data = GetItem();

                EditButton.Enabled = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        private struct DirectoryInfoData
        {
            public NumericValue<int> FilesCount;
            public ItemType ItemTypes;
            public NumericValue<int> LastItemId;
            public NumericValue<int> FirstUnusedId;
        }

        private DirectoryInfoData GetDirectoryInfo(string path)
        {
            DirectoryInfoData data = new DirectoryInfoData
            {
                FilesCount = new NumericValue<int>(0, 0, int.MaxValue),
                ItemTypes = ItemType.Undefined,
                LastItemId = new NumericValue<int>(0, 0, int.MaxValue),
                FirstUnusedId = new NumericValue<int>(0, 0, int.MaxValue),
            };

            try
            {
                int lastId = -1;
                HashSet<int> occupiedIds = new HashSet<int>();
                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                {
                    var text = File.ReadAllText(file);
                    var item = JsonConvert.DeserializeObject<SerializableItem>(text);

                    data.FilesCount.Value++;

                    if (item.ItemType == ItemType.Undefined)
                        continue;

                    if (lastId <= item.Id)
                        lastId = item.Id;

                    occupiedIds.Add(item.Id);

                    if (data.ItemTypes == ItemType.Undefined)
                        data.ItemTypes = item.ItemType;
                }

                data.LastItemId.Value = lastId;
                var index = 1;
                while (occupiedIds.Contains(index))
                {
                    index++;
                }

                data.FirstUnusedId.Value = index;
            }
            catch (Exception e)
            {
            }

            return data;
        }

        private void DatabaseTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditButton_Click(sender, e);
        }

        public static Dictionary<string, Form> OppenedWindows;

        private void EditButton_Click(object sender, EventArgs e)
        {
            var item = GetItem();
            if (item == null)
                return;
            if (OppenedWindows.ContainsKey(_selectedItem.FileName))
            {
                return;
            }

            Form window;
            switch (_selectedItem.ItemType)
            {
                case ItemType.Component:
                    (window = new ComponentEditorDialog(_database, (Component) item)).Show();
                    break;
                case ItemType.Satellite:
                case ItemType.Ship:
                    (window = new ShipEditorDialog(_database, item, _selectedItem.FileName)).Show();
                    break;
                default:
                    (window = new EditorDialog(_database, item, _selectedItem.FileName)).Show();
                    break;
            }

            OppenedWindows.Add(_selectedItem.FileName, window);
        }

        private object GetItem()
        {
            return _database.GetItem(_selectedItem.ItemType, _selectedItem.Id);
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenDatabase(folderBrowserDialog1.SelectedPath);
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _database.Save(new DatabaseStorage(folderBrowserDialog1.SelectedPath));
                ghostFiles.Clear();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (!string.IsNullOrWhiteSpace(_lastDatabasePath))
            {
                _database.Save(new DatabaseStorage(_lastDatabasePath));
                ghostFiles.Clear();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_lastDatabasePath != null && Settings.Default.ClosingConfirmation)
            {
                var result = MessageBox.Show("Do you want to save database before closing?", "About to exit program?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        save();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void createModMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lastDatabasePath))
                return;

            try
            {
                if (!ModBuilder.TryReadSignature(_lastDatabasePath, out var name, out var guid))
                {
                    var dialog = new NameForm();
                    if (dialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.Name))
                        return;

                    name = dialog.Name;
                    guid = Guid.NewGuid().ToString();

                    File.WriteAllText(Path.Combine(_lastDatabasePath, ModBuilder.SignatureFileName),
                        name + '\n' + guid);
                }

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                _database.Save(new DatabaseStorage(_lastDatabasePath));
                var builder = ModBuilder.Create(_lastDatabasePath);
                builder.Build((FileStream) saveFileDialog.OpenFile());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private SerializableItem _selectedItem;
        private Database _database;
        private Templates _templates;
        private string _lastDatabasePath;

        private void reloadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabase(_lastDatabasePath);
        }

        private void loadAsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabase(DatabaseTreeView.SelectedNode.Name);
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Input folder name", "");
            if (name == "") return;
            var _node = DatabaseTreeView.SelectedNode;
            if (Path.GetInvalidFileNameChars().Any(name.Contains))
            {
                MessageBox.Show("Folder name contains invalid characters");
                return;
            }

            if (_node.Tag == null || _node.Tag.ToString() != "Folder")
            {
                _node = _node.Parent;
            }

            var _path = Path.Combine(_node.Name, name);
            if (Directory.Exists(_path))
            {
                MessageBox.Show("Folder with same name already exists");
                return;
            }

            var _folder = new TreeNode(name);
            _folder.Name = _path;
            _folder.Tag = "Folder";
            _node.Nodes.Insert(0, _folder);
        }

        private void TemplateMenuItem_Click(object sender, EventArgs e)
        {
            ItemFromTemplate(sender, e, "", "");
        }

        private void ItemFromTemplate(object sender, EventArgs e, string name, string __id)
        {
            if (sender is ToolStripMenuItem)
            {
                var template = _templates.Get((sender as ToolStripMenuItem).Tag.ToString());

                name = Prompt.ShowDialog(template.NameDialog, "", name);
                if (name == "") return;
                var _node = DatabaseTreeView.SelectedNode;
                if (Path.GetInvalidFileNameChars().Any(name.Contains))
                {
                    MessageBox.Show("File Name contains invalid characters");
                    ItemFromTemplate(sender, e, "", __id);
                    return;
                }

                if (_node.Tag == null || _node.Tag.ToString() != "Folder")
                {
                    _node = _node.Parent;
                }

                var result = Prompt.ShowDialog(template.IdDialog, "", __id);
                if (result == "") return;
                int id;
                try
                {
                    id = Int32.Parse(result);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Id is too big");
                    ItemFromTemplate(sender, e, name, "");
                    return;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.GetType());
                    MessageBox.Show("Invalid Id");
                    ItemFromTemplate(sender, e, name, "");
                    return;
                }

                try
                {
                    var items = template.Items;
                    Dictionary<string, JObject> files = new Dictionary<string, JObject>();
                    Dictionary<TreeNode, TreeNode> nodes = new Dictionary<TreeNode, TreeNode>();
                    HashSet<string> _files = new HashSet<string>();
                    HashSet<string> _dirs = new HashSet<string>();

                    int FormatIntegerField(string value)
                    {
                            string formatted = string.Format(value, id);
                            return (int) new DataTable().Compute(formatted, null);
                    }

                    string FormatStringField(string value)
                    {
                        return string.Format(value, id, name);
                    }

                    void FormatField(JToken field)
                    {
                        switch (field.Type)
                        {
                            case JTokenType.String:
                                var value = field.Value<string>();
                                if (value.StartsWith("%n"))
                                {
                                    value = value.Replace("%n", "");
                                    var num = FormatIntegerField(value);
                                    field.Replace(num);
                                } else if (value.StartsWith("%s"))
                                {
                                    value = value.Replace("%s", "");
                                    var str = FormatStringField(value);
                                    field.Replace(str);
                                }
                                break;
                            case JTokenType.Object:
                                FormatRecursive(field.Value<JObject>());
                                break;
                            case JTokenType.Array:
                                foreach (var element in field.Value<JArray>())
                                {
                                    FormatField(element);
                                }
                                break;
                        }
                    }

                    void FormatRecursive(JObject body)
                    {
                        foreach (var property in body.Properties())
                        {
                            FormatField(property.Value);
                        }
                    }

                    bool error = false;

                    void BuildTemplateItems(SerializableTemplateItem[] _items, TreeNode _parentNode)
                    {
                        if (error) return;
                        for (int i = 0; i < _items.Length; i++)
                        {
                            var item = _items[i];
                            var path = Path.Combine(_parentNode.Name, FormatStringField(item.Filename));
                            TreeNode _newNode;
                            if (item.Type == "Folder")
                            {
                                _newNode = new TreeNode(
                                    path.Substring(path.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) + 1))
                                {
                                    Name = path
                                };
                                _newNode.Tag = "Folder";
                                nodes.Add(_newNode, _parentNode);
                                BuildTemplateItems(item.Items, _newNode);
                                continue;
                            }

                            path += ".json";
                            string filename = Helpers.FileName(path);
                            _newNode = new TreeNode(filename)
                            {
                                Name = path
                            };
                            nodes.Add(_newNode, _parentNode);
                            _files.Add(path);
                            var content = files[path] = (JObject) _items[i].Content.DeepClone();
                            FormatRecursive(content);
                            
                            var _id = (int) content.GetValue("Id");

                            if (File.Exists(path) || ghostFiles.ContainsKey(path))
                            {
                                MessageBox.Show($"File {path} already exists");
                                error = true;
                                return;
                            }

                            var type = (ItemType) (int) content.GetValue("ItemType");
                            try
                            {
                                _database.GetItem(type, id);
                                MessageBox.Show($"{type} with Id  {_id} already exists");
                                return;
                            }
                            catch (NullReferenceException)
                            {
                            }
                        }
                    }

                    BuildTemplateItems(template.Items, _node);

                    if (error)
                    {
                        ItemFromTemplate(sender, e, name, id.ToString());
                        return;
                    }

                    foreach (string path in _files)
                    {
                        _database.LoadJson(path, files[path].ToString());

                        ghostFiles.Add(path, files[path].ToString());
                    }

                    foreach (TreeNode node in nodes.Keys)
                    {
                        nodes[node].Nodes.Add(node);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Unexpected error happened, most likely due to invalid template file.\nIf yoy sure your template file is correct, then report stacktrace bellow\n\n" +
                        ex);
                    return;
                }
            }
        }

        private void closeConfrmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ClosingConfirmation = closeConfrmationToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void CloseAllChilds()
        {
            foreach (var key in new List<string>(OppenedWindows.Keys))
            {
                if (!OppenedWindows.ContainsKey(key)) continue;
                OppenedWindows[key].Close();
            }

            OppenedWindows = new Dictionary<string, Form>();
        }

        private void ChangeSorting(int type)
        {
            byFolderToolStripMenuItem.Checked = type == 0;
            byNameToolStripMenuItem.Checked = type == 1;
            byIdToolStripMenuItem.Checked = type == 2;
            Settings.Default.SortingType = type;
            Settings.Default.Save();
        }

        private void byFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSorting(0);
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSorting(1);
        }

        private void byIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSorting(2);
        }
    }
}