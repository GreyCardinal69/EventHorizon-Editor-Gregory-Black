using Controls;
using GameDatabase.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static GameDatabase.Reusables;

namespace GameDatabase
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        SolidBrush _backgroundBrush = new SolidBrush( MainWindow.BackgroundColor );
        SolidBrush _borderBrush = new SolidBrush( MainWindow.BorderColor );

        private void DatabaseTreeView_drawNode( object sender, DrawTreeNodeEventArgs e )
        {
            if ( e.Node.IsSelected )
            {
                if ( DatabaseTreeView.Focused )
                {
                    e.Graphics.FillRectangle( _backgroundBrush, e.Bounds );
                }
            }
            else
                e.Graphics.FillRectangle( _borderBrush, e.Bounds );

            TextRenderer.DrawText( e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Node.Bounds, MainWindow.FontColor );
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.DatabaseTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.FileId = new Controls.AdvancedTextBox();
            this.structDataView1 = new Controls.StructDataView();
            this.label1 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.ItemTypeText = new System.Windows.Forms.Label();
            this.ItemTypeLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.createToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.folderToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.contextMenuStrip1 = new Controls.AdvancedContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.pasteToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.loadAsDatabaseToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customMenuStrip1 = new System.Windows.Forms.CustomMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createModMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeConfrmationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listsSortingTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reformatDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAnalytToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.customMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatabaseTreeView
            // 
            this.DatabaseTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseTreeView.BackColor = MainWindow.BorderColor;
            this.DatabaseTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DatabaseTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.DatabaseTreeView.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseTreeView.ForeColor = MainWindow.FontColor;
            this.DatabaseTreeView.Location = new System.Drawing.Point(6, 3);
            this.DatabaseTreeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatabaseTreeView.Name = "DatabaseTreeView";
            this.DatabaseTreeView.Size = new System.Drawing.Size(384, 590);
            this.DatabaseTreeView.TabIndex = 0;
            this.DatabaseTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DatabaseTreeView_drawNode);
            this.DatabaseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabaseTreeView_AfterSelect);
            this.DatabaseTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DatabaseTreeView_MouseDoubleClick);
            this.DatabaseTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DatabaseTreeView_MouseUp);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.ForeColor = MainWindow.FontColor;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.DatabaseTreeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = MainWindow.BorderColor;
            this.splitContainer.Panel2.Controls.Add(this.FileId);
            this.splitContainer.Panel2.Controls.Add(this.structDataView1);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.EditButton);
            this.splitContainer.Panel2.Controls.Add(this.ItemTypeText);
            this.splitContainer.Panel2.Controls.Add(this.ItemTypeLabel);
            this.splitContainer.Panel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer.Panel2.ForeColor = MainWindow.FontColor;
            this.splitContainer.Size = new System.Drawing.Size(800, 605);
            this.splitContainer.SplitterDistance = 394;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 1;
            // 
            // FileId
            // 
            this.FileId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileId.BackColor = MainWindow.BackgroundColor;
            this.FileId.BorderColor = MainWindow.BackgroundColor;
            this.FileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileId.ForeColor = MainWindow.FontColor;
            this.FileId.Location = new System.Drawing.Point(8, 28);
            this.FileId.Name = "FileId";
            this.FileId.Size = new System.Drawing.Size(238, 33);
            this.FileId.TabIndex = 7;
            this.FileId.Text = "ID 0";
            // 
            // structDataView1
            // 
            this.structDataView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.structDataView1.BackColor = MainWindow.BackgroundColor;
            this.structDataView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.structDataView1.Data = null;
            this.structDataView1.Database = null;
            this.structDataView1.ForeColor = MainWindow.FontColor;
            this.structDataView1.Location = new System.Drawing.Point(8, 69);
            this.structDataView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.structDataView1.Name = "structDataView1";
            this.structDataView1.Size = new System.Drawing.Size(238, 458);
            this.structDataView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = MainWindow.BackgroundColor;
            this.label1.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = MainWindow.FontColor;
            this.label1.Location = new System.Drawing.Point(207, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gregory Black By Cardinal";
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.FlatAppearance.BorderColor = MainWindow.FontColor;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = MainWindow.FontColor;
            this.EditButton.Location = new System.Drawing.Point(8, 537);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(112, 37);
            this.EditButton.TabIndex = 4;
            this.EditButton.TabStop = false;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ItemTypeText
            // 
            this.ItemTypeText.AutoSize = true;
            this.ItemTypeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypeText.ForeColor = MainWindow.FontColor;
            this.ItemTypeText.Location = new System.Drawing.Point(90, 3);
            this.ItemTypeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ItemTypeText.Name = "ItemTypeText";
            this.ItemTypeText.Size = new System.Drawing.Size(14, 20);
            this.ItemTypeText.TabIndex = 3;
            this.ItemTypeText.Text = "-";
            // 
            // ItemTypeLabel
            // 
            this.ItemTypeLabel.AutoSize = true;
            this.ItemTypeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypeLabel.ForeColor = MainWindow.FontColor;
            this.ItemTypeLabel.Location = new System.Drawing.Point(3, 3);
            this.ItemTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ItemTypeLabel.Name = "ItemTypeLabel";
            this.ItemTypeLabel.Size = new System.Drawing.Size(86, 21);
            this.ItemTypeLabel.TabIndex = 2;
            this.ItemTypeLabel.Text = "Item type:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.AddExtension = false;
            this.saveFileDialog.FileName = "mod";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.createToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.createToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.folderToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = MainWindow.BackgroundColor;
            this.contextMenuStrip1.ForeColor = MainWindow.FontColor;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 82);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.copyToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.copyToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.pasteToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.pasteToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // loadAsDatabaseToolStripMenuItem
            // 
            this.loadAsDatabaseToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.loadAsDatabaseToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.loadAsDatabaseToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.loadAsDatabaseToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.loadAsDatabaseToolStripMenuItem.Name = "loadAsDatabaseToolStripMenuItem";
            this.loadAsDatabaseToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.loadAsDatabaseToolStripMenuItem.Text = "Load as Database";
            this.loadAsDatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadAsDatabaseToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // customMenuStrip1
            // 
            this.customMenuStrip1.ForeColor = MainWindow.BackgroundColor;
            this.customMenuStrip1.ImageMarginGradientBegin = MainWindow.BorderColor;
            this.customMenuStrip1.ImageMarginGradientEnd = MainWindow.FontColor;
            this.customMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.utilitesToolStripMenuItem});
            this.customMenuStrip1.Location = new System.Drawing.Point(0, 0);

            this.customMenuStrip1.MenuBorder = MainWindow.BorderColor;
            this.customMenuStrip1.MenuItemBorder = MainWindow.BorderColor;

            this.customMenuStrip1.MenuItemPressedGradientBegin = MainWindow.BorderColor;
            this.customMenuStrip1.MenuItemPressedGradientEnd = MainWindow.BorderColor;

            this.customMenuStrip1.MenuItemSelected = MainWindow.BorderColor;
            this.customMenuStrip1.MenuItemSelectedGradientBegin = MainWindow.BorderColor;
            this.customMenuStrip1.MenuItemSelectedGradientEnd = MainWindow.BorderColor;

            this.customMenuStrip1.MenuStripForeColor = MainWindow.FontColor;
            this.customMenuStrip1.MenuStripGradientBegin = MainWindow.BorderColor;
            this.customMenuStrip1.MenuStripGradientEnd = MainWindow.FontColor;

            this.customMenuStrip1.Name = "customMenuStrip1";
            this.customMenuStrip1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.customMenuStrip1.Size = new System.Drawing.Size(800, 25);
            this.customMenuStrip1.TabIndex = 3;
            this.customMenuStrip1.Text = "customMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsMenuItem,
            this.reloadDatabaseToolStripMenuItem,
            this.createModMenuItem});
            this.fileToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.BackColor = MainWindow.BackgroundColor;
            this.loadMenuItem.ForeColor = MainWindow.FontColor;
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.Size = new System.Drawing.Size(161, 22);
            this.loadMenuItem.Text = "Load";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.saveToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.BackColor = MainWindow.BackgroundColor;
            this.saveAsMenuItem.ForeColor = MainWindow.FontColor;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveAsMenuItem.Text = "Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // reloadDatabaseToolStripMenuItem
            // 
            this.reloadDatabaseToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.reloadDatabaseToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.reloadDatabaseToolStripMenuItem.Name = "reloadDatabaseToolStripMenuItem";
            this.reloadDatabaseToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.reloadDatabaseToolStripMenuItem.Text = "Reload Database";
            this.reloadDatabaseToolStripMenuItem.Click += new System.EventHandler(this.reloadDatabaseToolStripMenuItem_Click);
            // 
            // createModMenuItem
            // 
            this.createModMenuItem.BackColor = MainWindow.BackgroundColor;
            this.createModMenuItem.ForeColor = MainWindow.FontColor;
            this.createModMenuItem.Name = "createModMenuItem";
            this.createModMenuItem.Size = new System.Drawing.Size(161, 22);
            this.createModMenuItem.Text = "Create Mod...";
            this.createModMenuItem.Click += new System.EventHandler(this.createModMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
   //         this.optionsToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeConfrmationToolStripMenuItem,
            this.listsSortingTypeToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // closeConfrmationToolStripMenuItem
            // 
            this.closeConfrmationToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.closeConfrmationToolStripMenuItem.Checked = true;
            this.closeConfrmationToolStripMenuItem.CheckOnClick = true;
            this.closeConfrmationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeConfrmationToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.closeConfrmationToolStripMenuItem.Name = "closeConfrmationToolStripMenuItem";
            this.closeConfrmationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeConfrmationToolStripMenuItem.Text = "Exit Confirmation";
            this.closeConfrmationToolStripMenuItem.Click += new System.EventHandler(this.closeConfrmationToolStripMenuItem_Click);
            // 
            // listsSortingTypeToolStripMenuItem
            // 
            this.listsSortingTypeToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.listsSortingTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byFolderToolStripMenuItem,
            this.byNameToolStripMenuItem,
            this.byIdToolStripMenuItem});
            this.listsSortingTypeToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.listsSortingTypeToolStripMenuItem.Name = "listsSortingTypeToolStripMenuItem";
            this.listsSortingTypeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.listsSortingTypeToolStripMenuItem.Text = "Lists Sorting Type";
            // 
            // byFolderToolStripMenuItem
            // 
            this.byFolderToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.byFolderToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.byFolderToolStripMenuItem.Name = "byFolderToolStripMenuItem";
            this.byFolderToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.byFolderToolStripMenuItem.Text = "By Folder";
            this.byFolderToolStripMenuItem.Click += new System.EventHandler(this.byFolderToolStripMenuItem_Click);
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.byNameToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.byNameToolStripMenuItem.Text = "By Name";
            this.byNameToolStripMenuItem.Click += new System.EventHandler(this.byNameToolStripMenuItem_Click);
            // 
            // byIdToolStripMenuItem
            // 
            this.byIdToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.byIdToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.byIdToolStripMenuItem.Name = "byIdToolStripMenuItem";
            this.byIdToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.byIdToolStripMenuItem.Text = "By Id";
            this.byIdToolStripMenuItem.Click += new System.EventHandler(this.byIdToolStripMenuItem_Click);
            // 
            // utilitesToolStripMenuItem
            // 
            this.utilitesToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.utilitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reformatDatabaseToolStripMenuItem,
            this.runAnalytToolStripMenuItem});
            this.utilitesToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.utilitesToolStripMenuItem.Name = "utilitesToolStripMenuItem";
            this.utilitesToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.utilitesToolStripMenuItem.Text = "Utilites";
            // 
            // reformatDatabaseToolStripMenuItem
            // 
            this.reformatDatabaseToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.reformatDatabaseToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.reformatDatabaseToolStripMenuItem.Name = "reformatDatabaseToolStripMenuItem";
            this.reformatDatabaseToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reformatDatabaseToolStripMenuItem.Text = "Reformat Database";
            this.reformatDatabaseToolStripMenuItem.Click += new System.EventHandler(this.reformatDatabaseToolStripMenuItem_Click);
            // 
            // runAnalytToolStripMenuItem
            // 
            this.runAnalytToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.runAnalytToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runAnalytToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.runAnalytToolStripMenuItem.Name = "runAnalytToolStripMenuItem";
            this.runAnalytToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.runAnalytToolStripMenuItem.Text = "Run Analytics";
            this.runAnalytToolStripMenuItem.Click += new System.EventHandler(this.runAnalytToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = MainWindow.BorderColor;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.customMenuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = MainWindow.FontColor;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(100, 100);
            this.MainMenuStrip = this.customMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "Game database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.customMenuStrip1.ResumeLayout(false);
            this.customMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void loadAsDatabaseToolStripMenuItem_Open( PaintEventArgs obj )
        {
            throw new NotImplementedException();
        }

        private System.Windows.Forms.TreeView DatabaseTreeView;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label ItemTypeLabel;
        private System.Windows.Forms.Label ItemTypeText;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Controls.StructDataView structDataView1;
        private Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog folderBrowserDialog1;

        #endregion

        private Controls.AdvancedToolStripMenuItem createToolStripMenuItem;
        private Controls.AdvancedToolStripMenuItem folderToolStripMenuItem;
        private Controls.AdvancedToolStripMenuItem loadAsDatabaseToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private CustomMenuStrip customMenuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
        private ToolStripMenuItem reloadDatabaseToolStripMenuItem;
        private Controls.AdvancedToolStripMenuItem createModMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem closeConfrmationToolStripMenuItem;
        private ToolStripMenuItem listsSortingTypeToolStripMenuItem;
        private ToolStripMenuItem byFolderToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byIdToolStripMenuItem;
        private ToolStripMenuItem utilitesToolStripMenuItem;
        private ToolStripMenuItem reformatDatabaseToolStripMenuItem;
        private Controls.AdvancedContextMenuStrip contextMenuStrip1;
        private Label label1;
        private AdvancedToolStripMenuItem copyToolStripMenuItem;
        private AdvancedToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem runAnalytToolStripMenuItem;
        private Controls.AdvancedTextBox FileId;
    }
}