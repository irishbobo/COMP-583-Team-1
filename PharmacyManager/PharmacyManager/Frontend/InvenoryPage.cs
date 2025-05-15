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
            string name = InventoryMedicationsAddNameTextbox.Text;
            DateTime expirationDate = InventoryMedicationsAddExpDate.Value;
            int amount = (int)InventoryMedicationsAddQtyNumeric.Value;

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
                    else
                    {
                        MessageBox.Show("Failed to retrieve the last inserted Drug ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UpdateDataGridView()
        {
            List<DrugEntry> drugs = DatabaseManager.GetRows<DrugEntry>("Drug", "DrugId", count: 10000);
            InventoryMedicationsListGridView.DataSource = drugs;
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            InventoryMedicationsListGridView.AutoGenerateColumns = true;
            UpdateDataGridView();
        }

        private void searchDrugButton_Click(object sender, EventArgs e)
        {
            // Check if the name box is checked & valid.
            string selectedName = null;
            if (InventorySearchDrugNameCheckBox.Checked 
                && string.IsNullOrEmpty(InventorySearchDrugNameComboBox.Text) == false)
            {
                selectedName = InventorySearchDrugNameComboBox.Text;
            }


            // Check if the ID box is checked.
            int? selectedID = null;
            if (InventorySearchMedicationIDCheckBox.Checked)
            {
                selectedID = (int)InventorySearchMedicationIDNumeric.Value;
            }

            // Check if the expiration start-date box is checked.
            DateTime? selectedStartExpDate = null;
            if (InventorySearchExpirationStartCheckBox.Checked)
            {
                selectedStartExpDate = InventorySearchExpirationStartDate.Value;
            }

            // Check if the expiration end-date box is checked.
            DateTime? selectedEndExpDate = null;
            if (InventorySearchExpirationEndCheckBox.Checked)
            {
                selectedEndExpDate = InventorySearchExpirationEndDate.Value;
            }

            List<DrugEntry> drugs = DatabaseManager.SearchDrugs(25, DatabaseManager.SortOrder.ExpRecent, 
                                                                selectedName, 
                                                                selectedStartExpDate, selectedEndExpDate, 
                                                                selectedID);
            InventoryMedicationsListGridView.DataSource = drugs;
            InventoryMedicationsListGridView.Refresh();
        }

        private void searchDrugNameComboBox_DropDown(object sender, EventArgs e)
        {
            List<string> uniqueNames = DatabaseManager.GetUniqueDrugNames();
            string selectedName = InventorySearchDrugNameComboBox.Text;

            InventorySearchDrugNameComboBox.Items.Clear();
            InventorySearchDrugNameComboBox.Items.Add("");
            foreach (string name in uniqueNames)
            {
                InventorySearchDrugNameComboBox.Items.Add(name);
            }

            if (uniqueNames.Contains(selectedName))
            {
                InventorySearchDrugNameComboBox.Text = selectedName;
            }
            else
            {
                InventorySearchDrugNameComboBox.Text = "";
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

        private void InventorySearchResetButton_Click(object sender, EventArgs e)
        {
            // Reset each search field to its default state.

            // Reset the drug name.
            InventorySearchDrugNameCheckBox.Checked = false;
            InventorySearchDrugNameComboBox.Text = "";

            // Reset the medication ID.
            InventorySearchMedicationIDCheckBox.Checked = false;
            InventorySearchMedicationIDNumeric.Value = 0;

            // Reset the expiration start-date.
            InventorySearchExpirationStartCheckBox.Checked = false;
            InventorySearchExpirationStartDate.Value = DateTime.Now;

            // Reset the expiration end-date.
            InventorySearchExpirationEndCheckBox.Checked = false;
            InventorySearchExpirationEndDate.Value = DateTime.Now;

            // Refresh the list.
            List<DrugEntry> drugs = DatabaseManager.SearchDrugs(25, DatabaseManager.SortOrder.ExpRecent);
            InventoryMedicationsListGridView.DataSource = drugs;
            InventoryMedicationsListGridView.Refresh();
        }
    }
}