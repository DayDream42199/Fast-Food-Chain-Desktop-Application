using Project.MainPages.Edit;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project.MainPages
{
    public partial class EmployeePage : Form
    {
        Login parentForm1;
        DashBoard parentForm2;

        public ManagerQueryHandler? queryHandler;
        public SuperAdminQueryHandler? adminQueryHandler;
        public EmployeeUI mainTable;
        List<Employee> fetchedEmployee = new List<Employee>();
        long currentPage = 1;
        long maxPage = 1;
        bool fetchErrorMessageOnCooldown = false;

        public DateTime employeeLastUpdate = DateTime.MinValue;

        private bool closeParent = true;

        public EmployeePage(DashBoard parent2, Login parent1, ManagerQueryHandler query)
        {
            InitializeComponent();
            queryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            mainTable = new EmployeeUI(this.dataGridView1);
            mainTable.setupTable();
        }

        public EmployeePage(DashBoard parent2, Login parent1, SuperAdminQueryHandler query)
        {
            InitializeComponent();
            adminQueryHandler = query;
            parentForm1 = parent1;
            parentForm2 = parent2;
            mainTable = new EmployeeUI(this.dataGridView1);
            mainTable.setupTable();
        }

        private void EmployeePage_Load(object sender, EventArgs e)
        {
            sort_combo.SelectedIndex = 0;
            direction_combo.SelectedIndex = 0;

            fetchData();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                EditEmployee editEmployeePage = new EditEmployee(this, queryHandler);
                this.Hide();

                editEmployeePage.StartPosition = FormStartPosition.Manual;
                editEmployeePage.Location = this.Location;
                editEmployeePage.Size = this.Size;
                editEmployeePage.WindowState = this.WindowState;
                editEmployeePage.Show();
            }
            else
            {
                EditEmployee editEmployeePage = new EditEmployee(this, adminQueryHandler);
                this.Hide();

                editEmployeePage.StartPosition = FormStartPosition.Manual;
                editEmployeePage.Location = this.Location;
                editEmployeePage.Size = this.Size;
                editEmployeePage.WindowState = this.WindowState;
                editEmployeePage.Show();
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                uint rowIndex = Convert.ToUInt32(selectedRow.Cells["Em_ID"].Value);
                // get current data? Its bad Ik but this is the only way 🗿🗿🗿
                string fname = selectedRow.Cells["FName"].Value?.ToString() ?? "";
                string lname = selectedRow.Cells["LName"].Value?.ToString() ?? "";
                string role = selectedRow.Cells["Role"].Value?.ToString() ?? "";
                string email = selectedRow.Cells["Email"].Value?.ToString() ?? "";
                string phone = selectedRow.Cells["Phone"].Value?.ToString() ?? "";
                DateTime dob = Convert.ToDateTime(selectedRow.Cells["DOB"].Value);
                DateTime startDate = Convert.ToDateTime(selectedRow.Cells["StartDate"].Value);
                string salary = selectedRow.Cells["Salary"].Value?.ToString() ?? "0";
                string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";
                // ZZZ
                if (queryHandler != null)
                {
                    if (role == "manager")
                    {
                        MessageBox.Show("Unable to edit data");
                        return;
                    }
                    EditEmployee editEmployeePage = new EditEmployee(this, queryHandler, rowIndex, role);
                    editEmployeePage.prefillData(fname, lname, role, email, phone, dob, startDate, salary, status);
                    this.Hide();

                    editEmployeePage.StartPosition = FormStartPosition.Manual;
                    editEmployeePage.Location = this.Location;
                    editEmployeePage.Size = this.Size;
                    editEmployeePage.WindowState = this.WindowState;
                    editEmployeePage.Show();
                    return;
                }
                else
                {
                    EditEmployee editEmployeePage = new EditEmployee(this, adminQueryHandler, rowIndex, role);
                    editEmployeePage.prefillData(fname, lname, role, email, phone, dob, startDate, salary, status);
                    this.Hide();

                    editEmployeePage.StartPosition = FormStartPosition.Manual;
                    editEmployeePage.Location = this.Location;
                    editEmployeePage.Size = this.Size;
                    editEmployeePage.WindowState = this.WindowState;
                    editEmployeePage.Show();
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
                    uint rowIndex = Convert.ToUInt32(selectedRow.Cells["Em_ID"].Value);
                    string role = selectedRow.Cells["Role"].Value?.ToString() ?? "";
                    try
                    {
                        if (role == "manager" || !queryHandler.deleteEmployee(rowIndex)) MessageBox.Show("Unable to delete data");
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
                    uint rowIndex = Convert.ToUInt32(selectedRow.Cells["Em_ID"].Value);
                    try
                    {
                        if (!adminQueryHandler.deleteEmployee(rowIndex)) MessageBox.Show("Unable to delete data");
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
                    if (employeeLastUpdate == queryHandler.getEmployeeLastUpdateTime(employeeLastUpdate) &&
                        !isManual) return;
                    maxPage = queryHandler.getEmployeePageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedEmployee = queryHandler.getEmployeeByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedEmployee, mainTable.getIgnoredAccount(fetchedEmployee));

                    fetchErrorMessageOnCooldown = false;
                    employeeLastUpdate = queryHandler.getEmployeeLastUpdateTime(employeeLastUpdate);
                }
                else
                {
                    if (employeeLastUpdate == adminQueryHandler.getEmployeeLastUpdateTime(employeeLastUpdate) &&
                        !isManual) return;
                    maxPage = adminQueryHandler.getEmployeePageCount(search_txtbox.Text);
                    if (currentPage > maxPage) currentPage = maxPage;
                    page_number.Text = currentPage.ToString();
                    page_number.SelectionStart = page_number.Text.Length;
                    page_number.SelectionLength = 0;
                    page_label.Text = "/" + maxPage.ToString();
                    updateButtonClickability();
                    if (currentPage == 0) currentPage = 1;
                    fetchedEmployee = adminQueryHandler.getEmployeeByPage(search_txtbox.Text, sort_combo.Text, direction_combo.Text, currentPage);

                    mainTable.clearData();
                    mainTable.addDataFromList(fetchedEmployee, new List<Employee>());

                    fetchErrorMessageOnCooldown = false;
                    employeeLastUpdate = adminQueryHandler.getEmployeeLastUpdateTime(employeeLastUpdate);
                }
            }
            catch
            {
                mainTable.clearData();
                employeeLastUpdate = DateTime.MinValue;

                if (!fetchErrorMessageOnCooldown)
                {
                    MessageBox.Show("Unable to fetch employees. Connection disrupted.");
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

        private void EmployeePage_FormClosing(object sender, FormClosingEventArgs e)
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
