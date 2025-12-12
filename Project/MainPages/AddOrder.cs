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
    public partial class AddOrder : Form
    {
        CashierQueryHandler queryHandler = new CashierQueryHandler();
        AddOrderUI1? addOrderUI;
        MenuTabHandler? menuTabHandler;

        Login parentForm;
        OrderProgress parentForm2;

        private readonly string cashierName = "";
        private readonly uint cashierID;

        // prevent stack overflow 🙏🙏🙏
        bool isClosed = false;

        public AddOrder(Login parent, string name, uint id)
        {
            InitializeComponent();
            parentForm = parent;
            cashierName = name;
            cashierID = id;

            parentForm2 = new OrderProgress(parentForm, this, queryHandler);
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            if (cashierName == "")
            {
                Hello_label.Text = "Hello, employee!\nWelcome to your cashier page!";
            }
            else
            {

                Hello_label.Text = $"Hello, {cashierName}!\nWelcome to your cashier page!";
            }

            addOrderUI = new AddOrderUI1(dataGridView1, Price_label);
            menuTabHandler = new MenuTabHandler(tabControl1, addOrderUI);
            addOrderUI.setUpTable();

            try
            {
                List<Category> allCategory = queryHandler.getAllCategory();
                List<Menu_item> allMenuItem = queryHandler.getAllMenuItem();

                menuTabHandler.setupTabControl(allCategory, allMenuItem);
            }
            catch
            {
                MessageBox.Show("Unable to load menu. Connection disrupted.");
                this.Close();
            }
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            BindingList<OrderItem> orderList = addOrderUI!.getOrder();
            decimal totalPrice = addOrderUI.getTotal();
            if (orderList == null || orderList.Count == 0)
            {
                MessageBox.Show("Order is empty, please input something before creating order.");
                return;
            }
            if (!queryHandler.isInventoryEnoughList(orderList))
            {
                MessageBox.Show("Stock not enough, please add more inventory.");
                return;
            }

            string choice = PaymentPopup.Show();
            if (choice == "Cancel") return;

            if (!queryHandler.createOrder(orderList, cashierID, choice, totalPrice))
            {
                MessageBox.Show("Unable to create new order. Connection disrupted.");
                return;
            }
            queryHandler.deductInventoryList(orderList);
            addOrderUI!.clearOrder();
            MessageBox.Show("Successfully created new order");
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            addOrderUI!.clearOrder();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            addOrderUI!.quantityChanged(e);
        }
        private void progress_btn_Click(object sender, EventArgs e)
        {
            parentForm2.enableTimer(true);
            parentForm2.fetchData();
            parentForm2.updateButtonClickability();
            this.Hide();

            parentForm2.StartPosition = FormStartPosition.Manual;
            parentForm2.Location = this.Location;
            parentForm2.Size = this.Size;
            parentForm2.WindowState = this.WindowState;
            parentForm2.Show();
        }

        private void AddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosed && e.CloseReason == CloseReason.UserClosing)
            {
                isClosed = true;

                parentForm2.Close();
                parentForm.Show();
            }
        }
    }
}
