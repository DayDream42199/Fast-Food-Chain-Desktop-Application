using Project.QueryHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.MainPages.Edit
{
    public partial class EditInventory : Form
    {
        ManagerQueryHandler? queryHandler;
        SuperAdminQueryHandler? adminQueryHandler;
        uint managerID;
        ulong inventoryID;
        bool isUpdate = false;

        InventoryPage parent;

        public EditInventory(InventoryPage parentForm, ManagerQueryHandler queryH, uint id)
        {
            InitializeComponent();
            queryHandler = queryH;
            managerID = id;
            parent = parentForm;
        }

        public EditInventory(InventoryPage parentForm, SuperAdminQueryHandler queryH, uint id)
        {
            InitializeComponent();
            adminQueryHandler = queryH;
            managerID = id;
            parent = parentForm;
        }

        public EditInventory(InventoryPage parentForm, ManagerQueryHandler queryH, uint id, ulong invenID)
        {
            InitializeComponent();
            queryHandler = queryH;
            managerID = id;
            parent = parentForm;
            inventoryID = invenID;
            isUpdate = true;
        }

        public EditInventory(InventoryPage parentForm, SuperAdminQueryHandler queryH, uint id, ulong invenID)
        {
            InitializeComponent();
            adminQueryHandler = queryH;
            managerID = id;
            parent = parentForm;
            inventoryID = invenID;
            isUpdate = true;
        }

        public void prefillData(string menuName, string quantity, string batchNo, DateTime expiredDate, string shelfLoc)
        {
            name_txtbox.Text = menuName;
            amount_txtbox.Text = quantity;
            batch_txtbox.Text = batchNo;
            dateTimePicker1.Value = expiredDate;
            shelf_txtbox.Text = shelfLoc;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                if (!queryHandler.isMenuExists(name_txtbox.Text))
                {
                    MessageBox.Show("Menu does not exists.");
                    return;
                }
                if (!uint.TryParse(amount_txtbox.Text, out uint amount))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }
                if (batch_txtbox.Text.Length <= 0 || shelf_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                uint menuID = queryHandler.getMenuIDFromName(name_txtbox.Text);
                if (!isUpdate)
                {
                    queryHandler.insertInventoryItem(amount, batch_txtbox.Text, dateTimePicker1.Value, shelf_txtbox.Text, menuID, managerID);
                }
                else
                {
                    queryHandler.updateInventoryItem(amount, batch_txtbox.Text, dateTimePicker1.Value, shelf_txtbox.Text, menuID, managerID, inventoryID);
                }
            }
            else
            {
                if (!adminQueryHandler.isMenuExists(name_txtbox.Text))
                {
                    MessageBox.Show("Menu does not exists.");
                    return;
                }
                if (!uint.TryParse(amount_txtbox.Text, out uint amount))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }
                if (batch_txtbox.Text.Length <= 0 || shelf_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                uint menuID = adminQueryHandler.getMenuIDFromName(name_txtbox.Text);
                if (!isUpdate)
                {
                    adminQueryHandler.insertInventoryItem(amount, batch_txtbox.Text, dateTimePicker1.Value, shelf_txtbox.Text, menuID);
                }
                else
                {
                    adminQueryHandler.updateInventoryItem(amount, batch_txtbox.Text, dateTimePicker1.Value, shelf_txtbox.Text, menuID, inventoryID);
                }
            }

            parent.fetchData();
            this.Close();
        }

        private void EditInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
