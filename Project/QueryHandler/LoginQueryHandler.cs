using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient; // Install-Package MySql.Data
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;

namespace Project.QueryHandler
{
    public class LoginQueryHandler
    {
        private readonly string connectionString = "datasource=localhost;port=3306;username=login;password=login;" +
            "database=restaurantmanagement;";

        public LoginQueryHandler()
        {

        }

        public bool checkUserPass(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass)) return false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT Password FROM `employee_logindata` " +
                    "JOIN employee ON employee_logindata.Em_ID = employee.Em_ID " +
                    "WHERE `Username` = @username AND `Status` = 'active' ORDER BY employee_logindata.Login_ID", connection))
                {
                    q.Parameters.AddWithValue("@username", user);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashed = reader.GetString(0);
                            if (hashed == null) return false;

                            return BCrypt.Net.BCrypt.Verify(pass, hashed);
                        }
                    }
                }
            }
            return false;
        }

        public string? getNameFromUser(string user)
        {
            if (string.IsNullOrWhiteSpace(user)) return null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CONCAT(FName, ' ', LName) FROM `employee_logindata` " +
                    "JOIN employee ON employee_logindata.Em_ID = employee.Em_ID " +
                    "WHERE employee_logindata.Username = @user " +
                    "ORDER BY employee_logindata.Login_ID LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@user", user);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }
            }
            return null;
        }

        public uint getIDFromUser(string user)
        {
            if (user == null) throw new ArgumentNullException("Unable to retrieve id");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT Em_ID FROM `employee_logindata` " +
                    "WHERE Username = @user ORDER BY Login_ID LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@user", user);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetUInt32(0);
                        }
                    }
                }
            }
            return 0;
        }

        public string getRoleFromUser(string user)
        {
            if (user == null) throw new ArgumentNullException("Unable to retrieve role");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT " +
                    "CASE " +
                    "WHEN EXISTS(SELECT 1 FROM cashier c WHERE c.Cs_Em_ID = e.Em_ID) THEN 'cashier' " +
                    "WHEN EXISTS(SELECT 1 FROM chef ch WHERE ch.Cf_Em_ID = e.Em_ID) THEN 'chef' " +
                    "WHEN EXISTS(SELECT 1 FROM manager m WHERE m.M_Em_ID = e.Em_ID) THEN 'manager' " +
                    "WHEN EXISTS(SELECT 1 FROM superadmin s WHERE s.S_Em_ID = e.Em_ID) THEN 'superadmin' " +
                    "ELSE 'none' " +
                    "END " +
                    "AS Role " +
                    "FROM employee_logindata e " +
                    "WHERE e.Username = @user ORDER BY Login_ID " +
                    "LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@user", user);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }
            }
            return "none";
        }
    }
}
