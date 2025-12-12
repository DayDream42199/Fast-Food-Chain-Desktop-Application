using Project.QueryHandler;
using Project.TableHandler;
using Project.UIHandler;
using System;
using System.Collections;
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
    public partial class PaymentPage : Form
    {
        Login parentForm1;
        DashBoard parentForm2;

        public ManagerQueryHandler? queryHandler;
        public SuperAdminQueryHandler? adminQueryHandler;
        public PaymentUI mainTable;
        List<Payment> fetchedPayment = new List<Payment>();
        long currentPage = 1;
        long maxPage = 1;
        bool fetchErrorMessageOnCooldown = false;

        public DateTime paymentLastUpdate = DateTime.MinValue;

        private bool closeParent = true;

        public PaymentPage(DashBoard parent2, Login parent1, ManagerQueryHandler query)
        {
            InitializeComponent();
            queryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            mainTable = new PaymentUI(this.dataGridView1);
            mainTable.setupTable();
        }

        public PaymentPage(DashBoard parent2, Login parent1, SuperAdminQueryHandler query)
        {
            InitializeComponent();
            adminQueryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            mainTable = new PaymentUI(this.dataGridView1);
            mainTable.setupTable();
        }

        private void PaymentPage_Load(object sender, EventArgs e)
        {
            sort_combo.SelectedIndex = 0;
            direction_combo.SelectedIndex = 0;

            fetchData();
        }

        public void fetchData(bool isManual = true)
        {
            try
            {
                if (queryHandler != null)
                {
                    if (paymentLastUpdate == queryHandler.getPaymentLastUpdateTime(paymentLastUpdate) &&
                        !isManual) return;
                    maxPage = queryHandler.getPaymentPageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedPayment = queryHandler.getPaymentByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedPayment);

                    fetchErrorMessageOnCooldown = false;
                    paymentLastUpdate = queryHandler.getEmployeeLastUpdateTime(paymentLastUpdate);
                }
                else
                {
                    if (paymentLastUpdate == adminQueryHandler.getPaymentLastUpdateTime(paymentLastUpdate) &&
                    !isManual) return;
                    maxPage = adminQueryHandler.getPaymentPageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedPayment = adminQueryHandler.getPaymentByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedPayment);

                    fetchErrorMessageOnCooldown = false;
                    paymentLastUpdate = adminQueryHandler.getEmployeeLastUpdateTime(paymentLastUpdate);
                }
            }
            catch
            {
                mainTable.clearData();
                paymentLastUpdate = DateTime.MinValue;

                if (!fetchErrorMessageOnCooldown)
                {
                    MessageBox.Show("Unable to fetch payments. Connection disrupted.");
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

        private void PaymentPage_FormClosing(object sender, FormClosingEventArgs e)
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
