using PharmacyManager.Backend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PharmacyManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<DrugEntry> drugs = DatabaseManager.GetRows<DrugEntry>("Drug", "DrugId");
            List<AlertEntry> alerts = DatabaseManager.GetRows<AlertEntry>("Alert", "AlertId");
            List<HistoryEntry> history = DatabaseManager.GetRows<HistoryEntry>("History", "HistoryId");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }
    }
}
