using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            //string username = "a";
            //string password = "1";

            // Simulated user authentication (Replace this with database validation)
            if (username == "a" && password == "1")
            {
                // Open Home Page and hide login form
                MainForm mainPage = new MainForm();
                mainPage.Show();
                this.Hide();
            }
            else
            {
                labelError.Text = "Invalid username or password!";
                labelError.Visible = true;
            }
        }

    }
}
