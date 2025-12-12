using Project.QueryHandler;
using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UIHandler
{
    public class AccountUI
    {
        DataGridView dataGridView1;
        BindingList<Account> currentAccount = new BindingList<Account>();

        public AccountUI(DataGridView grid_from_form)
        {
            this.dataGridView1 = grid_from_form;
            this.dataGridView1.DataSource = currentAccount;
        }

        public void setupTable()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["Em_ID"].Width = 65;
            dataGridView1.Columns["LName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["FName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Em_ID"].HeaderText = "ID";
            dataGridView1.Columns["FName"].HeaderText = "First Name";
            dataGridView1.Columns["LName"].HeaderText = "Last Name";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["FName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["LName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Em_ID"].DisplayIndex = 0;
            dataGridView1.Columns["FName"].DisplayIndex = 1;
            dataGridView1.Columns["LName"].DisplayIndex = 2;
            dataGridView1.Columns["Username"].DisplayIndex = 3;
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
            currentAccount.Add(new Account
            {
                Em_ID = 1,
                FName = "john",
                LName = "Doe",
                Username = "hello"
            });
            currentAccount.Add(new Account
            {
                Em_ID = 2,
                FName = "jane",
                LName = "Doe",
                Username = "dddd"
            });
            currentAccount.Add(new Account
            {
                Em_ID = 3,
                FName = "john",
                LName = "Doedd",
                Username = "Cashier123"
            });
        }
        public void clearData()
        {
            currentAccount.Clear();
        }
        public void addDataFromList(List<Account> fullList, List<Account> ignoreList)
        {
            foreach (Account item in fullList)
            {
                if (item.Em_ID == 0) continue;
                if (ignoreList.Contains(item)) continue;
                currentAccount.Add(item);
            }
        }
        public List<Account> getIgnoredAccount(List<Account> fullList, ManagerQueryHandler queryHandler)
        {
            List<Account> result = new List<Account>();
            foreach (Account item in fullList)
            {
                string role = queryHandler.getRoleFromUser(item.Username);
                if (role == "superadmin") result.Add(item);
            }
            return result;
        }
    }
}
