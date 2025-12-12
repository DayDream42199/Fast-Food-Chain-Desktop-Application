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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.MainPages.Edit
{
    public partial class EditEmployee : Form
    {
        ManagerQueryHandler? queryHandler;
        SuperAdminQueryHandler? adminQueryHandler;
        uint employeeID;
        bool isUpdate = false;
        string? oldRole;

        EmployeePage parent;

        public EditEmployee(EmployeePage parentForm, ManagerQueryHandler queryH)
        {
            InitializeComponent();
            queryHandler = queryH;
            parent = parentForm;
            role_combo.Items.RemoveAt(2);
            role_combo.Items.RemoveAt(2);
        }

        public EditEmployee(EmployeePage parentForm, SuperAdminQueryHandler queryH)
        {
            InitializeComponent();
            adminQueryHandler = queryH;
            parent = parentForm;
        }

        public EditEmployee(EmployeePage parentForm, ManagerQueryHandler queryH, uint emID, string oldRole)
        {
            InitializeComponent();
            queryHandler = queryH;
            parent = parentForm;
            employeeID = emID;
            isUpdate = true;
            this.oldRole = oldRole;
            role_combo.Items.RemoveAt(2);
            role_combo.Items.RemoveAt(2);
        }

        public EditEmployee(EmployeePage parentForm, SuperAdminQueryHandler queryH, uint emID, string oldRole)
        {
            InitializeComponent();
            adminQueryHandler = queryH;
            parent = parentForm;
            employeeID = emID;
            isUpdate = true;
            this.oldRole = oldRole;
        }

        public void prefillData(string fname, string lname, string role, string email, string phone, DateTime dob, DateTime startDate, string salary, string status)
        {
            fname_txtbox.Text = fname;
            lname_txtbox.Text = lname;
            if (role == "cashier") role_combo.SelectedIndex = 0;
            else if (role == "chef") role_combo.SelectedIndex = 1;
            else if (role == "manager") role_combo.SelectedIndex = 2;
            else role_combo.SelectedIndex = 3;
            email_txtbox.Text = email;
            phone_txtbox.Text = phone;
            DOB.Value = dob;
            startdate.Value = startDate;
            salary_txtbox.Text = salary;
            if (status == "active") comboBox2.SelectedIndex = 0;
            else comboBox2.SelectedIndex = 1;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                if (!decimal.TryParse(salary_txtbox.Text, out decimal salary))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }
                if (fname_txtbox.Text.Length <= 0 || lname_txtbox.Text.Length <= 0 || email_txtbox.Text.Length <= 0 ||
                    phone_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                if (!isUpdate)
                {
                    if (!queryHandler.insertEmployee(fname_txtbox.Text, lname_txtbox.Text, email_txtbox.Text, phone_txtbox.Text,
                        DOB.Value, startdate.Value, salary, comboBox2.Text, role_combo.Text))
                    {
                        MessageBox.Show("Unable to create employee. Connection disrupted.");
                    }
                }
                else
                {
                    if (!queryHandler.updateEmployee(fname_txtbox.Text, lname_txtbox.Text, email_txtbox.Text, phone_txtbox.Text,
                        DOB.Value, startdate.Value, salary, comboBox2.Text, role_combo.Text, employeeID, oldRole))
                    {
                        MessageBox.Show("Unable to edit employee data. Connection disrupted.");
                    }
                }
            }
            else
            {
                if (!decimal.TryParse(salary_txtbox.Text, out decimal salary))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }
                if (fname_txtbox.Text.Length <= 0 || lname_txtbox.Text.Length <= 0 || email_txtbox.Text.Length <= 0 ||
                    phone_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                if (!isUpdate)
                {
                    if (!adminQueryHandler.insertEmployee(fname_txtbox.Text, lname_txtbox.Text, email_txtbox.Text, phone_txtbox.Text,
                        DOB.Value, startdate.Value, salary, comboBox2.Text, role_combo.Text))
                    {
                        MessageBox.Show("Unable to create employee. Connection disrupted.");
                    }
                }
                else
                {
                    if (!adminQueryHandler.updateEmployee(fname_txtbox.Text, lname_txtbox.Text, email_txtbox.Text, phone_txtbox.Text,
                        DOB.Value, startdate.Value, salary, comboBox2.Text, role_combo.Text, employeeID, oldRole))
                    {
                        MessageBox.Show("Unable to edit employee data. Connection disrupted.");
                    }
                }
            }

            parent.fetchData();
            this.Close();
        }

        private void EditEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            if (!isUpdate)
            {
                role_combo.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }
    }
}
