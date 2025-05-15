using System.Windows.Forms;

namespace PharmacyManager
{
    partial class InventoryPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AutoScaleMode AutoScaleMode { get; private set; }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InventoryMedicationsAddNameTextbox = new System.Windows.Forms.TextBox();
            this.InventoryMedicationsAddButton = new System.Windows.Forms.Button();
            this.InventorySearchSearchButton = new System.Windows.Forms.Button();
            this.InventoryMedicationsListGridView = new System.Windows.Forms.DataGridView();
            this.InventoryMedicationsAddExpDate = new System.Windows.Forms.DateTimePicker();
            this.InventoryMedicationsAddQtyNumeric = new System.Windows.Forms.NumericUpDown();
            this.InventorySearchDrugNameComboBox = new System.Windows.Forms.ComboBox();
            this.InventoryMedicationsGroupBox = new System.Windows.Forms.GroupBox();
            this.InventoryMedicationsAddGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchExpirationEndGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchExpirationEndDate = new System.Windows.Forms.DateTimePicker();
            this.InventorySearchExpirationEndCheckBox = new System.Windows.Forms.CheckBox();
            this.InventorySearchExpirationStartGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchExpirationStartDate = new System.Windows.Forms.DateTimePicker();
            this.InventorySearchExpirationStartCheckBox = new System.Windows.Forms.CheckBox();
            this.InventorySearchMedicationIDGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchMedicationIDCheckBox = new System.Windows.Forms.CheckBox();
            this.InventorySearchMedicationIDNumeric = new System.Windows.Forms.NumericUpDown();
            this.InventorySearchDrugNameGroupBox = new System.Windows.Forms.GroupBox();
            this.InventorySearchDrugNameCheckBox = new System.Windows.Forms.CheckBox();
            this.InventorySearchResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryMedicationsListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryMedicationsAddQtyNumeric)).BeginInit();
            this.InventoryMedicationsGroupBox.SuspendLayout();
            this.InventoryMedicationsAddGroupBox.SuspendLayout();
            this.InventorySearchGroupBox.SuspendLayout();
            this.InventorySearchExpirationEndGroupBox.SuspendLayout();
            this.InventorySearchExpirationStartGroupBox.SuspendLayout();
            this.InventorySearchMedicationIDGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySearchMedicationIDNumeric)).BeginInit();
            this.InventorySearchDrugNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryMedicationsAddNameTextbox
            // 
            this.InventoryMedicationsAddNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryMedicationsAddNameTextbox.Location = new System.Drawing.Point(5, 18);
            this.InventoryMedicationsAddNameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryMedicationsAddNameTextbox.MinimumSize = new System.Drawing.Size(50, 4);
            this.InventoryMedicationsAddNameTextbox.Name = "InventoryMedicationsAddNameTextbox";
            this.InventoryMedicationsAddNameTextbox.Size = new System.Drawing.Size(280, 20);
            this.InventoryMedicationsAddNameTextbox.TabIndex = 0;
            this.InventoryMedicationsAddNameTextbox.Text = "Name";
            this.InventoryMedicationsAddNameTextbox.UseWaitCursor = true;
            // 
            // InventoryMedicationsAddButton
            // 
            this.InventoryMedicationsAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryMedicationsAddButton.Location = new System.Drawing.Point(585, 17);
            this.InventoryMedicationsAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryMedicationsAddButton.Name = "InventoryMedicationsAddButton";
            this.InventoryMedicationsAddButton.Size = new System.Drawing.Size(106, 22);
            this.InventoryMedicationsAddButton.TabIndex = 1;
            this.InventoryMedicationsAddButton.Text = "Add Entry";
            this.InventoryMedicationsAddButton.UseVisualStyleBackColor = true;
            this.InventoryMedicationsAddButton.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // InventorySearchSearchButton
            // 
            this.InventorySearchSearchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InventorySearchSearchButton.Location = new System.Drawing.Point(3, 436);
            this.InventorySearchSearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.InventorySearchSearchButton.Name = "InventorySearchSearchButton";
            this.InventorySearchSearchButton.Size = new System.Drawing.Size(282, 36);
            this.InventorySearchSearchButton.TabIndex = 4;
            this.InventorySearchSearchButton.Text = "Search";
            this.InventorySearchSearchButton.UseVisualStyleBackColor = true;
            this.InventorySearchSearchButton.Click += new System.EventHandler(this.searchDrugButton_Click);
            // 
            // InventoryMedicationsListGridView
            // 
            this.InventoryMedicationsListGridView.AllowUserToAddRows = false;
            this.InventoryMedicationsListGridView.AllowUserToDeleteRows = false;
            this.InventoryMedicationsListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InventoryMedicationsListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryMedicationsListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryMedicationsListGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.InventoryMedicationsListGridView.Location = new System.Drawing.Point(3, 16);
            this.InventoryMedicationsListGridView.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryMedicationsListGridView.Name = "InventoryMedicationsListGridView";
            this.InventoryMedicationsListGridView.RowHeadersWidth = 62;
            this.InventoryMedicationsListGridView.RowTemplate.Height = 28;
            this.InventoryMedicationsListGridView.ShowEditingIcon = false;
            this.InventoryMedicationsListGridView.Size = new System.Drawing.Size(696, 447);
            this.InventoryMedicationsListGridView.TabIndex = 7;
            // 
            // InventoryMedicationsAddExpDate
            // 
            this.InventoryMedicationsAddExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryMedicationsAddExpDate.Location = new System.Drawing.Point(400, 18);
            this.InventoryMedicationsAddExpDate.Name = "InventoryMedicationsAddExpDate";
            this.InventoryMedicationsAddExpDate.Size = new System.Drawing.Size(182, 20);
            this.InventoryMedicationsAddExpDate.TabIndex = 10;
            // 
            // InventoryMedicationsAddQtyNumeric
            // 
            this.InventoryMedicationsAddQtyNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryMedicationsAddQtyNumeric.Location = new System.Drawing.Point(290, 18);
            this.InventoryMedicationsAddQtyNumeric.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.InventoryMedicationsAddQtyNumeric.Name = "InventoryMedicationsAddQtyNumeric";
            this.InventoryMedicationsAddQtyNumeric.Size = new System.Drawing.Size(107, 20);
            this.InventoryMedicationsAddQtyNumeric.TabIndex = 11;
            // 
            // InventorySearchDrugNameComboBox
            // 
            this.InventorySearchDrugNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchDrugNameComboBox.FormattingEnabled = true;
            this.InventorySearchDrugNameComboBox.Location = new System.Drawing.Point(23, 15);
            this.InventorySearchDrugNameComboBox.Name = "InventorySearchDrugNameComboBox";
            this.InventorySearchDrugNameComboBox.Size = new System.Drawing.Size(253, 21);
            this.InventorySearchDrugNameComboBox.TabIndex = 13;
            this.InventorySearchDrugNameComboBox.DropDown += new System.EventHandler(this.searchDrugNameComboBox_DropDown);
            // 
            // InventoryMedicationsGroupBox
            // 
            this.InventoryMedicationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryMedicationsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InventoryMedicationsGroupBox.Controls.Add(this.InventoryMedicationsListGridView);
            this.InventoryMedicationsGroupBox.Controls.Add(this.InventoryMedicationsAddGroupBox);
            this.InventoryMedicationsGroupBox.Location = new System.Drawing.Point(11, 3);
            this.InventoryMedicationsGroupBox.MinimumSize = new System.Drawing.Size(500, 0);
            this.InventoryMedicationsGroupBox.Name = "InventoryMedicationsGroupBox";
            this.InventoryMedicationsGroupBox.Size = new System.Drawing.Size(702, 511);
            this.InventoryMedicationsGroupBox.TabIndex = 14;
            this.InventoryMedicationsGroupBox.TabStop = false;
            this.InventoryMedicationsGroupBox.Text = "Medications";
            // 
            // InventoryMedicationsAddGroupBox
            // 
            this.InventoryMedicationsAddGroupBox.Controls.Add(this.InventoryMedicationsAddNameTextbox);
            this.InventoryMedicationsAddGroupBox.Controls.Add(this.InventoryMedicationsAddButton);
            this.InventoryMedicationsAddGroupBox.Controls.Add(this.InventoryMedicationsAddQtyNumeric);
            this.InventoryMedicationsAddGroupBox.Controls.Add(this.InventoryMedicationsAddExpDate);
            this.InventoryMedicationsAddGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InventoryMedicationsAddGroupBox.Location = new System.Drawing.Point(3, 463);
            this.InventoryMedicationsAddGroupBox.Name = "InventoryMedicationsAddGroupBox";
            this.InventoryMedicationsAddGroupBox.Size = new System.Drawing.Size(696, 45);
            this.InventoryMedicationsAddGroupBox.TabIndex = 29;
            this.InventoryMedicationsAddGroupBox.TabStop = false;
            this.InventoryMedicationsAddGroupBox.Text = "Add Medication";
            // 
            // InventorySearchGroupBox
            // 
            this.InventorySearchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchExpirationEndGroupBox);
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchExpirationStartGroupBox);
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchMedicationIDGroupBox);
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchDrugNameGroupBox);
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchSearchButton);
            this.InventorySearchGroupBox.Controls.Add(this.InventorySearchResetButton);
            this.InventorySearchGroupBox.Location = new System.Drawing.Point(719, 3);
            this.InventorySearchGroupBox.MinimumSize = new System.Drawing.Size(270, 0);
            this.InventorySearchGroupBox.Name = "InventorySearchGroupBox";
            this.InventorySearchGroupBox.Size = new System.Drawing.Size(288, 511);
            this.InventorySearchGroupBox.TabIndex = 15;
            this.InventorySearchGroupBox.TabStop = false;
            this.InventorySearchGroupBox.Text = "Search";
            // 
            // InventorySearchExpirationEndGroupBox
            // 
            this.InventorySearchExpirationEndGroupBox.Controls.Add(this.InventorySearchExpirationEndDate);
            this.InventorySearchExpirationEndGroupBox.Controls.Add(this.InventorySearchExpirationEndCheckBox);
            this.InventorySearchExpirationEndGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventorySearchExpirationEndGroupBox.Location = new System.Drawing.Point(3, 142);
            this.InventorySearchExpirationEndGroupBox.Name = "InventorySearchExpirationEndGroupBox";
            this.InventorySearchExpirationEndGroupBox.Size = new System.Drawing.Size(282, 42);
            this.InventorySearchExpirationEndGroupBox.TabIndex = 25;
            this.InventorySearchExpirationEndGroupBox.TabStop = false;
            this.InventorySearchExpirationEndGroupBox.Text = "Expiration Range (End)";
            // 
            // InventorySearchExpirationEndDate
            // 
            this.InventorySearchExpirationEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchExpirationEndDate.Location = new System.Drawing.Point(23, 16);
            this.InventorySearchExpirationEndDate.Name = "InventorySearchExpirationEndDate";
            this.InventorySearchExpirationEndDate.Size = new System.Drawing.Size(253, 20);
            this.InventorySearchExpirationEndDate.TabIndex = 20;
            // 
            // InventorySearchExpirationEndCheckBox
            // 
            this.InventorySearchExpirationEndCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchExpirationEndCheckBox.AutoSize = true;
            this.InventorySearchExpirationEndCheckBox.Location = new System.Drawing.Point(6, 19);
            this.InventorySearchExpirationEndCheckBox.Name = "InventorySearchExpirationEndCheckBox";
            this.InventorySearchExpirationEndCheckBox.Size = new System.Drawing.Size(15, 14);
            this.InventorySearchExpirationEndCheckBox.TabIndex = 24;
            this.InventorySearchExpirationEndCheckBox.UseVisualStyleBackColor = true;
            // 
            // InventorySearchExpirationStartGroupBox
            // 
            this.InventorySearchExpirationStartGroupBox.Controls.Add(this.InventorySearchExpirationStartDate);
            this.InventorySearchExpirationStartGroupBox.Controls.Add(this.InventorySearchExpirationStartCheckBox);
            this.InventorySearchExpirationStartGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventorySearchExpirationStartGroupBox.Location = new System.Drawing.Point(3, 100);
            this.InventorySearchExpirationStartGroupBox.Name = "InventorySearchExpirationStartGroupBox";
            this.InventorySearchExpirationStartGroupBox.Size = new System.Drawing.Size(282, 42);
            this.InventorySearchExpirationStartGroupBox.TabIndex = 26;
            this.InventorySearchExpirationStartGroupBox.TabStop = false;
            this.InventorySearchExpirationStartGroupBox.Text = "Expiration Range (Start)";
            // 
            // InventorySearchExpirationStartDate
            // 
            this.InventorySearchExpirationStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchExpirationStartDate.Location = new System.Drawing.Point(23, 16);
            this.InventorySearchExpirationStartDate.Name = "InventorySearchExpirationStartDate";
            this.InventorySearchExpirationStartDate.Size = new System.Drawing.Size(253, 20);
            this.InventorySearchExpirationStartDate.TabIndex = 20;
            // 
            // InventorySearchExpirationStartCheckBox
            // 
            this.InventorySearchExpirationStartCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchExpirationStartCheckBox.AutoSize = true;
            this.InventorySearchExpirationStartCheckBox.Location = new System.Drawing.Point(6, 19);
            this.InventorySearchExpirationStartCheckBox.Name = "InventorySearchExpirationStartCheckBox";
            this.InventorySearchExpirationStartCheckBox.Size = new System.Drawing.Size(15, 14);
            this.InventorySearchExpirationStartCheckBox.TabIndex = 24;
            this.InventorySearchExpirationStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // InventorySearchMedicationIDGroupBox
            // 
            this.InventorySearchMedicationIDGroupBox.Controls.Add(this.InventorySearchMedicationIDCheckBox);
            this.InventorySearchMedicationIDGroupBox.Controls.Add(this.InventorySearchMedicationIDNumeric);
            this.InventorySearchMedicationIDGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventorySearchMedicationIDGroupBox.Location = new System.Drawing.Point(3, 58);
            this.InventorySearchMedicationIDGroupBox.Name = "InventorySearchMedicationIDGroupBox";
            this.InventorySearchMedicationIDGroupBox.Size = new System.Drawing.Size(282, 42);
            this.InventorySearchMedicationIDGroupBox.TabIndex = 27;
            this.InventorySearchMedicationIDGroupBox.TabStop = false;
            this.InventorySearchMedicationIDGroupBox.Text = "Medication ID";
            // 
            // InventorySearchMedicationIDCheckBox
            // 
            this.InventorySearchMedicationIDCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchMedicationIDCheckBox.AutoSize = true;
            this.InventorySearchMedicationIDCheckBox.Location = new System.Drawing.Point(6, 19);
            this.InventorySearchMedicationIDCheckBox.Name = "InventorySearchMedicationIDCheckBox";
            this.InventorySearchMedicationIDCheckBox.Size = new System.Drawing.Size(15, 14);
            this.InventorySearchMedicationIDCheckBox.TabIndex = 24;
            this.InventorySearchMedicationIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // InventorySearchMedicationIDNumeric
            // 
            this.InventorySearchMedicationIDNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchMedicationIDNumeric.Location = new System.Drawing.Point(23, 16);
            this.InventorySearchMedicationIDNumeric.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.InventorySearchMedicationIDNumeric.Name = "InventorySearchMedicationIDNumeric";
            this.InventorySearchMedicationIDNumeric.Size = new System.Drawing.Size(256, 20);
            this.InventorySearchMedicationIDNumeric.TabIndex = 12;
            // 
            // InventorySearchDrugNameGroupBox
            // 
            this.InventorySearchDrugNameGroupBox.Controls.Add(this.InventorySearchDrugNameCheckBox);
            this.InventorySearchDrugNameGroupBox.Controls.Add(this.InventorySearchDrugNameComboBox);
            this.InventorySearchDrugNameGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventorySearchDrugNameGroupBox.Location = new System.Drawing.Point(3, 16);
            this.InventorySearchDrugNameGroupBox.Name = "InventorySearchDrugNameGroupBox";
            this.InventorySearchDrugNameGroupBox.Size = new System.Drawing.Size(282, 42);
            this.InventorySearchDrugNameGroupBox.TabIndex = 28;
            this.InventorySearchDrugNameGroupBox.TabStop = false;
            this.InventorySearchDrugNameGroupBox.Text = "Drug Name";
            // 
            // InventorySearchDrugNameCheckBox
            // 
            this.InventorySearchDrugNameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySearchDrugNameCheckBox.AutoSize = true;
            this.InventorySearchDrugNameCheckBox.Location = new System.Drawing.Point(6, 19);
            this.InventorySearchDrugNameCheckBox.Name = "InventorySearchDrugNameCheckBox";
            this.InventorySearchDrugNameCheckBox.Size = new System.Drawing.Size(15, 14);
            this.InventorySearchDrugNameCheckBox.TabIndex = 24;
            this.InventorySearchDrugNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // InventorySearchResetButton
            // 
            this.InventorySearchResetButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InventorySearchResetButton.Location = new System.Drawing.Point(3, 472);
            this.InventorySearchResetButton.Margin = new System.Windows.Forms.Padding(2);
            this.InventorySearchResetButton.Name = "InventorySearchResetButton";
            this.InventorySearchResetButton.Size = new System.Drawing.Size(282, 36);
            this.InventorySearchResetButton.TabIndex = 14;
            this.InventorySearchResetButton.Text = "Reset";
            this.InventorySearchResetButton.UseVisualStyleBackColor = true;
            this.InventorySearchResetButton.Click += new System.EventHandler(this.InventorySearchResetButton_Click);
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InventorySearchGroupBox);
            this.Controls.Add(this.InventoryMedicationsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(835, 0);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(1019, 517);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryMedicationsListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryMedicationsAddQtyNumeric)).EndInit();
            this.InventoryMedicationsGroupBox.ResumeLayout(false);
            this.InventoryMedicationsAddGroupBox.ResumeLayout(false);
            this.InventoryMedicationsAddGroupBox.PerformLayout();
            this.InventorySearchGroupBox.ResumeLayout(false);
            this.InventorySearchExpirationEndGroupBox.ResumeLayout(false);
            this.InventorySearchExpirationEndGroupBox.PerformLayout();
            this.InventorySearchExpirationStartGroupBox.ResumeLayout(false);
            this.InventorySearchExpirationStartGroupBox.PerformLayout();
            this.InventorySearchMedicationIDGroupBox.ResumeLayout(false);
            this.InventorySearchMedicationIDGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySearchMedicationIDNumeric)).EndInit();
            this.InventorySearchDrugNameGroupBox.ResumeLayout(false);
            this.InventorySearchDrugNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox InventoryMedicationsAddNameTextbox;
        private Button InventoryMedicationsAddButton;
        private Button InventorySearchSearchButton;
        private DataGridView InventoryMedicationsListGridView;
        private DateTimePicker InventoryMedicationsAddExpDate;
        private NumericUpDown InventoryMedicationsAddQtyNumeric;
        private ComboBox InventorySearchDrugNameComboBox;
        private GroupBox InventoryMedicationsGroupBox;
        private GroupBox InventorySearchGroupBox;
        private Button InventorySearchResetButton;
        private DateTimePicker InventorySearchExpirationEndDate;
        private CheckBox InventorySearchExpirationEndCheckBox;
        private GroupBox InventorySearchExpirationEndGroupBox;
        private GroupBox InventorySearchExpirationStartGroupBox;
        private DateTimePicker InventorySearchExpirationStartDate;
        private CheckBox InventorySearchExpirationStartCheckBox;
        private GroupBox InventorySearchDrugNameGroupBox;
        private CheckBox InventorySearchDrugNameCheckBox;
        private GroupBox InventorySearchMedicationIDGroupBox;
        private CheckBox InventorySearchMedicationIDCheckBox;
        private NumericUpDown InventorySearchMedicationIDNumeric;
        private GroupBox InventoryMedicationsAddGroupBox;
    }
}
