namespace Project.MainPages
{
    partial class InventoryPage
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
            panel1 = new Panel();
            page_number = new TextBox();
            next_btn = new Button();
            add_btn = new Button();
            page_label = new Label();
            Edit_btn = new Button();
            prev_btn = new Button();
            delete_btn = new Button();
            direction_combo = new ComboBox();
            sort_combo = new ComboBox();
            label1 = new Label();
            search_btn = new Button();
            search_txtbox = new TextBox();
            totalorder_label = new Label();
            back_btn = new Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(page_number);
            panel1.Controls.Add(next_btn);
            panel1.Controls.Add(add_btn);
            panel1.Controls.Add(page_label);
            panel1.Controls.Add(Edit_btn);
            panel1.Controls.Add(prev_btn);
            panel1.Controls.Add(delete_btn);
            panel1.Controls.Add(direction_combo);
            panel1.Controls.Add(sort_combo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(search_btn);
            panel1.Controls.Add(search_txtbox);
            panel1.Controls.Add(totalorder_label);
            panel1.Controls.Add(back_btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 182);
            panel1.TabIndex = 0;
            // 
            // page_number
            // 
            page_number.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            page_number.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            page_number.Location = new Point(54, 98);
            page_number.Name = "page_number";
            page_number.Size = new Size(83, 36);
            page_number.TabIndex = 15;
            page_number.Text = "0";
            page_number.TextAlign = HorizontalAlignment.Right;
            page_number.KeyDown += page_number_KeyDown;
            // 
            // next_btn
            // 
            next_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            next_btn.BackColor = Color.FromArgb(22, 110, 170);
            next_btn.Font = new Font("Microsoft Sans Serif", 15F);
            next_btn.ForeColor = Color.White;
            next_btn.Location = new Point(221, 99);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(35, 35);
            next_btn.TabIndex = 9;
            next_btn.Text = ">";
            next_btn.UseVisualStyleBackColor = false;
            next_btn.Click += next_btn_Click;
            // 
            // add_btn
            // 
            add_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            add_btn.BackColor = Color.FromArgb(255, 79, 1);
            add_btn.Font = new Font("Segoe UI Semibold", 14F);
            add_btn.ForeColor = Color.White;
            add_btn.Location = new Point(840, 123);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(107, 52);
            add_btn.TabIndex = 14;
            add_btn.Text = "Add";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // page_label
            // 
            page_label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            page_label.Font = new Font("Microsoft Sans Serif", 15F);
            page_label.Location = new Point(143, 101);
            page_label.Name = "page_label";
            page_label.Size = new Size(72, 29);
            page_label.TabIndex = 8;
            page_label.Text = "/0";
            page_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Edit_btn
            // 
            Edit_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Edit_btn.BackColor = Color.FromArgb(255, 178, 11);
            Edit_btn.Font = new Font("Segoe UI Semibold", 14F);
            Edit_btn.ForeColor = Color.White;
            Edit_btn.Location = new Point(953, 124);
            Edit_btn.Name = "Edit_btn";
            Edit_btn.Size = new Size(107, 52);
            Edit_btn.TabIndex = 13;
            Edit_btn.Text = "Edit";
            Edit_btn.UseVisualStyleBackColor = false;
            Edit_btn.Click += Edit_btn_Click;
            // 
            // prev_btn
            // 
            prev_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            prev_btn.BackColor = Color.FromArgb(22, 110, 170);
            prev_btn.Font = new Font("Microsoft Sans Serif", 15F);
            prev_btn.ForeColor = Color.White;
            prev_btn.Location = new Point(13, 99);
            prev_btn.Name = "prev_btn";
            prev_btn.Size = new Size(35, 35);
            prev_btn.TabIndex = 7;
            prev_btn.Text = "<";
            prev_btn.UseVisualStyleBackColor = false;
            prev_btn.Click += prev_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            delete_btn.BackColor = Color.Black;
            delete_btn.Font = new Font("Segoe UI Semibold", 14F);
            delete_btn.ForeColor = Color.White;
            delete_btn.Location = new Point(1066, 123);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(107, 52);
            delete_btn.TabIndex = 12;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // direction_combo
            // 
            direction_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            direction_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            direction_combo.Font = new Font("Segoe UI Semibold", 14F);
            direction_combo.FormattingEnabled = true;
            direction_combo.Items.AddRange(new object[] { "ASC", "DESC" });
            direction_combo.Location = new Point(304, 140);
            direction_combo.Name = "direction_combo";
            direction_combo.Size = new Size(93, 39);
            direction_combo.TabIndex = 11;
            direction_combo.SelectedIndexChanged += direction_combo_SelectedIndexChanged;
            // 
            // sort_combo
            // 
            sort_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            sort_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            sort_combo.Font = new Font("Segoe UI Semibold", 14F);
            sort_combo.FormattingEnabled = true;
            sort_combo.Items.AddRange(new object[] { "ID", "Quantity", "Batch", "Expired Date" });
            sort_combo.Location = new Point(114, 140);
            sort_combo.Name = "sort_combo";
            sort_combo.Size = new Size(184, 39);
            sort_combo.TabIndex = 10;
            sort_combo.SelectedIndexChanged += sort_combo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F);
            label1.Location = new Point(9, 143);
            label1.Name = "label1";
            label1.Size = new Size(99, 32);
            label1.TabIndex = 9;
            label1.Text = "Sort by:";
            // 
            // search_btn
            // 
            search_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            search_btn.BackgroundImage = Properties.Resources.search;
            search_btn.BackgroundImageLayout = ImageLayout.Zoom;
            search_btn.Location = new Point(654, 140);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(39, 39);
            search_btn.TabIndex = 8;
            search_btn.TextAlign = ContentAlignment.TopCenter;
            search_btn.UseVisualStyleBackColor = true;
            search_btn.Click += search_btn_Click;
            // 
            // search_txtbox
            // 
            search_txtbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            search_txtbox.Font = new Font("Segoe UI Semibold", 14F);
            search_txtbox.Location = new Point(420, 140);
            search_txtbox.Name = "search_txtbox";
            search_txtbox.Size = new Size(228, 39);
            search_txtbox.TabIndex = 7;
            search_txtbox.KeyDown += search_txtbox_KeyDown;
            // 
            // totalorder_label
            // 
            totalorder_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalorder_label.Font = new Font("Microsoft Sans Serif", 50F, FontStyle.Bold);
            totalorder_label.ForeColor = Color.FromArgb(220, 38, 127);
            totalorder_label.ImageAlign = ContentAlignment.BottomCenter;
            totalorder_label.Location = new Point(594, 6);
            totalorder_label.Name = "totalorder_label";
            totalorder_label.Size = new Size(573, 118);
            totalorder_label.TabIndex = 6;
            totalorder_label.Text = "INVENTORY";
            totalorder_label.TextAlign = ContentAlignment.TopRight;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.FromArgb(220, 38, 127);
            back_btn.Font = new Font("Segoe UI Semibold", 14F);
            back_btn.ForeColor = Color.White;
            back_btn.Location = new Point(9, 9);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(146, 65);
            back_btn.TabIndex = 5;
            back_btn.Text = "Back";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 191);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1176, 559);
            dataGridView1.TabIndex = 1;
            // 
            // InventoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "InventoryPage";
            Text = "InventoryPage";
            FormClosing += InventoryPage_FormClosing;
            Load += InventoryPage_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button back_btn;
        private Label totalorder_label;
        private Button search_btn;
        private TextBox search_txtbox;
        private ComboBox sort_combo;
        private Label label1;
        private ComboBox direction_combo;
        private Button Edit_btn;
        private Button delete_btn;
        private Button add_btn;
        private Button next_btn;
        private Label page_label;
        private Button prev_btn;
        private TextBox page_number;
    }
}