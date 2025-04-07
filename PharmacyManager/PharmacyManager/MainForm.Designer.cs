using System.Windows.Forms;

namespace PharmacyManager
{
    partial class MainForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.LightGray;
            this.panelSidebar.Controls.Add(this.btnInventory);
            this.panelSidebar.Controls.Add(this.btnAlerts);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(150, 100);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Location = new System.Drawing.Point(0, 46);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(150, 23);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnAlerts
            // 
            this.btnAlerts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlerts.Location = new System.Drawing.Point(0, 23);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(150, 23);
            this.btnAlerts.TabIndex = 1;
            this.btnAlerts.Text = "Alerts";
            this.btnAlerts.Click += new System.EventHandler(this.btnAlerts_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.Location = new System.Drawing.Point(0, 0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(150, 23);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Location = new System.Drawing.Point(0, 77);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(200, 100);
            this.panelContent.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "MainForm";
            this.Text = "Pharmacy Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
    }
}