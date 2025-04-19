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
            this.addDrugNameTextbox = new System.Windows.Forms.TextBox();
            this.addDrugButton = new System.Windows.Forms.Button();
            this.searchDrugButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.addDrugExpDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addDrugAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.removeDrugNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchDrugNameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDrugAmountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeDrugNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addDrugNameTextbox
            // 
            this.addDrugNameTextbox.Location = new System.Drawing.Point(76, 14);
            this.addDrugNameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.addDrugNameTextbox.Name = "addDrugNameTextbox";
            this.addDrugNameTextbox.Size = new System.Drawing.Size(200, 20);
            this.addDrugNameTextbox.TabIndex = 0;
            this.addDrugNameTextbox.Text = "Name";
            this.addDrugNameTextbox.UseWaitCursor = true;
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(13, 14);
            this.addDrugButton.Margin = new System.Windows.Forms.Padding(2);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(59, 20);
            this.addDrugButton.TabIndex = 1;
            this.addDrugButton.Text = "Add";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // searchDrugButton
            // 
            this.searchDrugButton.Location = new System.Drawing.Point(13, 106);
            this.searchDrugButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchDrugButton.Name = "searchDrugButton";
            this.searchDrugButton.Size = new System.Drawing.Size(59, 20);
            this.searchDrugButton.TabIndex = 4;
            this.searchDrugButton.Text = "Search";
            this.searchDrugButton.UseVisualStyleBackColor = true;
            this.searchDrugButton.Click += new System.EventHandler(this.searchDrugButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(294, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(666, 569);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(13, 154);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 20);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // addDrugExpDateDateTimePicker
            // 
            this.addDrugExpDateDateTimePicker.Location = new System.Drawing.Point(76, 65);
            this.addDrugExpDateDateTimePicker.Name = "addDrugExpDateDateTimePicker";
            this.addDrugExpDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.addDrugExpDateDateTimePicker.TabIndex = 10;
            // 
            // addDrugAmountNumericUpDown
            // 
            this.addDrugAmountNumericUpDown.Location = new System.Drawing.Point(76, 39);
            this.addDrugAmountNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.addDrugAmountNumericUpDown.Name = "addDrugAmountNumericUpDown";
            this.addDrugAmountNumericUpDown.Size = new System.Drawing.Size(200, 20);
            this.addDrugAmountNumericUpDown.TabIndex = 11;
            // 
            // removeDrugNumericUpDown
            // 
            this.removeDrugNumericUpDown.Location = new System.Drawing.Point(76, 154);
            this.removeDrugNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.removeDrugNumericUpDown.Name = "removeDrugNumericUpDown";
            this.removeDrugNumericUpDown.Size = new System.Drawing.Size(200, 20);
            this.removeDrugNumericUpDown.TabIndex = 12;
            // 
            // searchDrugNameComboBox
            // 
            this.searchDrugNameComboBox.FormattingEnabled = true;
            this.searchDrugNameComboBox.Location = new System.Drawing.Point(76, 105);
            this.searchDrugNameComboBox.Name = "searchDrugNameComboBox";
            this.searchDrugNameComboBox.Size = new System.Drawing.Size(200, 21);
            this.searchDrugNameComboBox.TabIndex = 13;
            this.searchDrugNameComboBox.DropDown += new System.EventHandler(this.searchDrugNameComboBox_DropDown);
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchDrugNameComboBox);
            this.Controls.Add(this.removeDrugNumericUpDown);
            this.Controls.Add(this.addDrugAmountNumericUpDown);
            this.Controls.Add(this.addDrugExpDateDateTimePicker);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchDrugButton);
            this.Controls.Add(this.addDrugButton);
            this.Controls.Add(this.addDrugNameTextbox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(992, 606);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDrugAmountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeDrugNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox addDrugNameTextbox;
        private Button addDrugButton;
        private Button searchDrugButton;
        private DataGridView dataGridView1;
        private Button btnRemove;
        private DateTimePicker addDrugExpDateDateTimePicker;
        private NumericUpDown addDrugAmountNumericUpDown;
        private NumericUpDown removeDrugNumericUpDown;
        private ComboBox searchDrugNameComboBox;
    }
}
