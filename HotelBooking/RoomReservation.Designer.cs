namespace HotelBooking
{
    partial class RoomReservation
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
            this.RoomImg_pic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Check_in_dtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Check_out_dtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Reservation_name = new System.Windows.Forms.TextBox();
            this.Reserve_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.Room_lbl = new System.Windows.Forms.Label();
            this.Price_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RoomImg_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomImg_pic
            // 
            this.RoomImg_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RoomImg_pic.Location = new System.Drawing.Point(21, 23);
            this.RoomImg_pic.Name = "RoomImg_pic";
            this.RoomImg_pic.Size = new System.Drawing.Size(720, 373);
            this.RoomImg_pic.TabIndex = 0;
            this.RoomImg_pic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(50, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(50, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price";
            // 
            // Check_in_dtp
            // 
            this.Check_in_dtp.Location = new System.Drawing.Point(141, 521);
            this.Check_in_dtp.Name = "Check_in_dtp";
            this.Check_in_dtp.Size = new System.Drawing.Size(200, 22);
            this.Check_in_dtp.TabIndex = 3;
            this.Check_in_dtp.ValueChanged += new System.EventHandler(this.Reserve_btn_EnableChecked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(50, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Check-in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(364, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Check-out";
            // 
            // Check_out_dtp
            // 
            this.Check_out_dtp.Location = new System.Drawing.Point(483, 521);
            this.Check_out_dtp.Name = "Check_out_dtp";
            this.Check_out_dtp.Size = new System.Drawing.Size(200, 22);
            this.Check_out_dtp.TabIndex = 6;
            this.Check_out_dtp.ValueChanged += new System.EventHandler(this.Reserve_btn_EnableChecked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(50, 558);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Reservation name";
            // 
            // Reservation_name
            // 
            this.Reservation_name.Location = new System.Drawing.Point(225, 559);
            this.Reservation_name.Name = "Reservation_name";
            this.Reservation_name.Size = new System.Drawing.Size(458, 22);
            this.Reservation_name.TabIndex = 8;
            this.Reservation_name.TextChanged += new System.EventHandler(this.Reserve_btn_EnableChecked);
            // 
            // Reserve_btn
            // 
            this.Reserve_btn.Enabled = false;
            this.Reserve_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Reserve_btn.Location = new System.Drawing.Point(54, 607);
            this.Reserve_btn.Name = "Reserve_btn";
            this.Reserve_btn.Size = new System.Drawing.Size(87, 33);
            this.Reserve_btn.TabIndex = 9;
            this.Reserve_btn.Text = "Reserve";
            this.Reserve_btn.UseVisualStyleBackColor = true;
            this.Reserve_btn.Click += new System.EventHandler(this.Reserve_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Cancel_btn.Location = new System.Drawing.Point(196, 607);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(87, 33);
            this.Cancel_btn.TabIndex = 10;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Room_lbl
            // 
            this.Room_lbl.AutoSize = true;
            this.Room_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Room_lbl.ForeColor = System.Drawing.Color.Orange;
            this.Room_lbl.Location = new System.Drawing.Point(137, 434);
            this.Room_lbl.Name = "Room_lbl";
            this.Room_lbl.Size = new System.Drawing.Size(79, 24);
            this.Room_lbl.TabIndex = 11;
            this.Room_lbl.Text = "HOTEL";
            // 
            // Price_lbl
            // 
            this.Price_lbl.AutoSize = true;
            this.Price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Price_lbl.ForeColor = System.Drawing.Color.Orange;
            this.Price_lbl.Location = new System.Drawing.Point(137, 478);
            this.Price_lbl.Name = "Price_lbl";
            this.Price_lbl.Size = new System.Drawing.Size(49, 24);
            this.Price_lbl.TabIndex = 12;
            this.Price_lbl.Text = "192.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("標楷體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Magenta;
            this.label6.Location = new System.Drawing.Point(496, 584);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "At least 8 charaters";
            // 
            // Room_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 665);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Price_lbl);
            this.Controls.Add(this.Room_lbl);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Reserve_btn);
            this.Controls.Add(this.Reservation_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Check_out_dtp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Check_in_dtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoomImg_pic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Room_Reservation";
            this.Text = "Room Reservation";
            this.Load += new System.EventHandler(this.RoomReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomImg_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RoomImg_pic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Check_in_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Check_out_dtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Reservation_name;
        private System.Windows.Forms.Button Reserve_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Label Room_lbl;
        private System.Windows.Forms.Label Price_lbl;
        private System.Windows.Forms.Label label6;
    }
}