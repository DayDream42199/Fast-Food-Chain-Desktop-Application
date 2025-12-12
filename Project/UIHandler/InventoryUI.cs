using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.UIHandler
{
    public class InventoryUI
    {
        DataGridView dataGridView1;
        public BindingList<Inventory> currentInventory = new BindingList<Inventory>();

        public InventoryUI(DataGridView grid_from_form)
        {
            this.dataGridView1 = grid_from_form;
            this.dataGridView1.DataSource = currentInventory;
        }
        public void setuptableLowStock()
        {
            //tab1
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Inventory_ID"].Visible = false;
            dataGridView1.Columns["Menu_ID"].Visible = false;
            dataGridView1.Columns["Batch_Number"].Visible = false;
            dataGridView1.Columns["Expiry_date"].Visible = false;
            dataGridView1.Columns["Shelf_location"].Visible = false;
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Type"].Width = 150;
            dataGridView1.Columns["Quantity"].Width = 70;
            dataGridView1.Columns["Shelf_location"].Width = 135;
            dataGridView1.Columns["Quantity"].HeaderText = "Amt.";
            dataGridView1.Columns["Shelf_location"].HeaderText = "Shelf No.";
            dataGridView1.Columns["Name"].HeaderText = "Name";
            dataGridView1.Columns["Type"].HeaderText = "Type";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Shelf_location"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Type"].DisplayIndex = 2;
            dataGridView1.Columns["Quantity"].DisplayIndex = 3;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6347");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }
        public void setuptableNearExpire()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Inventory_ID"].Visible = false;
            dataGridView1.Columns["Menu_ID"].Visible = false;
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Shelf_location"].Width = 135;
            dataGridView1.Columns["quantity"].Width = 70;
            dataGridView1.Columns["Batch_Number"].Width = 145;
            dataGridView1.Columns["Expiry_date"].Width = 165;
            dataGridView1.Columns["Type"].Width = 150;
            dataGridView1.Columns["Expiry_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Batch_Number"].HeaderText = "Batch No.";
            dataGridView1.Columns["Expiry_date"].HeaderText = "Expire Date";
            dataGridView1.Columns["Shelf_location"].HeaderText = "Shelf No.";
            dataGridView1.Columns["quantity"].HeaderText = "Amt.";
            dataGridView1.Columns["Name"].HeaderText = "Name";
            dataGridView1.Columns["Type"].HeaderText = "Type";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Shelf_location"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["quantity"].DisplayIndex = 2;
            dataGridView1.Columns["Type"].DisplayIndex = 3;
            dataGridView1.Columns["Batch_Number"].DisplayIndex = 4;
            dataGridView1.Columns["Expiry_date"].DisplayIndex = 5;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6347");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }
        public void setupMainTable()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Menu_ID"].Visible = false;
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Shelf_location"].Width = 135;
            dataGridView1.Columns["Batch_Number"].Width = 145;
            dataGridView1.Columns["Expiry_date"].Width = 165;
            dataGridView1.Columns["Type"].Width = 150;
            dataGridView1.Columns["Quantity"].Width = 70;
            dataGridView1.Columns["Inventory_ID"].Width = 65;
            dataGridView1.Columns["Expiry_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Batch_Number"].HeaderText = "Batch No.";
            dataGridView1.Columns["Expiry_date"].HeaderText = "Expire Date";
            dataGridView1.Columns["Quantity"].HeaderText = "Amt.";
            dataGridView1.Columns["Shelf_location"].HeaderText = "Shelf No.";
            dataGridView1.Columns["Inventory_ID"].HeaderText = "ID";
            dataGridView1.Columns["Name"].HeaderText = "Name";
            dataGridView1.Columns["Type"].HeaderText = "Type";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Inventory_ID"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Type"].DisplayIndex = 2;
            dataGridView1.Columns["Quantity"].DisplayIndex = 3;
            dataGridView1.Columns["Batch_Number"].DisplayIndex = 4;
            dataGridView1.Columns["Expiry_date"].DisplayIndex = 5;
            dataGridView1.Columns["Shelf_location"].DisplayIndex = 6;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6347");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }
        public void AddData()
        {
            currentInventory.Add(new Inventory
            {
                Inventory_ID = 1,
                Name = "test1",
                Type = "shit",
                Quantity = 400,
                Batch_Number = "A-1",
                Expiry_date = DateTime.Now,
                Shelf_location = "C1",
                Menu_ID = 1
            });
            currentInventory.Add(new Inventory
            {
                Inventory_ID = 2,
                Name = "test2",
                Type = "food",
                Quantity = 4,
                Batch_Number = "A-1",
                Expiry_date = DateTime.Now,
                Shelf_location = "C1",
                Menu_ID = 2
            });
            currentInventory.Add(new Inventory
            {
                Inventory_ID = 3,
                Name = "test3",
                Type = "unknown",
                Quantity = 120,
                Batch_Number = "A-2",
                Expiry_date = DateTime.MinValue,
                Shelf_location = "A1",
                Menu_ID = 3
            });
        }
        public void clearData()
        {
            currentInventory.Clear();
        }
        public void addDataFromList(List<Inventory> fullList)
        {
            foreach(Inventory item in fullList)
            {
                currentInventory.Add(item);
            }
        }
    }
}
