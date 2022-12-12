﻿namespace GameDatabase.Controls
{
    partial class CollectionEditor
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutOuterPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.cloneButton = new System.Windows.Forms.Button();
            this.collapseButton = new System.Windows.Forms.Button();
            this.expandBtton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.prevPageButton = new System.Windows.Forms.Button();
            this.pageNumberButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutOuterPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.tableLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(508, 207);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutOuterPanel
            // 
            this.tableLayoutOuterPanel.AutoScroll = true;
            this.tableLayoutOuterPanel.AutoSize = true;
            this.tableLayoutOuterPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutOuterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tableLayoutOuterPanel.ColumnCount = 1;
            this.tableLayoutOuterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutOuterPanel.Controls.Add(this.buttonsPanel, 0, 1);
            this.tableLayoutOuterPanel.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutOuterPanel.Controls.Add(this.tableLayoutPanel, 0, 0);
            this.tableLayoutOuterPanel.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.tableLayoutOuterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutOuterPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutOuterPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutOuterPanel.Name = "tableLayoutOuterPanel";
            this.tableLayoutOuterPanel.RowCount = 4;
            this.tableLayoutOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutOuterPanel.Size = new System.Drawing.Size(512, 326);
            this.tableLayoutOuterPanel.TabIndex = 1;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonsPanel.Controls.Add(this.addButton);
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.moveUpButton);
            this.buttonsPanel.Controls.Add(this.moveDownButton);
            this.buttonsPanel.Controls.Add(this.cloneButton);
            this.buttonsPanel.Controls.Add(this.collapseButton);
            this.buttonsPanel.Controls.Add(this.expandBtton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.buttonsPanel.Location = new System.Drawing.Point(2, 213);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(508, 58);
            this.buttonsPanel.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.deleteButton.Location = new System.Drawing.Point(84, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.moveUpButton.Location = new System.Drawing.Point(165, 3);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 1;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.moveDownButton.Location = new System.Drawing.Point(246, 3);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 1;
            this.moveDownButton.Text = "MoveDown";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cloneButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.cloneButton.Location = new System.Drawing.Point(327, 3);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(43, 23);
            this.cloneButton.TabIndex = 7;
            this.cloneButton.Text = "Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Visible = false;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // collapseButton
            // 
            this.collapseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.collapseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.collapseButton.Location = new System.Drawing.Point(376, 3);
            this.collapseButton.Name = "collapseButton";
            this.collapseButton.Size = new System.Drawing.Size(75, 23);
            this.collapseButton.TabIndex = 5;
            this.collapseButton.Text = "Collapse all";
            this.collapseButton.UseVisualStyleBackColor = true;
            this.collapseButton.Click += new System.EventHandler(this.collapseButton_Click);
            // 
            // expandBtton
            // 
            this.expandBtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expandBtton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.expandBtton.Location = new System.Drawing.Point(3, 32);
            this.expandBtton.Name = "expandBtton";
            this.expandBtton.Size = new System.Drawing.Size(75, 23);
            this.expandBtton.TabIndex = 6;
            this.expandBtton.Text = "Expand all";
            this.expandBtton.UseVisualStyleBackColor = true;
            this.expandBtton.Click += new System.EventHandler(this.expandBtton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel1.Controls.Add(this.prevPageButton);
            this.flowLayoutPanel1.Controls.Add(this.pageNumberButton);
            this.flowLayoutPanel1.Controls.Add(this.nextPageButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 275);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(508, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // prevPageButton
            // 
            this.prevPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.prevPageButton.Location = new System.Drawing.Point(3, 3);
            this.prevPageButton.Name = "prevPageButton";
            this.prevPageButton.Size = new System.Drawing.Size(75, 23);
            this.prevPageButton.TabIndex = 2;
            this.prevPageButton.Text = "Prev. Page";
            this.prevPageButton.UseVisualStyleBackColor = true;
            this.prevPageButton.Visible = false;
            this.prevPageButton.Click += new System.EventHandler(this.prevPageButton_Click);
            // 
            // pageNumberButton
            // 
            this.pageNumberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageNumberButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.pageNumberButton.Location = new System.Drawing.Point(84, 3);
            this.pageNumberButton.Name = "pageNumberButton";
            this.pageNumberButton.Size = new System.Drawing.Size(63, 23);
            this.pageNumberButton.TabIndex = 4;
            this.pageNumberButton.Text = "0/0";
            this.pageNumberButton.UseVisualStyleBackColor = true;
            this.pageNumberButton.Visible = false;
            // 
            // nextPageButton
            // 
            this.nextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.nextPageButton.Location = new System.Drawing.Point(153, 3);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(75, 23);
            this.nextPageButton.TabIndex = 3;
            this.nextPageButton.Text = "Next Page";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Visible = false;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 306);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(512, 20);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // CollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutOuterPanel);
            this.Name = "CollectionEditor";
            this.Size = new System.Drawing.Size(512, 326);
            this.tableLayoutOuterPanel.ResumeLayout(false);
            this.tableLayoutOuterPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected System.Windows.Forms.Button addButton;
        public System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        protected System.Windows.Forms.Button cloneButton;
        protected System.Windows.Forms.Button collapseButton;
        protected System.Windows.Forms.Button deleteButton;
        protected System.Windows.Forms.Button expandBtton;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        protected System.Windows.Forms.Button moveDownButton;
        protected System.Windows.Forms.Button moveUpButton;
        protected System.Windows.Forms.Button nextPageButton;
        protected System.Windows.Forms.Button pageNumberButton;
        protected System.Windows.Forms.Button prevPageButton;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutOuterPanel;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

        #endregion
    }
}