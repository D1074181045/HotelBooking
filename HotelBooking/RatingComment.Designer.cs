namespace HotelBooking
{
    partial class RatingComment
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
            this.hotel_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Rating_list = new System.Windows.Forms.ListBox();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comment_tbox = new System.Windows.Forms.TextBox();
            this.Save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hotel_lbl
            // 
            this.hotel_lbl.AutoSize = true;
            this.hotel_lbl.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotel_lbl.ForeColor = System.Drawing.Color.Red;
            this.hotel_lbl.Location = new System.Drawing.Point(12, 9);
            this.hotel_lbl.Name = "hotel_lbl";
            this.hotel_lbl.Size = new System.Drawing.Size(156, 22);
            this.hotel_lbl.TabIndex = 0;
            this.hotel_lbl.Text = "City - HotelName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rating";
            // 
            // Rating_list
            // 
            this.Rating_list.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Rating_list.FormattingEnabled = true;
            this.Rating_list.Items.AddRange(new object[] {
            "Excellent (A)",
            "Good (B)",
            "Fair (C)",
            "Poor (D)",
            "Not Recommand (E)",
            "N/A (F)"});
            this.Rating_list.Location = new System.Drawing.Point(58, 53);
            this.Rating_list.Name = "Rating_list";
            this.Rating_list.Size = new System.Drawing.Size(110, 82);
            this.Rating_list.TabIndex = 5;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(397, 340);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 31);
            this.Cancel_btn.TabIndex = 6;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(9, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your moment：";
            // 
            // comment_tbox
            // 
            this.comment_tbox.Location = new System.Drawing.Point(12, 186);
            this.comment_tbox.Multiline = true;
            this.comment_tbox.Name = "comment_tbox";
            this.comment_tbox.Size = new System.Drawing.Size(460, 135);
            this.comment_tbox.TabIndex = 8;
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(14, 339);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(75, 31);
            this.Save_btn.TabIndex = 9;
            this.Save_btn.Text = "Save";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // RatingComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 385);
            this.ControlBox = false;
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.comment_tbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Rating_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotel_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RatingComment";
            this.Text = "Rating and Comment";
            this.Load += new System.EventHandler(this.RatingComment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hotel_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Rating_list;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox comment_tbox;
        private System.Windows.Forms.Button Save_btn;
    }
}