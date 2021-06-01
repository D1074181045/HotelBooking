using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace HotelBooking.IO.DbInterface.Customized
{
    public class TableRoomInfo
    {
        private MySqlConnection connection;
        private string sqlstmt;
        public string errMsg;

        public TableRoomInfo(MySqlConnection conn, string sqlStmt)
        {
            this.connection = conn;
            this.sqlstmt = sqlStmt;
            this.errMsg = null;
        }

        public ArrayList CustomizedSelect()
        {
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
                        Model.RoomInfo ri = new Model.RoomInfo();
                        ri.HotelNameAbbr = dataReader.GetString("hotel_name_abbr");
                        ri.Room1 = dataReader.GetString("room1");
                        ri.Price1 = dataReader.GetFloat("price1");
                        ri.Pic1 = (byte[])dataReader["pic1"];
                        ri.Room2 = dataReader.GetString("room2");
                        ri.Price2 = dataReader.GetFloat("price2");
                        ri.Pic2 = (byte[])dataReader["pic2"];
                        ri.Room3 = dataReader.GetString("room3");
                        ri.Price3 = dataReader.GetFloat("price3");
                        ri.Pic3 = (byte[])dataReader["pic3"];
                        ri.Room4 = dataReader.GetString("room4");
                        ri.Price4 = dataReader.GetFloat("price4");
                        ri.Pic4 = (byte[])dataReader["pic4"];
                        list.Add(ri);
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

