namespace Project.MainPages
{
    partial class AddOrder
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            clear_btn = new Button();
            create_btn = new Button();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            Price_label = new Label();
            label1 = new Label();
            panel1 = new Panel();
            logout_btn = new Button();
            progress_btn = new Button();
            Hello_label = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.Control;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 93);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1176, 657);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI Semibold", 12F);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(582, 651);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(574, 610);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel3.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel3.Controls.Add(panel2, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(591, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.Size = new Size(582, 651);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            tableLayoutPanel5.Controls.Add(clear_btn, 0, 0);
            tableLayoutPanel5.Controls.Add(create_btn, 2, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 523);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(576, 125);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // clear_btn
            // 
            clear_btn.BackColor = Color.FromArgb(255, 178, 11);
            clear_btn.Dock = DockStyle.Fill;
            clear_btn.Font = new Font("Segoe UI Semibold", 14F);
            clear_btn.ForeColor = Color.White;
            clear_btn.Location = new Point(3, 3);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(195, 119);
            clear_btn.TabIndex = 0;
            clear_btn.Text = "Clear";
            clear_btn.UseVisualStyleBackColor = false;
            clear_btn.Click += clear_btn_Click;
            // 
            // create_btn
            // 
            create_btn.BackColor = Color.FromArgb(255, 79, 1);
            create_btn.Dock = DockStyle.Fill;
            create_btn.Font = new Font("Segoe UI Semibold", 14F);
            create_btn.ForeColor = Color.White;
            create_btn.Location = new Point(215, 3);
            create_btn.Name = "create_btn";
            create_btn.Size = new Size(358, 119);
            create_btn.TabIndex = 1;
            create_btn.Text = "Create Order";
            create_btn.UseVisualStyleBackColor = false;
            create_btn.Click += create_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(576, 449);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(Price_label);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 458);
            panel2.Name = "panel2";
            panel2.Size = new Size(576, 59);
            panel2.TabIndex = 3;
            // 
            // Price_label
            // 
            Price_label.Anchor = AnchorStyles.Left;
            Price_label.Font = new Font("Microsoft Sans Serif", 15F);
            Price_label.ForeColor = Color.White;
            Price_label.Location = new Point(340, 13);
            Price_label.Name = "Price_label";
            Price_label.Size = new Size(233, 29);
            Price_label.TabIndex = 1;
            Price_label.Text = "$0";
            Price_label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(76, 29);
            label1.TabIndex = 0;
            label1.Text = "Total:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(logout_btn);
            panel1.Controls.Add(progress_btn);
            panel1.Controls.Add(Hello_label);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.MaximumSize = new Size(0, 84);
            panel1.MinimumSize = new Size(0, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 84);
            panel1.TabIndex = 1;
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
            logout_btn.TabIndex = 2;
            logout_btn.Text = "Log Out";
            logout_btn.UseVisualStyleBackColor = false;
            logout_btn.Click += logout_btn_Click;
            // 
            // progress_btn
            // 
            progress_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            progress_btn.BackColor = Color.FromArgb(22, 110, 170);
            progress_btn.Font = new Font("Segoe UI Semibold", 14F);
            progress_btn.ForeColor = Color.White;
            progress_btn.Location = new Point(911, 9);
            progress_btn.Name = "progress_btn";
            progress_btn.Size = new Size(125, 65);
            progress_btn.TabIndex = 1;
            progress_btn.Text = "Progress";
            progress_btn.UseVisualStyleBackColor = false;
            progress_btn.Click += progress_btn_Click;
            // 
            // Hello_label
            // 
            Hello_label.Font = new Font("Segoe UI Semibold", 12F);
            Hello_label.Location = new Point(3, 3);
            Hello_label.Name = "Hello_label";
            Hello_label.Size = new Size(582, 71);
            Hello_label.TabIndex = 0;
            Hello_label.Text = "Hello, ...";
            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "AddOrder";
            Text = "AddOrder";
            FormClosing += AddOrder_FormClosing;
            Load += AddOrder_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel1;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button logout_btn;
        private Button progress_btn;
        private Label Hello_label;
        private TableLayoutPanel tableLayoutPanel5;
        private Button clear_btn;
        private Button create_btn;
        private Panel panel2;
        private Label label1;
        private Label Price_label;
    }
}