using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Classes
{
    internal class User
    {
       
        private int id;
        private String name;
        private String username;
        private String password;
        private String role;

        public  String getRole()
        {
            return role;
        }

        public int getId()
        {
            return id;
        }


        public void RegisterCustomer(int userId, string userName, string userUsername, string userPassword, string userRole)
        {
            string connectionString = DatabaseManager.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (Id, Name, Username, Password, Role) VALUES (@Id, @Name, @Username, @Password, @Role)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", userId);
                command.Parameters.AddWithValue("@Name", userName);
                command.Parameters.AddWithValue("@Username", userUsername);
                command.Parameters.AddWithValue("@Password", userPassword);
                command.Parameters.AddWithValue("@Role", userRole);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted.");
            }
        }

        public bool Login(string enteredUsername, string enteredPassword)
        {
            string connectionString = DatabaseManager.GetConnectionString();
            string sqlQuery = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", enteredUsername);
                    cmd.Parameters.AddWithValue("@Password", enteredPassword);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        this.id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                        this.name = dataTable.Rows[0]["Name"].ToString();
                        this.username = dataTable.Rows[0]["Username"].ToString();
                        this.password = dataTable.Rows[0]["Password"].ToString();
                        this.role = dataTable.Rows[0]["Role"].ToString();

                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
        }
    }
}
