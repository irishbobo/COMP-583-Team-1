using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class InventoryPage : UserControl
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = addDrugNameTextbox.Text;
            DateTime expirationDate = addDrugExpDateDateTimePicker.Value;
            int amount = (int)addDrugAmountNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the drug name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newDrugValues = new Dictionary<string, object>
            {
                { "Name", name },
                { "Amount", amount },
                { "ExpirationDate", expirationDate }
            };

            try
            {
                int rowsAffected = DatabaseManager.AddRow("Drug", newDrugValues);

                if (rowsAffected > 0)
                {
                    int newDrugID = GetLastInsertedDrugID();
                    if (newDrugID != -1)
                    {
                        LogHistory(newDrugID, 0, amount);
                    }

                    MessageBox.Show("Drug added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No rows were inserted.", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding drug: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int drugID = (int)removeDrugNumericUpDown.Value;

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the drug with ID {drugID}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int previousAmount = GetDrugAmount(drugID);

                    // Log to history BEFORE deleting the drug
                    LogHistory(drugID, previousAmount, 0);

                    int rowsAffected = DatabaseManager.DeleteRow("Drug", "DrugID", drugID);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Drug deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting drug: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDataGridView();
            }
        }

        private void UpdateDataGridView()
        {
            List<DrugEntry> drugs = DatabaseManager.GetRows<DrugEntry>("Drug", "DrugId", count: 10000);
            dataGridView1.DataSource = drugs;
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            UpdateDataGridView();
        }

        private void searchDrugButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchDrugNameComboBox.Text))
            {
                UpdateDataGridView();
                return;
            }

            string selectedName = searchDrugNameComboBox.Text;
            List<DrugEntry> drugs = DatabaseManager.SearchDrugs(selectedName, 10000, DatabaseManager.SortOrder.ExpRecent);
            dataGridView1.DataSource = drugs;
            dataGridView1.Refresh();
        }

        private void searchDrugNameComboBox_DropDown(object sender, EventArgs e)
        {
            List<string> uniqueNames = DatabaseManager.GetUniqueDrugNames();
            string selectedName = searchDrugNameComboBox.Text;

            searchDrugNameComboBox.Items.Clear();
            searchDrugNameComboBox.Items.Add("");
            foreach (string name in uniqueNames)
            {
                searchDrugNameComboBox.Items.Add(name);
            }

            if (uniqueNames.Contains(selectedName))
            {
                searchDrugNameComboBox.Text = selectedName;
            }
            else
            {
                searchDrugNameComboBox.Text = "";
            }
        }

        private int GetLastInsertedDrugID()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true"))
            {
                conn.Open();
                string query = "SELECT TOP 1 DrugID FROM dbo.Drug ORDER BY DrugID DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }


        private int GetDrugAmount(int drugID)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true"))
            {
                conn.Open();
                string query = "SELECT Amount FROM dbo.Drug WHERE DrugID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", drugID);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private void LogHistory(int drugID, int before, int after)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true"))
            {
                conn.Open();
                string query = "INSERT INTO dbo.History (drugID, historyTime, beforeAmount, afterAmount) VALUES (@drugID, @time, @before, @after)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@drugID", drugID);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@before", before);
                    cmd.Parameters.AddWithValue("@after", after);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}