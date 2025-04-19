using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class AlertsPage : UserControl
    {
        int counter = 0;
        public AlertsPage()
        {
            InitializeComponent();
        }

        private void TestAlert()
        {
            ListViewItem item = new ListViewItem("Type");
            item.SubItems.Add(counter.ToString());
            counter++;
            item.SubItems.Add("Name");
            //item.SubItems.Add(Convert.ToDateTime(["CreatedAt"]).ToString("g"));
            listViewAlerts.Items.Add(item);
        }

        private void acknowledgeAlertButton_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected alert.
            if (listViewAlerts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAlerts.SelectedItems[0];
                int alertID = int.Parse(selectedItem.SubItems[1].Text);

                // Acknowledge the alert in the database.
                DatabaseManager.UpdateRowValue("Alert", "AlertID", alertID, "Aknowledged", true);
                // Update the alerts display.
                UpdateAlerts(showAcknowledgedAlerts.Checked);
            }
            else
            {
                MessageBox.Show("Please select an alert to acknowledge.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AlertsPage_Load(object sender, EventArgs e)
        {
            // Set the ListView to show item details.
            listViewAlerts.View = View.Details;
            UpdateAlerts(showAcknowledgedAlerts.Checked);
        }

        private void UpdateAlerts(bool showAcknowledgedAlerts)
        {
            // Clear the ListView before loading new data.
            listViewAlerts.Items.Clear();
            // Clear the columns.
            listViewAlerts.Columns.Clear();
            // Add columns to the ListView.
            listViewAlerts.Columns.Add("Type", 100);
            listViewAlerts.Columns.Add("Alert ID", 50);
            listViewAlerts.Columns.Add("Drug ID", 100);
            listViewAlerts.Columns.Add("Alert Type", 100);
            listViewAlerts.Columns.Add("Alert Time", 100);
            listViewAlerts.Columns.Add("Acknowledged", 100);

            // Query the database for alerts and populate the ListView.
            List<AlertEntry> alerts = DatabaseManager.GetRows<AlertEntry>("Alert", "AlertID", count: 10000);

            // Remove acknowledged alerts if the checkbox is unchecked.
            if (showAcknowledgedAlerts == false)
            {
                alerts.RemoveAll(alert => alert.Acknowledged);
            }

            // Assuming AlertEntry has a method to convert to ListViewItem
            foreach (var alert in alerts)
            {
                ListViewItem item = new ListViewItem(alert.AlertType.ToString());
                item.SubItems.Add(alert.AlertID.ToString());
                item.SubItems.Add(alert.DrugID.ToString());
                item.SubItems.Add(alert.AlertType.ToString("g"));
                item.SubItems.Add(alert.AlertTime.ToString("g"));
                item.SubItems.Add(alert.Acknowledged.ToString());
                listViewAlerts.Items.Add(item);
            }

            // Make the columns auto-resize to fit the content.
            foreach (ColumnHeader column in listViewAlerts.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void showAcknowledgedAlerts_CheckedChanged(object sender, EventArgs e)
        {
            // Update the search to show acknowledged alerts if the checkbox is checked.
            UpdateAlerts(showAcknowledgedAlerts.Checked);
        }

        private void unacknowledgeButton_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected alert.
            if (listViewAlerts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAlerts.SelectedItems[0];
                int alertID = int.Parse(selectedItem.SubItems[1].Text);

                // Acknowledge the alert in the database.
                DatabaseManager.UpdateRowValue("Alert", "AlertID", alertID, "Aknowledged", false);
                // Update the alerts display.
                UpdateAlerts(showAcknowledgedAlerts.Checked);
            }
            else
            {
                MessageBox.Show("Please select an alert to unacknowledge.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
