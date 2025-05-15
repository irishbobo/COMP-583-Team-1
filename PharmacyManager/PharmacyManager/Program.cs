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
/*            List<DrugEntry> drugs = DatabaseManager.GetRows<DrugEntry>("Drug", "DrugId");

            var newDrugValues = new Dictionary<string, object>
            {
                { "Name", "Aspirin" },
                { "ExpirationDate", DateTime.Now.AddYears(1) },
                { "Amount", 100 }
            };

            int inserted = DatabaseManager.AddRow("Drug", newDrugValues);
            Console.WriteLine($"{inserted} row(s) inserted.");

            // Suppose DrugID is the primary key.
            int updated = DatabaseManager.UpdateRowValue("Drug", "DrugID", 1234, "Amount", 150);
            Console.WriteLine($"{updated} row(s) updated.");
*/


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
