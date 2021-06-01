using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class RatingComment : Form
    {
        private IO.DbInterface.MySqlDb sqldb;
        public event EventHandler Updated;

        public string name_abbr { get; set; }
        public string city { get; set; }
        public string hotel_name { get; set; }

        public RatingComment()
        {
            InitializeComponent();
            SelectHotel.Rating_Exit += (se, ev) => this.Close();
        }

        private void RatingComment_Load(object sender, EventArgs e)
        {
            sqldb = new IO.DbInterface.MySqlDb();
            hotel_lbl.Text = string.Format("{0} - {1}", this.city, this.hotel_name);
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> retes = new Dictionary<string, int>() { { "A", 5 },
                                                                            { "B", 4 },
                                                                            { "C", 3 },
                                                                            { "D", 2 },
                                                                            { "E", 1 },
                                                                            { "F", 0 } };

                string select_rating = Rating_list.SelectedItem.ToString();
                sqldb.Sqlstmt = string.Format("INSERT INTO hotel_rating (name_abbr, rating, comment, lastUpdate)\n" +
                                              "VALUES ('{0}', '{1}', '{2}', '{3}');", this.name_abbr, retes[select_rating.Substring(select_rating.Length - 2, 1)], comment_tbox.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (sqldb.Insert() != -1)
                {
                    MessageBox.Show("Your rating and command to " + this.hotel_name + "is saved", "MySQL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    sqldb.Sqlstmt = "SELECT AVG(rating) FROM hotel_rating WHERE name_abbr = '" + this.name_abbr + "';";

                    foreach (string avg_rating in sqldb.Select())
                    {
                        sqldb.Sqlstmt = "UPDATE hotel_info SET rating = '" + (int)Convert.ToDouble(avg_rating) + "' WHERE name_abbr = '" + this.name_abbr + "';";
                        if (sqldb.Update() == -1)
                        {
                            MessageBox.Show(this.hotel_name + "評價更新失敗", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (Updated != null)
                    {
                        Updated(sender, new EventArgs());
                    }
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Your rating and command to is failed", "MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("請選取評價。", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
