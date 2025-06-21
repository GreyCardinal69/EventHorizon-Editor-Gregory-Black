using GameDatabase.Controls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameDatabase
{
    partial class ShipEditorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipEditorDialog));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.structDataEditor1 = new StructDataEditor();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BarrelCreation = new System.Windows.Forms.Button();
            this.BarrelInfo = new System.Windows.Forms.Button();
            this.layoutEditor1 = new LayoutEditor();
            this.barrelCollection = new Controls.BarrelsCollectionEditor();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.downButton = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.upButton = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rightButton = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.leftButton = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.layoutSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSize)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = MainWindow.BackgroundColor;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = MainWindow.BorderColor;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.structDataEditor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 539);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // structDataEditor1
            // 
            this.structDataEditor1.AutoScroll = true;
            this.structDataEditor1.AutoSize = true;
            this.structDataEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.structDataEditor1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.structDataEditor1.ContentAutoScroll = true;
            this.structDataEditor1.Data = null;
            this.structDataEditor1.Database = null;
            this.structDataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structDataEditor1.Exclusions = ((System.Collections.Generic.List<string>)(resources.GetObject("structDataEditor1.Exclusions")));
            this.structDataEditor1.Location = new System.Drawing.Point(0, 0);
            this.structDataEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.structDataEditor1.Name = "structDataEditor1";
            this.structDataEditor1.Padding = new System.Windows.Forms.Padding(4);
            this.structDataEditor1.Size = new System.Drawing.Size(209, 537);
            this.structDataEditor1.TabIndex = 0;
            this.structDataEditor1.DataChanged += new System.EventHandler(this.structDataEditor1_DataChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.barrelCollection);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(569, 539);
            this.splitContainer2.SplitterDistance = 338;
            this.splitContainer2.TabIndex = 6;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add( this.BarrelInfo );
            this.panel1.Controls.Add(this.BarrelCreation);
            this.panel1.Controls.Add(this.layoutEditor1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 310);
            this.panel1.TabIndex = 4;
            // 
            // BarrelCreation
            // 
            this.BarrelCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BarrelCreation.BackColor = MainWindow.BackgroundColor;
            this.BarrelCreation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BarrelCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.BarrelCreation.ForeColor = MainWindow.FontColor;
            this.BarrelCreation.Location = new System.Drawing.Point(372, 5);
            this.BarrelCreation.Name = "BarrelCreation";
            this.BarrelCreation.Size = new System.Drawing.Size(195, 38);
            this.BarrelCreation.TabIndex = 6;
            this.BarrelCreation.Text = "Fill Barrels ( Replaces All )";
            this.BarrelCreation.UseVisualStyleBackColor = false;
            this.BarrelCreation.Click += new System.EventHandler(this.BarrelCreation_Click);


            this.BarrelInfo.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.BarrelInfo.BackColor = MainWindow.BackgroundColor;
            this.BarrelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BarrelInfo.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8F );
            this.BarrelInfo.ForeColor = MainWindow.FontColor;
            this.BarrelInfo.Location = new System.Drawing.Point( 372, 50 );
            this.BarrelInfo.Name = "BarrelInfo";
            this.BarrelInfo.Size = new System.Drawing.Size( 195, 38 );
            this.BarrelInfo.TabIndex = 6;
            this.BarrelInfo.Text = "INFO\nBarrels' drawn AutoAimArc is (arc / 2)";
            this.BarrelInfo.UseVisualStyleBackColor = false;


            // 
            // layoutEditor1
            // 
            this.layoutEditor1.BackColor = MainWindow.BackgroundColor;
            this.layoutEditor1.Barrels = null;
            this.layoutEditor1.BarrelsCollection = this.barrelCollection;
            this.layoutEditor1.BorderSize = 32;
            this.layoutEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutEditor1.Engines = null;
            this.layoutEditor1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutEditor1.ForeColor = MainWindow.FontColor;
            this.layoutEditor1.Image = null;
            this.layoutEditor1.Layout = "000000000";
            this.layoutEditor1.Location = new System.Drawing.Point(0, 0);
            this.layoutEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutEditor1.Name = "layoutEditor1";
            this.layoutEditor1.SelectedCategory = '1';
            this.layoutEditor1.Size = new System.Drawing.Size(567, 310);
            this.layoutEditor1.TabIndex = 2;
            this.layoutEditor1.ValueChanged += new System.EventHandler(this.layoutEditor1_ValueChanged);
            // 
            // barrelCollection
            // 
            this.barrelCollection.AutoSize = true;
            this.barrelCollection.BackColor = MainWindow.BackgroundColor;
            this.barrelCollection.Collapseable = true;
            this.barrelCollection.ContentAutoScroll = true;
            this.barrelCollection.Data = null;
            this.barrelCollection.Database = null;
            this.barrelCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barrelCollection.Location = new System.Drawing.Point(0, 39);
            this.barrelCollection.Margin = new System.Windows.Forms.Padding(4);
            this.barrelCollection.Name = "barrelCollection";
            this.barrelCollection.ShowItemsNumbers = true;
            this.barrelCollection.Size = new System.Drawing.Size(567, 156);
            this.barrelCollection.TabIndex = 5;
            this.barrelCollection.CollectionChanged += new System.EventHandler(this.barrelCollection_CollectionChanged);
            this.barrelCollection.DataChanged += new System.EventHandler(this.barrelCollection_DataChanged);
            // 
            // button1
            // 
            this.button1.BackColor = MainWindow.BackgroundColor;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = MainWindow.FontColor;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(567, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show Ship Info";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = MainWindow.BackgroundColor;
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.downButton, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.upButton, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightButton, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftButton, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.layoutSize, 12, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 39);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.BackColor = System.Drawing.Color.LightGray;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(32, 32);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "X";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.BackColor = System.Drawing.Color.RoyalBlue;
            this.radioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.Location = new System.Drawing.Point(41, 3);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(32, 32);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.UseVisualStyleBackColor = false;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downButton.Location = new System.Drawing.Point(460, 3);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(32, 32);
            this.downButton.TabIndex = 5;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.BackColor = System.Drawing.Color.Lime;
            this.radioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(79, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(32, 32);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upButton.Location = new System.Drawing.Point(422, 3);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(32, 32);
            this.upButton.TabIndex = 5;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.BackColor = System.Drawing.Color.Yellow;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(117, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(32, 32);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightButton.Location = new System.Drawing.Point(384, 3);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(32, 32);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.BackColor = System.Drawing.Color.Red;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(155, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(32, 32);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftButton.Location = new System.Drawing.Point(346, 3);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(32, 32);
            this.leftButton.TabIndex = 5;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.BackColor = System.Drawing.Color.Aqua;
            this.radioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.Location = new System.Drawing.Point(193, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(32, 32);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.UseVisualStyleBackColor = false;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // layoutSize
            // 
            this.layoutSize.AutoSize = true;
            this.layoutSize.BackColor = MainWindow.BackgroundColor;
            this.layoutSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutSize.ForeColor = MainWindow.FontColor;
            this.layoutSize.Location = new System.Drawing.Point(498, 3);
            this.layoutSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.layoutSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layoutSize.Name = "layoutSize";
            this.layoutSize.Size = new System.Drawing.Size(66, 29);
            this.layoutSize.TabIndex = 4;
            this.layoutSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layoutSize.ValueChanged += new System.EventHandler(this.layoutSize_ValueChanged);
            // 
            // ShipEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = MainWindow.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ShipEditorDialog";
            this.Text = "ShipEditorDialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShipEditorDialog_FormClosed);
            this.Load += new System.EventHandler(this.ShipEditorDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void ShipEditorDialog_FormClosed( object sender, FormClosedEventArgs e )
        {
            foreach ( var key in new List<string>( MainWindow.OppenedWindows.Keys ) )
            {
                if ( MainWindow.OppenedWindows[key] == this )
                {
                    MainWindow.OppenedWindows.Remove( key );
                    return;
                }
            }
        }


        private BarrelsCollectionEditor barrelCollection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button downButton;
        private LayoutEditor layoutEditor1;
        private System.Windows.Forms.NumericUpDown layoutSize;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private StructDataEditor structDataEditor1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button upButton;

        #endregion

        private Button BarrelCreation;
        private Button BarrelInfo;
    }
}