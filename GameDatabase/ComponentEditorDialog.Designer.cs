﻿using System.Drawing;

namespace GameDatabase
{
    partial class ComponentEditorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentEditorDialog));
            this.structDataEditor1 = new StructDataEditor();
            this.SuspendLayout();
            // 
            // structDataEditor1
            // 
            this.structDataEditor1.AutoSize = true;
            this.structDataEditor1.BackColor = MainWindow.BackgroundColor;
            this.structDataEditor1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.structDataEditor1.ContentAutoScroll = true;
            this.structDataEditor1.Data = null;
            this.structDataEditor1.Database = null;
            this.structDataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structDataEditor1.Exclusions = ((System.Collections.Generic.List<string>)(resources.GetObject("structDataEditor1.Exclusions")));
            this.structDataEditor1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.structDataEditor1.ForeColor = MainWindow.FontColor;
            this.structDataEditor1.Location = new System.Drawing.Point(0, 0);
            this.structDataEditor1.Name = "structDataEditor1";
            this.structDataEditor1.Size = new System.Drawing.Size(784, 561);
            this.structDataEditor1.TabIndex = 1;
            this.structDataEditor1.Load += new System.EventHandler(this.ComponentEditorDialog_Load);
            // 
            // ComponentEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.structDataEditor1);
            this.Name = "ComponentEditorDialog";
            this.Text = "ComponentEditorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StructDataEditor structDataEditor1;
    }
}