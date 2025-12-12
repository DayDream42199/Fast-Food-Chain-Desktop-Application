using MySql.Data.MySqlClient;
using Project.QueryHandler;

namespace Project.MainPages
{
    public partial class Login : Form
    {
        LoginQueryHandler queryHandler = new LoginQueryHandler();
        private readonly bool bypassRoot = true;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = user_txtbox.Text;
            string password = pass_txtbox.Text;

            try
            {
                if (queryHandler.checkUserPass(username, password))
                {
                    string name = queryHandler.getNameFromUser(username) ?? "???";
                    uint id = queryHandler.getIDFromUser(username);

                    // Bypass if root
                    if (id == 0 && bypassRoot)
                    {
                        user_txtbox.Text = "";
                        pass_txtbox.Text = "";
                        warning_label.Text = "";

                        DashBoard dashBoard = new DashBoard(this, id, true);
                        this.Hide();

                        dashBoard.StartPosition = FormStartPosition.Manual;
                        dashBoard.Location = this.Location;
                        dashBoard.Size = this.Size;
                        dashBoard.WindowState = this.WindowState;
                        dashBoard.Show();
                        return;
                    }

                    string role = queryHandler.getRoleFromUser(username);

                    user_txtbox.Text = "";
                    pass_txtbox.Text = "";
                    warning_label.Text = "";

                    if (role == "cashier")
                    {
                        AddOrder orderForm = new AddOrder(this, name, id);
                        this.Hide();

                        orderForm.StartPosition = FormStartPosition.Manual;
                        orderForm.Location = this.Location;
                        orderForm.Size = this.Size;
                        orderForm.WindowState = this.WindowState;
                        orderForm.Show();
                    }
                    else if (role == "chef")
                    {
                        OrderProgress progressForm = new OrderProgress(this);
                        progressForm.enableTimer(true);
                        progressForm.fetchData();
                        progressForm.updateButtonClickability();
                        this.Hide();

                        progressForm.StartPosition = FormStartPosition.Manual;
                        progressForm.Location = this.Location;
                        progressForm.Size = this.Size;
                        progressForm.WindowState = this.WindowState;
                        progressForm.Show();
                    }
                    else if (role == "manager")
                    {
                        DashBoard dashBoard = new DashBoard(this, id);
                        this.Hide();

                        dashBoard.StartPosition = FormStartPosition.Manual;
                        dashBoard.Location = this.Location;
                        dashBoard.Size = this.Size;
                        dashBoard.WindowState = this.WindowState;
                        dashBoard.Show();
                    }
                    else if (role == "superadmin")
                    {
                        DashBoard dashBoard = new DashBoard(this, id, true);
                        this.Hide();

                        dashBoard.StartPosition = FormStartPosition.Manual;
                        dashBoard.Location = this.Location;
                        dashBoard.Size = this.Size;
                        dashBoard.WindowState = this.WindowState;
                        dashBoard.Show();
                    }
                    else
                    {
                        warning_label.Text = "Unknow user, please contact support";
                    }
                }
                else
                {
                    pass_txtbox.Text = "";
                    warning_label.Text = "Wrong username or password, please try again.";
                }
            }
            catch (BCrypt.Net.SaltParseException)
            {
                warning_label.Text = "Unable to validate password.";
            }
            catch
            {
                warning_label.Text = "Unable to connect to server.";
            }
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                if (f != this)
                {
                    f.Close();
                    f.Dispose();
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
