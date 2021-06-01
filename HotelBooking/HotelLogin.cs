using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using MySql.Data;
using System.Security.Principal;
using MySql.Data.MySqlClient;
using System.Collections;
using Microsoft.Win32;

namespace HotelBooking
{
    public partial class HotelLogin : Form
    {
        IO.DbInterface.MySqlDb sqldb;
        private int LoginFail_count = 0;
        

        private void HotelLogin_Load(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey prev = Registry.CurrentUser.OpenSubKey("LHU"))
                {
                    using (RegistryKey prevSettings = prev.OpenSubKey("AWP"))
                    {
                        User_tb.Text = (string)prevSettings.GetValue("prevUser");
                        Password_tb.Text = (string)prevSettings.GetValue("prevPswd");
                    }
                }
            }
            catch
            {
                User_tb.Text = "";
                Password_tb.Text = "";
            }
        }

        public HotelLogin()
        {
            InitializeComponent();
            errMsg_lbl.Location = linkLabel1.Location;
            sqldb = new IO.DbInterface.MySqlDb();

            toolTip1.AutoPopDelay = 1500;
            if (!ShowPswd.Checked)
                toolTip1.SetToolTip(ShowPswd, "Show Password");
            else
                toolTip1.SetToolTip(ShowPswd, "Cancel Display Password");
            toolTip1.SetToolTip(Password_tb, "Password is case sensitive");
        }
 

        private void loginTime()
        {
            sqldb.Sqlstmt = "UPDATE login SET loginTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'\n" +
                            "WHERE name = '" + User_tb.Text + "';"
                            ;

            sqldb.Update();  
        }

        private void login_Click(object sender, EventArgs e)
        {
            label1.Focus();

            if (User_tb.Text != "" && Password_tb.Text != "")
            {
                // ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'SuperUser_'
                string specialKey = "[`~!#$^&*()=|{}':;',\\[\\].<>/?~！#￥……&*（）——|{}【】‘；：”“'。，、？]‘'";

                if (specialKey.IndexOfAny(User_tb.Text.ToCharArray(0, User_tb.Text.Length)) < 0)
                {
                    if (!sqldb.OpenConnection())
                    {
                        errMsg_lbl.Visible = true;
                        errMsg_lbl.Text = sqldb.errMsg;
                    }
                    else
                    {
                        try
                        {
                            sqldb.Sqlstmt = "SELECT password FROM login\n" +
                                            "WHERE name = '" + User_tb.Text + "';"
                                            ;

                            ArrayList SqlDb = sqldb.Select();
                            foreach (string password in SqlDb)
                            {
                                string Decrpy_password = null;
                                if (Security.SecurePassword.IsBase64String(password))
                                    Decrpy_password = Security.SecurePassword.Decrypt(password);
                                else
                                    Decrpy_password = password;

                                if (Password_tb.Text == Decrpy_password)
                                {
                                    errMsg_lbl.Visible = false;
                                    linkLabel1.Text = "Successful login of config method #" + Program.Read_Config_mode + " click me go to next window";
                                    linkLabel1.Visible = true;
                                    loginTime();
                                    login.Enabled = false;

                                    if (Program.IsAdministrator)
                                    {
                                        Crate_User.Enabled = true;
                                        try
                                        {
                                            using (RegistryKey prev = Registry.CurrentUser.CreateSubKey("LHU"))
                                            {
                                                using (RegistryKey prevSettings = prev.CreateSubKey("AWP"))
                                                {
                                                    // Create data for the TestSettings subkey.
                                                    prevSettings.SetValue("prevUser", User_tb.Text);
                                                    prevSettings.SetValue("prevPswd", Password_tb.Text);
                                                }
                                            }
                                        }
                                        catch {}
                                    }

                                    User_tb.Text = "";
                                    Password_tb.Text = "";
                                }
                                else
                                {
                                    LoginFail_count++;
                                    if (LoginFail_count == 3)
                                    {
                                        MessageBox.Show("You have tried login to \"HotelBooking\" for 3 times and all\nfailed, exit system", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Environment.Exit(Environment.ExitCode);
                                    }
                                    errMsg_lbl.Visible = true;
                                    linkLabel1.Visible = false;
                                    errMsg_lbl.Text = "帳號或密碼錯誤";
                                }
                            }
                            if (SqlDb.Count == 0)
                            {
                                errMsg_lbl.Visible = true;
                                errMsg_lbl.Text = "沒有此使用者：" + User_tb.Text;
                            }
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error " + ex.Number + " : " + ex.Message);
                            errMsg_lbl.Text = sqldb.errMsg;
                        }
                    }
                }
                else
                    errMsg_lbl.Text = "帳號有非法字元";
            }
            else
                errMsg_lbl.Text = "帳號與密碼為空";
        }

        private void Create_User_Click(object sender, EventArgs e)
        {
            CreateUser create_user = new CreateUser();
            create_user.Show();
        }

        private void ShowPswd_CheckedChanged(object sender, EventArgs e)
        {
            Password_tb.UseSystemPasswordChar = !ShowPswd.Checked;

            if (!ShowPswd.Checked)
                toolTip1.SetToolTip(ShowPswd, "Show Password");
            else
                toolTip1.SetToolTip(ShowPswd, "Cancel Display Password");

            toolTip1.Hide(ShowPswd);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Links[0].Enabled = false;
            SelectHotel select_hotel = new SelectHotel();
            select_hotel.Updated += (se, ev) => linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            select_hotel.Updated += (se, ev) => linkLabel1.Text = "Done...";
            select_hotel.Show();
        }

        private void User_tb_GotFocus(object sender, EventArgs e)
        {

        }

        private void Password_tb_GotFocus(object sender, EventArgs e)
        {
            toolTip1.Show("Password is case sensitive", Password_tb, 1500);
        }
    }
}
