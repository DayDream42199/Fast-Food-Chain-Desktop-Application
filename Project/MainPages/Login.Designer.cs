namespace Project.MainPages
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            warning_label = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            pass_txtbox = new TextBox();
            user_txtbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(warning_label);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pass_txtbox);
            panel1.Controls.Add(user_txtbox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(180, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(821, 596);
            panel1.TabIndex = 1;
            // 
            // warning_label
            // 
            warning_label.Anchor = AnchorStyles.None;
            warning_label.Font = new Font("Segoe UI Semibold", 8F);
            warning_label.ForeColor = Color.Red;
            warning_label.Location = new Point(164, 476);
            warning_label.Name = "warning_label";
            warning_label.Size = new Size(473, 23);
            warning_label.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(821, 257);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(255, 79, 1);
            button1.Font = new Font("Segoe UI Semibold", 14F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(323, 513);
            button1.Name = "button1";
            button1.Size = new Size(139, 47);
            button1.TabIndex = 4;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pass_txtbox
            // 
            pass_txtbox.Anchor = AnchorStyles.None;
            pass_txtbox.Font = new Font("Segoe UI Semibold", 14F);
            pass_txtbox.Location = new Point(148, 434);
            pass_txtbox.Name = "pass_txtbox";
            pass_txtbox.PasswordChar = '*';
            pass_txtbox.Size = new Size(514, 39);
            pass_txtbox.TabIndex = 3;
            // 
            // user_txtbox
            // 
            user_txtbox.Anchor = AnchorStyles.None;
            user_txtbox.Font = new Font("Segoe UI Semibold", 14F);
            user_txtbox.Location = new Point(148, 329);
            user_txtbox.Name = "user_txtbox";
            user_txtbox.Size = new Size(514, 39);
            user_txtbox.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F);
            label2.Location = new Point(148, 399);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F);
            label1.Location = new Point(148, 294);
            label1.Name = "label1";
            label1.Size = new Size(130, 32);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            VisibleChanged += Login_VisibleChanged;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private TextBox user_txtbox;
        private Label label2;
        private Button button1;
        private TextBox pass_txtbox;
        private PictureBox pictureBox1;
        private Label warning_label;
    }
}
