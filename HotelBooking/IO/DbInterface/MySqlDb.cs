using System;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;
using HotelBooking.IO.DbInterface.Customized;

namespace HotelBooking.IO.DbInterface
{
    public class MySqlDb
    {
        protected MySqlConnection connection;
        private string dbHost;
        private string dbPort;
        private string dbUser;
        private string dbPass;
        private string dbName;
        protected string sqlstmt;
        public string errMsg;

        public MySqlDb()
        {
            dbHost = "127.0.0.1";
            dbPort = "3306";

            switch (Program.Read_Config_mode)
            {
                case 1:
                    dbUser = Read_Config_Mode.GetConfigurationUsingSection("EncryptingUser");
                    dbPass = Read_Config_Mode.GetConfigurationUsingSection("EncryptingPswd");
                    break;
                case 2:
                    dbUser = Read_Config_Mode.GetConfigurationValue("PlainUser");
                    dbPass = Read_Config_Mode.GetConfigurationValue("PlainPswd");
                    break;
                case 3:
                    dbUser = Read_Config_Mode.GetConfigurationUsingSectionGroup("PlainUser");
                    dbPass = Read_Config_Mode.GetConfigurationUsingSectionGroup("PlainPswd");
                    break;
                case 4:
                    dbUser = Read_Config_Mode.GetConfigurationUsingCustomClass("PlainUser");
                    dbPass = Read_Config_Mode.GetConfigurationUsingCustomClass("PlainPswd");
                    break;
            }
            


            dbName = "hotelbooking";
            string connectionString = "server=" + dbHost +
                                      ";port=" + dbPort +
                                      ";user=" + dbUser +
                                      ";password=" + dbPass +
                                      ";database=" + dbName + 
                                      ";charset=utf8;";

            Console.WriteLine(string.Format("Config 讀取模式為： {0}", Program.Read_Config_mode));
            Console.WriteLine(string.Format("user is {0}, password is {1}", dbUser, dbPass));

            connection = new MySqlConnection(connectionString);
        }

        public void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        public string Sqlstmt
        {
            get { return sqlstmt; }
            set { sqlstmt = value;}
        }

        public int Insert()
        {
            this.errMsg = null;
            if (this.sqlstmt == null)
            {
                this.errMsg = "No 'Insert' SQL defined!";
                Console.WriteLine(this.errMsg);
                return -1;
            }
            if (!this.sqlstmt.ToUpper().StartsWith("INSERT INTO "))
            {
                this.errMsg = "Incorrect 'Insert' SQL defined!";
                Console.WriteLine(this.errMsg);
                return -1;
            }
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                int recaffect = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(this.sqlstmt, connection);
                    recaffect = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.errMsg = string.Format("Insert(): {0}::{1}", ex.GetType().ToString(), ex.Message);
                    Console.WriteLine(this.errMsg);
                    return -1;
                }
                finally
                {
                    this.CloseConnection();
                }
                return recaffect;
            }
            return -1;
        }

        public int Update()
        {
            this.errMsg = null;
            if (this.sqlstmt == null)
            {
                this.errMsg = "No 'Update' SQL defined!";
                Console.WriteLine(this.errMsg);
                return -1;
            }
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                int recaffect = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(this.sqlstmt, connection);
                    recaffect = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.errMsg = string.Format("Update(): {0}::{1}", ex.GetType().ToString(), ex.Message);
                    Console.WriteLine(this.errMsg);
                    return -1;
                }
                finally
                {
                    this.CloseConnection();
                }
                return recaffect;
            }
            return -1;
        }

        public ArrayList RatingInfo_Select()
        {
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                TableRatingInfo tableRatingInfo = new TableRatingInfo(connection, this.sqlstmt);
                return tableRatingInfo.CustomizedSelect();
            }
            return new ArrayList();
        }

        public ArrayList PaymentInfo_Select()
        {
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                TablePayment tablePayment = new TablePayment(connection, this.sqlstmt);
                return tablePayment.CustomizedSelect();
            }
            return new ArrayList();
        }

        public ArrayList HotelInfo_Select()
        {
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                TableHotelInfo tableHotel = new TableHotelInfo(connection, this.sqlstmt);
                return tableHotel.CustomizedSelect();
            }
            return new ArrayList();
        }

        public ArrayList RoomInfo_Select()
        {
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                TableRoomInfo tableRoom = new TableRoomInfo(connection, this.sqlstmt);
                return tableRoom.CustomizedSelect();
            }
            return new ArrayList();
        }
        
        public MySqlDataReader Select2()
        {
            this.errMsg = null;
            if (this.sqlstmt == null)
            {
                this.errMsg = "No 'Select' SQL defined!";
                Console.WriteLine(this.errMsg);
                return null;
            }
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                MySqlDataReader dataReader = null;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(this.sqlstmt, connection);
                    dataReader = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    this.errMsg = string.Format("Select(): {0}::{1}", ex.GetType().ToString(), ex.Message);
                    Console.WriteLine(this.errMsg);
                    return null;
                }
                return dataReader;
            }
            return null;
        }

        public ArrayList Select()
        {
            this.errMsg = null;
            if (this.sqlstmt == null)
            {
                this.errMsg = "No 'Select' SQL defined!";
                Console.WriteLine(this.errMsg);
                return new ArrayList();
            }
            if (this.connection.State == System.Data.ConnectionState.Open || this.OpenConnection() == true)
            {
                ArrayList list = new ArrayList();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(this.sqlstmt, connection);

                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                    list.Add(dataReader.GetString(i));
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    this.errMsg = string.Format("Select(): {0}::{1}", ex.GetType().ToString(), ex.Message);
                    Console.WriteLine(this.errMsg);
                    return new ArrayList();
                }
                finally
                {
                    this.CloseConnection();
                }
                return list;
            }
            Console.WriteLine("沒有資料.");
            return new ArrayList();
        }

        public bool OpenConnection()
        {
            this.errMsg = null;
            // 連線到資料庫
            try
            {
                connection.Open();
                Console.WriteLine("成功連線到資料庫.");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        this.errMsg = "無法連線到資料庫.";
                        Console.WriteLine(this.errMsg);
                        break;
                    case 1045:
                        this.errMsg = "資料庫帳號或密碼錯誤,請再試一次.";
                        Console.WriteLine(this.errMsg);
                        break;
                    default:
                        this.errMsg = ex.Message;
                        Console.WriteLine(this.errMsg);
                        break;
                }
                return false;
            }
        }
    }
}
