using Project.MainPages;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.UIHandler
{
    public class AddOrderUI1
    {
        private DataGridView dataGridView1;
        private Label priceLabel;

        private BindingList<OrderItem> currentOrder = new BindingList<OrderItem>();
        private readonly string columnHeaderColor = "#FF6347";
        private decimal currentTotal = 0;

        public AddOrderUI1(DataGridView dgv, Label priceLab)
        {
            dataGridView1 = dgv;
            priceLabel = priceLab;
        }

        public void setUpTable()
        {
            dataGridView1.DataSource = currentOrder;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["MenuItemID"].Visible = false;
            dataGridView1.Columns["ItemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Quantity"].Width = 65;
            dataGridView1.Columns["Quantity"].HeaderText = "Amt.";
            dataGridView1.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Price"].Visible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(columnHeaderColor);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);

            DataGridViewImageColumn imgSub = new DataGridViewImageColumn();
            imgSub.Name = "colSub";
            imgSub.HeaderText = "Sub";
            imgSub.Image = Properties.Resources.minus;
            imgSub.Width = 55;
            imgSub.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgSub);

            DataGridViewImageColumn imgAdd = new DataGridViewImageColumn();
            imgAdd.Name = "colAdd";
            imgAdd.HeaderText = "Add";
            imgAdd.Image = Properties.Resources.add;
            imgAdd.Width = 55;
            imgAdd.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgAdd);

            DataGridViewImageColumn imgClear = new DataGridViewImageColumn();
            imgClear.Name = "colClear";
            imgClear.HeaderText = "Clear";
            imgClear.Image = Properties.Resources.trashcan;
            imgClear.Width = 70;
            imgClear.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgClear);
        }

        public void addOrder(uint itemID, string itemName, int quantity, decimal price)
        {
            if (currentOrder.Any(item => item.MenuItemID == itemID)) return;
            currentOrder.Add(new OrderItem
            {
                MenuItemID = itemID,
                ItemName = itemName,
                Quantity = quantity,
                Price = price
            });
            currentTotal += price;
            priceLabel.Text = $"${currentTotal.ToString()}";
        }

        public void quantityChanged(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= currentOrder.Count) return;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            OrderItem item = this.currentOrder[e.RowIndex];
            decimal price = item.Price;

            switch (colName)
            {
                case "colAdd":
                    item.Quantity++;
                    currentTotal += price;
                    priceLabel.Text = $"${currentTotal.ToString()}";
                    break;

                case "colSub":
                    if (item.Quantity > 0)
                    {
                        item.Quantity--;
                        currentTotal -= price;
                        priceLabel.Text = $"${currentTotal.ToString()}";

                        if (item.Quantity == 0)
                        {
                            currentOrder.Remove(item);
                        }
                    }
                    break;
                case "colClear":
                    currentOrder.Remove(item);
                    currentTotal -= price * item.Quantity;
                    priceLabel.Text = $"${currentTotal.ToString()}";
                    break;
            }
        }

        public void clearOrder()
        {
            currentOrder.Clear();
            currentTotal = 0;
            priceLabel.Text = "$0";
        }

        public BindingList<OrderItem> getOrder()
        {
            return currentOrder;
        }

        public decimal getTotal()
        {
            return currentTotal;
        }
    }
}
