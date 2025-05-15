using System;
using System.Windows.Forms;

namespace PharmacyManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordTextBox.Text;
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

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
