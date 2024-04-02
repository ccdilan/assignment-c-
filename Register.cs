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
using ComponentFactory.Krypton.Toolkit;

namespace ABC_Car_Traders
{
    public partial class frmRegister : KryptonForm
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonForm home = new Welcome();
            home.Show();
            this.Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pcs\\source\\repos\\ABC-Car-Traders\\ABC-Car-Traders\\CarDB.mdf;Integrated Security=True";
            String name = txtName.Text;
            String username = txtUserName.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (confirmPassword == password)
            {

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // SQL command to insert data into the "user" table
                        string sqlInsert = "INSERT INTO [users] (name, username, password) VALUES (@Name, @Username, @Password); SELECT SCOPE_IDENTITY();";

                        // Create a command object with parameters
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);

                            // Execute the command
                            int newUserID = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine(newUserID);

                            if (newUserID > 0)
                            {
                                Console.WriteLine("User registered successfully.");
                                KryptonForm Dashboard = new CustomerDashboard(newUserID);
                                Dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Failed to register user.");
                                Console.WriteLine("Failed to register user.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to register user.");
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Password and confirm password do not match.");
                Console.WriteLine("Password and confirm password do not match.");
            }

        }
    }
}
