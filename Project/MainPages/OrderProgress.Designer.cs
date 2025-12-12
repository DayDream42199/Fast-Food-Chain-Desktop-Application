namespace Project.MainPages
{
    partial class OrderProgress
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
            next_btn = new Button();
            page_label = new Label();
            prev_btn = new Button();
            logout_btn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(Order_btn);
            panel1.Controls.Add(next_btn);
            panel1.Controls.Add(page_label);
            panel1.Controls.Add(prev_btn);
            panel1.Controls.Add(logout_btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 84);
            panel1.TabIndex = 0;
            // 
            // Order_btn
            // 
            Order_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Order_btn.BackColor = Color.FromArgb(255, 79, 1);
            Order_btn.Font = new Font("Segoe UI Semibold", 14F);
            Order_btn.ForeColor = Color.White;
            Order_btn.Location = new Point(911, 9);
            Order_btn.Name = "Order_btn";
            Order_btn.Size = new Size(125, 65);
            Order_btn.TabIndex = 7;
            Order_btn.Text = "Order";
            Order_btn.UseVisualStyleBackColor = false;
            Order_btn.Click += Order_btn_Click;
            // 
            // next_btn
            // 
            next_btn.BackColor = Color.FromArgb(22, 110, 170);
            next_btn.Font = new Font("Microsoft Sans Serif", 15F);
            next_btn.ForeColor = Color.White;
            next_btn.Location = new Point(146, 18);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(53, 47);
            next_btn.TabIndex = 6;
            next_btn.Text = ">";
            next_btn.UseVisualStyleBackColor = false;
            next_btn.Click += next_btn_Click;
            // 
            // page_label
            // 
            page_label.Font = new Font("Microsoft Sans Serif", 15F);
            page_label.Location = new Point(68, 27);
            page_label.Name = "page_label";
            page_label.Size = new Size(72, 29);
            page_label.TabIndex = 5;
            page_label.Text = "0/0";
            page_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // prev_btn
            // 
            prev_btn.BackColor = Color.FromArgb(22, 110, 170);
            prev_btn.Font = new Font("Microsoft Sans Serif", 15F);
            prev_btn.ForeColor = Color.White;
            prev_btn.Location = new Point(9, 18);
            prev_btn.Name = "prev_btn";
            prev_btn.Size = new Size(53, 47);
            prev_btn.TabIndex = 4;
            prev_btn.Text = "<";
            prev_btn.UseVisualStyleBackColor = false;
            prev_btn.Click += prev_btn_Click;
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 93);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1176, 657);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // OrderProgress
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "OrderProgress";
            Text = "OrderProgress";
            FormClosing += OrderProgress_FormClosing;
            Load += OrderProgress_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button logout_btn;
        private Button prev_btn;
        private Button next_btn;
        private Label page_label;
        private Button Order_btn;
        private System.Windows.Forms.Timer timer1;
    }
}