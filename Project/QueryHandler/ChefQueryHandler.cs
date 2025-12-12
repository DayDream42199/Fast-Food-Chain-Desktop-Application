using MySql.Data.MySqlClient;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QueryHandler
{
    public class ChefQueryHandler
    {
        private readonly string connectionString = "datasource=localhost;port=3306;username=chef;password=chef;" +
           "database=restaurantmanagement;";

        public ChefQueryHandler()
        {

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
            if (status != "preparing" && status != "ready") return false;
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
