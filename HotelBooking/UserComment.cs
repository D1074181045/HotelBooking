using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using HotelBooking.IO.DbInterface.Customized.Model;
using MySql.Data.MySqlClient;

namespace HotelBooking
{
    public partial class UserComment : Form
    {
        IO.DbInterface.MySqlDb sqldb;
        private static int Offset = 0;

        Dictionary<string, string> retes = new Dictionary<string, string>() { { "Excellent", "5.00" },
                                                                              { "Good", "4.00" },
                                                                              { "Fair", "3.00" },
                                                                              { "Poor", "2.00" },
                                                                              { "Not Recommand", "1.00" },
                                                                              { "N/A", "0.00" } };

        Dictionary<int, string> user_rating = new Dictionary<int, string>() { { 5, "Excellent" },
                                                                              { 4, "Good" },
                                                                              { 3, "Fair" },
                                                                              { 2, "Poor" },
                                                                              { 1, "Not Recommand" },
                                                                              { 0, "N/A" } };

        TextBox[] date_tb;
        TextBox[] rating_tb;
        TextBox[] commemt_tb;
        public string hotel_name { get; set; }
        public string Rating { get; set; }
        public string nameabbr { get; set; }

        public UserComment()
        {
            InitializeComponent();
            sqldb = new IO.DbInterface.MySqlDb();
            SelectHotel.Comment_Exit += (se, ev) => this.Close();
        }

        public void Comment_Insert()
        {
            date_tb = new TextBox[] { textBox1, textBox4, textBox7, textBox10 };
            rating_tb = new TextBox[] { textBox2, textBox5, textBox8, textBox11 };
            commemt_tb = new TextBox[] { textBox3, textBox6, textBox9, textBox12 };

            sqldb.Sqlstmt = "SELECT * FROM hotel_rating WHERE name_abbr = '" + nameabbr + "' ORDER BY lastUpdate DESC LIMIT 4;";

            int i = 0;
            foreach (RatingInfo ri in sqldb.RatingInfo_Select())
            {
                date_tb[i].Text = ri.lastUpdate.ToString("yyyy-MM-dd");
                rating_tb[i].Text = user_rating[ri.Rating];
                commemt_tb[i].Text = ri.Comment;
                i++;
            }
        }

        private void UserComment_Load(object sender, EventArgs e)
        {
            sqldb.Sqlstmt = "SELECT AVG(hr.rating) avg_rating, COUNT(*) total, hotel_name FROM hotel_rating hr, hotel_info hi WHERE hr.name_abbr = hi.name_abbr AND hr.name_abbr = '" + this.nameabbr + "' GROUP BY hr.name_abbr;";

            using (MySqlDataReader mySqlData = sqldb.Select2())
            {
                while(mySqlData.Read())
                {
                    this.Text = "User Comment" + "       Hotel:" + mySqlData.GetString("hotel_name") + "       Average Rate:" + Math.Round(mySqlData.GetDouble("avg_rating"), 2);
                    if (mySqlData.GetInt32("total") > 4)
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                    sqldb.CloseConnection();
                    Comment_Insert();
                    return;
                }
            }
            /*
            foreach (string avg_rating in sqldb.Select())
            {
                this.Text = "User Comment" + "       Hotel:" + this.hotel_name + "       Average Rate:" + Math.Round(Convert.ToDouble(avg_rating), 2);
                Comment_Insert();
                return;
            }*/

            this.Text = "User Comment" + "       Hotel:" + this.hotel_name + "       Average Rate:" + retes[Rating];
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Textbox_Clear()
        {
            for (int i = 0; i < Comment_tlp.RowCount - 1; i++)
            {
                date_tb[i].Text = "";
                rating_tb[i].Text = "";
                commemt_tb[i].Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Textbox_Clear();
            button2.Enabled = true;

            Offset -= 4;
            if (Offset < 0)
            {
                Offset = 0;
            }

            if (Offset-4 < 0)
            {
                button1.Enabled = false;
            }
            
            sqldb.Sqlstmt = "SELECT * FROM hotel_rating WHERE name_abbr = '" + nameabbr + "' ORDER BY lastUpdate DESC LIMIT 4 OFFSET " + Offset + ";";

            int i = 0;
            foreach (RatingInfo ri in sqldb.RatingInfo_Select())
            {
                date_tb[i].Text = ri.lastUpdate.ToString("yyyy-MM-dd");
                rating_tb[i].Text = user_rating[ri.Rating];
                commemt_tb[i].Text = ri.Comment;
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Textbox_Clear();
            button1.Enabled = true;

            sqldb.Sqlstmt = "SELECT id FROM hotel_rating WHERE name_abbr = '" + nameabbr + "';";

            Offset += 4;
            if (Offset > sqldb.Select().Count)
            {
                Offset -= 4;
            }

            if (Offset+4 > sqldb.Select().Count)
            {
                button2.Enabled = false;
            }

            sqldb.Sqlstmt = "SELECT * FROM hotel_rating WHERE name_abbr = '" + nameabbr + "' ORDER BY lastUpdate DESC LIMIT 4 OFFSET " + Offset + ";";

            int i = 0;
            foreach (RatingInfo ri in sqldb.RatingInfo_Select())
            {
                date_tb[i].Text = ri.lastUpdate.ToString("yyyy-MM-dd");
                rating_tb[i].Text = user_rating[ri.Rating];
                commemt_tb[i].Text = ri.Comment;
                i++;
            }
        }
    }
}
