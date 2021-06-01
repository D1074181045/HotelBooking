using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;

namespace HotelBooking.IO.DbInterface.Customized
{
    public class TableRatingInfo
    {
        private MySqlConnection connection;
        private string sqlstmt;
        public string errMsg;

        public TableRatingInfo(MySqlConnection conn, string sqlStmt)
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
                        Model.RatingInfo ri = new Model.RatingInfo();
                        ri.id = dataReader.GetInt16("id");
                        ri.Name_abbr = dataReader.GetString("name_abbr");
                        ri.Rating = dataReader.GetInt16("rating");
                        ri.Comment = dataReader.GetString("comment");
                        ri.lastUpdate = dataReader.GetDateTime("lastUpdate");
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
