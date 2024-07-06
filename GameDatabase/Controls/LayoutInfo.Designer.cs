using System.Drawing;
using static GameDatabase.Reusables;

namespace GameDatabase.Controls
{
    partial class LayoutInfo
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb( ( ( int ) ( ( ( byte ) ( 45 ) ) ) ), ( ( int ) ( ( ( byte ) ( 45 ) ) ) ), ( ( int ) ( ( ( byte ) ( 45 ) ) ) ) );
            this.ClientSize = new System.Drawing.Size( 284, 261 );
            tableLayoutPanel.ForeColor = System.Drawing.Color.FromArgb( ( ( int ) ( ( ( byte ) ( 242 ) ) ) ), ( ( int ) ( ( ( byte ) ( 188 ) ) ) ), ( ( int ) ( ( ( byte ) ( 87 ) ) ) ) );
            this.Name = "LayoutInfo";
            this.ResumeLayout( false );
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point( 0, 0 );
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            this.tableLayoutPanel.Size = new System.Drawing.Size( 300, 265 );
            this.tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.BackColor = DarkPrimary45;
            tableLayoutPanel.ForeColor = OrangePrimary;
            // 
            // LayoutInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 16F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size( 300, 265 );
            this.Controls.Add( this.tableLayoutPanel );
            this.Name = "LayoutInfo";
            this.Text = "Ship Info";
            this.ResumeLayout( false );
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

        #endregion
    }
}