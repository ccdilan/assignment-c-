using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_Car_Traders.Classes;
using ComponentFactory.Krypton.Toolkit;

namespace ABC_Car_Traders
{
    public partial class frmLogin : KryptonForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = new User();
            bool isAuthenticated = user.Login(username, password);

            if (isAuthenticated)
            {
                if (user.getRole().Trim() == "Admin")
                {
                    // Redirect to the admin dashboard
                    KryptonForm adminDashboard = new Dashboard(user.getId());
                    adminDashboard.Show();
                    this.Hide();
                }
                else
                {
                    // Redirect to the customer dashboard
                    KryptonForm customerDashboard = new CustomerDashboard(user.getId());
                    customerDashboard.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
