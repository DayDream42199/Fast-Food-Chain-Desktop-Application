using Mysqlx.Datatypes;
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
    public partial class EditAccount : Form
    {
        ManagerQueryHandler? queryHandler;
        SuperAdminQueryHandler? adminQueryHandler;
        uint employeeID;
        string oldUsername;

        AccountPage parent;

        public EditAccount(AccountPage parentForm, ManagerQueryHandler queryH, uint emID, string oldUsername)
        {
            InitializeComponent();
            queryHandler = queryH;
            parent = parentForm;
            employeeID = emID;
            this.oldUsername = oldUsername;
        }

        public EditAccount(AccountPage parentForm, SuperAdminQueryHandler queryH, uint emID, string oldUsername)
        {
            InitializeComponent();
            adminQueryHandler = queryH;
            parent = parentForm;
            employeeID = emID;
            this.oldUsername = oldUsername;
        }

        public void prefillData(string username)
        {
            user_txtbox.Text = username;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (queryHandler != null)
            {
                if (user_txtbox.Text.Length <= 0 || pass_txtbox.Text.Length <= 0 || cpass_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                if (queryHandler.isUsernameExists(user_txtbox.Text) && user_txtbox.Text != oldUsername)
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }
                if (pass_txtbox.Text != cpass_txtbox.Text)
                {
                    MessageBox.Show("Password does not match, please try again.");
                    return;
                }
                queryHandler.updateAccount(user_txtbox.Text, pass_txtbox.Text, employeeID);
            }
            else
            {
                if (user_txtbox.Text.Length <= 0 || pass_txtbox.Text.Length <= 0 || cpass_txtbox.Text.Length <= 0)
                {
                    MessageBox.Show("Please enter all the field.");
                    return;
                }
                if (adminQueryHandler.isUsernameExists(user_txtbox.Text) && user_txtbox.Text != oldUsername)
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }
                if (pass_txtbox.Text != cpass_txtbox.Text)
                {
                    MessageBox.Show("Password does not match, please try again.");
                    return;
                }
                adminQueryHandler.updateAccount(user_txtbox.Text, pass_txtbox.Text, employeeID);
            }

            parent.fetchData();
            this.Close();
        }

        private void EditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
