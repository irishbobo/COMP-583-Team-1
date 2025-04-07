using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using PharmacyManager;

namespace PharmacyManager
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            //InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "password123";

            // Simulated user authentication (Replace this with database validation)
            if (username == "admin" && password == "password123")
            {
                // Open Home Page and hide login form
                HomePageForm homePage = new HomePageForm();
                this.Hide();
                homePage.ShowDialog();
                this.Close();
            }
            else
            {
                //lblError.Text = "Invalid username or password!";
                //lblError.Visible = true;
            }
        }

        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private Button buttonLogIn;
    }
}
