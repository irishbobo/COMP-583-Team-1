using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class ReportsPage : UserControl
    {
        private TextBox txtDrugID;
        private DateTimePicker startDatePicker, endDatePicker;
        private Button btnGenerate;
        private ListView listViewReports;

        private const string CONNECTION_STRING = @"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true";

        public ReportsPage()
        {
            InitializeComponent();
            InitializeReportsUI();
        }

        private void InitializeReportsUI()
        {
            txtDrugID = new TextBox { Top = 10, Left = 10, Width = 100 };
            txtDrugID.Text = "Drug ID";
            txtDrugID.ForeColor = Color.Gray;

            txtDrugID.GotFocus += (s, e) =>
            {
                if (txtDrugID.Text == "Drug ID")
                {
                    txtDrugID.Text = "";
                    txtDrugID.ForeColor = Color.Black;
                }
            };

            txtDrugID.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtDrugID.Text))
                {
                    txtDrugID.Text = "Drug ID";
                    txtDrugID.ForeColor = Color.Gray;
                }
            };

            startDatePicker = new DateTimePicker { Top = 10, Left = 120, Width = 150 };
            endDatePicker = new DateTimePicker { Top = 10, Left = 280, Width = 150 };
            btnGenerate = new Button { Text = "Generate", Top = 10, Left = 440, Width = 100 };
            btnGenerate.Click += BtnGenerate_Click;

            listViewReports = new ListView
            {
                Top = 50,
                Left = 10,
                Width = 750,
                Height = 400,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            listViewReports.Columns.Add("Time", 150);
            listViewReports.Columns.Add("Drug ID", 100);
            listViewReports.Columns.Add("Before", 100);
            listViewReports.Columns.Add("After", 100);

            this.Controls.Add(txtDrugID);
            this.Controls.Add(startDatePicker);
            this.Controls.Add(endDatePicker);
            this.Controls.Add(btnGenerate);
            this.Controls.Add(listViewReports);
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDrugID.Text.Trim(), out int drugID))
            {
                MessageBox.Show("Please enter a valid numeric Drug ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime start = startDatePicker.Value;
            DateTime end = endDatePicker.Value;

            List<HistoryEntry> entries = GetHistoryByDrugID(drugID, start, end);
            DisplayHistory(entries);
        }

        private List<HistoryEntry> GetHistoryByDrugID(int drugID, DateTime start, DateTime end)
        {
            List<HistoryEntry> results = new List<HistoryEntry>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string query = @"
                    SELECT * FROM dbo.History
                    WHERE drugID = @drugID
                      AND historyTime BETWEEN @start AND @end
                    ORDER BY historyTime DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@drugID", drugID);
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@end", end);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryEntry entry = new HistoryEntry();
                            entry.ParseFromReader(reader);
                            results.Add(entry);
                        }
                    }
                }

                connection.Close();
            }

            return results;
        }

        private void DisplayHistory(List<HistoryEntry> entries)
        {
            listViewReports.Items.Clear();

            foreach (var entry in entries)
            {
                ListViewItem item = new ListViewItem(entry.historyTime.ToString("g"));
                item.SubItems.Add(entry.drugID.ToString());
                item.SubItems.Add(entry.beforeAmount.ToString());
                item.SubItems.Add(entry.afterAmount.ToString());
                listViewReports.Items.Add(item);
            }
        }
    }
}
