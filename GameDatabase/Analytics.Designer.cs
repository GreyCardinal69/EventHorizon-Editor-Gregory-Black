using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase
{
    partial class Analytics
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
            this.Data = new System.Windows.Forms.RichTextBox();
            this.QuestAnalytics = new Controls.AdvancedButton();
            this.ShipBuildAnalitics = new Controls.AdvancedButton();
            this.ShipAnalitics = new Controls.AdvancedButton();
            this.ComponentAnalitics = new Controls.AdvancedButton();
            this.LootAnalitics = new Controls.AdvancedButton();
            this.FleetAnalitics = new Controls.AdvancedButton();
            this.TechAnalitics = new Controls.AdvancedButton();
            this.OtherAnalitics = new Controls.AdvancedButton();
            this.TextAnalitics = new Controls.AdvancedButton();
            this.AllAnalytics = new Controls.AdvancedButton();
            this.Statistics = new Controls.AdvancedButton();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.BackColor = MainWindow.BackgroundColor;
            this.Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data.ForeColor = MainWindow.FontColor;
            this.Data.Location = new System.Drawing.Point(12, 12);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(1041, 737);
            this.Data.TabIndex = 0;
            this.Data.Text = "";
            // 
            // QuestAnalytics
            // 
            this.QuestAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestAnalytics.BackColor = MainWindow.BackgroundColor;
            this.QuestAnalytics.BorderColor = MainWindow.BackgroundColor;
            this.QuestAnalytics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.QuestAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QuestAnalytics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestAnalytics.ForeColor = MainWindow.FontColor;
            this.QuestAnalytics.Location = new System.Drawing.Point(1070, 135);
            this.QuestAnalytics.Name = "QuestAnalytics";
            this.QuestAnalytics.Size = new System.Drawing.Size(122, 35);
            this.QuestAnalytics.TabIndex = 1;
            this.QuestAnalytics.Text = "Analize Quests";
            this.QuestAnalytics.UseVisualStyleBackColor = false;
            this.QuestAnalytics.Click += new System.EventHandler(this.QuestAnalytics_Click);
            // 
            // ShipBuildAnalitics
            // 
            this.ShipBuildAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipBuildAnalitics.BackColor = MainWindow.BackgroundColor;
            this.ShipBuildAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.ShipBuildAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.ShipBuildAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShipBuildAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipBuildAnalitics.ForeColor = MainWindow.FontColor;
            this.ShipBuildAnalitics.Location = new System.Drawing.Point(1070, 53);
            this.ShipBuildAnalitics.Name = "ShipBuildAnalitics";
            this.ShipBuildAnalitics.Size = new System.Drawing.Size(122, 35);
            this.ShipBuildAnalitics.TabIndex = 2;
            this.ShipBuildAnalitics.Text = "Analize ShipBuilds";
            this.ShipBuildAnalitics.UseVisualStyleBackColor = false;
            this.ShipBuildAnalitics.Click += new System.EventHandler(this.ShipBuildAnalitics_Click);
            // 
            // ShipAnalitics
            // 
            this.ShipAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipAnalitics.BackColor = MainWindow.BackgroundColor;
            this.ShipAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.ShipAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.ShipAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShipAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipAnalitics.ForeColor = MainWindow.FontColor;
            this.ShipAnalitics.Location = new System.Drawing.Point(1070, 12);
            this.ShipAnalitics.Name = "ShipAnalitics";
            this.ShipAnalitics.Size = new System.Drawing.Size(122, 35);
            this.ShipAnalitics.TabIndex = 3;
            this.ShipAnalitics.Text = "Analize Ships";
            this.ShipAnalitics.UseVisualStyleBackColor = false;
            this.ShipAnalitics.Click += new System.EventHandler(this.ShipAnalitics_Click);
            // 
            // ComponentAnalitics
            // 
            this.ComponentAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComponentAnalitics.BackColor = MainWindow.BackgroundColor;
            this.ComponentAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.ComponentAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.ComponentAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComponentAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentAnalitics.ForeColor = MainWindow.FontColor;
            this.ComponentAnalitics.Location = new System.Drawing.Point(1070, 258);
            this.ComponentAnalitics.Name = "ComponentAnalitics";
            this.ComponentAnalitics.Size = new System.Drawing.Size(122, 35);
            this.ComponentAnalitics.TabIndex = 4;
            this.ComponentAnalitics.Text = "Analize Components";
            this.ComponentAnalitics.UseVisualStyleBackColor = false;
            this.ComponentAnalitics.Click += new System.EventHandler(this.ComponentAnalitics_Click);
            // 
            // LootAnalitics
            // 
            this.LootAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LootAnalitics.BackColor = MainWindow.BackgroundColor;
            this.LootAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.LootAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.LootAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LootAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LootAnalitics.ForeColor = MainWindow.FontColor;
            this.LootAnalitics.Location = new System.Drawing.Point(1070, 217);
            this.LootAnalitics.Name = "LootAnalitics";
            this.LootAnalitics.Size = new System.Drawing.Size(122, 35);
            this.LootAnalitics.TabIndex = 5;
            this.LootAnalitics.Text = "Analize Loot";
            this.LootAnalitics.UseVisualStyleBackColor = false;
            this.LootAnalitics.Click += new System.EventHandler(this.LootAnalitics_Click);
            // 
            // FleetAnalitics
            // 
            this.FleetAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FleetAnalitics.BackColor = MainWindow.BackgroundColor;
            this.FleetAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.FleetAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.FleetAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FleetAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FleetAnalitics.ForeColor = MainWindow.FontColor;
            this.FleetAnalitics.Location = new System.Drawing.Point(1070, 176);
            this.FleetAnalitics.Name = "FleetAnalitics";
            this.FleetAnalitics.Size = new System.Drawing.Size(122, 35);
            this.FleetAnalitics.TabIndex = 6;
            this.FleetAnalitics.Text = "Analize Fleets";
            this.FleetAnalitics.UseVisualStyleBackColor = false;
            this.FleetAnalitics.Click += new System.EventHandler(this.FleetAnalitics_Click);
            // 
            // TechAnalitics
            // 
            this.TechAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TechAnalitics.BackColor = MainWindow.BackgroundColor;
            this.TechAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.TechAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.TechAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TechAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TechAnalitics.ForeColor = MainWindow.FontColor;
            this.TechAnalitics.Location = new System.Drawing.Point(1070, 94);
            this.TechAnalitics.Name = "TechAnalitics";
            this.TechAnalitics.Size = new System.Drawing.Size(122, 35);
            this.TechAnalitics.TabIndex = 8;
            this.TechAnalitics.Text = "Analize Technologies";
            this.TechAnalitics.UseVisualStyleBackColor = false;
            this.TechAnalitics.Click += new System.EventHandler(this.TechAnalitics_Click);
            // 
            // OtherAnalitics
            // 
            this.OtherAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherAnalitics.BackColor = MainWindow.BackgroundColor;
            this.OtherAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.OtherAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.OtherAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OtherAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherAnalitics.ForeColor = MainWindow.FontColor;
            this.OtherAnalitics.Location = new System.Drawing.Point(1070, 340);
            this.OtherAnalitics.Name = "OtherAnalitics";
            this.OtherAnalitics.Size = new System.Drawing.Size(122, 35);
            this.OtherAnalitics.TabIndex = 9;
            this.OtherAnalitics.Text = "Analize Miscellanea";
            this.OtherAnalitics.UseVisualStyleBackColor = false;
            this.OtherAnalitics.Click += new System.EventHandler(this.OtherAnalitics_Click);
            // 
            // TextAnalitics
            // 
            this.TextAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextAnalitics.BackColor = MainWindow.BackgroundColor;
            this.TextAnalitics.BorderColor = MainWindow.BackgroundColor;
            this.TextAnalitics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.TextAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TextAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAnalitics.ForeColor = MainWindow.FontColor;
            this.TextAnalitics.Location = new System.Drawing.Point(1070, 299);
            this.TextAnalitics.Name = "TextAnalitics";
            this.TextAnalitics.Size = new System.Drawing.Size(122, 35);
            this.TextAnalitics.TabIndex = 10;
            this.TextAnalitics.Text = "Scan For Typos (Quests)";
            this.TextAnalitics.UseVisualStyleBackColor = false;
            this.TextAnalitics.Click += new System.EventHandler(this.TextAnalitics_Click);
            // 
            // AllAnalytics
            // 
            this.AllAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AllAnalytics.BackColor = MainWindow.BackgroundColor;
            this.AllAnalytics.BorderColor = MainWindow.BackgroundColor;
            this.AllAnalytics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.AllAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllAnalytics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllAnalytics.ForeColor = MainWindow.FontColor;
            this.AllAnalytics.Location = new System.Drawing.Point(1070, 423);
            this.AllAnalytics.Name = "AllAnalytics";
            this.AllAnalytics.Size = new System.Drawing.Size(122, 35);
            this.AllAnalytics.TabIndex = 12;
            this.AllAnalytics.Text = "Analize All";
            this.AllAnalytics.UseVisualStyleBackColor = false;
            this.AllAnalytics.Click += new System.EventHandler(this.AllAnalytics_Click);
            // 
            // Statistics
            // 
            this.Statistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Statistics.BackColor = MainWindow.BackgroundColor;
            this.Statistics.BorderColor = MainWindow.BackgroundColor;
            this.Statistics.FlatAppearance.BorderColor = MainWindow.BackgroundColor;
            this.Statistics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Statistics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statistics.ForeColor = MainWindow.FontColor;
            this.Statistics.Location = new System.Drawing.Point(1070, 382);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(122, 35);
            this.Statistics.TabIndex = 13;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = false;
            this.Statistics.Click += new System.EventHandler(this.Statistics_Click);
            // 
            // Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = MainWindow.BorderColor;
            this.ClientSize = new System.Drawing.Size(1204, 761);
            this.Controls.Add(this.Statistics);
            this.Controls.Add(this.AllAnalytics);
            this.Controls.Add(this.TextAnalitics);
            this.Controls.Add(this.OtherAnalitics);
            this.Controls.Add(this.TechAnalitics);
            this.Controls.Add(this.FleetAnalitics);
            this.Controls.Add(this.LootAnalitics);
            this.Controls.Add(this.ComponentAnalitics);
            this.Controls.Add(this.ShipAnalitics);
            this.Controls.Add(this.ShipBuildAnalitics);
            this.Controls.Add(this.QuestAnalytics);
            this.Controls.Add(this.Data);
            this.Name = "Analytics";
            this.Text = "Analytics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Data;
        private Controls.AdvancedButton QuestAnalytics;
        private Controls.AdvancedButton ShipBuildAnalitics;
        private Controls.AdvancedButton ShipAnalitics;
        private Controls.AdvancedButton ComponentAnalitics;
        private Controls.AdvancedButton LootAnalitics;
        private Controls.AdvancedButton FleetAnalitics;
        private Controls.AdvancedButton TechAnalitics;
        private Controls.AdvancedButton OtherAnalitics;
        private Controls.AdvancedButton TextAnalitics;
        private Controls.AdvancedButton AllAnalytics;
        private Controls.AdvancedButton Statistics;
    }
}