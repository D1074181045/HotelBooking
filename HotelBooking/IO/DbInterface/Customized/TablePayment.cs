using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;

namespace HotelBooking.IO.DbInterface.Customized
{
    public class TablePayment
    {
        private MySqlConnection connection;
        private string sqlstmt;
        public string errMsg;

        public TablePayment(MySqlConnection conn, string sqlStmt)
        {
            this.connection = conn;
            this.sqlstmt = sqlStmt;
            this.errMsg = null;
        }

        public ArrayList CustomizedSelect()
        {
            char[] rates = { 'F', 'E', 'D', 'C', 'B', 'A' };
            ArrayList list = new ArrayList();
            MySqlCommand cmd = null;
            MySqlDataReader dataReader = null;
            try
            {
                cmd = new MySqlCommand(this.sqlstmt, this.connection);
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Model.PaymentInfo pi = new Model.PaymentInfo();
                        pi.id = dataReader.GetInt32("id");
                        pi.Name_Abbr = dataReader.GetString("name_abbr");
                        pi.Customer_name = dataReader.GetString("customer_name");
                        pi.Room = dataReader.GetString("room");
                        pi.Start_Date = dataReader.GetString("start_date");
                        pi.End_Date = dataReader.GetString("end_date");
                        pi.Total_Reserve_Days = dataReader.GetUInt16("total_reserve_days");
                        pi.Currency_Code = dataReader.GetString("currency_code");
                        pi.Price_per_day = dataReader.GetFloat("price_per_day");

                        pi.Is_Paid = dataReader.GetUInt16("is_paid");
                        list.Add(pi);
                    }
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                this.errMsg = string.Format("TableHotelInfo.CustomizedSelect: {0}::{1}", ex.GetType().ToString(), ex.Message);
            }
            return list;
        }
    }
}
