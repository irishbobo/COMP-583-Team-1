using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class ReportsPage : UserControl
    {
        private DataGridView dataGridViewReports;
        private DateTimePicker startDatePicker, endDatePicker;
        private NumericUpDown drugIdFilter;
        private Button filterButton;

        private const string CONNECTION_STRING = @"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true";

        public ReportsPage()
        {
            InitializeComponent();
            InitializeReportsUI();
        }

        private void InitializeReportsUI()
        {
            Label lblDrugId = new Label { Text = "Drug ID:", Top = 10, Left = 10 };
            drugIdFilter = new NumericUpDown { Top = 10, Left = 70, Width = 100, Minimum = 0, Maximum = int.MaxValue };

            Label lblStart = new Label { Text = "Start Date:", Top = 10, Left = 180 };
            startDatePicker = new DateTimePicker { Top = 10, Left = 260, Width = 150 };

            Label lblEnd = new Label { Text = "End Date:", Top = 10, Left = 420 };
            endDatePicker = new DateTimePicker { Top = 10, Left = 500, Width = 150 };

            filterButton = new Button { Text = "Filter", Top = 10, Left = 660, Width = 80 };
            filterButton.Click += FilterButton_Click;

            dataGridViewReports = new DataGridView
            {
                Top = 50,
                Left = 10,
                Width = 800,
                Height = 400,
                AutoGenerateColumns = true
            };

            this.Controls.Add(lblDrugId);
            this.Controls.Add(drugIdFilter);
            this.Controls.Add(lblStart);
            this.Controls.Add(startDatePicker);
            this.Controls.Add(lblEnd);
            this.Controls.Add(endDatePicker);
            this.Controls.Add(filterButton);
            this.Controls.Add(dataGridViewReports);

            LoadAllHistory();
        }

        private void LoadAllHistory()
        {
            // Use a valid SQL datetime range
            DateTime start = new DateTime(1753, 1, 1);
            DateTime end = DateTime.Now;

            List<HistoryEntry> entries = GetHistoryEntries(null, start, end);
            dataGridViewReports.DataSource = entries;
        }


        private void FilterButton_Click(object sender, EventArgs e)
        {
            int? drugID = drugIdFilter.Value > 0 ? (int?)drugIdFilter.Value : null;
            DateTime start = startDatePicker.Value.Date;
            DateTime end = endDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

            List<HistoryEntry> entries = GetHistoryEntries(drugID, start, end);
            dataGridViewReports.DataSource = entries;
        }

        private List<HistoryEntry> GetHistoryEntries(int? drugID, DateTime start, DateTime end)
        {
            List<HistoryEntry> results = new List<HistoryEntry>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string query = @"
                    SELECT * FROM dbo.History
                    WHERE (@drugID IS NULL OR drugID = @drugID)
                      AND historyTime BETWEEN @start AND @end
                    ORDER BY historyTime DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@drugID", (object)drugID ?? DBNull.Value);
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
    }
}