using Project.MainPages;
using Project.QueryHandler;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.UIHandler
{
    public partial class OrderCard : UserControl
    {
        List<CardItem> currentCard = new List<CardItem>();
        CashierQueryHandler queryHandler1 = new CashierQueryHandler();
        ChefQueryHandler queryHandler2 = new ChefQueryHandler();
        OrderProgress parent;

        string role = "";
        ulong orderID;
        string orderStatus = "";

        bool onCooldown = false;

        public OrderCard(string r, List<CardItem> itemList, OrderProgress par)
        {
            InitializeComponent();
            role = r;
            parent = par;
            setup_table();
            CreateItem(itemList);
            setButtonText();
            this.Dock = DockStyle.Fill;
        }
        public void setup_table()
        {
            dataGridView1.DataSource = currentCard;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["order_id"].Visible = false;
            dataGridView1.Columns["card_id"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
            dataGridView1.Columns["item_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["quantity"].Width = 65;
            dataGridView1.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }
        public void CreateItem(List<CardItem> itemList)
        {
            if (itemList.Count == 0) return;

            orderID = itemList[0].order_id;
            orderStatus = itemList[0].status;
            orderno_label.Text = $"Order #{itemList[0].card_id.ToString("D4")} ";
            status_label.Text = char.ToUpper(orderStatus[0]) + orderStatus.Substring(1);

            foreach (CardItem item in itemList)
            {
                currentCard.Add(item);
            }
        }

        private void status_btn_Click(object sender, EventArgs e)
        {
            if (!onCooldown)
            {
                onCooldown = true;
                if (role == "cashier")
                {
                    if (parent.orderLastUpdate != queryHandler1.getOrderLastUpdateTime(parent.orderLastUpdate))
                    {
                        MessageBox.Show("Another cashier handled that order, refreshing now.");
                        parent.fetchData();
                        return;
                    }
                    if (orderStatus == "ready")
                    {
                        queryHandler1.updateOrderStatus(orderID, "completed");
                        parent.fetchData(true);
                        setButtonText();
                    }
                }
                else if (role == "chef")
                {
                    if (parent.orderLastUpdate != queryHandler2.getOrderLastUpdateTime(parent.orderLastUpdate))
                    {
                        MessageBox.Show("Another chef handled that order, refreshing now.");
                        parent.fetchData();
                        return;
                    }
                    if (orderStatus == "received")
                    {
                        queryHandler2.updateOrderStatus(orderID, "preparing");
                        parent.fetchData(true);
                        setButtonText();
                    }
                    else if (orderStatus == "preparing")
                    {
                        queryHandler2.updateOrderStatus(orderID, "ready");
                        parent.fetchData(true);
                        setButtonText();
                    }
                }
            }
        }

        public void setButtonText()
        {
            if (role == "cashier")
            {
                if (orderStatus == "received")
                {
                    status_btn.Text = "...";
                }
                else if (orderStatus == "preparing")
                {
                    status_btn.Text = "...";
                }
                else if (orderStatus == "ready")
                {
                    status_btn.Text = "Complete";
                }
            }
            else if (role == "chef")
            {
                if (orderStatus == "received")
                {
                    status_btn.Text = "Prepare";
                }
                else if (orderStatus == "preparing")
                {
                    status_btn.Text = "Ready";
                }
                else if (orderStatus == "ready")
                {
                    status_btn.Text = "...";
                }
            }
        }
    }
}
