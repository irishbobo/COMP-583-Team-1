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
            this.textBoxAddName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxAddAmount = new System.Windows.Forms.TextBox();
            this.textBoxAddExpDate = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxSearchName = new System.Windows.Forms.TextBox();
            this.textBoxSearchID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.textBoxRemoveID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxAddName
            // 
            this.textBoxAddName.Location = new System.Drawing.Point(114, 22);
            this.textBoxAddName.Name = "textBoxAddName";
            this.textBoxAddName.Size = new System.Drawing.Size(100, 26);
            this.textBoxAddName.TabIndex = 0;
            this.textBoxAddName.Text = "Name";
            this.textBoxAddName.UseWaitCursor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxAddAmount
            // 
            this.textBoxAddAmount.Location = new System.Drawing.Point(114, 54);
            this.textBoxAddAmount.Name = "textBoxAddAmount";
            this.textBoxAddAmount.Size = new System.Drawing.Size(100, 26);
            this.textBoxAddAmount.TabIndex = 2;
            this.textBoxAddAmount.Text = "Amount";
            // 
            // textBoxAddExpDate
            // 
            this.textBoxAddExpDate.Location = new System.Drawing.Point(114, 86);
            this.textBoxAddExpDate.Name = "textBoxAddExpDate";
            this.textBoxAddExpDate.Size = new System.Drawing.Size(100, 26);
            this.textBoxAddExpDate.TabIndex = 3;
            this.textBoxAddExpDate.Text = "Expiration Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(20, 160);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchName
            // 
            this.textBoxSearchName.Location = new System.Drawing.Point(114, 157);
            this.textBoxSearchName.Name = "textBoxSearchName";
            this.textBoxSearchName.Size = new System.Drawing.Size(100, 26);
            this.textBoxSearchName.TabIndex = 5;
            this.textBoxSearchName.Text = "Name";
            // 
            // textBoxSearchID
            // 
            this.textBoxSearchID.Location = new System.Drawing.Point(114, 189);
            this.textBoxSearchID.Name = "textBoxSearchID";
            this.textBoxSearchID.Size = new System.Drawing.Size(100, 26);
            this.textBoxSearchID.TabIndex = 6;
            this.textBoxSearchID.Text = "Drug ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(271, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 193);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(20, 264);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // textBoxRemoveID
            // 
            this.textBoxRemoveID.Location = new System.Drawing.Point(114, 264);
            this.textBoxRemoveID.Name = "textBoxRemoveID";
            this.textBoxRemoveID.Size = new System.Drawing.Size(100, 26);
            this.textBoxRemoveID.TabIndex = 9;
            this.textBoxRemoveID.Text = "ID";
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxRemoveID);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxSearchID);
            this.Controls.Add(this.textBoxSearchName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxAddExpDate);
            this.Controls.Add(this.textBoxAddAmount);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxAddName);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(786, 498);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxAddName;
        private Button btnAdd;
        private TextBox textBoxAddAmount;
        private TextBox textBoxAddExpDate;
        private Button btnSearch;
        private TextBox textBoxSearchName;
        private TextBox textBoxSearchID;
        private DataGridView dataGridView1;
        private Button btnRemove;
        private TextBox textBoxRemoveID;
    }
}
