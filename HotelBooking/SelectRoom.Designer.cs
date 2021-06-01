namespace HotelBooking
{
    partial class SelectRoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hotel_title = new System.Windows.Forms.Label();
            this.dgvRoomList = new System.Windows.Forms.DataGridView();
            this.Comment_btn = new System.Windows.Forms.Button();
            this.reservation_btn = new System.Windows.Forms.Button();
            this.Select_Priceunit = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomList)).BeginInit();
            this.SuspendLayout();
            // 
            // hotel_title
            // 
            this.hotel_title.AutoSize = true;
            this.hotel_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hotel_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotel_title.ForeColor = System.Drawing.Color.Orange;
            this.hotel_title.Location = new System.Drawing.Point(28, 26);
            this.hotel_title.Name = "hotel_title";
            this.hotel_title.Size = new System.Drawing.Size(78, 27);
            this.hotel_title.TabIndex = 0;
            this.hotel_title.Text = "label1";
            // 
            // dgvRoomList
            // 
            this.dgvRoomList.AllowUserToAddRows = false;
            this.dgvRoomList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoomList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoomList.Location = new System.Drawing.Point(28, 111);
            this.dgvRoomList.MultiSelect = false;
            this.dgvRoomList.Name = "dgvRoomList";
            this.dgvRoomList.ReadOnly = true;
            this.dgvRoomList.RowTemplate.Height = 24;
            this.dgvRoomList.Size = new System.Drawing.Size(731, 410);
            this.dgvRoomList.TabIndex = 1;
            // 
            // Comment_btn
            // 
            this.Comment_btn.Location = new System.Drawing.Point(765, 22);
            this.Comment_btn.Name = "Comment_btn";
            this.Comment_btn.Size = new System.Drawing.Size(196, 31);
            this.Comment_btn.TabIndex = 2;
            this.Comment_btn.Text = "View User\'s Comments....";
            this.Comment_btn.UseVisualStyleBackColor = true;
            this.Comment_btn.Click += new System.EventHandler(this.Comment_btn_Click);
            // 
            // reservation_btn
            // 
            this.reservation_btn.Location = new System.Drawing.Point(556, 22);
            this.reservation_btn.Name = "reservation_btn";
            this.reservation_btn.Size = new System.Drawing.Size(203, 31);
            this.reservation_btn.TabIndex = 3;
            this.reservation_btn.Text = "Make Reservation...";
            this.reservation_btn.UseVisualStyleBackColor = true;
            this.reservation_btn.Click += new System.EventHandler(this.reservation_btn_Click);
            // 
            // Select_Priceunit
            // 
            this.Select_Priceunit.FormattingEnabled = true;
            this.Select_Priceunit.ItemHeight = 12;
            this.Select_Priceunit.Items.AddRange(new object[] {
            "TWD - Waiwan New Dollar",
            "USD - United States Dollar",
            "VND - Viet Nam Dong",
            "EUR - Euro Member Countries",
            "HKD - Hong Kong Dollar",
            "JPY - Japan Yen",
            "CNY - Chinese New Year"});
            this.Select_Priceunit.Location = new System.Drawing.Point(766, 59);
            this.Select_Priceunit.Name = "Select_Priceunit";
            this.Select_Priceunit.Size = new System.Drawing.Size(195, 40);
            this.Select_Priceunit.TabIndex = 5;
            this.Select_Priceunit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Select_Priceunit_MouseClick);
            // 
            // SelectRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(973, 543);
            this.Controls.Add(this.Select_Priceunit);
            this.Controls.Add(this.reservation_btn);
            this.Controls.Add(this.Comment_btn);
            this.Controls.Add(this.dgvRoomList);
            this.Controls.Add(this.hotel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SelectRoom";
            this.Text = "Select a room";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Select_Room_Closing);
            this.Load += new System.EventHandler(this.SelectRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hotel_title;
        private System.Windows.Forms.DataGridView dgvRoomList;
        private System.Windows.Forms.Button Comment_btn;
        private System.Windows.Forms.Button reservation_btn;
        private System.Windows.Forms.ListBox Select_Priceunit;
    }
}