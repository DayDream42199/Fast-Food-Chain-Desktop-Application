namespace Project.MainPages.Edit
{
    partial class EditAccount
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
            cpass_txtbox = new TextBox();
            pass_txtbox = new TextBox();
            user_txtbox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            totalorder_label = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(submit_btn);
            panel1.Controls.Add(cpass_txtbox);
            panel1.Controls.Add(pass_txtbox);
            panel1.Controls.Add(user_txtbox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
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
            submit_btn.Location = new Point(1015, 646);
            submit_btn.Name = "submit_btn";
            submit_btn.Size = new Size(155, 96);
            submit_btn.TabIndex = 36;
            submit_btn.Text = "Submit";
            submit_btn.UseVisualStyleBackColor = false;
            submit_btn.Click += submit_btn_Click;
            // 
            // cpass_txtbox
            // 
            cpass_txtbox.Anchor = AnchorStyles.None;
            cpass_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            cpass_txtbox.Location = new Point(500, 428);
            cpass_txtbox.MaxLength = 72;
            cpass_txtbox.Name = "cpass_txtbox";
            cpass_txtbox.PasswordChar = '*';
            cpass_txtbox.Size = new Size(450, 52);
            cpass_txtbox.TabIndex = 35;
            // 
            // pass_txtbox
            // 
            pass_txtbox.Anchor = AnchorStyles.None;
            pass_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            pass_txtbox.Location = new Point(500, 328);
            pass_txtbox.MaxLength = 72;
            pass_txtbox.Name = "pass_txtbox";
            pass_txtbox.PasswordChar = '*';
            pass_txtbox.Size = new Size(450, 52);
            pass_txtbox.TabIndex = 34;
            // 
            // user_txtbox
            // 
            user_txtbox.Anchor = AnchorStyles.None;
            user_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            user_txtbox.Location = new Point(500, 228);
            user_txtbox.MaxLength = 30;
            user_txtbox.Name = "user_txtbox";
            user_txtbox.Size = new Size(450, 52);
            user_txtbox.TabIndex = 33;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 20F);
            label5.Location = new Point(113, 431);
            label5.Name = "label5";
            label5.Size = new Size(308, 46);
            label5.TabIndex = 32;
            label5.Text = "Confirm Password:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 20F);
            label4.Location = new Point(113, 331);
            label4.Name = "label4";
            label4.Size = new Size(174, 46);
            label4.TabIndex = 31;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20F);
            label3.Location = new Point(113, 231);
            label3.Name = "label3";
            label3.Size = new Size(184, 46);
            label3.TabIndex = 30;
            label3.Text = "Username:";
            // 
            // totalorder_label
            // 
            totalorder_label.Font = new Font("Microsoft Sans Serif", 50F, FontStyle.Bold);
            totalorder_label.ForeColor = Color.FromArgb(220, 38, 127);
            totalorder_label.ImageAlign = ContentAlignment.BottomCenter;
            totalorder_label.Location = new Point(12, 10);
            totalorder_label.Name = "totalorder_label";
            totalorder_label.Size = new Size(1087, 118);
            totalorder_label.TabIndex = 29;
            totalorder_label.Text = "ACCOUNT - EDIT";
            // 
            // EditAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panel1);
            Name = "EditAccount";
            Text = "EditAccount";
            FormClosing += EditAccount_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button submit_btn;
        private TextBox cpass_txtbox;
        private TextBox pass_txtbox;
        private TextBox user_txtbox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label totalorder_label;
    }
}