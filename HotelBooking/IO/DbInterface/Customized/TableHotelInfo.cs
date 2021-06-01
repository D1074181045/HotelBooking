using System;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace HotelBooking.IO.DbInterface.Customized
{
    public class TableHotelInfo
    {
        private MySqlConnection connection;
        private string sqlstmt;
        public string errMsg;

        public TableHotelInfo(MySqlConnection conn, string sqlStmt)
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
                        Model.HotelInfo hi = new Model.HotelInfo();
                        hi.NameAbbr = dataReader.GetString("name_abbr");
                        hi.HotelName = dataReader.GetString("hotel_name");
                        hi.City = dataReader.GetString("city");
                        hi.Country = dataReader.GetString("country");
                        hi.Pic1 = (byte[])dataReader["pic1"];
                        /*
                        hi.Pic2 = (byte[])dataReader["pic2"];
                        hi.Pic3 = (byte[])dataReader["pic3"];
                        hi.Pic4 = (byte[])dataReader["pic4"];
                        */
                        hi.PriceUnit = dataReader.GetString("price_unit");
                        int rate = dataReader.GetInt16("rating");
                        hi.Rating = rates[rate];
                        list.Add(hi);
                    }
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                this.errMsg = string.Format("TableHotelInfo.CustomizedSelect: {0}::{1}",ex.GetType().ToString(), ex.Message);
            }
            return list;
        }
    }
}
