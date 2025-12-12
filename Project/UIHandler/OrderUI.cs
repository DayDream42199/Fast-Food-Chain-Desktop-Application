using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UIHandler
{
    public class OrderUI
    {
        DataGridView dataGridView1;
        BindingList<Order> currentOrder = new BindingList<Order>();

        public OrderUI(DataGridView grid_from_form)
        {
            this.dataGridView1 = grid_from_form;
            this.dataGridView1.DataSource = currentOrder;
        }

        public void setupTable()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Order_ID"].Width = 65;
            dataGridView1.Columns["Order_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Quantity"].Width = 65;
            dataGridView1.Columns["Menu_ID"].Visible= false;
            dataGridView1.Columns["Order_ID"].HeaderText = "ID";
            dataGridView1.Columns["Order_Name"].HeaderText = "Items";
            dataGridView1.Columns["Quantity"].HeaderText = "Amt.";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Order_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Order_ID"].DisplayIndex = 0;
            dataGridView1.Columns["Order_Name"].DisplayIndex = 1;
            dataGridView1.Columns["Quantity"].DisplayIndex = 2;
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
            currentOrder.Add(new Order
            {
                Order_ID = 1,
                Order_Name = "Burger",
                Quantity = 2,
                Menu_ID=1
            });
            currentOrder.Add(new Order
            {
                Order_ID = 1,
                Order_Name = "fries",
                Quantity = 1,
                Menu_ID=1
            });
            currentOrder.Add(new Order
            {
                Order_ID = 2,
                Order_Name = "Burger",
                Quantity = 4,
                Menu_ID=2
            });
        }
        public void clearData()
        {
            currentOrder.Clear();
        }
        public void addDataFromList(List<Order> fullList)
        {
            foreach (Order item in fullList)
            {
                currentOrder.Add(item);
            }
        }
    }
}
