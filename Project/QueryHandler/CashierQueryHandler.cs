using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Project.QueryHandler
{
    public class CashierQueryHandler
    {
        private readonly string connectionString = "datasource=localhost;port=3306;username=cashier;password=cashier;" +
           "database=restaurantmanagement;";

        public CashierQueryHandler()
        {

        }

        public List<Category> getAllCategory()
        {
            List<Category> result = new List<Category>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT * FROM `category`", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Category
                            {
                                Category_id = reader.GetUInt32("Category_ID"),
                                Name = reader.GetString("Name")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public List<Menu_item> getAllMenuItem()
        {
            List<Menu_item> result = new List<Menu_item>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT * FROM `menu_item`", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Menu_item
                            {
                                Menu_id = reader.GetUInt32("Menu_ID"),
                                Name = reader.GetString("Name"),
                                Price = reader.GetDecimal("Price"),
                                Path = reader["Path"] == DBNull.Value ? null : reader.GetString("Path"),
                                Category_ID = reader.GetUInt32("Category_ID")
                            };
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public bool createOrder(BindingList<OrderItem> itemList, uint id, string choice, decimal totalPrice)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        uint orderId;
                        using (MySqlCommand q = new MySqlCommand("INSERT INTO `order` (`Timestamp`, `Status`, `Cs_Em_ID`) " +
                            "VALUES (NOW(), 'received', @id)", connection, transaction))
                        {
                            q.Parameters.AddWithValue("@id", id);
                            q.ExecuteNonQuery();
                            orderId = (uint)q.LastInsertedId;
                        }
                        for (int i = 0; i < itemList.Count; i++)
                        {
                            using (MySqlCommand q = new MySqlCommand($"INSERT INTO `order_item` (`Order_ID`, `Order_Item_ID`, `Quantity`, `Menu_ID`) " +
                                $"VALUES (@orderID, @orderItemID, @quantity, @menuID)", connection, transaction))
                            {
                                q.Parameters.AddWithValue("@orderID", orderId);
                                q.Parameters.AddWithValue("@orderItemID", i + 1);
                                q.Parameters.AddWithValue("@quantity", itemList[i].Quantity);
                                q.Parameters.AddWithValue("@menuID", itemList[i].MenuItemID);
                                q.ExecuteNonQuery();
                            }
                        }
                        using (MySqlCommand q = new MySqlCommand($"INSERT INTO `payment` (`Timestamp`, `Payment_Type`, `Total`, `Order_ID`) " +
                            $"VALUES (NOW(), @paymentType, @total, @orderID)", connection, transaction))
                        {
                            q.Parameters.AddWithValue("@paymentType", choice.ToLower());
                            q.Parameters.AddWithValue("@total", totalPrice);
                            q.Parameters.AddWithValue("@orderID", orderId);
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

        public bool isInventoryEnough(OrderItem item)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("check_inventory_item", connection))
                    {
                        q.CommandType = System.Data.CommandType.StoredProcedure;
                        q.Parameters.AddWithValue("p_menu_id", item.MenuItemID);
                        q.Parameters.AddWithValue("p_quantity", item.Quantity);

                        var output = new MySqlParameter("p_is_sufficient", MySqlDbType.Bit);
                        output.Direction = System.Data.ParameterDirection.Output;
                        q.Parameters.Add(output);

                        q.ExecuteNonQuery();
                        return Convert.ToBoolean(output.Value);
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public bool isInventoryEnoughList(BindingList<OrderItem> itemList)
        {
            foreach (OrderItem item in itemList)
            {
                if (!isInventoryEnough(item)) return false;
            }
            return true;
        }
        public void deductInventory(OrderItem item)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("deduct_inventory_item", connection))
                    {
                        q.CommandType = System.Data.CommandType.StoredProcedure;
                        q.Parameters.AddWithValue("p_menu_id", item.MenuItemID);
                        q.Parameters.AddWithValue("p_quantity", item.Quantity);

                        q.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
        public void deductInventoryList(BindingList<OrderItem> itemList)
        {
            foreach (OrderItem item in itemList)
            {
                deductInventory(item);
            }
        }

        public List<List<CardItem>> getAllUnfinishedOrder()
        {
            List<List<CardItem>> result = new List<List<CardItem>>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand q = new MySqlCommand("SELECT " +
                    "`order`.Order_ID as orderID, " +
                    "menu_item.Name as itemName, " +
                    "order_item.Quantity as itemQuantity, " +
                    "`order`.Status as orderStatus " +
                    "FROM `order` " +
                    "JOIN order_item ON `order`.Order_ID = order_item.Order_ID " +
                    "JOIN menu_item ON order_item.Menu_ID = menu_item.Menu_ID " +
                    "WHERE DATE(`order`.Timestamp) = CURDATE() " +
                    "ORDER BY `order`.Order_ID, order_item.Order_Item_ID;", connection))
                {
                    using (MySqlDataReader reader = q.ExecuteReader())
                    {
                        List<CardItem> itemList = new List<CardItem>();
                        ulong? order = null;
                        ulong cardCount = 0;
                        while (reader.Read())
                        {
                            if (order == null || order != reader.GetUInt64("orderID"))
                            {
                                if (itemList.Count > 0)
                                    result.Add(itemList);
                                cardCount++;
                                itemList = new List<CardItem>();
                                order = reader.GetUInt64("orderID");
                            }
                            if (reader.GetString("orderStatus") == "completed") continue;
                            CardItem item = new CardItem
                            {
                                order_id = reader.GetUInt64("orderID"),
                                card_id = cardCount,
                                item_name = reader.GetString("itemName"),
                                quantity = reader.GetUInt32("itemQuantity"),
                                status = reader.GetString("orderStatus")
                            };
                            itemList.Add(item);

                        }
                        if (itemList.Count > 0)
                            result.Add(itemList);
                        return result;
                    }
                }
            }
        }

        public bool updateOrderStatus(ulong id, string status)
        {
            if (string.IsNullOrEmpty(status)) return false;
            if (status != "completed") return false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand q = new MySqlCommand("UPDATE `order` SET Status = @status " +
                        "WHERE Order_ID = @orderID", connection))
                    {
                        q.Parameters.AddWithValue("@status", status);
                        q.Parameters.AddWithValue("@orderID", id);
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
    }
}
