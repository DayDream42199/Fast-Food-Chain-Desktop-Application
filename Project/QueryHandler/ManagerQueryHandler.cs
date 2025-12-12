using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Datatypes;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.QueryHandler
{
    public class ManagerQueryHandler
    {
        private readonly string connectionString = "datasource=localhost;port=3306;username=manager;password=manager;" +
           "database=restaurantmanagement;";

        public ManagerQueryHandler()
        {

        }

        public long getTodayOrderCount()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT COUNT(*) FROM `order` " +
                    "WHERE DATE(`order`.Timestamp) = CURDATE()", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt64(0);
                        }
                    }
                }
            }
            return 0;
        }

        public decimal getTodayRevenue()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT SUM(Total) FROM `payment` " +
                    "WHERE DATE(`payment`.Timestamp) = CURDATE()", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader.IsDBNull(0)) return 0;
                            return reader.GetDecimal(0);
                        }
                    }
                }
            }
            return 0;
        }

        public List<Inventory> getLowStock()
        {
            List<Inventory> result = new List<Inventory>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT m.Menu_ID AS MenuID, m.Name AS Name, c.Name AS Category, " +
                    "COALESCE(i.Quantity, 0) AS Quantity FROM menu_item m " +
                    "LEFT JOIN (SELECT Menu_ID, SUM(Quantity) AS Quantity FROM inventory_item " +
                    "WHERE Expiry_date >= CURDATE() GROUP BY Menu_ID) AS i ON m.Menu_ID = i.Menu_ID " +
                    "LEFT JOIN category c ON m.Category_ID = c.Category_ID " +
                    "WHERE COALESCE(i.Quantity, 0) <= 20 ORDER BY m.Menu_ID;", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Inventory
                            {
                                Inventory_ID = 0,
                                Name = reader.GetString("Name"),
                                Type = reader.GetString("Category"),
                                Quantity = reader.GetUInt32("Quantity"),
                                Batch_Number = "?",
                                Expiry_date = DateTime.MinValue,
                                Shelf_location = "?",
                                Menu_ID = reader.GetUInt32("MenuID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public List<Inventory> getNearExpire()
        {
            List<Inventory> result = new List<Inventory>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT i.Inventory_Item_ID AS InventoryID, " +
                    "m.Name AS Name, c.Name AS Category, i.Quantity AS Quantity, i.Batch_Number AS BatchNum, " +
                    "i.Expiry_date AS ExpiryDate, i.Shelf_location AS ShelfLoc, i.Menu_ID AS MenuID FROM inventory_item i " +
                    "JOIN menu_item m ON i.Menu_ID = m.Menu_ID " +
                    "JOIN category c ON m.Category_ID = c.Category_ID " +
                    "WHERE i.Expiry_date <= CURDATE() + INTERVAL 3 DAY " +
                    "AND i.Quantity > 0 ORDER BY i.Expiry_date;", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Inventory
                            {
                                Inventory_ID = reader.GetUInt64("InventoryID"),
                                Name = reader.GetString("Name"),
                                Type = reader.GetString("Category"),
                                Quantity = reader.GetUInt32("Quantity"),
                                Batch_Number = reader.GetString("BatchNum"),
                                Expiry_date = reader.GetDateTime("ExpiryDate"),
                                Shelf_location = reader.GetString("ShelfLoc"),
                                Menu_ID = reader.GetUInt32("MenuID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public DateTime getOrderLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'order'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getOrderItemLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'order_item'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getInventoryItemLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'inventory_item'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getMenuItemLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'menu_item'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getEmployeeLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'employee'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getEmployeeLogindataLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'employee_logindata'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }
        public DateTime getPaymentLastUpdateTime(DateTime curDateTime)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT lastUpdatedTime FROM `tablelastupdate` " +
                    "WHERE tableName = 'payment'", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDateTime(0);
                        }
                    }
                }
            }
            return curDateTime;
        }

        private static string searchFixer(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == ' ')
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public long getInventoryItemPageCount(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CEIL(COUNT(*)/50) FROM `inventory_item` i " +
                    "LEFT JOIN menu_item m on i.Menu_ID = m.Menu_ID " +
                    "WHERE (m.name LIKE @searchName OR (@searchNull = 'Removed menu' AND i.Menu_ID IS NULL))", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");
                    q.Parameters.AddWithValue("@searchNull", searchFixer(name));

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt64(0);
                        }
                    }
                }
            }
            return 0;
        }
        public List<Inventory> getInventoryItemByPage(string name, string sortBy, string sortMode, long page)
        {
            if (page == 0) page = 1;

            // Check for allowed sort 🙏🙏🙏 Don't read this just skip 🙏🙏🙏 It works trust me 🙏🙏🙏
            if (sortMode != "ASC" && sortMode != "DESC") return new List<Inventory>();
            if (sortBy == "ID") sortBy = "Inventory_Item_ID";
            else if (sortBy == "Quantity") sortBy = "Quantity";
            else if (sortBy == "Batch") sortBy = "Batch_Number";
            else sortBy = "Expiry_date";
            // Yes continue to next part, skip this ^^^^^^^^^^^^ 🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏

            List<Inventory> result = new List<Inventory>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT i.Inventory_Item_ID AS InventoryID, " +
                    "IFNULL(m.name, '[Removed menu]') AS Name, IFNULL(c.Name, 'X') AS Category, " +
                    "i.Quantity AS Quantity, i.Batch_Number AS BatchNum, " +
                    "i.Expiry_date AS ExpiryDate, i.Shelf_location AS ShelfLoc, IFNULL(i.Menu_ID, 0) AS MenuID " +
                    "FROM inventory_item i " +
                    "LEFT JOIN menu_item m on i.Menu_ID = m.Menu_ID " +
                    "LEFT JOIN category c on c.Category_ID = m.Category_ID " +
                    "WHERE (m.name LIKE @searchName OR (@searchNull = 'Removed menu' AND i.Menu_ID IS NULL))" +
                    $"ORDER BY i.{sortBy} {sortMode} LIMIT 50 OFFSET @offset", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");
                    q.Parameters.AddWithValue("@searchNull", searchFixer(name));
                    q.Parameters.AddWithValue("@offset", (page - 1) * 50);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Inventory
                            {
                                Inventory_ID = reader.GetUInt64("InventoryID"),
                                Name = reader.GetString("Name"),
                                Type = reader.GetString("Category"),
                                Quantity = reader.GetUInt32("Quantity"),
                                Batch_Number = reader.GetString("BatchNum"),
                                Expiry_date = reader.GetDateTime("ExpiryDate"),
                                Shelf_location = reader.GetString("ShelfLoc"),
                                Menu_ID = reader.GetUInt32("MenuID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }
        public bool isMenuExists(string menu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT * FROM `menu_item` " +
                    "WHERE Name = @menuName LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@menuName", menu);
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }
        public uint getMenuIDFromName(string menu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT Menu_ID, Category_ID FROM `menu_item` " +
                    "WHERE Name = @menuName LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@menuName", menu);
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetUInt32("Menu_ID");
                        }
                    }
                }
            }
            return 0;
        }
        public bool insertInventoryItem(uint quantity, string batchNum, DateTime expiryDate, string shelfLoc, uint menuID, uint managerID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("INSERT INTO `inventory_item`(`Quantity`, " +
                        "`Batch_Number`, `Expiry_date`, `Shelf_location`, `Menu_ID`, `M_Em_ID`) VALUES " +
                        "(@quantity, @batchNum, @expiryDate, @shelfLoc, @menuID, @managerID)", connection))
                    {
                        q.Parameters.AddWithValue("@quantity", quantity);
                        q.Parameters.AddWithValue("@batchNum", batchNum);
                        q.Parameters.AddWithValue("@expiryDate", expiryDate);
                        q.Parameters.AddWithValue("@shelfLoc", shelfLoc);
                        q.Parameters.AddWithValue("@menuID", menuID);
                        q.Parameters.AddWithValue("@managerID", managerID);
                        q.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateInventoryItem(uint quantity, string batchNum, DateTime expiryDate, string shelfLoc, uint menuID, uint managerID, ulong inventoryID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("UPDATE `inventory_item` SET `Quantity`=@quantity, " +
                        "`Batch_Number`=@batchNum, `Expiry_date`=@expiryDate, `Shelf_location`=@shelfLoc, " +
                        "`Menu_ID`=@menuID, `M_Em_ID`=@managerID WHERE Inventory_Item_ID = @inventoryID", connection))
                    {
                        q.Parameters.AddWithValue("@quantity", quantity);
                        q.Parameters.AddWithValue("@batchNum", batchNum);
                        q.Parameters.AddWithValue("@expiryDate", expiryDate);
                        q.Parameters.AddWithValue("@shelfLoc", shelfLoc);
                        q.Parameters.AddWithValue("@menuID", menuID);
                        q.Parameters.AddWithValue("@managerID", managerID);
                        q.Parameters.AddWithValue("@inventoryID", inventoryID);
                        q.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteInventoryItem(ulong id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("DELETE FROM `inventory_item` " +
                        "WHERE Inventory_Item_ID = @inventoryID", connection))
                    {
                        q.Parameters.AddWithValue("@inventoryID", id);
                        q.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getEmployeePageCount(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CEIL(COUNT(*)/50) FROM `employee` " +
                    "WHERE CONCAT(FName, ' ', LName) LIKE @searchName", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            return 0;
        }
        public List<Employee> getEmployeeByPage(string name, string sortBy, string sortMode, long page)
        {
            if (page == 0) page = 1;

            // Check for allowed sort 🙏🙏🙏 Don't read this just skip 🙏🙏🙏 It works trust me 🙏🙏🙏
            if (sortMode != "ASC" && sortMode != "DESC") return new List<Employee>();
            if (sortBy == "ID") sortBy = "Em_ID";
            else if (sortBy == "Name") sortBy = "CONCAT(FName, ' ', LName)";
            else if (sortBy == "Start Date") sortBy = "StartDate";
            else sortBy = "Salary";
            // Yes continue to next part, skip this ^^^^^^^^^^^^ 🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏

            List<Employee> result = new List<Employee>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT Em_ID, FName, LName, " +
                    "CASE " +
                    "WHEN EXISTS (SELECT 1 FROM cashier c WHERE c.Cs_Em_ID = Em_ID) THEN 'cashier' " +
                    "WHEN EXISTS (SELECT 1 FROM chef ch WHERE ch.Cf_Em_ID = Em_ID) THEN 'chef' " +
                    "WHEN EXISTS (SELECT 1 FROM manager m WHERE m.M_Em_ID = Em_ID) THEN 'manager' " +
                    "WHEN EXISTS (SELECT 1 FROM superadmin s WHERE s.S_Em_ID = Em_ID) THEN 'superadmin' " +
                    "ELSE 'none' END AS Role, " +
                    "Email, Phone, DOB, StartDate, Salary, Status " +
                    "FROM employee WHERE (FName LIKE @searchName OR CONCAT(FName, ' ', LName) LIKE @searchName) " +
                    $"ORDER BY {sortBy} {sortMode} LIMIT 50 OFFSET @offset;", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");
                    q.Parameters.AddWithValue("@offset", (page - 1) * 50);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Employee
                            {
                                Em_ID = reader.GetUInt32("Em_ID"),
                                FName = reader.GetString("FName"),
                                LName = reader.GetString("LName"),
                                Role = reader.GetString("Role"),
                                Email = reader.GetString("Email"),
                                Phone = reader.GetString("Phone"),
                                DOB = reader.GetDateTime("DOB"),
                                StartDate = reader.GetDateTime("StartDate"),
                                Salary = reader.GetDecimal("Salary"),
                                Status = reader.GetString("Status")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }
        public bool insertEmployee(string fname, string lname, string email, string phone, DateTime DOB, DateTime startDate, decimal salary, string status, string role)
        {
            if (role != "cashier" && role != "chef" && role != "manager") return false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        uint emID;
                        using (MySqlCommand q = new MySqlCommand("INSERT INTO `employee`(`FName`, " +
                            "`LName`, `Email`, `Phone`, `DOB`, `StartDate`, `Salary`, `Status`) VALUES " +
                            "(@fname, @lname, @email, @phone, @dob, @startDate, @salary, @status)", connection))
                        {
                            q.Parameters.AddWithValue("@fname", fname);
                            q.Parameters.AddWithValue("@lname", lname);
                            q.Parameters.AddWithValue("@email", email);
                            q.Parameters.AddWithValue("@phone", phone);
                            q.Parameters.AddWithValue("@dob", DOB);
                            q.Parameters.AddWithValue("@startDate", startDate);
                            q.Parameters.AddWithValue("@salary", salary);
                            q.Parameters.AddWithValue("@status", status);
                            q.ExecuteNonQuery();
                            emID = (uint)q.LastInsertedId;
                        }
                        using (MySqlCommand q = new MySqlCommand($"INSERT INTO `{role}` VALUES (@id)", connection))
                        {
                            q.Parameters.AddWithValue("@id", emID);
                            q.ExecuteNonQuery();
                        }
                        using (MySqlCommand q = new MySqlCommand("INSERT INTO `employee_logindata` " +
                            "VALUES (@id, @id, @user, '$2a$12$rIvDNHXnYyD.nVzUXUk/6ueXT/tO3uKr6MDPpjw3flR1tfIEYZXGu')", connection))
                        {
                            q.Parameters.AddWithValue("@id", emID);
                            q.Parameters.AddWithValue("@user", getCurrentDefaultUser());
                            q.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateEmployee(string fname, string lname, string email, string phone, DateTime DOB, DateTime startDate, decimal salary, string status, string role, uint employeeID, string oldRole)
        {
            if (role != "cashier" && role != "chef") return false;
            if (oldRole != "cashier" && oldRole != "chef") return false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (MySqlCommand q = new MySqlCommand("UPDATE `employee` SET `FName`=@fname, " +
                            "`LName`=@lname, `Email`=@email, `Phone`=@phone, `DOB`=@dob, `StartDate`=@startDate, " +
                            "`Salary`=@salary, `Status`=@status WHERE Em_ID = @emID", connection))
                        {
                            q.Parameters.AddWithValue("@fname", fname);
                            q.Parameters.AddWithValue("@lname", lname);
                            q.Parameters.AddWithValue("@email", email);
                            q.Parameters.AddWithValue("@phone", phone);
                            q.Parameters.AddWithValue("@dob", DOB);
                            q.Parameters.AddWithValue("@startDate", startDate);
                            q.Parameters.AddWithValue("@salary", salary);
                            q.Parameters.AddWithValue("@status", status);
                            q.Parameters.AddWithValue("@emID", employeeID);
                            q.ExecuteNonQuery();
                        }
                        if (oldRole == "cashier")
                        {
                            using (MySqlCommand q = new MySqlCommand("DELETE FROM `cashier` WHERE Cs_Em_ID = @csid", connection))
                            {
                                q.Parameters.AddWithValue("@csid", employeeID);
                                q.ExecuteNonQuery();
                            }
                        }
                        else if (oldRole == "chef")
                        {
                            using (MySqlCommand q = new MySqlCommand("DELETE FROM `chef` WHERE Cf_Em_ID = @cfid", connection))
                            {
                                q.Parameters.AddWithValue("@cfid", employeeID);
                                q.ExecuteNonQuery();
                            }
                        }
                        else if (oldRole == "manager")
                        {
                            using (MySqlCommand q = new MySqlCommand("DELETE FROM `manager` WHERE M_Em_ID = @mid", connection))
                            {
                                q.Parameters.AddWithValue("@mid", employeeID);
                                q.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (MySqlCommand q = new MySqlCommand("DELETE FROM `superadmin` WHERE S_Em_ID = @sfid", connection))
                            {
                                q.Parameters.AddWithValue("@sfid", employeeID);
                                q.ExecuteNonQuery();
                            }
                        }
                        using (MySqlCommand q = new MySqlCommand($"INSERT INTO `{role}` VALUES (@id)", connection))
                        {
                            q.Parameters.AddWithValue("@id", employeeID);
                            q.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteEmployee(uint id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("DELETE FROM `employee` " +
                        "WHERE Em_ID = @emID", connection))
                    {
                        q.Parameters.AddWithValue("@emID", id);
                        q.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string getCurrentDefaultUser()
        {
            string baseName = "defaultuser";
            string username = baseName;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand(
                    "SELECT Username FROM employee_logindata " +
                    "WHERE Username LIKE @pattern " +
                    "ORDER BY LENGTH(Username) DESC, Username DESC LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@pattern", baseName + "%");

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string lastUser = reader.GetString(0);
                            string tail = lastUser.Substring(baseName.Length);
                            uint num = 0;
                            uint.TryParse(tail, out num);
                            username = baseName + (num + 1);
                        }
                    }
                }
            }
            return username;
        }

        public int getEmployeeLogindataPageCount(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CEIL(COUNT(*)/50) FROM `employee_logindata` l " +
                    "Join employee e on l.Em_ID = e.Em_ID " +
                    "WHERE CONCAT(e.FName, ' ', e.LName) LIKE @searchName", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            return 0;
        }
        public List<Account> getEmployeeLogindataByPage(string name, string sortBy, string sortMode, long page)
        {
            if (page == 0) page = 1;

            // Check for allowed sort 🙏🙏🙏 Don't read this just skip 🙏🙏🙏 It works trust me 🙏🙏🙏
            if (sortMode != "ASC" && sortMode != "DESC") return new List<Account>();
            if (sortBy == "ID") sortBy = "Em_ID";
            else if (sortBy == "Name") sortBy = "CONCAT(FName, ' ', LName)";
            else sortBy = "Username";
            // Yes continue to next part, skip this ^^^^^^^^^^^^ 🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏

            List<Account> result = new List<Account>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT l.em_id AS Em_ID, e.fname AS FName, " +
                    "e.lname AS LName, l.Username AS user " +
                    "FROM employee_logindata l JOIN employee e ON l.em_id = e.em_id " +
                    "WHERE (FName LIKE @searchName OR CONCAT(FName, ' ', LName) LIKE @searchName) " +
                    $"ORDER BY {sortBy} {sortMode} LIMIT 50 OFFSET @offset;", connection))
                {
                    q.Parameters.AddWithValue("@searchName", searchFixer(name) + "%");
                    q.Parameters.AddWithValue("@offset", (page - 1) * 50);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Account
                            {
                                Em_ID = reader.GetUInt32("Em_ID"),
                                FName = reader.GetString("FName"),
                                LName = reader.GetString("LName"),
                                Username = reader.GetString("user")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }
        public bool updateAccount(string username, string password, uint employeeID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("UPDATE `employee_logindata` " +
                        "SET `Username`=@user, `Password`=@pass WHERE Em_ID = @emID", connection))
                    {
                        q.Parameters.AddWithValue("@user", username);
                        q.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword(password));
                        q.Parameters.AddWithValue("@emID", employeeID);
                        q.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool isUsernameExists(string user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT Username FROM `employee_logindata` " +
                    "WHERE `Username` = @username LIMIT 1", connection))
                {
                    q.Parameters.AddWithValue("@username", user);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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
                    "WHEN EXISTS (SELECT 1 FROM superadmin s WHERE s.S_Em_ID = Em_ID) THEN 'superadmin' " +
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

        public long getPaymentPageCount(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CEIL(COUNT(*)/50) FROM `payment` " +
                    "WHERE Order_ID LIKE @orderID", connection))
                {
                    q.Parameters.AddWithValue("@orderID", searchFixer(id) + "%");

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt64(0);
                        }
                    }
                }
            }
            return 0;
        }
        public List<Payment> getPaymentByPage(string id, string sortBy, string sortMode, long page)
        {
            if (page == 0) page = 1;

            // Check for allowed sort 🙏🙏🙏 Don't read this just skip 🙏🙏🙏 It works trust me 🙏🙏🙏
            if (sortMode != "ASC" && sortMode != "DESC") return new List<Payment>();
            if (sortBy == "ID") sortBy = "Payment_ID";
            else if (sortBy == "Timestamp") sortBy = "Timestamp";
            else if (sortBy == "Payment Type") sortBy = "Payment_Type";
            else sortBy = "Total";
            // Yes continue to next part, skip this ^^^^^^^^^^^^ 🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏

            List<Payment> result = new List<Payment>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT * FROM payment " +
                    "WHERE Order_ID LIKE @orderID " +
                    $"ORDER BY {sortBy} {sortMode} LIMIT 50 OFFSET @offset;", connection))
                {
                    q.Parameters.AddWithValue("@orderID", searchFixer(id) + "%");
                    q.Parameters.AddWithValue("@offset", (page - 1) * 50);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Payment
                            {
                                Payment_ID = reader.GetUInt64("Payment_ID"),
                                Timestamp = reader.GetDateTime("Timestamp"),
                                Payment_Type = reader.GetString("Payment_Type"),
                                Total = reader.GetDecimal("Total"),
                                Order_ID = reader.GetUInt64("Order_ID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public long getOrderItemPageCount(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT CEIL(COUNT(*)/50) FROM order_item oi " +
                    "LEFT JOIN menu_item m ON oi.menu_id = m.menu_id " +
                    "WHERE oi.Order_ID LIKE @orderID", connection))
                {
                    q.Parameters.AddWithValue("@orderID", searchFixer(id) + "%");

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt64(0);
                        }
                    }
                }
            }
            return 0;
        }
        public List<TableHandler.Order> getOrderItemByPage(string id, string sortBy, string sortMode, long page)
        {
            if (page == 0) page = 1;

            // Check for allowed sort 🙏🙏🙏 Don't read this just skip 🙏🙏🙏 It works trust me 🙏🙏🙏
            if (sortMode != "ASC" && sortMode != "DESC") return new List<TableHandler.Order>();
            if (sortBy == "ID") sortBy = "Order_ID";
            else if (sortBy == "Name") sortBy = "Name";
            else sortBy = "Quantity";
            // Yes continue to next part, skip this ^^^^^^^^^^^^ 🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏🙏

            List<TableHandler.Order> result = new List<TableHandler.Order>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT oi.Order_ID AS 'ID', " +
                    "IFNULL(m.Name, '[Removed menu]') AS 'orderName', oi.Quantity AS 'quantity', " +
                    "IFNULL(oi.Menu_ID, 0) AS 'menuID' FROM order_item oi " +
                    "LEFT JOIN menu_item m ON oi.menu_id = m.menu_id " +
                    "WHERE oi.Order_ID LIKE @orderID " +
                    $"ORDER BY {sortBy} {sortMode} LIMIT 50 OFFSET @offset", connection))
                {
                    q.Parameters.AddWithValue("@orderID", searchFixer(id) + "%");
                    q.Parameters.AddWithValue("@offset", (page - 1) * 50);

                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new TableHandler.Order
                            {
                                Order_ID = reader.GetUInt64("ID"),
                                Order_Name = reader.GetString("orderName"),
                                Quantity = reader.GetUInt32("quantity"),
                                Menu_ID = reader.GetUInt32("menuID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }
    }
}