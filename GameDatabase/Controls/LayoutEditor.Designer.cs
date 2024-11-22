using Controls;
using GameDatabase.Controls;
using GameDatabase.Properties;
using System.Drawing;

namespace GameDatabase
{
    partial class LayoutEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.horizontalSymmetryToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.verticalSymmetryToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showGridToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showLayoutToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showBarrelsToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showBarrelsNumbersToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showEnginesToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.showImageToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.zoomToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.defaultToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.xToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.xToolStripMenuItem1 = new Controls.AdvancedToolStripMenuItem();
            this.xToolStripMenuItem2 = new Controls.AdvancedToolStripMenuItem();
            this.xToolStripMenuItem3 = new Controls.AdvancedToolStripMenuItem();
            this.xToolStripMenuItem4 = new Controls.AdvancedToolStripMenuItem();
            this.barrelsEditingModeToolStripMenuItem = new Controls.AdvancedToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = MainWindow.BackgroundColor;
            this.contextMenuStrip1.ForeColor = MainWindow.FontColor;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalSymmetryToolStripMenuItem,
            this.verticalSymmetryToolStripMenuItem,
            this.showGridToolStripMenuItem,
            this.showLayoutToolStripMenuItem,
            this.showBarrelsToolStripMenuItem,
            this.showBarrelsNumbersToolStripMenuItem,
            this.showEnginesToolStripMenuItem,
            this.showImageToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.barrelsEditingModeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 264);
            // 
            // horizontalSymmetryToolStripMenuItem
            // 
            this.horizontalSymmetryToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.horizontalSymmetryToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.horizontalSymmetryToolStripMenuItem.CheckOnClick = true;
            this.horizontalSymmetryToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.horizontalSymmetryToolStripMenuItem.Name = "horizontalSymmetryToolStripMenuItem";
            this.horizontalSymmetryToolStripMenuItem.ShowShortcutKeys = false;
            this.horizontalSymmetryToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.horizontalSymmetryToolStripMenuItem.Text = "Horizontal symmetry";
            this.horizontalSymmetryToolStripMenuItem.Click += new System.EventHandler(this.horizontalSymmetryToolStripMenuItem_Click);
            // 
            // verticalSymmetryToolStripMenuItem
            // 
            this.verticalSymmetryToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.verticalSymmetryToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.verticalSymmetryToolStripMenuItem.CheckOnClick = true;
            this.verticalSymmetryToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.verticalSymmetryToolStripMenuItem.Name = "verticalSymmetryToolStripMenuItem";
            this.verticalSymmetryToolStripMenuItem.ShowShortcutKeys = false;
            this.verticalSymmetryToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.verticalSymmetryToolStripMenuItem.Text = "Vertical symmetry";
            this.verticalSymmetryToolStripMenuItem.Click += new System.EventHandler(this.verticalSymmetryToolStripMenuItem_Click);
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.showGridToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showGridToolStripMenuItem.Checked = true;
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.ShowShortcutKeys = false;
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showGridToolStripMenuItem.Text = "Show grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // showLayoutToolStripMenuItem
            // 
            this.showLayoutToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.showLayoutToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showLayoutToolStripMenuItem.Checked = true;
            this.showLayoutToolStripMenuItem.CheckOnClick = true;
            this.showLayoutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLayoutToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.showLayoutToolStripMenuItem.Name = "showLayoutToolStripMenuItem";
            this.showLayoutToolStripMenuItem.ShowShortcutKeys = false;
            this.showLayoutToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showLayoutToolStripMenuItem.Text = "Show layout";
            this.showLayoutToolStripMenuItem.Click += new System.EventHandler(this.showLayoutToolStripMenuItem_Click);
            // 
            // showBarrelsToolStripMenuItem
            // 
            this.showBarrelsToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.showBarrelsToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showBarrelsToolStripMenuItem.Checked = true;
            this.showBarrelsToolStripMenuItem.CheckOnClick = true;
            this.showBarrelsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBarrelsToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.showBarrelsToolStripMenuItem.Name = "showBarrelsToolStripMenuItem";
            this.showBarrelsToolStripMenuItem.ShowShortcutKeys = false;
            this.showBarrelsToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showBarrelsToolStripMenuItem.Text = "Show barrels";
            this.showBarrelsToolStripMenuItem.Click += new System.EventHandler(this.showBarrelsToolStripMenuItem_Click);
            // 
            // showBarrelsNumbersToolStripMenuItem
            // 
            this.showBarrelsNumbersToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.showBarrelsNumbersToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showBarrelsNumbersToolStripMenuItem.CheckOnClick = true;
            this.showBarrelsNumbersToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.showBarrelsNumbersToolStripMenuItem.Name = "showBarrelsNumbersToolStripMenuItem";
            this.showBarrelsNumbersToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showBarrelsNumbersToolStripMenuItem.Text = "Show barrels numbers";
            this.showBarrelsNumbersToolStripMenuItem.Click += new System.EventHandler(this.showBarrelsNumbersToolStripMenuItem_Click);
            // 
            // showEnginesToolStripMenuItem
            // 
            this.showEnginesToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.showEnginesToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showEnginesToolStripMenuItem.Checked = true;
            this.showEnginesToolStripMenuItem.CheckOnClick = true;
            this.showEnginesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEnginesToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.showEnginesToolStripMenuItem.Name = "showEnginesToolStripMenuItem";
            this.showEnginesToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showEnginesToolStripMenuItem.Text = "Show Engines";
            this.showEnginesToolStripMenuItem.Click += new System.EventHandler(this.showEnginesToolStripMenuItem_Click);
            // 
            // showImageToolStripMenuItem
            // 
            this.showImageToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.showImageToolStripMenuItem.Checked = true;
            this.showImageToolStripMenuItem.CheckOnClick = true;
            this.showImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showImageToolStripMenuItem.Name = "showImageToolStripMenuItem";
            this.showImageToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.showImageToolStripMenuItem.Text = "Show Image";
            this.showImageToolStripMenuItem.Click += new System.EventHandler(this.showImageToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.zoomToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2,
            this.xToolStripMenuItem3,
            this.xToolStripMenuItem4});
            this.zoomToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.zoomToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Background;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.zoomToolStripMenuItem.Text = "Cell Size";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.defaultToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.defaultToolStripMenuItem.Checked = true;
            this.defaultToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.defaultToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.defaultToolStripMenuItem.Text = "Auto";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.xToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.xToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.xToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.xToolStripMenuItem.Text = "20px";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.BackColor = MainWindow.BackgroundColor;
            this.xToolStripMenuItem1.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.xToolStripMenuItem1.ForeColor = MainWindow.FontColor;
            this.xToolStripMenuItem1.Image = global::GameDatabase.Properties.Resources.Icon;
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.xToolStripMenuItem1.Text = "40px";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.BackColor = MainWindow.BackgroundColor;
            this.xToolStripMenuItem2.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.xToolStripMenuItem2.ForeColor = MainWindow.FontColor;
            this.xToolStripMenuItem2.Image = global::GameDatabase.Properties.Resources.Icon;
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.xToolStripMenuItem2.Text = "60px";
            this.xToolStripMenuItem2.Click += new System.EventHandler(this.xToolStripMenuItem2_Click);
            // 
            // xToolStripMenuItem3
            // 
            this.xToolStripMenuItem3.BackColor = MainWindow.BackgroundColor;
            this.xToolStripMenuItem3.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.xToolStripMenuItem3.ForeColor = MainWindow.FontColor;
            this.xToolStripMenuItem3.Image = global::GameDatabase.Properties.Resources.Icon;
            this.xToolStripMenuItem3.Name = "xToolStripMenuItem3";
            this.xToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
            this.xToolStripMenuItem3.Text = "80px";
            this.xToolStripMenuItem3.Click += new System.EventHandler(this.xToolStripMenuItem3_Click);
            // 
            // xToolStripMenuItem4
            // 
            this.xToolStripMenuItem4.BackColor = MainWindow.BackgroundColor;
            this.xToolStripMenuItem4.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.xToolStripMenuItem4.ForeColor = MainWindow.FontColor;
            this.xToolStripMenuItem4.Image = global::GameDatabase.Properties.Resources.Icon;
            this.xToolStripMenuItem4.Name = "xToolStripMenuItem4";
            this.xToolStripMenuItem4.Size = new System.Drawing.Size(105, 22);
            this.xToolStripMenuItem4.Text = "100px";
            this.xToolStripMenuItem4.Click += new System.EventHandler(this.xToolStripMenuItem4_Click);
            // 
            // barrelsEditingModeToolStripMenuItem
            // 
            this.barrelsEditingModeToolStripMenuItem.BackColor = MainWindow.BackgroundColor;
            this.barrelsEditingModeToolStripMenuItem.BackgroundImage = global::GameDatabase.Properties.Resources.Background;
            this.barrelsEditingModeToolStripMenuItem.CheckOnClick = true;
            this.barrelsEditingModeToolStripMenuItem.ForeColor = MainWindow.FontColor;
            this.barrelsEditingModeToolStripMenuItem.Image = global::GameDatabase.Properties.Resources.Icon;
            this.barrelsEditingModeToolStripMenuItem.Name = "barrelsEditingModeToolStripMenuItem";
            this.barrelsEditingModeToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.barrelsEditingModeToolStripMenuItem.Text = "Barrels Editing Mode";
            this.barrelsEditingModeToolStripMenuItem.Click += new System.EventHandler(this.barrelsEditingModeToolStripMenuItem_Click);
            // 
            // LayoutEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = MainWindow.BackgroundColor;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = MainWindow.FontColor;
            this.Name = "LayoutEditor";
            this.Size = new System.Drawing.Size(600, 603);
            this.SizeChanged += new System.EventHandler(this.LayoutEditor_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayoutEditor_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LayoutEditor_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LayoutEditor_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private AdvancedToolStripMenuItem defaultToolStripMenuItem;
        private AdvancedToolStripMenuItem horizontalSymmetryToolStripMenuItem;
        private AdvancedToolStripMenuItem showBarrelsNumbersToolStripMenuItem;
        private AdvancedToolStripMenuItem showBarrelsToolStripMenuItem;
        private AdvancedToolStripMenuItem showEnginesToolStripMenuItem;
        private AdvancedToolStripMenuItem showGridToolStripMenuItem;
        private AdvancedToolStripMenuItem showImageToolStripMenuItem;
        private AdvancedToolStripMenuItem showLayoutToolStripMenuItem;
        private AdvancedToolStripMenuItem verticalSymmetryToolStripMenuItem;
        private AdvancedToolStripMenuItem xToolStripMenuItem;
        private AdvancedToolStripMenuItem xToolStripMenuItem1;
        private AdvancedToolStripMenuItem xToolStripMenuItem2;
        private AdvancedToolStripMenuItem xToolStripMenuItem3;
        private AdvancedToolStripMenuItem xToolStripMenuItem4;
        private AdvancedToolStripMenuItem zoomToolStripMenuItem;

        #endregion

        private Controls.AdvancedToolStripMenuItem barrelsEditingModeToolStripMenuItem;
    }
}
