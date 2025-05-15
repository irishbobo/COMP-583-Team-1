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
            this.AlertsAlertGroupBox = new System.Windows.Forms.GroupBox();
            this.AlertsControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.AlertsAlertGroupBox.SuspendLayout();
            this.AlertsControlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewAlerts
            // 
            this.listViewAlerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderName,
            this.columnHeaderId});
            this.listViewAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAlerts.FullRowSelect = true;
            this.listViewAlerts.HideSelection = false;
            this.listViewAlerts.Location = new System.Drawing.Point(3, 16);
            this.listViewAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.listViewAlerts.Name = "listViewAlerts";
            this.listViewAlerts.Size = new System.Drawing.Size(808, 320);
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
            this.alertsMarkAsRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alertsMarkAsRead.Location = new System.Drawing.Point(556, 12);
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
            this.showAcknowledgedAlerts.Location = new System.Drawing.Point(6, 18);
            this.showAcknowledgedAlerts.Name = "showAcknowledgedAlerts";
            this.showAcknowledgedAlerts.Size = new System.Drawing.Size(162, 17);
            this.showAcknowledgedAlerts.TabIndex = 3;
            this.showAcknowledgedAlerts.Text = "Show Acknowledged Alerts?";
            this.showAcknowledgedAlerts.UseVisualStyleBackColor = true;
            this.showAcknowledgedAlerts.CheckedChanged += new System.EventHandler(this.showAcknowledgedAlerts_CheckedChanged);
            // 
            // unacknowledgeButton
            // 
            this.unacknowledgeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unacknowledgeButton.Location = new System.Drawing.Point(676, 12);
            this.unacknowledgeButton.Margin = new System.Windows.Forms.Padding(2);
            this.unacknowledgeButton.Name = "unacknowledgeButton";
            this.unacknowledgeButton.Size = new System.Drawing.Size(133, 23);
            this.unacknowledgeButton.TabIndex = 4;
            this.unacknowledgeButton.Text = "Unacknowledge Alert";
            this.unacknowledgeButton.UseVisualStyleBackColor = true;
            this.unacknowledgeButton.Click += new System.EventHandler(this.unacknowledgeButton_Click);
            // 
            // AlertsAlertGroupBox
            // 
            this.AlertsAlertGroupBox.Controls.Add(this.listViewAlerts);
            this.AlertsAlertGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertsAlertGroupBox.Location = new System.Drawing.Point(0, 0);
            this.AlertsAlertGroupBox.Name = "AlertsAlertGroupBox";
            this.AlertsAlertGroupBox.Size = new System.Drawing.Size(814, 339);
            this.AlertsAlertGroupBox.TabIndex = 5;
            this.AlertsAlertGroupBox.TabStop = false;
            this.AlertsAlertGroupBox.Text = "Alerts";
            // 
            // AlertsControlsGroupBox
            // 
            this.AlertsControlsGroupBox.Controls.Add(this.showAcknowledgedAlerts);
            this.AlertsControlsGroupBox.Controls.Add(this.alertsMarkAsRead);
            this.AlertsControlsGroupBox.Controls.Add(this.unacknowledgeButton);
            this.AlertsControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AlertsControlsGroupBox.Location = new System.Drawing.Point(0, 339);
            this.AlertsControlsGroupBox.Name = "AlertsControlsGroupBox";
            this.AlertsControlsGroupBox.Size = new System.Drawing.Size(814, 40);
            this.AlertsControlsGroupBox.TabIndex = 6;
            this.AlertsControlsGroupBox.TabStop = false;
            this.AlertsControlsGroupBox.Text = "Controls";
            // 
            // AlertsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AlertsAlertGroupBox);
            this.Controls.Add(this.AlertsControlsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlertsPage";
            this.Size = new System.Drawing.Size(814, 379);
            this.Load += new System.EventHandler(this.AlertsPage_Load);
            this.AlertsAlertGroupBox.ResumeLayout(false);
            this.AlertsControlsGroupBox.ResumeLayout(false);
            this.AlertsControlsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewAlerts;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Button alertsMarkAsRead;
        private System.Windows.Forms.CheckBox showAcknowledgedAlerts;
        private System.Windows.Forms.Button unacknowledgeButton;
        private System.Windows.Forms.GroupBox AlertsAlertGroupBox;
        private System.Windows.Forms.GroupBox AlertsControlsGroupBox;
    }
}
