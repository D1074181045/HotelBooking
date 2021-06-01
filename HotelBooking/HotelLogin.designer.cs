namespace HotelBooking
{
    partial class HotelLogin
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.User_tb = new System.Windows.Forms.TextBox();
            this.Password_tb = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.Crate_User = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.ShowPswd = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.errMsg_lbl = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(35, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼";
            // 
            // User_tb
            // 
            this.User_tb.Location = new System.Drawing.Point(96, 46);
            this.User_tb.Name = "User_tb";
            this.User_tb.Size = new System.Drawing.Size(150, 22);
            this.User_tb.TabIndex = 2;
            this.User_tb.GotFocus += new System.EventHandler(this.User_tb_GotFocus);
            // 
            // Password_tb
            // 
            this.Password_tb.Location = new System.Drawing.Point(96, 97);
            this.Password_tb.Name = "Password_tb";
            this.Password_tb.Size = new System.Drawing.Size(150, 22);
            this.Password_tb.TabIndex = 3;
            this.Password_tb.UseSystemPasswordChar = true;
            this.Password_tb.GotFocus += new System.EventHandler(this.Password_tb_GotFocus);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(230, 196);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(73, 35);
            this.login.TabIndex = 4;
            this.login.Text = "登入";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Crate_User
            // 
            this.Crate_User.Enabled = false;
            this.Crate_User.Location = new System.Drawing.Point(37, 196);
            this.Crate_User.Name = "Crate_User";
            this.Crate_User.Size = new System.Drawing.Size(103, 35);
            this.Crate_User.TabIndex = 6;
            this.Crate_User.Text = "建立使用者";
            this.Crate_User.UseVisualStyleBackColor = true;
            this.Crate_User.Click += new System.EventHandler(this.Create_User_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(393, 196);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(103, 35);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "離開";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ShowPswd
            // 
            this.ShowPswd.AutoSize = true;
            this.ShowPswd.Location = new System.Drawing.Point(251, 101);
            this.ShowPswd.Name = "ShowPswd";
            this.ShowPswd.Size = new System.Drawing.Size(72, 16);
            this.ShowPswd.TabIndex = 8;
            this.ShowPswd.Text = "顯示密碼";
            this.ShowPswd.UseVisualStyleBackColor = true;
            this.ShowPswd.CheckedChanged += new System.EventHandler(this.ShowPswd_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("標楷體", 10F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(14, 260);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(519, 14);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Successful login of config method #1, click me go to next window";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // errMsg_lbl
            // 
            this.errMsg_lbl.AutoSize = true;
            this.errMsg_lbl.Font = new System.Drawing.Font("標楷體", 10F, System.Drawing.FontStyle.Bold);
            this.errMsg_lbl.ForeColor = System.Drawing.Color.Red;
            this.errMsg_lbl.Location = new System.Drawing.Point(14, 244);
            this.errMsg_lbl.Name = "errMsg_lbl";
            this.errMsg_lbl.Size = new System.Drawing.Size(23, 14);
            this.errMsg_lbl.TabIndex = 12;
            this.errMsg_lbl.Text = "--";
            this.errMsg_lbl.Visible = false;
            // 
            // HotelLogin
            // 
            this.AcceptButton = this.login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(549, 290);
            this.Controls.Add(this.errMsg_lbl);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ShowPswd);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Crate_User);
            this.Controls.Add(this.login);
            this.Controls.Add(this.Password_tb);
            this.Controls.Add(this.User_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HotelLogin";
            this.Text = "使用者登入";
            this.Load += new System.EventHandler(this.HotelLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox User_tb;
        private System.Windows.Forms.TextBox Password_tb;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button Crate_User;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.CheckBox ShowPswd;
        public System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label errMsg_lbl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

