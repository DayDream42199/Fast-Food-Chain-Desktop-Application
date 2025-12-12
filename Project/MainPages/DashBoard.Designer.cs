namespace Project.MainPages
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            Order_btn = new Button();
            Payment_btn = new Button();
            Account_btn = new Button();
            Employee_btn = new Button();
            Inventory_btn = new Button();
            logout_btn = new Button();
            panel2 = new Panel();
            revenue_label = new Label();
            totalorder_label = new Label();
            label1 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(Order_btn);
            panel1.Controls.Add(Payment_btn);
            panel1.Controls.Add(Account_btn);
            panel1.Controls.Add(Employee_btn);
            panel1.Controls.Add(Inventory_btn);
            panel1.Controls.Add(logout_btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 81);
            panel1.TabIndex = 0;
            // 
            // Order_btn
            // 
            Order_btn.BackColor = Color.FromArgb(220, 38, 127);
            Order_btn.Font = new Font("Segoe UI Semibold", 14F);
            Order_btn.ForeColor = Color.White;
            Order_btn.Location = new Point(617, 9);
            Order_btn.Name = "Order_btn";
            Order_btn.Size = new Size(146, 65);
            Order_btn.TabIndex = 9;
            Order_btn.Text = "Order";
            Order_btn.UseVisualStyleBackColor = false;
            Order_btn.Click += Order_btn_Click;
            // 
            // Payment_btn
            // 
            Payment_btn.BackColor = Color.FromArgb(220, 38, 127);
            Payment_btn.Font = new Font("Segoe UI Semibold", 14F);
            Payment_btn.ForeColor = Color.White;
            Payment_btn.Location = new Point(465, 9);
            Payment_btn.Name = "Payment_btn";
            Payment_btn.Size = new Size(146, 65);
            Payment_btn.TabIndex = 7;
            Payment_btn.Text = "Payment";
            Payment_btn.UseVisualStyleBackColor = false;
            Payment_btn.Click += Payment_btn_Click;
            // 
            // Account_btn
            // 
            Account_btn.BackColor = Color.FromArgb(220, 38, 127);
            Account_btn.Font = new Font("Segoe UI Semibold", 14F);
            Account_btn.ForeColor = Color.White;
            Account_btn.Location = new Point(313, 9);
            Account_btn.Name = "Account_btn";
            Account_btn.Size = new Size(146, 65);
            Account_btn.TabIndex = 6;
            Account_btn.Text = "Account";
            Account_btn.UseVisualStyleBackColor = false;
            Account_btn.Click += Account_btn_Click;
            // 
            // Employee_btn
            // 
            Employee_btn.BackColor = Color.FromArgb(220, 38, 127);
            Employee_btn.Font = new Font("Segoe UI Semibold", 14F);
            Employee_btn.ForeColor = Color.White;
            Employee_btn.Location = new Point(161, 9);
            Employee_btn.Name = "Employee_btn";
            Employee_btn.Size = new Size(146, 65);
            Employee_btn.TabIndex = 5;
            Employee_btn.Text = "Employee";
            Employee_btn.UseVisualStyleBackColor = false;
            Employee_btn.Click += Employee_btn_Click;
            // 
            // Inventory_btn
            // 
            Inventory_btn.BackColor = Color.FromArgb(220, 38, 127);
            Inventory_btn.Font = new Font("Segoe UI Semibold", 14F);
            Inventory_btn.ForeColor = Color.White;
            Inventory_btn.Location = new Point(9, 9);
            Inventory_btn.Name = "Inventory_btn";
            Inventory_btn.Size = new Size(146, 65);
            Inventory_btn.TabIndex = 4;
            Inventory_btn.Text = "Inventory";
            Inventory_btn.UseVisualStyleBackColor = false;
            Inventory_btn.Click += Inventory_btn_Click;
            // 
            // logout_btn
            // 
            logout_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logout_btn.BackColor = Color.Black;
            logout_btn.Font = new Font("Segoe UI Semibold", 14F);
            logout_btn.ForeColor = Color.White;
            logout_btn.Location = new Point(1042, 9);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(125, 65);
            logout_btn.TabIndex = 3;
            logout_btn.Text = "Log Out";
            logout_btn.UseVisualStyleBackColor = false;
            logout_btn.Click += logout_btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(revenue_label);
            panel2.Controls.Add(totalorder_label);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(1176, 235);
            panel2.TabIndex = 1;
            // 
            // revenue_label
            // 
            revenue_label.Font = new Font("Microsoft Sans Serif", 70F, FontStyle.Bold);
            revenue_label.ForeColor = Color.FromArgb(220, 38, 127);
            revenue_label.Location = new Point(408, 79);
            revenue_label.Name = "revenue_label";
            revenue_label.Size = new Size(576, 125);
            revenue_label.TabIndex = 3;
            revenue_label.Text = "$7839";
            // 
            // totalorder_label
            // 
            totalorder_label.Font = new Font("Microsoft Sans Serif", 70F, FontStyle.Bold);
            totalorder_label.ForeColor = Color.FromArgb(220, 38, 127);
            totalorder_label.ImageAlign = ContentAlignment.BottomCenter;
            totalorder_label.Location = new Point(60, 86);
            totalorder_label.Name = "totalorder_label";
            totalorder_label.Size = new Size(351, 118);
            totalorder_label.TabIndex = 2;
            totalorder_label.Text = "299";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F);
            label1.Location = new Point(427, 46);
            label1.Name = "label1";
            label1.Size = new Size(173, 32);
            label1.TabIndex = 1;
            label1.Text = "Total Revenue:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F);
            label2.Location = new Point(79, 46);
            label2.Name = "label2";
            label2.Size = new Size(93, 32);
            label2.TabIndex = 0;
            label2.Text = "Orders:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI Semibold", 12F);
            tabControl1.Location = new Point(3, 331);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1176, 397);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1168, 356);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Low Stock";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1162, 350);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1168, 356);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Near Expire";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1162, 350);
            dataGridView2.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "DashBoard";
            Text = "DashBoard";
            FormClosing += DashBoard_FormClosing;
            Load += DashBoard_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button logout_btn;
        private Button Inventory_btn;
        private Button Payment_btn;
        private Button Account_btn;
        private Button Employee_btn;
        private Panel panel2;
        private Label label2;
        private Label totalorder_label;
        private Label label1;
        private Label revenue_label;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private System.Windows.Forms.Timer timer1;
        private Button Order_btn;
    }
}