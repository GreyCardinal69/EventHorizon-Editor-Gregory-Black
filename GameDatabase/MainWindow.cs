﻿using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using GameDatabase.Controls;
using GameDatabase.GameDatabase.Helpers;
using GameDatabase.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static GameDatabase.Reusables;

namespace GameDatabase
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            DBESettings = JsonConvert.DeserializeObject<DBESettings>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Settings.gregory"));

            ApplyTheme(DBESettings.Themes[DBESettings.ActiveTheme]);

            InitializeComponent();
            folderBrowserDialog1 = new CommonOpenFileDialog();
            folderBrowserDialog1.IsFolderPicker = true;
            MainInstance = this;

            OppenedWindows = new Dictionary<string, Form>();

            closeConfrmationToolStripMenuItem.Checked = Settings.Default.ClosingConfirmation;


            ChangeSorting( Settings.Default.SortingType );
        }

        public DBESettings DBESettings;
        internal static MainWindow MainInstance;
        internal SerializableItem _copiedData;
        internal bool _isTryingToCopy;

        private void ApplyTheme(DBESettings.Theme theme)
        {
            BackgroundColor = ColorTranslator.FromHtml(theme.BackgroundColor);
            BorderColor = ColorTranslator.FromHtml(theme.BorderColor);
            FontColor = ColorTranslator.FromHtml(theme.FontColor);
            Accent = ColorTranslator.FromHtml(theme.Accent);
            Accent2 = ColorTranslator.FromHtml(theme.Accent2);
            Accent3 = ColorTranslator.FromHtml(theme.Accent2);
        }

        internal static Color BackgroundColor;
        internal static Color BorderColor;
        internal static Color FontColor;
        internal static Color Accent;
        internal static Color Accent2;
        internal static Color Accent3;

        private void MainWindow_Load( object sender, EventArgs eventArgs )
        {
            OpenDatabase( Directory.GetCurrentDirectory() );
        }

        private void OpenDatabase( string path )
        {
            folderBrowserDialog1.InitialDirectory = path;
            if ( string.IsNullOrEmpty( _lastDatabasePath ) )
            {
                _lastDatabasePath = path;
            }

            try
            {
                DatabaseTreeView.Nodes.Clear();
                CloseAllChilds();

                var storage = new DatabaseStorage( path );
                storage.LoadDatabaseVersion();
                var result = storage.Version.Compare( Database.VersionMajor, Database.VersionMinor );
                if ( result > 0 )
                    throw new InvalidOperationException( $"Database version in not supported - {storage.Version}. Must be {Database.VersionMajor}.{Database.VersionMinor} or less." );
                if ( result < 0 )
                {
                    var dialogResult = MessageBox.Show( $"Database version is outdated - {storage.Version}. Do you want to upgrade it to {Database.VersionMajor}.{Database.VersionMinor}?",
                        "Warning", MessageBoxButtons.YesNo );
                    if ( dialogResult == DialogResult.Yes )
                        _database = UpgradeDatabase( storage, path );
                }
                else
                {
                    _database = new Database( storage );
                }

                _secondaryDatabse = new Database( new DatabaseStorage( path ) );

                BuildFilesTree( path, DatabaseTreeView.Nodes );
                _lastDatabasePath = path;
                BuildTemplates( path );
            }
            catch ( Exception e )
            {
                MessageBox.Show( e.Message + " " + e.StackTrace );
            }

            if ( _expandedNodes.Count > 0 )
            {
                TreeNode IamExpandedNode;
                for ( int i = 0; i < _expandedNodes.Count; i++ )
                {
                    IamExpandedNode = FindNodeByName( DatabaseTreeView.Nodes, _expandedNodes[i] );
                    if ( IamExpandedNode == null ) continue;
                    ExpandNodePath( IamExpandedNode );
                }
            }
            _expandedNodes.Clear();
        }

        private static Database UpgradeDatabase( IDataStorage storage, string path )
        {
            Console.WriteLine( "Upgrading Database ..." );
            var database = Database.MigrateFrom( storage );
            database.Save( new DatabaseStorage( path ) );
            Console.WriteLine( $"Database upgraded - {database.DatabaseSettings.DatabaseVersion}.{database.DatabaseSettings.DatabaseVersionMinor}" );
            return database;
        }

        internal Database _secondaryDatabse;

        private void BuildFilesTree( string path, TreeNodeCollection nodeCollection )
        {
            try
            {
                foreach ( var directory in Directory.EnumerateDirectories( path ) )
                {
                    var name = directory.Substring( directory.LastIndexOf( "\\", StringComparison.OrdinalIgnoreCase ) + 1 );
                    var node = nodeCollection.Add( directory, name );
                    node.Tag = "Folder";
                    BuildFilesTree( directory, node.Nodes );
                }

                foreach ( var file in Directory.EnumerateFiles( path, "*.json", SearchOption.TopDirectoryOnly ) )
                    nodeCollection.Add( file, Helpers.FileName( file ) );
            }
            catch ( Exception e )
            {
                MessageBox.Show( "Error: " + e.Message );
            }
        }

        private void BuildTemplates( string _path )
        {
            createToolStripMenuItem.DropDownItems.Clear();
            createToolStripMenuItem.DropDownItems.Add( folderToolStripMenuItem );
            AdvancedToolStripMenuItem item = new AdvancedToolStripMenuItem( "Templates" );

            item.BackColor = MainWindow.BackgroundColor;
            item.ForeColor = MainWindow.FontColor;
            item.UseBelow = true;
            item.Name = "Templates";

            createToolStripMenuItem.DropDownItems.Add( item );
            _templates = new Templates();
            _templates.Load( _path );
            foreach ( SerializableTemplate template in _templates.Data )
            {
                AdvancedToolStripMenuItem lastNode = createToolStripMenuItem;

                lastNode.BackColor = MainWindow.BackgroundColor;
                lastNode.ForeColor = MainWindow.FontColor;

                var name = template.Name;
                if ( template.Name.Contains( '/' ) )
                {
                    var path = template.Name.Split( '/' );
                    name = path.Last();
                    for ( var i = 0; i < path.Length - 1; i++ )
                    {
                        var findResult = lastNode.DropDownItems.Find( path[i], false );
                        AdvancedToolStripMenuItem curNode;
                        if ( findResult.Length == 0 || ( curNode = findResult[0] as AdvancedToolStripMenuItem ) == null )
                        {
                            curNode = new AdvancedToolStripMenuItem( path[i] );
                            curNode.BackColor = MainWindow.BackgroundColor;
                            curNode.ForeColor = MainWindow.FontColor;
                            curNode.Name = path[i];
                            lastNode.DropDownItems.Add( curNode );
                        }

                        lastNode = curNode;
                    }
                }

                item = new AdvancedToolStripMenuItem( name );
                item.BackColor = MainWindow.BackgroundColor;
                item.ForeColor = MainWindow.FontColor;
                lastNode.DropDownItems.Add( item );
                item.Tag = item.Name = template.Name;
                item.Click += TemplateMenuItem_Click;
            }
        }

        private void DatabaseTreeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            ShowItemInfo( e.Node.Name );
        }

        private void DatabaseTreeView_MouseUp( object sender, MouseEventArgs e )
        {
            this.EditButton.Enabled = true;
            this.EditButton.ForeColor = MainWindow.FontColor;

            if ( e.Button == MouseButtons.Right )
            {
                Point p = new Point( e.X, e.Y );
                TreeNode node = DatabaseTreeView.GetNodeAt( p );

                if ( node != null )
                {
                    DatabaseTreeView.SelectedNode = node;
                    ShowItemInfo( node.Name );
                    contextMenuStrip1.Show( this, p );
                }
            }
        }

        private Dictionary<string, string> ghostFiles = new Dictionary<string, string>();

        private void ShowItemInfo( string path )
        {
            if ( !( ghostFiles.ContainsKey( path ) ) && !File.Exists( path ) )
            {
                _selectedItem = new SerializableItem();
                ItemTypeText.Text = $@"- Folder";
                structDataView1.Data = null;
                return;
            }

            ItemTypeText.Text = @"-";
            _selectedItem = new SerializableItem();
            EditButton.ForeColor = MainWindow.FontColor;
            EditButton.Enabled = true;

            if ( Directory.Exists( path ) )
            {
                ItemTypeText.Text = @"Directory";
                structDataView1.Data = GetDirectoryInfo( path );
                return;
            }

            string data;
            if ( File.Exists( path ) )
                data = File.ReadAllText( path );
            else
                data = ghostFiles[path];
            var name = Helpers.FileName( path );
            var item = JsonConvert.DeserializeObject<SerializableItem>( data );
            item.FileName = name;
            if ( item.ItemType == ItemType.Undefined )
                return;

            FileId.Text = $"ID: {item.Id}";

            ItemTypeText.Text = item.ItemType.ToString();
            _selectedItem = item;

            structDataView1.Database = _database;
            structDataView1.Data = GetItem();
        }

        private struct DirectoryInfoData
        {
            public NumericValue<int> FilesCount;
            public ItemType ItemTypes;
            public NumericValue<int> FirstItemId;
            public NumericValue<int> LastItemId;
            public NumericValue<int> FirstUnusedId;
        }

        private DirectoryInfoData GetDirectoryInfo( string path )
        {
            DirectoryInfoData data = new DirectoryInfoData
            {
                FilesCount = new NumericValue<int>( 0, 0, int.MaxValue ),
                ItemTypes = ItemType.Undefined,
                FirstItemId = new NumericValue<int>( 0, 0, int.MaxValue ),
                LastItemId = new NumericValue<int>( 0, 0, int.MaxValue ),
                FirstUnusedId = new NumericValue<int>( 0, 0, int.MaxValue ),
            };

            try
            {
                int lastId = -1;
                HashSet<int> occupiedIds = new HashSet<int>();
                foreach ( var file in Directory.EnumerateFiles( path, "*.json", SearchOption.TopDirectoryOnly ) )
                {
                    var text = File.ReadAllText( file );
                    var item = JsonConvert.DeserializeObject<SerializableItem>( text );

                    data.FilesCount.Value++;

                    if ( item.ItemType == ItemType.Undefined )
                        continue;

                    if ( lastId <= item.Id )
                        lastId = item.Id;

                    occupiedIds.Add( item.Id );

                    if ( data.ItemTypes == ItemType.Undefined )
                        data.ItemTypes = item.ItemType;
                }

                data.LastItemId.Value = lastId;
                var index = 1;
                while ( occupiedIds.Contains( index ) )
                {
                    index++;
                }

                data.FirstUnusedId.Value = index;
            }
            catch ( Exception )
            {
            }

            return data;
        }

        private void DatabaseTreeView_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            this.EditButton.Enabled = true;
            this.EditButton.ForeColor = MainWindow.FontColor;

            EditButton_Click( sender, e );
        }

        public static Dictionary<string, Form> OppenedWindows;

        private void EditButton_Click( object sender, EventArgs e )
        {
            this.EditButton.Enabled = true;
            this.EditButton.ForeColor = MainWindow.FontColor;

            var item = GetItem();
            if ( item == null )
                return;
            if ( OppenedWindows.ContainsKey( _selectedItem.FileName ) )
            {
                return;
            }

            Form window;
            switch ( _selectedItem.ItemType )
            {
                case ItemType.Component:
                    ( window = new ComponentEditorDialog( _database, ( Component ) item ) ).Show();
                    break;
                case ItemType.Satellite:
                case ItemType.Ship:
                    ( window = new ShipEditorDialog( _database, item, _selectedItem.FileName ) ).Show();
                    break;
                default:
                    ( window = new EditorDialog( _database, item, _selectedItem.FileName ) ).Show();
                    break;
            }

            var name = _selectedItem.FileName;

            OppenedWindows.Add( name, window );
            window.FormClosed += ( s, i ) =>
            {
                OppenedWindows.Remove( name );
            };
        }

        private object GetItem()
        {
            return _database.GetItem( _selectedItem.ItemType, _selectedItem.Id );
        }

        private void loadMenuItem_Click( object sender, EventArgs e )
        {
            if ( folderBrowserDialog1.ShowDialog() == CommonFileDialogResult.Ok )
            {
                OpenDatabase( folderBrowserDialog1.FileName );
            }
        }

        private void saveAsMenuItem_Click( object sender, EventArgs e )
        {
            if ( folderBrowserDialog1.ShowDialog() == CommonFileDialogResult.Ok )
            {
                _database.Save( new DatabaseStorage( folderBrowserDialog1.FileName ) );
                ghostFiles.Clear();
            }
        }

        private void saveToolStripMenuItem_Click( object sender, EventArgs e )
        {
            save();
        }

        public static void SaveDataBase()
        {
            if ( !string.IsNullOrWhiteSpace( MainInstance._lastDatabasePath ) )
            {
                MainInstance._database.Save( new DatabaseStorage( MainInstance._lastDatabasePath ) );
                MainInstance.ghostFiles.Clear();
            }
        }

        private void save()
        {
            if ( !string.IsNullOrWhiteSpace( _lastDatabasePath ) )
            {
                _database.Save( new DatabaseStorage( _lastDatabasePath ) );
                ghostFiles.Clear();
            }
        }

        private void MainWindow_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( _lastDatabasePath != null && Settings.Default.ClosingConfirmation )
            {
                var result = MessageBox.Show( "Do you want to save database before closing?", "About to exit program?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );

                switch ( result )
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

        public void createModMenuItem_Click( object sender, EventArgs e )
        {
            if ( string.IsNullOrWhiteSpace( _lastDatabasePath ) )
                return;

            try
            {
                if ( !ModBuilder.TryReadSignature( _lastDatabasePath, out var name, out var guid ) )
                {
                    var dialog = new NameForm();
                    if ( dialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace( dialog.Name ) )
                        return;

                    name = dialog.Name;
                    guid = Guid.NewGuid().ToString();

                    File.WriteAllText( Path.Combine( _lastDatabasePath, ModBuilder.SignatureFileName ),
                        name + '\n' + guid );
                }

                if ( saveFileDialog.ShowDialog() != DialogResult.OK )
                    return;

                _database.Save( new DatabaseStorage( _lastDatabasePath ) );
                var builder = ModBuilder.Create( _lastDatabasePath,
                    _database.DatabaseSettings.DatabaseVersion.Value,
                    _database.DatabaseSettings.DatabaseVersionMinor.Value );
                builder.Build( ( FileStream ) saveFileDialog.OpenFile() );
            }
            catch ( Exception exception )
            {
                MessageBox.Show( exception.Message );
            }
        }

        private SerializableItem _selectedItem;
        private Database _database;
        private Templates _templates;
        private string _lastDatabasePath;
        private List<string> _expandedNodes = new List<string>();

        private void reloadDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var name2 = DatabaseTreeView.SelectedNode;

            _expandedNodes = CollectExpandedNodes( DatabaseTreeView.Nodes );

            DatabaseTreeView.Nodes.Remove( name2 );

            OpenDatabase( _lastDatabasePath );
        }

        private void loadAsDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenDatabase( DatabaseTreeView.SelectedNode.Name );
        }

        private void folderToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var name = Prompt.ShowDialog( "Input folder name", "" );
            if ( name == "" ) return;
            var _node = DatabaseTreeView.SelectedNode;
            if ( Path.GetInvalidFileNameChars().Any( name.Contains ) )
            {
                MessageBox.Show( "Folder name contains invalid characters" );
                return;
            }

            if ( _node.Tag == null || _node.Tag.ToString() != "Folder" )
            {
                _node = _node.Parent;
            }

            var _path = Path.Combine( _node.Name, name );
            if ( Directory.Exists( _path ) )
            {
                MessageBox.Show( "Folder with same name already exists" );
                return;
            }

            var _folder = new TreeNode( name );
            _folder.Name = _path;
            _folder.Tag = "Folder";
            _node.Nodes.Insert( 0, _folder );
        }

        private void TemplateMenuItem_Click( object sender, EventArgs e )
        {
            ItemFromTemplate( sender, e, "", "" );
        }

        private void ItemFromTemplate( object sender, EventArgs e, string name, string __id )
        {
            if ( sender is ToolStripMenuItem )
            {
                var template = _templates.Get( ( sender as ToolStripMenuItem ).Tag.ToString() );

                name = Prompt.ShowDialog( template.NameDialog, "", name );
                if ( name == "" ) return;
                TreeNode _node = DatabaseTreeView.SelectedNode;
                if ( Path.GetInvalidFileNameChars().Any( name.Contains ) )
                {
                    MessageBox.Show( "File Name contains invalid characters" );
                    ItemFromTemplate( sender, e, "", __id );
                    return;
                }

                if ( _node.Tag == null || _node.Tag.ToString() != "Folder" )
                {
                    _node = _node.Parent;
                }

                var result = Prompt.ShowDialog( template.IdDialog, "", __id );
                if ( result == "" ) return;
                int id;
                try
                {
                    id = Int32.Parse( result );
                }
                catch ( OverflowException )
                {
                    MessageBox.Show( "Id is too big" );
                    ItemFromTemplate( sender, e, name, "" );
                    return;
                }
                catch ( Exception )
                {
                    MessageBox.Show( "Invalid Id" );
                    ItemFromTemplate( sender, e, name, "" );
                    return;
                }

                try
                {
                    var items = template.Items;
                    Dictionary<string, JObject> files = new Dictionary<string, JObject>();
                    Dictionary<TreeNode, TreeNode> nodes = new Dictionary<TreeNode, TreeNode>();
                    HashSet<string> _files = new HashSet<string>();
                    HashSet<string> _dirs = new HashSet<string>();

                    int FormatIntegerField( string value )
                    {
                        string formatted = string.Format( value, id );
                        return ( int ) new DataTable().Compute( formatted, null );
                    }

                    string FormatStringField( string value )
                    {
                        return string.Format( value, id, name );
                    }

                    void FormatField( JToken field )
                    {
                        switch ( field.Type )
                        {
                            case JTokenType.String:
                                var value = field.Value<string>();
                                if ( value.StartsWith( "%n" ) )
                                {
                                    value = value.Replace( "%n", "" );
                                    var num = FormatIntegerField( value );
                                    field.Replace( num );
                                }
                                else if ( value.StartsWith( "%s" ) )
                                {
                                    value = value.Replace( "%s", "" );
                                    var str = FormatStringField( value );
                                    field.Replace( str );
                                }
                                break;
                            case JTokenType.Object:
                                FormatRecursive( field.Value<JObject>() );
                                break;
                            case JTokenType.Array:
                                foreach ( var element in field.Value<JArray>() )
                                {
                                    FormatField( element );
                                }
                                break;
                        }
                    }

                    void FormatRecursive( JObject body )
                    {
                        foreach ( var property in body.Properties() )
                        {
                            FormatField( property.Value );
                        }
                    }

                    bool error = false;

                    void BuildTemplateItems( SerializableTemplateItem[] _items, TreeNode _parentNode )
                    {
                        if ( error ) return;
                        for ( int i = 0; i < _items.Length; i++ )
                        {
                            var item = _items[i];
                            var path = Path.Combine( _parentNode.Name, FormatStringField( item.Filename ) );
                            TreeNode _newNode;
                            if ( item.Type == "Folder" )
                            {
                                _newNode = new TreeNode(
                                    path.Substring( path.LastIndexOf( "\\", StringComparison.OrdinalIgnoreCase ) + 1 ) )
                                {
                                    Name = path
                                };
                                _newNode.Tag = "Folder";
                                nodes.Add( _newNode, _parentNode );
                                BuildTemplateItems( item.Items, _newNode );
                                continue;
                            }

                            path += ".json";
                            string filename = Helpers.FileName( path );
                            _newNode = new TreeNode( filename )
                            {
                                Name = path
                            };
                            nodes.Add( _newNode, _parentNode );
                            _files.Add( path );
                            var content = files[path] = ( JObject ) _items[i].Content.DeepClone();
                            FormatRecursive( content );

                            var _id = ( int ) content.GetValue( "Id" );

                            if ( File.Exists( path ) || ghostFiles.ContainsKey( path ) )
                            {
                                MessageBox.Show( $"File {path} already exists" );
                                error = true;
                                return;
                            }

                            var type = ( ItemType ) ( int ) content.GetValue( "ItemType" );
                    /*        try
                            {
                                _database.GetItem( type, id );
                                MessageBox.Show( $"{type} with Id  {_id} already exists" );
                                return;
                            }
                            catch ( NullReferenceException )
                            {
                            }*/
                        }
                    }

                    BuildTemplateItems( template.Items, _node );

                    if ( error )
                    {
                        ItemFromTemplate( sender, e, name, id.ToString() );
                        return;
                    }

                    foreach ( string path in _files )
                    {
                        _database.LoadJson( path, files[path].ToString() );

                        ghostFiles.Add( path, files[path].ToString() );
                    }

                    foreach ( TreeNode node in nodes.Keys )
                    {
                        nodes[node].Nodes.Add( node );
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        "Unexpected error happened, most likely due to invalid template file.\nIf yoy sure your template file is correct, then report stacktrace bellow\n\n" +
                        ex );
                    return;
                }
            }
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if ( keyData == ( Keys.Control | Keys.S ) )
            {
                save();
                MessageBox.Show( "The Database has been saved!" );
            }
            else if ( keyData == ( Keys.Control | Keys.F ) )
            {
                createModMenuItem_Click( null, null );
            }
            else if ( keyData == Keys.Delete && DatabaseTreeView.SelectedNode.Level != 0 )
            {
                DialogResult dialogResult = MessageBox.Show( "Delete file?", "", MessageBoxButtons.YesNo );

                if ( dialogResult == DialogResult.Yes )
                {
                    string path = DatabaseTreeView.SelectedNode.Name;
                    string data;
                    if ( File.Exists( path ) )
                        data = File.ReadAllText( path );
                    else
                        data = ghostFiles[path];

                    var name = Helpers.FileName( path );
                    var item = JsonConvert.DeserializeObject<SerializableItem>( data );
                    item.FileName = name;

                    if ( item.ItemType == ItemType.Undefined ) { }

                    ghostFiles.Remove( path );

                    var name2 = DatabaseTreeView.SelectedNode;

                    List<string> ExpandedNodes = new List<string>();
                    ExpandedNodes = CollectExpandedNodes( DatabaseTreeView.Nodes );

                    DatabaseTreeView.Nodes.Remove( name2 );
                    File.Delete( path );

                    OpenDatabase( Directory.GetCurrentDirectory() );

                    if ( ExpandedNodes.Count > 0 )
                    {
                        TreeNode IamExpandedNode;
                        for ( int i = 0; i < ExpandedNodes.Count; i++ )
                        {
                            IamExpandedNode = FindNodeByName( DatabaseTreeView.Nodes, ExpandedNodes[i] );
                            if ( IamExpandedNode == null ) continue;
                            ExpandNodePath( IamExpandedNode );
                        }
                    }
                }
            }

            return base.ProcessCmdKey( ref msg, keyData );
        }

        List<string> CollectExpandedNodes( TreeNodeCollection Nodes )
        {
            List<string> _lst = new List<string>();
            foreach ( TreeNode checknode in Nodes )
            {
                if ( checknode.IsExpanded )
                    _lst.Add( checknode.Name );
                if ( checknode.Nodes.Count > 0 )
                    _lst.AddRange( CollectExpandedNodes( checknode.Nodes ) );
            }
            return _lst;
        }

        TreeNode FindNodeByName( TreeNodeCollection NodesCollection, string Name )
        {
            TreeNode returnNode = null;
            foreach ( TreeNode checkNode in NodesCollection )
            {
                if ( checkNode.Name == Name )
                    returnNode = checkNode;
                else if ( checkNode.Nodes.Count > 0 )
                {
                    returnNode = FindNodeByName( checkNode.Nodes, Name );
                }

                if ( returnNode != null )
                {
                    return returnNode;
                }

            }

            return returnNode;
        }

        void ExpandNodePath( TreeNode node )
        {
            if ( node.Level != 0 )
            {
                node.Expand();
                ExpandNodePath( node.Parent );
            }
            else
            {
                node.Expand();
            }
        }

        private void closeConfrmationToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Settings.Default.ClosingConfirmation = closeConfrmationToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void CloseAllChilds()
        {
            foreach ( var key in new List<string>( OppenedWindows.Keys ) )
            {
                if ( !OppenedWindows.ContainsKey( key ) ) continue;
                OppenedWindows[key].Close();
            }

            OppenedWindows = new Dictionary<string, Form>();
        }

        private void ChangeSorting( int type )
        {
            byFolderToolStripMenuItem.Checked = type == 0;
            byNameToolStripMenuItem.Checked = type == 1;
            byIdToolStripMenuItem.Checked = type == 2;
            Settings.Default.SortingType = type;
            Settings.Default.Save();
        }

        private void byFolderToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ChangeSorting( 0 );
        }

        private void byNameToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ChangeSorting( 1 );
        }

        private void byIdToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ChangeSorting( 2 );
        }

        private void reformatDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new DatabaseReformat().Run();
        }

        private void copyToolStripMenuItem_Click( object sender, EventArgs e )
        {
            _isTryingToCopy = true;
            _copiedData = _selectedItem;
        }

        private void pasteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( _isTryingToCopy && _selectedItem.ItemType == _copiedData.ItemType )
            {
                string path = Directory.GetCurrentDirectory();
                int old = _selectedItem.Id;
                folderBrowserDialog1.InitialDirectory = path;
                _isTryingToCopy = false;
                _selectedItem = _copiedData;
                _database.SetItem( _copiedData.ItemType, _copiedData.Id, old );
            }
        }

        private void runAnalytToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Analytics window = new Analytics( _database );
            window.Show();
        }
    }
}