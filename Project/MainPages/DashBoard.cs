using Mysqlx.Crud;
using Project.QueryHandler;
using Project.TableHandler;
using Project.UIHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.MainPages
{
    public partial class DashBoard : Form
    {
        ManagerQueryHandler? queryHandler;
        SuperAdminQueryHandler? adminQueryHandler;

        Login parentForm;

        public InventoryUI? lowStockUI;
        public InventoryUI? nearExpireUI;
        List<Inventory> lowStock = new List<Inventory>();
        List<Inventory> nearExpire = new List<Inventory>();

        private readonly uint managerID;

        public DateTime orderLastUpdate = DateTime.MinValue;
        public DateTime inventoryItemLastUpdate = DateTime.MinValue;
        bool fetchErrorMessageOnCooldown = false;

        public DashBoard(Login parent, uint id, bool isSuperAdmin = false)
        {
            InitializeComponent();
            if (!isSuperAdmin)
            {
                queryHandler = new ManagerQueryHandler();
            }
            else
            {
                adminQueryHandler = new SuperAdminQueryHandler();
            }
            parentForm = parent;
            managerID = id;
            lowStockUI = new InventoryUI(dataGridView1);
            lowStockUI.setuptableLowStock();
            nearExpireUI = new InventoryUI(dataGridView2);
            nearExpireUI.setuptableNearExpire();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            fetchData();

            enableTimer(true);
        }

        private void Inventory_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                InventoryPage inventoryPage = new InventoryPage(this, parentForm, queryHandler, managerID);
                enableTimer(false);
                this.Hide();

                inventoryPage.StartPosition = FormStartPosition.Manual;
                inventoryPage.Location = this.Location;
                inventoryPage.Size = this.Size;
                inventoryPage.WindowState = this.WindowState;
                inventoryPage.Show();
            }
            else
            {
                InventoryPage inventoryPage = new InventoryPage(this, parentForm, adminQueryHandler, managerID);
                enableTimer(false);
                this.Hide();

                inventoryPage.StartPosition = FormStartPosition.Manual;
                inventoryPage.Location = this.Location;
                inventoryPage.Size = this.Size;
                inventoryPage.WindowState = this.WindowState;
                inventoryPage.Show();
            }
        }

        private void Employee_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                EmployeePage employeePage = new EmployeePage(this, parentForm, queryHandler);
                enableTimer(false);
                this.Hide();

                employeePage.StartPosition = FormStartPosition.Manual;
                employeePage.Location = this.Location;
                employeePage.Size = this.Size;
                employeePage.WindowState = this.WindowState;
                employeePage.Show();
            }
            else
            {
                EmployeePage employeePage = new EmployeePage(this, parentForm, adminQueryHandler);
                enableTimer(false);
                this.Hide();

                employeePage.StartPosition = FormStartPosition.Manual;
                employeePage.Location = this.Location;
                employeePage.Size = this.Size;
                employeePage.WindowState = this.WindowState;
                employeePage.Show();
            }
        }

        private void Account_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                AccountPage accountPage = new AccountPage(this, parentForm, queryHandler);
                enableTimer(false);
                this.Hide();

                accountPage.StartPosition = FormStartPosition.Manual;
                accountPage.Location = this.Location;
                accountPage.Size = this.Size;
                accountPage.WindowState = this.WindowState;
                accountPage.Show();
            }
            else
            {
                AccountPage accountPage = new AccountPage(this, parentForm, adminQueryHandler);
                enableTimer(false);
                this.Hide();

                accountPage.StartPosition = FormStartPosition.Manual;
                accountPage.Location = this.Location;
                accountPage.Size = this.Size;
                accountPage.WindowState = this.WindowState;
                accountPage.Show();
            }
        }

        private void Payment_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                PaymentPage paymentPage = new PaymentPage(this, parentForm, queryHandler);
                enableTimer(false);
                this.Hide();

                paymentPage.StartPosition = FormStartPosition.Manual;
                paymentPage.Location = this.Location;
                paymentPage.Size = this.Size;
                paymentPage.WindowState = this.WindowState;
                paymentPage.Show();
            }
            else
            {
                PaymentPage paymentPage = new PaymentPage(this, parentForm, adminQueryHandler);
                enableTimer(false);
                this.Hide();

                paymentPage.StartPosition = FormStartPosition.Manual;
                paymentPage.Location = this.Location;
                paymentPage.Size = this.Size;
                paymentPage.WindowState = this.WindowState;
                paymentPage.Show();
            }
        }

        private void Order_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                OrderPage orderPage = new OrderPage(this, parentForm, queryHandler);
                enableTimer(false);
                this.Hide();

                orderPage.StartPosition = FormStartPosition.Manual;
                orderPage.Location = this.Location;
                orderPage.Size = this.Size;
                orderPage.WindowState = this.WindowState;
                orderPage.Show();
            }
            else
            {
                OrderPage orderPage = new OrderPage(this, parentForm, adminQueryHandler);
                enableTimer(false);
                this.Hide();

                orderPage.StartPosition = FormStartPosition.Manual;
                orderPage.Location = this.Location;
                orderPage.Size = this.Size;
                orderPage.WindowState = this.WindowState;
                orderPage.Show();
            }
        }

        private void DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            enableTimer(false);

            parentForm.Show();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fetchData();
        }

        public void fetchData()
        {
            try
            {
                if (queryHandler != null)
                {
                    if (orderLastUpdate == queryHandler.getOrderLastUpdateTime(orderLastUpdate) &&
                        inventoryItemLastUpdate == queryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate)) return;
                    lowStock = queryHandler.getLowStock();
                    nearExpire = queryHandler.getNearExpire();

                    lowStockUI.clearData();
                    lowStockUI.addDataFromList(lowStock);

                    nearExpireUI.clearData();
                    nearExpireUI.addDataFromList(nearExpire);

                    totalorder_label.Text = queryHandler.getTodayOrderCount().ToString();
                    revenue_label.Text = $"${queryHandler.getTodayRevenue().ToString()}";

                    fetchErrorMessageOnCooldown = false;
                    orderLastUpdate = queryHandler.getOrderLastUpdateTime(orderLastUpdate);
                    inventoryItemLastUpdate = queryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate);
                }
                else
                {
                    if (orderLastUpdate == adminQueryHandler.getOrderLastUpdateTime(orderLastUpdate) &&
                        inventoryItemLastUpdate == adminQueryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate)) return;
                    lowStock = adminQueryHandler.getLowStock();
                    nearExpire = adminQueryHandler.getNearExpire();

                    lowStockUI.clearData();
                    lowStockUI.addDataFromList(lowStock);

                    nearExpireUI.clearData();
                    nearExpireUI.addDataFromList(nearExpire);

                    totalorder_label.Text = adminQueryHandler.getTodayOrderCount().ToString();
                    revenue_label.Text = $"${adminQueryHandler.getTodayRevenue().ToString()}";

                    fetchErrorMessageOnCooldown = false;
                    orderLastUpdate = adminQueryHandler.getOrderLastUpdateTime(orderLastUpdate);
                    inventoryItemLastUpdate = adminQueryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate);
                }
            }
            catch
            {
                lowStockUI.clearData();
                nearExpireUI.clearData();
                orderLastUpdate = DateTime.MinValue;
                inventoryItemLastUpdate = DateTime.MinValue;

                totalorder_label.Text = "0";
                revenue_label.Text = "$0";

                if (!fetchErrorMessageOnCooldown)
                {
                    MessageBox.Show("Unable to fetch inventory. Connection disrupted.");
                    fetchErrorMessageOnCooldown = true;
                }
            }
        }

        public void enableTimer(bool enable)
        {
            if (enable) timer1.Start();
            else timer1.Stop();
        }
    }
}
