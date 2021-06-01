using HotelBooking.IO.DbInterface.Customized.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelBooking
{
    public partial class Payment : Form
    {
        enum dgvPaymentList_ColumnIndex { City, HotelName, Room, StartDate, EndDate, Days, Code, DueAmount, SubmitPayment };

        private IO.DbInterface.MySqlDb sqldb;
        string captcha;
        int count_time, Select_RowIndex, checked_index;
        int[] payment_id, frequency;
        string[] payment_nameabbr, payment_customer;

        public Payment()
        {
            InitializeComponent();
            sqldb = new IO.DbInterface.MySqlDb();
            SelectHotel.Paymemt_Exit += (se, ev) => this.Close();
        }

        private void default_customer_Insert()
        {
            Customer_list.Items.Clear();

            sqldb.Sqlstmt = "SELECT COUNT(*) FROM reservation WHERE is_paid = '0' GROUP BY customer_name;";
            int array_size = sqldb.Select().Count;
            frequency = new int[array_size];
            payment_customer = new string[array_size];

            sqldb.Sqlstmt = "SELECT COUNT(*) as cnt, customer_name FROM reservation WHERE is_paid = '0' GROUP BY customer_name ORDER BY cnt DESC, customer_name ASC;";
            using (MySqlDataReader mySqlData = sqldb.Select2())
            {
                int i = 0;
                while (mySqlData.Read())
                {
                    this.frequency[i] = mySqlData.GetInt32("cnt");
                    this.payment_customer[i] = mySqlData.GetString("customer_name");
                    Customer_list.Items.Add(string.Format("{0} - ({1})", this.payment_customer[i], this.frequency[i++]));
                }
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            default_customer_Insert();
        }

        private void Customer_list_view_ItemsCheck(object sender, ItemCheckEventArgs e) // 勾選更動
        {
            if (!Customer_list.GetItemChecked(e.Index))
            {
                checked_index = e.Index;
                for (int i = 0; i < Customer_list.Items.Count; i++)
                {
                    Customer_list.SetItemChecked(i, false);
                }

                dgvPaymentList.Rows.Clear();
                sqldb.Sqlstmt = string.Format("SELECT * FROM reservation WHERE customer_name = '{0}' AND is_paid = '0';", this.payment_customer[checked_index]);
                
                ArrayList PaymentData = sqldb.PaymentInfo_Select();
                payment_id = new int[PaymentData.Count];
                payment_nameabbr = new string[PaymentData.Count];
                int m = 0;
                foreach (PaymentInfo pi in PaymentData)
                {
                    dgvPaymentList.Rows.Add();

                    sqldb.Sqlstmt = string.Format("SELECT city FROM hotel_info WHERE name_abbr = '{0}';", pi.Name_Abbr);
                    foreach (string city in sqldb.Select())
                    {
                        dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.City].Value = city;
                    }
                    sqldb.Sqlstmt = string.Format("SELECT hotel_name FROM hotel_info WHERE name_abbr = '{0}';", pi.Name_Abbr);
                    foreach (string hotel_name in sqldb.Select())
                    {
                        dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.HotelName].Value = hotel_name;
                    }
                    payment_id[m] = pi.id;
                    payment_nameabbr[m] = pi.Name_Abbr;
                    dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.Room].Value = pi.Room;
                    dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.StartDate].Value = pi.Start_Date;
                    dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.EndDate].Value = pi.End_Date;
                    dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.Days].Value = pi.Total_Reserve_Days;
                    dgvPaymentList.Rows[m].Cells[(int)dgvPaymentList_ColumnIndex.Code].Value = pi.Currency_Code;
                    dgvPaymentList.Rows[m++].Cells[(int)dgvPaymentList_ColumnIndex.DueAmount].Value = pi.Price_per_day;
                }
                dgvPaymentList.AutoResizeColumns();
                dgvPaymentList.AutoResizeRows();
                dgvPaymentList.ClearSelection();
                this.ClientSize = new Size(1089, 443);
                number_btn.Enabled = false;
                comments_btn.Enabled = false;
                SubmitPayment_btn.Enabled = false;
            }
        }

        private void Random_Capicha()
        {
            Random random = new Random();

            captcha = random.Next(0, 10).ToString() + random.Next(0, 10).ToString() + random.Next(0, 10).ToString() + random.Next(0, 10).ToString();

            if (Convert.ToInt16(captcha) % 2 == 0)
            {
                captcha_pic1.BackgroundImage = captcha_imglist.Images[Convert.ToUInt16(captcha.Substring(0, 1))];
                captcha_pic2.BackgroundImage = captcha_imglist.Images[Convert.ToUInt16(captcha.Substring(1, 1))];
                captcha_pic3.BackgroundImage = captcha_imglist.Images[Convert.ToUInt16(captcha.Substring(2, 1))];
                captcha_pic4.BackgroundImage = captcha_imglist.Images[Convert.ToUInt16(captcha.Substring(3, 1))];
            }
            else
            {
                captcha_pic1.BackgroundImage = captcha_imglist2.Images[Convert.ToUInt16(captcha.Substring(0, 1))];
                captcha_pic2.BackgroundImage = captcha_imglist2.Images[Convert.ToUInt16(captcha.Substring(1, 1))];
                captcha_pic3.BackgroundImage = captcha_imglist2.Images[Convert.ToUInt16(captcha.Substring(2, 1))];
                captcha_pic4.BackgroundImage = captcha_imglist2.Images[Convert.ToUInt16(captcha.Substring(3, 1))];
            }
        }

        private void dgvPaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == (int)dgvPaymentList_ColumnIndex.SubmitPayment)
                {
                    Select_RowIndex = e.RowIndex;
                    Submit_lbl.Text = "Submit the payment for hotel:" + dgvPaymentList.Rows[Select_RowIndex].Cells[(int)dgvPaymentList_ColumnIndex.HotelName].Value.ToString();

                    Random_Capicha();

                    this.ClientSize = new Size(1089, 600);
                    number_btn.Enabled = true;
                    comments_btn.Enabled = false;
                    SubmitPayment_btn.Enabled = false;

                    timer1.Interval = 30000;
                    timer1.Start();
                    count_time = 0;
                }
            }
            catch
            {

            }
        }

        private void number_btn_Click(object sender, EventArgs e)
        {
            if (captcha_tb.Text == captcha)
            {
                number_btn.Enabled = false;
                comments_btn.Enabled = true;
                SubmitPayment_btn.Enabled = true;

                timer1.Stop();
                count_time = 0;
            }
            else
            {
                Random_Capicha();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if (count_time < 30)
            {
                count_time++;
            }
            else
            {*/
                timer1.Stop();
                MessageBox.Show("You haven't entered correct matched random number in 30 seconds, No payment submit", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ClientSize = new Size(1089, 443);
                number_btn.Enabled = true;
                comments_btn.Enabled = false;
                SubmitPayment_btn.Enabled = false;
            //}
        }

        private void SubmitPayment_btn_Click(object sender, EventArgs e)
        {
            sqldb.Sqlstmt = string.Format("UPDATE reservation SET is_paid = 1 WHERE id = '{0}';", payment_id[Select_RowIndex]);
            if (sqldb.Update() != -1)
            {
                string message = string.Format("{0} - '{1}' has been paid out", payment_customer[checked_index], dgvPaymentList.Rows[Select_RowIndex].Cells[1].Value.ToString());
                MessageBox.Show(message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPaymentList.Rows.RemoveAt(Select_RowIndex);
            }
            else
            {
                string message = "Payment failed";
                MessageBox.Show(message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPaymentList.Rows.RemoveAt(Select_RowIndex);
            }

            sqldb.Sqlstmt = string.Format("SELECT * FROM reservation WHERE customer_name = '{0}' AND is_paid = '0';", this.payment_customer[checked_index]);
            int m  = 0;
            ArrayList PaymentData = sqldb.PaymentInfo_Select();
            payment_id = new int[PaymentData.Count];
            payment_nameabbr = new string[PaymentData.Count];
            foreach (PaymentInfo pi in PaymentData)
            {
                payment_id[m] = pi.id;
                payment_nameabbr[m++] = pi.Name_Abbr;
            }

            this.ClientSize = new Size(1089, 443);
            default_customer_Insert();
        }

        private void comments_btn_Click(object sender, EventArgs e)
        {
            RatingComment ratingComment = new RatingComment();
            ratingComment.Updated += (se, ev) => comments_btn.Enabled = false;
            ratingComment.name_abbr = payment_nameabbr[Select_RowIndex];
            ratingComment.city = dgvPaymentList.Rows[Select_RowIndex].Cells[0].Value.ToString();
            ratingComment.hotel_name = dgvPaymentList.Rows[Select_RowIndex].Cells[1].Value.ToString();

            ratingComment.Show();
        }
    }
}
