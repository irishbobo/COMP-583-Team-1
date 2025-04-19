using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class InventoryPage : UserControl
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            // Read the input values from the text boxes.
            string name = addDrugNameTextbox.Text;
            System.DateTime expirationDate = addDrugExpDateDateTimePicker.Value;
            int amount = (int)addDrugAmountNumericUpDown.Value;

            // Validate that the drug name is not empty.
            if (name == "")
            {
                MessageBox.Show("Please enter the drug name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a dictionary with the corresponding column names and parsed values.
            var newDrugValues = new Dictionary<string, object>
            {
                { "Name", name },               // Corresponds to the drug's name.
                { "Amount", amount},           // Corresponds to the quantity in stock.
                { "ExpirationDate", expirationDate}       // Corresponds to the drug's expiration date.
            };

            try
            {
                // Call the AddRow function to insert the new drug into the 'Drug' table.
                int rowsAffected = DatabaseManager.AddRow("Drug", newDrugValues);

                if (rowsAffected > 0)
                    MessageBox.Show("Drug added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No rows were inserted.", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Display the error message if something goes wrong.
                MessageBox.Show($"Error adding drug: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            // Retrieve the drugs from the database and bind them to the DataGridView.
            List<DrugEntry> drugs = DatabaseManager.GetRows<DrugEntry>("Drug", "DrugId", count: 10000);
            dataGridView1.DataSource = drugs;
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            // Set the display of the grid to be manual.
            dataGridView1.AutoGenerateColumns = true;

            // Retrieve the first 'numberOfRows' drugs from the Drug table.
            UpdateDataGridView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Get the ID from the deletion box.
            int drugID = (int) removeDrugNumericUpDown.Value;

            // Prompt the user for confirmation.
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the drug with ID {drugID}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call the DeleteRow function to remove the drug from the 'Drug' table.
                    int rowsAffected = DatabaseManager.DeleteRow("Drug", "DrugID", drugID);

                    if (rowsAffected > 0)
                        MessageBox.Show("Drug deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No rows were deleted.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    // Display the error message if something goes wrong.
                    MessageBox.Show($"Error deleting drug: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDataGridView();
            }
        }

        private void searchDrugButton_Click(object sender, EventArgs e)
        {
            // Check if the search drug name is empty to revert to the original data.
            if (string.IsNullOrEmpty(searchDrugNameComboBox.Text))
            {
                // If the search box is empty, revert to the original data.
                UpdateDataGridView();
                return;
            }

            // Retrieve the selected drug name from the combo box.
            string selectedName = searchDrugNameComboBox.Text;
            // Retrieve the drugs from the database that match the selected name.
            List<DrugEntry> drugs = DatabaseManager.SearchDrugs(selectedName, 10000, DatabaseManager.SortOrder.ExpRecent);
            // Bind the results to the DataGridView.
            dataGridView1.DataSource = drugs;
            // Update the DataGridView to show the search results.
            dataGridView1.Refresh();
        }

        private void searchDrugNameComboBox_DropDown(object sender, EventArgs e)
        {
            // Update the contents of the combo box with unique drug names.
            List<string> uniqueNames = DatabaseManager.GetUniqueDrugNames();
            // Store the currently selected drug name.
            string selectedName = searchDrugNameComboBox.Text;

            // Clear the current items in the combo box & add the new ones.
            searchDrugNameComboBox.Items.Clear();
            // Add an empty item to the combo box.
            searchDrugNameComboBox.Items.Add("");

            // Add the unique drug names to the combo box.
            foreach (string name in uniqueNames)
            {
                searchDrugNameComboBox.Items.Add(name);
            }

            // Re-select the previously selected drug name.
            if (uniqueNames.Contains(selectedName))
            {
                searchDrugNameComboBox.Text = selectedName;
            }
            else
            {
                searchDrugNameComboBox.Text = "";
            }
        }
    }
}

