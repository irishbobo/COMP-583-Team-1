namespace PharmacyManager
{
    partial class AlertsPage
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
            this.listViewAlerts = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertsMarkAsRead = new System.Windows.Forms.Button();
            this.showAcknowledgedAlerts = new System.Windows.Forms.CheckBox();
            this.unacknowledgeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewAlerts
            // 
            this.listViewAlerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderName,
            this.columnHeaderId});
            this.listViewAlerts.FullRowSelect = true;
            this.listViewAlerts.HideSelection = false;
            this.listViewAlerts.Location = new System.Drawing.Point(10, 14);
            this.listViewAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.listViewAlerts.Name = "listViewAlerts";
            this.listViewAlerts.Size = new System.Drawing.Size(842, 334);
            this.listViewAlerts.TabIndex = 1;
            this.listViewAlerts.UseCompatibleStateImageBehavior = false;
            this.listViewAlerts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 172;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.DisplayIndex = 2;
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 225;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.DisplayIndex = 1;
            this.columnHeaderId.Text = "Drug Id";
            this.columnHeaderId.Width = 189;
            // 
            // alertsMarkAsRead
            // 
            this.alertsMarkAsRead.Location = new System.Drawing.Point(600, 363);
            this.alertsMarkAsRead.Margin = new System.Windows.Forms.Padding(2);
            this.alertsMarkAsRead.Name = "alertsMarkAsRead";
            this.alertsMarkAsRead.Size = new System.Drawing.Size(116, 23);
            this.alertsMarkAsRead.TabIndex = 2;
            this.alertsMarkAsRead.Text = "Acknowledge Alert";
            this.alertsMarkAsRead.UseVisualStyleBackColor = true;
            this.alertsMarkAsRead.Click += new System.EventHandler(this.acknowledgeAlertButton_Click);
            // 
            // showAcknowledgedAlerts
            // 
            this.showAcknowledgedAlerts.AutoSize = true;
            this.showAcknowledgedAlerts.Location = new System.Drawing.Point(10, 353);
            this.showAcknowledgedAlerts.Name = "showAcknowledgedAlerts";
            this.showAcknowledgedAlerts.Size = new System.Drawing.Size(162, 17);
            this.showAcknowledgedAlerts.TabIndex = 3;
            this.showAcknowledgedAlerts.Text = "Show Acknowledged Alerts?";
            this.showAcknowledgedAlerts.UseVisualStyleBackColor = true;
            this.showAcknowledgedAlerts.CheckedChanged += new System.EventHandler(this.showAcknowledgedAlerts_CheckedChanged);
            // 
            // unacknowledgeButton
            // 
            this.unacknowledgeButton.Location = new System.Drawing.Point(720, 363);
            this.unacknowledgeButton.Margin = new System.Windows.Forms.Padding(2);
            this.unacknowledgeButton.Name = "unacknowledgeButton";
            this.unacknowledgeButton.Size = new System.Drawing.Size(133, 23);
            this.unacknowledgeButton.TabIndex = 4;
            this.unacknowledgeButton.Text = "Unacknowledge Alert";
            this.unacknowledgeButton.UseVisualStyleBackColor = true;
            this.unacknowledgeButton.Click += new System.EventHandler(this.unacknowledgeButton_Click);
            // 
            // AlertsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unacknowledgeButton);
            this.Controls.Add(this.showAcknowledgedAlerts);
            this.Controls.Add(this.alertsMarkAsRead);
            this.Controls.Add(this.listViewAlerts);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlertsPage";
            this.Size = new System.Drawing.Size(890, 398);
            this.Load += new System.EventHandler(this.AlertsPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listViewAlerts;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Button alertsMarkAsRead;
        private System.Windows.Forms.CheckBox showAcknowledgedAlerts;
        private System.Windows.Forms.Button unacknowledgeButton;
    }
}
