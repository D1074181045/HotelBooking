namespace HotelBooking
{
    partial class SelectHotel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Make_Payment = new System.Windows.Forms.ToolStripLabel();
            this.About = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.Find_btn = new System.Windows.Forms.Button();
            this.dgvHotelList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Load_btn = new System.Windows.Forms.Button();
            this.Select_city = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotelList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Silver;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Make_Payment,
            this.About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(899, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Make_Payment
            // 
            this.Make_Payment.IsLink = true;
            this.Make_Payment.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Make_Payment.LinkColor = System.Drawing.Color.Black;
            this.Make_Payment.Name = "Make_Payment";
            this.Make_Payment.Size = new System.Drawing.Size(92, 22);
            this.Make_Payment.Text = "Make Payment";
            this.Make_Payment.Click += new System.EventHandler(this.Make_Payment_Click);
            // 
            // About
            // 
            this.About.IsLink = true;
            this.About.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.About.LinkColor = System.Drawing.Color.Black;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(43, 22);
            this.About.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "選取城市：";
            // 
            // Find_btn
            // 
            this.Find_btn.Location = new System.Drawing.Point(169, 64);
            this.Find_btn.Name = "Find_btn";
            this.Find_btn.Size = new System.Drawing.Size(75, 23);
            this.Find_btn.TabIndex = 3;
            this.Find_btn.Text = "Find...";
            this.Find_btn.UseVisualStyleBackColor = true;
            this.Find_btn.Click += new System.EventHandler(this.Find_Click);
            // 
            // dgvHotelList
            // 
            this.dgvHotelList.AllowUserToAddRows = false;
            this.dgvHotelList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvHotelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHotelList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHotelList.Location = new System.Drawing.Point(26, 112);
            this.dgvHotelList.Name = "dgvHotelList";
            this.dgvHotelList.ReadOnly = true;
            this.dgvHotelList.RowTemplate.Height = 24;
            this.dgvHotelList.Size = new System.Drawing.Size(842, 505);
            this.dgvHotelList.TabIndex = 4;
            this.dgvHotelList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHotelList_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "收尋結果：XX個飯店";
            this.label2.Visible = false;
            // 
            // Load_btn
            // 
            this.Load_btn.Location = new System.Drawing.Point(368, 64);
            this.Load_btn.Name = "Load_btn";
            this.Load_btn.Size = new System.Drawing.Size(75, 23);
            this.Load_btn.TabIndex = 6;
            this.Load_btn.Text = "Load...";
            this.Load_btn.UseVisualStyleBackColor = true;
            this.Load_btn.Visible = false;
            this.Load_btn.Click += new System.EventHandler(this.Load_Click);
            // 
            // Select_city
            // 
            this.Select_city.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Select_city.FormattingEnabled = true;
            this.Select_city.ItemHeight = 12;
            this.Select_city.Items.AddRange(new object[] {
            "Taipei",
            "Tokyo",
            "Shanghai"});
            this.Select_city.Location = new System.Drawing.Point(90, 44);
            this.Select_city.Name = "Select_city";
            this.Select_city.Size = new System.Drawing.Size(73, 40);
            this.Select_city.TabIndex = 7;
            // 
            // SelectHotel
            // 
            this.AcceptButton = this.Find_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(899, 634);
            this.Controls.Add(this.Select_city);
            this.Controls.Add(this.Load_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHotelList);
            this.Controls.Add(this.Find_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SelectHotel";
            this.Text = "Select a hotel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectHotel_Closing);
            this.Load += new System.EventHandler(this.SelectHotel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotelList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Make_Payment;
        private System.Windows.Forms.ToolStripLabel About;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Find_btn;
        private System.Windows.Forms.DataGridView dgvHotelList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Load_btn;
        private System.Windows.Forms.ListBox Select_city;
    }
}