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
using MySql.Data.MySqlClient;
using System.Collections;

namespace HotelBooking
{
    public partial class CreateUser : Form
    {
        IO.DbInterface.MySqlDb sqldb;

        public CreateUser()
        {
            InitializeComponent();
            sqldb = new IO.DbInterface.MySqlDb();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        public bool IsUserPresence()
        {
            sqldb.Sqlstmt = "SELECT * FROM login\n" +
                            "WHERE name='" + User.Text + "';"
                            ;

            ArrayList SqlDb = sqldb.Select();
            foreach (string myData in SqlDb)
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (User.Text != "" && Password.Text != "" && Check_Password.Text != "" && Password.Text == Check_Password.Text)
            {
                if (!IsUserPresence())
                {
                    var specialKey = "[`~!#$^&*()=|{}':;',\\[\\].<>/?~！#￥……&*（）——|{}【】‘；：”“'。，、？]‘'";
                    if (specialKey.IndexOfAny(User.Text.ToCharArray(0, User.Text.Length)) < 0)
                    {
                        string Encryp_password = Security.SecurePassword.Encrypt(Password.Text);

                        sqldb.Sqlstmt = "INSERT INTO login (name, password, loginTime)\n" +
                                        "VALUES ('" + User.Text + "', '" + Encryp_password + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');"
                                        ;

                        if (sqldb.Insert() != -1)
                        {
                            MessageBox.Show("使用者建立成功。");
                            Console.WriteLine(string.Format("Create User：{0}, Complete", User.Text));
                        }
                        else
                            MessageBox.Show(sqldb.errMsg);
                    }
                    else
                        MessageBox.Show("帳號不能有非法字元");
                }
                else
                    MessageBox.Show("建立失敗，已有使用者存在。");
            }
            else
                MessageBox.Show("密碼二次未相同或有未填寫。");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = !checkBox1.Checked;
            Check_Password.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
