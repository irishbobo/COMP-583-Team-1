using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadPage(new InventoryPage()); // Default page on load
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            //LoadPage(new AlertsPage());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadPage(new InventoryPage());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //LoadPage(new ReportsPage());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optional: Navigate back to login
            LogInForm login = new LogInForm();
            login.Show();
            this.Close();
        }
    }
}
