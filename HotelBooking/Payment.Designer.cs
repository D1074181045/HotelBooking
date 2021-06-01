namespace HotelBooking
{
    partial class Payment
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.dgvPaymentList = new System.Windows.Forms.DataGridView();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitPayment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Submit_lbl = new System.Windows.Forms.Label();
            this.captcha_pic1 = new System.Windows.Forms.PictureBox();
            this.captcha_pic2 = new System.Windows.Forms.PictureBox();
            this.captcha_pic3 = new System.Windows.Forms.PictureBox();
            this.captcha_pic4 = new System.Windows.Forms.PictureBox();
            this.captcha_tb = new System.Windows.Forms.TextBox();
            this.number_btn = new System.Windows.Forms.Button();
            this.comments_btn = new System.Windows.Forms.Button();
            this.SubmitPayment_btn = new System.Windows.Forms.Button();
            this.captcha_imglist = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Customer_list = new System.Windows.Forms.CheckedListBox();
            this.captcha_imglist2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPaymentList
            // 
            this.dgvPaymentList.AllowUserToAddRows = false;
            this.dgvPaymentList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.City,
            this.HotelName,
            this.Room,
            this.SrartDate,
            this.EndDate,
            this.Days,
            this.Code,
            this.DueAmount,
            this.SubmitPayment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentList.Location = new System.Drawing.Point(25, 216);
            this.dgvPaymentList.Name = "dgvPaymentList";
            this.dgvPaymentList.ReadOnly = true;
            this.dgvPaymentList.RowTemplate.Height = 24;
            this.dgvPaymentList.Size = new System.Drawing.Size(1041, 206);
            this.dgvPaymentList.TabIndex = 0;
            this.dgvPaymentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentList_CellContentClick);
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // HotelName
            // 
            this.HotelName.HeaderText = "Hotel Name";
            this.HotelName.Name = "HotelName";
            this.HotelName.ReadOnly = true;
            // 
            // Room
            // 
            this.Room.HeaderText = "Room";
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            // 
            // SrartDate
            // 
            this.SrartDate.HeaderText = "Srart Date";
            this.SrartDate.Name = "SrartDate";
            this.SrartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Days
            // 
            this.Days.HeaderText = "Days";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // DueAmount
            // 
            this.DueAmount.HeaderText = "Due Amount";
            this.DueAmount.Name = "DueAmount";
            this.DueAmount.ReadOnly = true;
            // 
            // SubmitPayment
            // 
            this.SubmitPayment.HeaderText = "Submit Payment";
            this.SubmitPayment.Name = "SubmitPayment";
            this.SubmitPayment.ReadOnly = true;
            this.SubmitPayment.Text = "ToPay";
            this.SubmitPayment.UseColumnTextForButtonValue = true;
            // 
            // Submit_lbl
            // 
            this.Submit_lbl.AutoSize = true;
            this.Submit_lbl.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit_lbl.ForeColor = System.Drawing.Color.Chocolate;
            this.Submit_lbl.Location = new System.Drawing.Point(40, 459);
            this.Submit_lbl.Name = "Submit_lbl";
            this.Submit_lbl.Size = new System.Drawing.Size(257, 18);
            this.Submit_lbl.TabIndex = 2;
            this.Submit_lbl.Text = "Submit the payment for hotel:";
            // 
            // captcha_pic1
            // 
            this.captcha_pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captcha_pic1.Location = new System.Drawing.Point(43, 515);
            this.captcha_pic1.Name = "captcha_pic1";
            this.captcha_pic1.Size = new System.Drawing.Size(32, 50);
            this.captcha_pic1.TabIndex = 3;
            this.captcha_pic1.TabStop = false;
            // 
            // captcha_pic2
            // 
            this.captcha_pic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captcha_pic2.Location = new System.Drawing.Point(90, 515);
            this.captcha_pic2.Name = "captcha_pic2";
            this.captcha_pic2.Size = new System.Drawing.Size(32, 50);
            this.captcha_pic2.TabIndex = 4;
            this.captcha_pic2.TabStop = false;
            // 
            // captcha_pic3
            // 
            this.captcha_pic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captcha_pic3.Location = new System.Drawing.Point(137, 515);
            this.captcha_pic3.Name = "captcha_pic3";
            this.captcha_pic3.Size = new System.Drawing.Size(32, 50);
            this.captcha_pic3.TabIndex = 5;
            this.captcha_pic3.TabStop = false;
            // 
            // captcha_pic4
            // 
            this.captcha_pic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captcha_pic4.Location = new System.Drawing.Point(184, 515);
            this.captcha_pic4.Name = "captcha_pic4";
            this.captcha_pic4.Size = new System.Drawing.Size(32, 50);
            this.captcha_pic4.TabIndex = 6;
            this.captcha_pic4.TabStop = false;
            // 
            // captcha_tb
            // 
            this.captcha_tb.Location = new System.Drawing.Point(243, 515);
            this.captcha_tb.Name = "captcha_tb";
            this.captcha_tb.Size = new System.Drawing.Size(51, 22);
            this.captcha_tb.TabIndex = 7;
            // 
            // number_btn
            // 
            this.number_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.number_btn.Location = new System.Drawing.Point(318, 515);
            this.number_btn.Name = "number_btn";
            this.number_btn.Size = new System.Drawing.Size(186, 50);
            this.number_btn.TabIndex = 8;
            this.number_btn.Text = "Enter number and press";
            this.number_btn.UseVisualStyleBackColor = true;
            this.number_btn.Click += new System.EventHandler(this.number_btn_Click);
            // 
            // comments_btn
            // 
            this.comments_btn.Enabled = false;
            this.comments_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comments_btn.Location = new System.Drawing.Point(605, 515);
            this.comments_btn.Name = "comments_btn";
            this.comments_btn.Size = new System.Drawing.Size(186, 50);
            this.comments_btn.TabIndex = 9;
            this.comments_btn.Text = "Give your comments...";
            this.comments_btn.UseVisualStyleBackColor = true;
            this.comments_btn.Click += new System.EventHandler(this.comments_btn_Click);
            // 
            // SubmitPayment_btn
            // 
            this.SubmitPayment_btn.Enabled = false;
            this.SubmitPayment_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SubmitPayment_btn.Location = new System.Drawing.Point(837, 515);
            this.SubmitPayment_btn.Name = "SubmitPayment_btn";
            this.SubmitPayment_btn.Size = new System.Drawing.Size(186, 50);
            this.SubmitPayment_btn.TabIndex = 10;
            this.SubmitPayment_btn.Text = "Submit payment...";
            this.SubmitPayment_btn.UseVisualStyleBackColor = true;
            this.SubmitPayment_btn.Click += new System.EventHandler(this.SubmitPayment_btn_Click);
            // 
            // captcha_imglist
            // 
            this.captcha_imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("captcha_imglist.ImageStream")));
            this.captcha_imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.captcha_imglist.Images.SetKeyName(0, "zero.jpg");
            this.captcha_imglist.Images.SetKeyName(1, "one.jpg");
            this.captcha_imglist.Images.SetKeyName(2, "two.jpg");
            this.captcha_imglist.Images.SetKeyName(3, "three.jpg");
            this.captcha_imglist.Images.SetKeyName(4, "four.jpg");
            this.captcha_imglist.Images.SetKeyName(5, "five.jpg");
            this.captcha_imglist.Images.SetKeyName(6, "six.jpg");
            this.captcha_imglist.Images.SetKeyName(7, "seven.jpg");
            this.captcha_imglist.Images.SetKeyName(8, "eight.jpg");
            this.captcha_imglist.Images.SetKeyName(9, "nine.jpg");
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Customer_list
            // 
            this.Customer_list.CheckOnClick = true;
            this.Customer_list.FormattingEnabled = true;
            this.Customer_list.Location = new System.Drawing.Point(25, 23);
            this.Customer_list.Name = "Customer_list";
            this.Customer_list.Size = new System.Drawing.Size(232, 174);
            this.Customer_list.TabIndex = 11;
            this.Customer_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Customer_list_view_ItemsCheck);
            // 
            // captcha_imglist2
            // 
            this.captcha_imglist2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("captcha_imglist2.ImageStream")));
            this.captcha_imglist2.TransparentColor = System.Drawing.Color.Transparent;
            this.captcha_imglist2.Images.SetKeyName(0, "zero_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(1, "one_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(2, "two_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(3, "three_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(4, "four_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(5, "five_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(6, "six_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(7, "seven_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(8, "eight_1.jpg");
            this.captcha_imglist2.Images.SetKeyName(9, "nine_1.jpg");
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1089, 445);
            this.Controls.Add(this.Customer_list);
            this.Controls.Add(this.SubmitPayment_btn);
            this.Controls.Add(this.comments_btn);
            this.Controls.Add(this.number_btn);
            this.Controls.Add(this.captcha_tb);
            this.Controls.Add(this.captcha_pic4);
            this.Controls.Add(this.captcha_pic3);
            this.Controls.Add(this.captcha_pic2);
            this.Controls.Add(this.captcha_pic1);
            this.Controls.Add(this.Submit_lbl);
            this.Controls.Add(this.dgvPaymentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.ShowIcon = false;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captcha_pic4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPaymentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueAmount;
        private System.Windows.Forms.DataGridViewButtonColumn SubmitPayment;
        private System.Windows.Forms.Label Submit_lbl;
        private System.Windows.Forms.PictureBox captcha_pic1;
        private System.Windows.Forms.PictureBox captcha_pic2;
        private System.Windows.Forms.PictureBox captcha_pic3;
        private System.Windows.Forms.PictureBox captcha_pic4;
        private System.Windows.Forms.TextBox captcha_tb;
        private System.Windows.Forms.Button number_btn;
        private System.Windows.Forms.Button comments_btn;
        private System.Windows.Forms.Button SubmitPayment_btn;
        private System.Windows.Forms.ImageList captcha_imglist;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckedListBox Customer_list;
        private System.Windows.Forms.ImageList captcha_imglist2;
    }
}