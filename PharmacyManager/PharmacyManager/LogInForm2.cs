using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;

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
                lblError.Text = "Invalid username or password!";
                lblError.Visible = true;
            }
        }

    }
}
