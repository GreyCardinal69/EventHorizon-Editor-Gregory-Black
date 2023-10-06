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
            this.AdvAmmoAnalitics = new Controls.AdvancedButton();
            this.TechAnalitics = new Controls.AdvancedButton();
            this.OtherAnalitics = new Controls.AdvancedButton();
            this.TextAnalitics = new Controls.AdvancedButton();
            this.AllAnalytics = new Controls.AdvancedButton();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.Data.Location = new System.Drawing.Point(12, 12);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(1041, 737);
            this.Data.TabIndex = 0;
            this.Data.Text = "";
            // 
            // QuestAnalytics
            // 
            this.QuestAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.QuestAnalytics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.QuestAnalytics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.QuestAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QuestAnalytics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestAnalytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.QuestAnalytics.Location = new System.Drawing.Point(1069, 177);
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
            this.ShipBuildAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipBuildAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipBuildAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipBuildAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShipBuildAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipBuildAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.ShipBuildAnalitics.Location = new System.Drawing.Point(1069, 95);
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
            this.ShipAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShipAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShipAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.ShipAnalitics.Location = new System.Drawing.Point(1069, 54);
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
            this.ComponentAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ComponentAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ComponentAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ComponentAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComponentAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.ComponentAnalitics.Location = new System.Drawing.Point(1069, 300);
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
            this.LootAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.LootAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.LootAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.LootAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LootAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LootAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.LootAnalitics.Location = new System.Drawing.Point(1069, 259);
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
            this.FleetAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FleetAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FleetAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FleetAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FleetAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FleetAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.FleetAnalitics.Location = new System.Drawing.Point(1069, 218);
            this.FleetAnalitics.Name = "FleetAnalitics";
            this.FleetAnalitics.Size = new System.Drawing.Size(122, 35);
            this.FleetAnalitics.TabIndex = 6;
            this.FleetAnalitics.Text = "Analize Fleets";
            this.FleetAnalitics.UseVisualStyleBackColor = false;
            this.FleetAnalitics.Click += new System.EventHandler(this.FleetAnalitics_Click);
            // 
            // AdvAmmoAnalitics
            // 
            this.AdvAmmoAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AdvAmmoAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AdvAmmoAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AdvAmmoAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AdvAmmoAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdvAmmoAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdvAmmoAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.AdvAmmoAnalitics.Location = new System.Drawing.Point(1069, 12);
            this.AdvAmmoAnalitics.Name = "AdvAmmoAnalitics";
            this.AdvAmmoAnalitics.Size = new System.Drawing.Size(122, 35);
            this.AdvAmmoAnalitics.TabIndex = 7;
            this.AdvAmmoAnalitics.Text = "Analize Ammunition (Adv)";
            this.AdvAmmoAnalitics.UseVisualStyleBackColor = false;
            // 
            // TechAnalitics
            // 
            this.TechAnalitics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TechAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TechAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TechAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TechAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TechAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TechAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.TechAnalitics.Location = new System.Drawing.Point(1069, 136);
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
            this.OtherAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.OtherAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.OtherAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.OtherAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OtherAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.OtherAnalitics.Location = new System.Drawing.Point(1069, 382);
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
            this.TextAnalitics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextAnalitics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextAnalitics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextAnalitics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TextAnalitics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAnalitics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.TextAnalitics.Location = new System.Drawing.Point(1069, 341);
            this.TextAnalitics.Name = "TextAnalitics";
            this.TextAnalitics.Size = new System.Drawing.Size(122, 35);
            this.TextAnalitics.TabIndex = 10;
            this.TextAnalitics.Text = "Scan For Typos";
            this.TextAnalitics.UseVisualStyleBackColor = false;
            this.TextAnalitics.Click += new System.EventHandler(this.TextAnalitics_Click);
            // 
            // AllAnalytics
            // 
            this.AllAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AllAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AllAnalytics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AllAnalytics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AllAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllAnalytics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllAnalytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(87)))));
            this.AllAnalytics.Location = new System.Drawing.Point(1070, 423);
            this.AllAnalytics.Name = "AllAnalytics";
            this.AllAnalytics.Size = new System.Drawing.Size(122, 35);
            this.AllAnalytics.TabIndex = 12;
            this.AllAnalytics.Text = "Analize All";
            this.AllAnalytics.UseVisualStyleBackColor = false;
            this.AllAnalytics.Click += new System.EventHandler(this.AllAnalytics_Click);
            // 
            // Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1204, 761);
            this.Controls.Add(this.AllAnalytics);
            this.Controls.Add(this.TextAnalitics);
            this.Controls.Add(this.OtherAnalitics);
            this.Controls.Add(this.TechAnalitics);
            this.Controls.Add(this.AdvAmmoAnalitics);
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
        private Controls.AdvancedButton AdvAmmoAnalitics;
        private Controls.AdvancedButton TechAnalitics;
        private Controls.AdvancedButton OtherAnalitics;
        private Controls.AdvancedButton TextAnalitics;
        private Controls.AdvancedButton AllAnalytics;
    }
}