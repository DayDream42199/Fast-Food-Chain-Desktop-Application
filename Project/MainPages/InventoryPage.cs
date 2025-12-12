using Project.MainPages.Edit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.MainPages
{
    public partial class InventoryPage : Form
    {
        Login parentForm1;
        DashBoard parentForm2;

        public ManagerQueryHandler? queryHandler;
        public SuperAdminQueryHandler? adminQueryHandler;
        public InventoryUI mainTable;
        List<Inventory> fetchedInventoryItem = new List<Inventory>();
        long currentPage = 1;
        long maxPage = 1;
        bool fetchErrorMessageOnCooldown = false;
        uint managerID;

        public DateTime menuItemLastUpdate = DateTime.MinValue;
        public DateTime inventoryItemLastUpdate = DateTime.MinValue;

        private bool closeParent = true;

        public InventoryPage(DashBoard parent2, Login parent1, ManagerQueryHandler query, uint mID)
        {
            InitializeComponent();
            queryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            managerID = mID;
            mainTable = new InventoryUI(this.dataGridView1);
            mainTable.setupMainTable();
        }

        public InventoryPage(DashBoard parent2, Login parent1, SuperAdminQueryHandler query, uint mID)
        {
            InitializeComponent();
            adminQueryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            managerID = mID;
            mainTable = new InventoryUI(this.dataGridView1);
            mainTable.setupMainTable();
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            sort_combo.SelectedIndex = 0;
            direction_combo.SelectedIndex = 0;

            fetchData();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                EditInventory editInventoryPage = new EditInventory(this, queryHandler, managerID);
                this.Hide();

                editInventoryPage.StartPosition = FormStartPosition.Manual;
                editInventoryPage.Location = this.Location;
                editInventoryPage.Size = this.Size;
                editInventoryPage.WindowState = this.WindowState;
                editInventoryPage.Show();
            }
            else
            {
                EditInventory editInventoryPage = new EditInventory(this, adminQueryHandler, managerID);
                this.Hide();

                editInventoryPage.StartPosition = FormStartPosition.Manual;
                editInventoryPage.Location = this.Location;
                editInventoryPage.Size = this.Size;
                editInventoryPage.WindowState = this.WindowState;
                editInventoryPage.Show();
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                ulong rowIndex = Convert.ToUInt64(selectedRow.Cells["Inventory_ID"].Value);
                // get current data? Its bad Ik but this is the only way 🗿🗿🗿
                string menuName = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["Quantity"].Value?.ToString() ?? "0";
                string batchNo = selectedRow.Cells["Batch_Number"].Value?.ToString() ?? "";
                DateTime expiredDate = Convert.ToDateTime(selectedRow.Cells["Expiry_date"].Value);
                string shelfLoc = selectedRow.Cells["Shelf_location"].Value?.ToString() ?? "";
                // ZZZ
                if (queryHandler != null)
                {
                    EditInventory editInventoryPage = new EditInventory(this, queryHandler, managerID, rowIndex);
                    editInventoryPage.prefillData(menuName, quantity, batchNo, expiredDate, shelfLoc);
                    this.Hide();

                    editInventoryPage.StartPosition = FormStartPosition.Manual;
                    editInventoryPage.Location = this.Location;
                    editInventoryPage.Size = this.Size;
                    editInventoryPage.WindowState = this.WindowState;
                    editInventoryPage.Show();
                    return;
                }
                else
                {
                    EditInventory editInventoryPage = new EditInventory(this, adminQueryHandler, managerID, rowIndex);
                    editInventoryPage.prefillData(menuName, quantity, batchNo, expiredDate, shelfLoc);
                    this.Hide();

                    editInventoryPage.StartPosition = FormStartPosition.Manual;
                    editInventoryPage.Location = this.Location;
                    editInventoryPage.Size = this.Size;
                    editInventoryPage.WindowState = this.WindowState;
                    editInventoryPage.Show();
                    return;
                }
            }
            MessageBox.Show("Select a row to perform action");
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                if (queryHandler != null)
                {
                    ulong rowIndex = Convert.ToUInt64(selectedRow.Cells["Inventory_ID"].Value);
                    try
                    {
                        if (!queryHandler.deleteInventoryItem(rowIndex)) MessageBox.Show("Unable to delete data");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to delete data");
                    }
                    fetchData();
                    return;
                }
                else
                {
                    ulong rowIndex = Convert.ToUInt64(selectedRow.Cells["Inventory_ID"].Value);
                    try
                    {
                        if (!adminQueryHandler.deleteInventoryItem(rowIndex)) MessageBox.Show("Unable to delete data");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to delete data");
                    }
                    fetchData();
                    return;
                }
            }
            MessageBox.Show("Select a row to perform action");
        }

        public void fetchData(bool isManual = true)
        {
            try
            {
                if (queryHandler != null)
                {
                    if (menuItemLastUpdate == queryHandler.getMenuItemLastUpdateTime(menuItemLastUpdate) &&
                        inventoryItemLastUpdate == queryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate) &&
                        !isManual) return;
                    maxPage = queryHandler.getInventoryItemPageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedInventoryItem = queryHandler.getInventoryItemByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedInventoryItem);

                    fetchErrorMessageOnCooldown = false;
                    menuItemLastUpdate = queryHandler.getMenuItemLastUpdateTime(menuItemLastUpdate);
                    inventoryItemLastUpdate = queryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate);
                }
                else
                {
                    if (menuItemLastUpdate == adminQueryHandler.getMenuItemLastUpdateTime(menuItemLastUpdate) &&
                        inventoryItemLastUpdate == adminQueryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate) &&
                        !isManual) return;
                    maxPage = adminQueryHandler.getInventoryItemPageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedInventoryItem = adminQueryHandler.getInventoryItemByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedInventoryItem);

                    fetchErrorMessageOnCooldown = false;
                    menuItemLastUpdate = adminQueryHandler.getMenuItemLastUpdateTime(menuItemLastUpdate);
                    inventoryItemLastUpdate = adminQueryHandler.getInventoryItemLastUpdateTime(inventoryItemLastUpdate);
                }
            }
            catch
            {
                mainTable.clearData();
                menuItemLastUpdate = DateTime.MinValue;
                inventoryItemLastUpdate = DateTime.MinValue;

                if (!fetchErrorMessageOnCooldown)
                {
                    MessageBox.Show("Unable to fetch inventory. Connection disrupted.");
                    fetchErrorMessageOnCooldown = true;
                }
            }
        }

        private void updateButtonClickability()
        {
            if (currentPage < 2) prev_btn.Enabled = false;
            else prev_btn.Enabled = true;

            if (currentPage >= maxPage) next_btn.Enabled = false;
            else next_btn.Enabled = true;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            fetchData();
        }

        private void page_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(page_number.Text) || !page_number.Text.All(char.IsDigit))
                {
                    page_number.Text = "1";
                }
                currentPage = long.Parse(page_number.Text);
                page_number.Text = currentPage.ToString();
                page_number.SelectionStart = page_number.Text.Length;
                page_number.SelectionLength = 0;
                fetchData();
            }
        }

        private void search_txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fetchData();
            }
        }

        private void sort_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchData();
        }

        private void direction_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchData();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            updateButtonClickability();
            fetchData();
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            currentPage -= 1;
            updateButtonClickability();
            fetchData();
        }

        private void InventoryPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeParent)
            {
                parentForm2.Close();
                parentForm1.Show();
            }
            else
            {
                parentForm2.Show();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            closeParent = false;
            parentForm2.fetchData();
            parentForm2.enableTimer(true);
            this.Close();
        }
    }
}
