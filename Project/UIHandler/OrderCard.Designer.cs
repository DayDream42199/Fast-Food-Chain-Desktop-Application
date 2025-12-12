namespace Project.UIHandler
{
    partial class OrderCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            status_btn = new Button();
            status_label = new Label();
            label1 = new Label();
            panel1 = new Panel();
            orderno_label = new Label();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(392, 657);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(status_btn);
            panel2.Controls.Add(status_label);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 528);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 126);
            panel2.TabIndex = 1;
            // 
            // status_btn
            // 
            status_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            status_btn.BackColor = Color.Black;
            status_btn.Font = new Font("Microsoft Sans Serif", 15F);
            status_btn.ForeColor = Color.White;
            status_btn.Location = new Point(210, 40);
            status_btn.Name = "status_btn";
            status_btn.Size = new Size(173, 83);
            status_btn.TabIndex = 3;
            status_btn.Text = "Complete";
            status_btn.UseVisualStyleBackColor = false;
            status_btn.Click += status_btn_Click;
            // 
            // status_label
            // 
            status_label.Font = new Font("Microsoft Sans Serif", 15F);
            status_label.ForeColor = Color.White;
            status_label.Location = new Point(183, 0);
            status_label.Name = "status_label";
            status_label.Size = new Size(200, 32);
            status_label.TabIndex = 2;
            status_label.Text = "ReadyOr...";
            status_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(184, 32);
            label1.TabIndex = 1;
            label1.Text = "Current status:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 110, 170);
            panel1.Controls.Add(orderno_label);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 92);
            panel1.TabIndex = 2;
            // 
            // orderno_label
            // 
            orderno_label.Font = new Font("Microsoft Sans Serif", 20F);
            orderno_label.ForeColor = Color.White;
            orderno_label.ImageAlign = ContentAlignment.TopCenter;
            orderno_label.Location = new Point(143, 17);
            orderno_label.Name = "orderno_label";
            orderno_label.Size = new Size(243, 43);
            orderno_label.TabIndex = 0;
            orderno_label.Text = "Order #0000 ";
            orderno_label.TextAlign = ContentAlignment.TopRight;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 101);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(386, 421);
            dataGridView1.TabIndex = 3;
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "OrderCard";
            Size = new Size(392, 657);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel1;
        private Label orderno_label;
        private DataGridView dataGridView1;
        private Label status_label;
        private Label label1;
        private Button status_btn;
    }
}
