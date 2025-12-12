namespace Project.MainPages.Edit
{
    partial class EditInventory
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
            dateTimePicker1 = new DateTimePicker();
            submit_btn = new Button();
            shelf_txtbox = new TextBox();
            batch_txtbox = new TextBox();
            amount_txtbox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            name_txtbox = new TextBox();
            label1 = new Label();
            totalorder_label = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(submit_btn);
            panel1.Controls.Add(shelf_txtbox);
            panel1.Controls.Add(batch_txtbox);
            panel1.Controls.Add(amount_txtbox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(name_txtbox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(totalorder_label);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 753);
            panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 12F);
            dateTimePicker1.Location = new Point(500, 435);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(450, 34);
            dateTimePicker1.TabIndex = 21;
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
            submit_btn.TabIndex = 20;
            submit_btn.Text = "Submit";
            submit_btn.UseVisualStyleBackColor = false;
            submit_btn.Click += submit_btn_Click;
            // 
            // shelf_txtbox
            // 
            shelf_txtbox.Anchor = AnchorStyles.None;
            shelf_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            shelf_txtbox.Location = new Point(500, 524);
            shelf_txtbox.MaxLength = 50;
            shelf_txtbox.Name = "shelf_txtbox";
            shelf_txtbox.Size = new Size(450, 52);
            shelf_txtbox.TabIndex = 17;
            // 
            // batch_txtbox
            // 
            batch_txtbox.Anchor = AnchorStyles.None;
            batch_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            batch_txtbox.Location = new Point(500, 324);
            batch_txtbox.MaxLength = 20;
            batch_txtbox.Name = "batch_txtbox";
            batch_txtbox.Size = new Size(450, 52);
            batch_txtbox.TabIndex = 16;
            // 
            // amount_txtbox
            // 
            amount_txtbox.Anchor = AnchorStyles.None;
            amount_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            amount_txtbox.Location = new Point(500, 221);
            amount_txtbox.MaxLength = 11;
            amount_txtbox.Name = "amount_txtbox";
            amount_txtbox.Size = new Size(450, 52);
            amount_txtbox.TabIndex = 15;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 20F);
            label6.Location = new Point(113, 527);
            label6.Name = "label6";
            label6.Size = new Size(161, 46);
            label6.TabIndex = 14;
            label6.Text = "Shelf No:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 20F);
            label5.Location = new Point(113, 427);
            label5.Name = "label5";
            label5.Size = new Size(204, 46);
            label5.TabIndex = 13;
            label5.Text = "Expire Date:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 20F);
            label4.Location = new Point(113, 327);
            label4.Name = "label4";
            label4.Size = new Size(170, 46);
            label4.TabIndex = 12;
            label4.Text = "Batch No:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20F);
            label3.Location = new Point(113, 227);
            label3.Name = "label3";
            label3.Size = new Size(153, 46);
            label3.TabIndex = 11;
            label3.Text = "Amount:";
            // 
            // name_txtbox
            // 
            name_txtbox.Anchor = AnchorStyles.None;
            name_txtbox.Font = new Font("Segoe UI Semibold", 20F);
            name_txtbox.Location = new Point(500, 127);
            name_txtbox.MaxLength = 30;
            name_txtbox.Name = "name_txtbox";
            name_txtbox.Size = new Size(450, 52);
            name_txtbox.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F);
            label1.Location = new Point(113, 130);
            label1.Name = "label1";
            label1.Size = new Size(117, 46);
            label1.TabIndex = 8;
            label1.Text = "Menu:";
            // 
            // totalorder_label
            // 
            totalorder_label.Font = new Font("Microsoft Sans Serif", 50F, FontStyle.Bold);
            totalorder_label.ForeColor = Color.FromArgb(220, 38, 127);
            totalorder_label.ImageAlign = ContentAlignment.BottomCenter;
            totalorder_label.Location = new Point(12, 9);
            totalorder_label.Name = "totalorder_label";
            totalorder_label.Size = new Size(1087, 118);
            totalorder_label.TabIndex = 7;
            totalorder_label.Text = "INVENTORY - ADD/EDIT";
            // 
            // EditInventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panel1);
            Name = "EditInventory";
            Text = "EditInventory";
            FormClosing += EditInventory_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label totalorder_label;
        private TextBox name_txtbox;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox batch_txtbox;
        private TextBox shelf_txtbox;
        private Button submit_btn;
        private DateTimePicker dateTimePicker1;
        private TextBox amount_txtbox;
    }
}