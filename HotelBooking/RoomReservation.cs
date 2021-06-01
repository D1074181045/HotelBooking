using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class RoomReservation : Form
    {
        private IO.DbInterface.MySqlDb sqldb;
        DateTime start_time;
        DateTime end_time;

        public static string name_abbr { get; set; }
        public string Room_name { get; set; }
        public float Price_num { get; set; }
        public string Currency { get; set; }
        public Image Room_Image { get; set; }

        public RoomReservation()
        {
            InitializeComponent();
            SelectHotel.Reservation_Exit += (se, ev) => this.Close();
            Check_in_dtp.MinDate = DateTime.Now;
            Check_out_dtp.MinDate = DateTime.Now.AddDays(1);
        }

        private void RoomReservation_Load(object sender, EventArgs e)
        {
            sqldb = new IO.DbInterface.MySqlDb();
            Room_lbl.Text = this.Room_name;
            Price_lbl.Text = this.Price_num.ToString();
            RoomImg_pic.BackgroundImage = this.Room_Image;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Reserve_btn_Click(object sender, EventArgs e)
        {
            int time_math = DateTime.Compare(this.end_time, this.start_time);

            TimeSpan ts = this.end_time.Subtract(this.start_time);
            int dayCount = ts.Days;

            if (time_math > 0 && Reservation_name.Text.Count<char>() >= 8)
            {
                float total_price = Price_num * dayCount;

                string message = "Reservation name：" + Reservation_name.Text + Environment.NewLine + 
                                 "Reserved room：" + this.Room_name + Environment.NewLine +
                                 "Starting Date：" + this.start_time.ToString("yyyy-MM-dd") + Environment.NewLine +
                                 "Days reserved：" + dayCount + Environment.NewLine +
                                 "Price charged：" + total_price + " (" + Currency + ")" +  Environment.NewLine +
                                 "is this information correct?";

                string caption = "Enter data confirmation";

                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    sqldb.Sqlstmt = string.Format("INSERT INTO reservation (name_abbr, customer_name, room, start_date, end_date, price_per_day, total_reserve_days, currency_code, create_date, is_paid)\n" +
                                                  "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');",
                                                  name_abbr, Reservation_name.Text, this.Room_name, this.start_time.ToString("yyyy-MM-dd"), this.end_time.ToString("yyyy-MM-dd"), total_price, dayCount, this.Currency, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0);
                    if (sqldb.Insert() != -1)
                    {
                        MessageBox.Show("預定完成");
                        this.Close();
                        this.Dispose();
                    }
                }
            }
            else if (time_math <= 0)
            {
                MessageBox.Show("時間預定錯誤");
            }
            else
            {
                MessageBox.Show("名字字數少於8");
            }
        }

        private void Reserve_btn_EnableChecked(object sender, EventArgs e)
        {
            this.start_time = new DateTime(Check_in_dtp.Value.Year, Check_in_dtp.Value.Month, Check_in_dtp.Value.Day);
            this.end_time = new DateTime(Check_out_dtp.Value.Year, Check_out_dtp.Value.Month, Check_out_dtp.Value.Day);

            int time_math = DateTime.Compare(end_time, start_time);

            if (time_math > 0 && Reservation_name.Text.Count<char>() > 8)
            {
                Reserve_btn.Enabled = true;
            }
            else
            {
                Reserve_btn.Enabled = false;
            }
        }
    }
}
