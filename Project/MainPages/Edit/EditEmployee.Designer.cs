namespace Project.MainPages.Edit
{
    partial class EditEmployee
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
            panel1 = new Panel();
            submit_btn = new Button();
            startdate = new DateTimePicker();
            DOB = new DateTimePicker();
            comboBox2 = new ComboBox();
            role_combo = new ComboBox();
            salary_txtbox = new TextBox();
            phone_txtbox = new TextBox();
            email_txtbox = new TextBox();
            lname_txtbox = new TextBox();
            fname_txtbox = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            totalorder_label = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(submit_btn);
            panel1.Controls.Add(startdate);
            panel1.Controls.Add(DOB);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(role_combo);
            panel1.Controls.Add(salary_txtbox);
            panel1.Controls.Add(phone_txtbox);
            panel1.Controls.Add(email_txtbox);
            panel1.Controls.Add(lname_txtbox);
            panel1.Controls.Add(fname_txtbox);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(totalorder_label);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 753);
            panel1.TabIndex = 0;
            // 
            // submit_btn
            // 
            submit_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            submit_btn.BackColor = Color.FromArgb(255, 79, 1);
            submit_btn.Font = new Font("Segoe UI Semibold", 20F);
            submit_btn.ForeColor = Color.White;
            submit_btn.Location = new Point(1015, 645);
            submit_btn.Name = "submit_btn";
            submit_btn.Size = new Size(155, 96);
            submit_btn.TabIndex = 27;
            submit_btn.Text = "Submit";
            submit_btn.UseVisualStyleBackColor = false;
            submit_btn.Click += submit_btn_Click;
            // 
            // startdate
            // 
            startdate.Anchor = AnchorStyles.None;
            startdate.Font = new Font("Segoe UI Semibold", 12F);
            startdate.Location = new Point(500, 558);
            startdate.Name = "startdate";
            startdate.Size = new Size(450, 34);
            startdate.TabIndex = 26;
            // 
            // DOB
            // 
            DOB.Anchor = AnchorStyles.None;
            DOB.Font = new Font("Segoe UI Semibold", 12F);
            DOB.Location = new Point(500, 488);
            DOB.Name = "DOB";
            DOB.Size = new Size(450, 34);
            DOB.TabIndex = 25;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.None;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI Semibold", 20F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "active", "inactive" });
            comboBox2.Location = new Point(500, 687);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(450, 53);
            comboBox2.TabIndex = 24;
            // 
            // role_combo
            // 
            role_combo.Anchor = AnchorStyles.None;
            role_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            role_combo.Font = new Font("Segoe UI Semibold", 20F);
            role_combo.FormattingEnabled = true;
            role_combo.Items.AddRange(new object[] { "cashier", "chef", "manager", "superadmin" });
            role_combo.Location = new Point(500, 267);
            role_combo.Name = "role_combo";
            role_combo.Size = new Size(450, 53);
            role_combo.TabIndex = 23;
            // 
            // salary_txtbox
            // 
            salary_txtbox.Anchor = AnchorStyles.None;
            salary_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            salary_txtbox.Location = new Point(500, 617);
            salary_txtbox.MaxLength = 13;
            salary_txtbox.Name = "salary_txtbox";
            salary_txtbox.Size = new Size(450, 52);
            salary_txtbox.TabIndex = 22;
            // 
            // phone_txtbox
            // 
            phone_txtbox.Anchor = AnchorStyles.None;
            phone_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            phone_txtbox.Location = new Point(500, 407);
            phone_txtbox.MaxLength = 12;
            phone_txtbox.Name = "phone_txtbox";
            phone_txtbox.Size = new Size(450, 52);
            phone_txtbox.TabIndex = 21;
            // 
            // email_txtbox
            // 
            email_txtbox.Anchor = AnchorStyles.None;
            email_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            email_txtbox.Location = new Point(500, 337);
            email_txtbox.MaxLength = 40;
            email_txtbox.Name = "email_txtbox";
            email_txtbox.Size = new Size(450, 52);
            email_txtbox.TabIndex = 20;
            // 
            // lname_txtbox
            // 
            lname_txtbox.Anchor = AnchorStyles.None;
            lname_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            lname_txtbox.Location = new Point(500, 197);
            lname_txtbox.MaxLength = 30;
            lname_txtbox.Name = "lname_txtbox";
            lname_txtbox.Size = new Size(450, 52);
            lname_txtbox.TabIndex = 19;
            // 
            // fname_txtbox
            // 
            fname_txtbox.Anchor = AnchorStyles.None;
            fname_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            fname_txtbox.Location = new Point(500, 127);
            fname_txtbox.MaxLength = 30;
            fname_txtbox.Name = "fname_txtbox";
            fname_txtbox.Size = new Size(450, 52);
            fname_txtbox.TabIndex = 18;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 20F);
            label9.Location = new Point(113, 690);
            label9.Name = "label9";
            label9.Size = new Size(123, 46);
            label9.TabIndex = 17;
            label9.Text = "Status:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 20F);
            label8.Location = new Point(113, 620);
            label8.Name = "label8";
            label8.Size = new Size(123, 46);
            label8.TabIndex = 16;
            label8.Text = "Salary:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 20F);
            label7.Location = new Point(113, 550);
            label7.Name = "label7";
            label7.Size = new Size(183, 46);
            label7.TabIndex = 15;
            label7.Text = "Start Date:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 20F);
            label6.Location = new Point(113, 480);
            label6.Name = "label6";
            label6.Size = new Size(225, 46);
            label6.TabIndex = 14;
            label6.Text = "Date of Birth:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 20F);
            label5.Location = new Point(113, 410);
            label5.Name = "label5";
            label5.Size = new Size(126, 46);
            label5.TabIndex = 13;
            label5.Text = "Phone:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 20F);
            label4.Location = new Point(113, 340);
            label4.Name = "label4";
            label4.Size = new Size(112, 46);
            label4.TabIndex = 12;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20F);
            label3.Location = new Point(113, 270);
            label3.Name = "label3";
            label3.Size = new Size(95, 46);
            label3.TabIndex = 11;
            label3.Text = "Role:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F);
            label2.Location = new Point(113, 200);
            label2.Name = "label2";
            label2.Size = new Size(191, 46);
            label2.TabIndex = 10;
            label2.Text = "Last Name:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F);
            label1.Location = new Point(113, 130);
            label1.Name = "label1";
            label1.Size = new Size(195, 46);
            label1.TabIndex = 9;
            label1.Text = "First Name:";
            // 
            // totalorder_label
            // 
            totalorder_label.Font = new Font("Microsoft Sans Serif", 50F, FontStyle.Bold);
            totalorder_label.ForeColor = Color.FromArgb(220, 38, 127);
            totalorder_label.ImageAlign = ContentAlignment.BottomCenter;
            totalorder_label.Location = new Point(12, 9);
            totalorder_label.Name = "totalorder_label";
            totalorder_label.Size = new Size(1087, 118);
            totalorder_label.TabIndex = 8;
            totalorder_label.Text = "EMPLOYEE - ADD/EDIT";
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panel1);
            Name = "EditEmployee";
            Text = "EditEmployee";
            FormClosing += EditEmployee_FormClosing;
            Load += EditEmployee_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label totalorder_label;
        private Label label1;
        private Label label2;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox salary_txtbox;
        private TextBox phone_txtbox;
        private TextBox email_txtbox;
        private TextBox lname_txtbox;
        private TextBox fname_txtbox;
        private ComboBox comboBox2;
        private ComboBox role_combo;
        private DateTimePicker startdate;
        private DateTimePicker DOB;
        private Button submit_btn;
    }
}