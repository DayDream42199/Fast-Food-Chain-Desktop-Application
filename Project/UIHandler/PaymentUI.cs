using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UIHandler
{
    public class PaymentUI
    {
        DataGridView dataGridView1;
        BindingList<Payment> currentPayment = new BindingList<Payment>();

        public PaymentUI(DataGridView grid_from_form)
        {
            this.dataGridView1 = grid_from_form;
            this.dataGridView1.DataSource = currentPayment;
        }

        public void setupTable()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Payment_ID"].Width = 65;
            dataGridView1.Columns["Order_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Payment_Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TimeStamp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Payment_ID"].HeaderText = "ID";
            dataGridView1.Columns["Order_ID"].HeaderText = "Order ID";
            dataGridView1.Columns["Payment_Type"].HeaderText = "Payment Type";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Payment_ID"].DisplayIndex = 0;
            dataGridView1.Columns["Order_ID"].DisplayIndex = 1;
            dataGridView1.Columns["Payment_Type"].DisplayIndex = 2;
            dataGridView1.Columns["Total"].DisplayIndex = 3;
            dataGridView1.Columns["TimeStamp"].DisplayIndex = 3;
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
            currentPayment.Add(new Payment
            {
                Payment_ID = 1,
                Order_ID = 1,
                Payment_Type = "Cash",
                Total = 120009.23m,
                Timestamp = DateTime.Now
            });
            currentPayment.Add(new Payment
            {
                Payment_ID = 2,
                Order_ID = 2,
                Payment_Type = "Card",
                Total = 120309.23m,
                Timestamp = DateTime.MaxValue
            });
            currentPayment.Add(new Payment
            {
                Payment_ID = 3,
                Order_ID = 3,
                Payment_Type = "Cancel",
                Total = 126609.23m,
                Timestamp = DateTime.MinValue
            });
        }
        public void clearData()
        {
            currentPayment.Clear();
        }
        public void addDataFromList(List<Payment> fullList)
        {
            foreach (Payment item in fullList)
            {
                currentPayment.Add(item);
            }
        }
    }
}
