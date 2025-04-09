using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewAlerts.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewAlerts.SelectedItems[0];
                listViewAlerts.Items.Remove(item);
            }
            else
            {
                TestAlert();
            } 
        }
    }
}
