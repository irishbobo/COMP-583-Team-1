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
            this.button1 = new System.Windows.Forms.Button();
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
            this.listViewAlerts.Location = new System.Drawing.Point(15, 22);
            this.listViewAlerts.Name = "listViewAlerts";
            this.listViewAlerts.Size = new System.Drawing.Size(600, 135);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlertsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewAlerts);
            this.Name = "AlertsPage";
            this.Size = new System.Drawing.Size(664, 553);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewAlerts;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Button button1;
    }
}
