using Project.QueryHandler;
using Project.TableHandler;
using Project.UIHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.MainPages
{
    public partial class OrderProgress : Form
    {
        CashierQueryHandler? queryHandler1;
        ChefQueryHandler? queryHandler2;

        List<List<CardItem>> allOrder = new List<List<CardItem>>();
        int currentAllOrderPage = 1;
        Login parentForm;
        AddOrder? parentForm2 = null;
        string role;
        public DateTime orderLastUpdate = DateTime.MinValue;
        public DateTime menuItemLastUpdate = DateTime.MinValue;

        bool fetchErrorMessageOnCooldown = false;

        // prevent stack overflow 🙏🙏🙏
        bool isClosed = false;

        public OrderProgress(Login parent)
        {
            InitializeComponent();
            parentForm = parent;
            parentForm2 = null;
            role = "chef";
            queryHandler2 = new ChefQueryHandler();
        }

        public OrderProgress(Login parent, AddOrder parent2, CashierQueryHandler cqh)
        {
            InitializeComponent();
            parentForm = parent;
            parentForm2 = parent2;
            role = "cashier";
            queryHandler1 = cqh;
        }

        private void OrderProgress_Load(object sender, EventArgs e)
        {
            if (role == "chef") Order_btn.Hide();
        }

        private void Order_btn_Click(object sender, EventArgs e)
        {
            enableTimer(false);
            this.Hide();

            parentForm2!.StartPosition = FormStartPosition.Manual;
            parentForm2!.Location = this.Location;
            parentForm2!.Size = this.Size;
            parentForm2!.WindowState = this.WindowState;
            parentForm2!.Show();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosed && e.CloseReason == CloseReason.UserClosing)
            {
                isClosed = true;

                enableTimer(false);

                if (parentForm2 != null) parentForm2.Close();
                parentForm.Show();
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            currentAllOrderPage += 1;
            updateButtonClickability();
            changePage();
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            currentAllOrderPage -= 1;
            updateButtonClickability();
            changePage();
        }

        public void fetchData(bool isManual = false)
        {
            try
            {
                if (role == "cashier")
                {
                    if (orderLastUpdate == queryHandler1.getOrderLastUpdateTime(orderLastUpdate) &&
                        menuItemLastUpdate == queryHandler1.getMenuItemLastUpdateTime(menuItemLastUpdate) &&
                        !isManual) return;
                    allOrder = queryHandler1.getAllUnfinishedOrder();
                    fetchErrorMessageOnCooldown = false;
                    orderLastUpdate = queryHandler1.getOrderLastUpdateTime(orderLastUpdate);
                    menuItemLastUpdate = queryHandler1.getMenuItemLastUpdateTime(menuItemLastUpdate);
                }
                else if (role == "chef")
                {
                    if (orderLastUpdate == queryHandler2.getOrderLastUpdateTime(orderLastUpdate) &&
                        menuItemLastUpdate == queryHandler2.getMenuItemLastUpdateTime(menuItemLastUpdate) &&
                        !isManual) return;
                    allOrder = queryHandler2.getAllUnfinishedOrder();
                    fetchErrorMessageOnCooldown = false;
                    orderLastUpdate = queryHandler2.getOrderLastUpdateTime(orderLastUpdate);
                    menuItemLastUpdate = queryHandler2.getMenuItemLastUpdateTime(menuItemLastUpdate);
                }
                changePage();
            }
            catch
            {
                allOrder = new List<List<CardItem>>();
                orderLastUpdate = DateTime.MinValue;
                menuItemLastUpdate = DateTime.MinValue;
                if (!fetchErrorMessageOnCooldown)
                {
                    MessageBox.Show("Unable to fetch order. Connection disrupted.");
                    fetchErrorMessageOnCooldown = true;
                }
                changePage();
            }
        }

        private void changePage()
        {
            if (currentAllOrderPage > Math.Ceiling((double)allOrder.Count / 3))
            {
                currentAllOrderPage = (int)Math.Ceiling((double)allOrder.Count / 3);
            }
            if (currentAllOrderPage == 0)
            {
                currentAllOrderPage = 1;
                page_label.Text = $"0/{Math.Ceiling((double)allOrder.Count / 3)}";
            }
            else
            {
                page_label.Text = $"{currentAllOrderPage}/{Math.Ceiling((double)allOrder.Count / 3)}";
            }
            tableLayoutPanel2.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (i + currentAllOrderPage * 3 - 3 >= allOrder.Count) break;

                OrderCard card = new OrderCard(role, allOrder[i + currentAllOrderPage * 3 - 3], this);
                tableLayoutPanel2.Controls.Add(card, i, 0);
            }
        }

        public void updateButtonClickability()
        {
            if (currentAllOrderPage < 2) prev_btn.Enabled = false;
            else prev_btn.Enabled = true;

            if ((currentAllOrderPage + 1) * 3 - 3 >= allOrder.Count) next_btn.Enabled = false;
            else next_btn.Enabled = true;
        }

        public void enableTimer(bool enable)
        {
            if (enable) timer1.Start();
            else timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fetchData();
        }
    }
}
