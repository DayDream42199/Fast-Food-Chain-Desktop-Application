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
    public class EmployeeUI
    {
        DataGridView dataGridView1;
        BindingList<Employee> currentEmployee = new BindingList<Employee>();

        public EmployeeUI(DataGridView grid_from_form)
        {
            this.dataGridView1 = grid_from_form;
            this.dataGridView1.DataSource = currentEmployee;
        }

        public void setupTable()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns["FName"].Width = 200;
            dataGridView1.Columns["LName"].Width = 200;
            dataGridView1.Columns["Em_ID"].Width = 65;
            dataGridView1.Columns["Email"].Width = 300;
            dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Email"].MinimumWidth = 300;
            dataGridView1.Columns["Role"].Width = 150;
            dataGridView1.Columns["Phone"].Width = 150;
            dataGridView1.Columns["DOB"].Width = 165;
            dataGridView1.Columns["StartDate"].Width = 165;
            dataGridView1.Columns["Salary"].Width = 150;
            dataGridView1.Columns["Status"].Width = 150;
            dataGridView1.Columns["DOB"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            dataGridView1.Columns["Role"].DisplayIndex = 3;
            dataGridView1.Columns["Email"].DisplayIndex = 4;
            dataGridView1.Columns["Phone"].DisplayIndex = 5;
            dataGridView1.Columns["DOB"].DisplayIndex = 6;
            dataGridView1.Columns["StartDate"].DisplayIndex = 7;
            dataGridView1.Columns["Salary"].DisplayIndex = 8;
            dataGridView1.Columns["Status"].DisplayIndex = 9;
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
            currentEmployee.Add(new Employee
            {
                Em_ID = 1,
                FName = "john",
                LName = "Doe",
                Role = "Cashier",
                Email = "johnDoe@email.com",
                Phone = "000-000-0000",
                DOB = DateTime.Now,
                StartDate = DateTime.Now,
                Salary = 120.12m,
                Status = "active"
            });
            currentEmployee.Add(new Employee
            {
                Em_ID = 2,
                FName = "jane",
                LName = "Doe",
                Role = "Chef",
                Email = "janee@email.com",
                Phone = "000-000-0000",
                DOB = DateTime.Now,
                StartDate = DateTime.Now,
                Salary = 12000.12m,
                Status = "active"
            });
            currentEmployee.Add(new Employee
            {
                Em_ID = 3,
                FName = "john",
                LName = "Doedd",
                Role = "Cashier",
                Email = "johnDoedd@email.com",
                Phone = "000-000-0000",
                DOB = DateTime.Now,
                StartDate = DateTime.Now,
                Salary = 120.12m,
                Status = "inactive"
            });
        }
        public void clearData()
        {
            currentEmployee.Clear();
        }
        public void addDataFromList(List<Employee> fullList, List<Employee> ignoreList)
        {
            foreach (Employee item in fullList)
            {
                if (item.Em_ID == 0) continue;
                if (ignoreList.Contains(item)) continue;
                currentEmployee.Add(item);
            }
        }
        public List<Employee> getIgnoredAccount(List<Employee> fullList)
        {
            List<Employee> result = new List<Employee>();
            foreach (Employee item in fullList)
            {
                if (item.Role == "superadmin") result.Add(item);
            }
            return result;
        }
    }
}
