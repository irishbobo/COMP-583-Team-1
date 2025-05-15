using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class ReportsPage : UserControl
    {

        private const string CONNECTION_STRING = @"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true";

        public ReportsPage()
        {
            InitializeComponent();
        }

        private void ReportsGenerateReportsGenerateButton_Click(object sender, EventArgs e)
        {
            // Read the datetime from the two date pickers
            DateTime start = ReportsGenerateReportsStartDateDate.Value.Date;
            DateTime end = ReportsGenerateReportsEndDateDate.Value.Date;

            // Retrieve the history entries in the given range.
            List<HistoryEntry> entries = DatabaseManager.GetHistoryEntries(start, DateTime.Now);
            // Ask the DB for mappings of ID to drug names.
            Dictionary<int, string> drugNameMappings = DatabaseManager.GetDrugNamesForHistory(entries);
            // Now generate the reports.
            List<ReportEntry> reportEntries = DatabaseManager.GenerateWeeklyAdjustmentReports(entries, drugNameMappings);


            // Set the data source of the DataGridView to the list of entries
            ReportsReportsListGridView.DataSource = reportEntries;
            ReportsReportsListGridView.Refresh();
        }

    }
}