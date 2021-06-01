using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using HotelBooking.IO.DbInterface.Customized.Model;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace HotelBooking
{
    public partial class SelectRoom : Form
    {
        enum dgvRoomList_ColumnIndex { Roompic, Name, Price };
        JObject Currency_json;

        private IO.DbInterface.MySqlDb sqldb;
        private string T_PriceUnit;
        private ArrayList viewListRoom = null;
        public event EventHandler Updated;
        public float[] Room_Price;

        public string HotelAbbr { get; set; }
        public string HotelName { get; set; }
        public string CityName { get; set; }
        public string PriceUnit { get; set; }

        public SelectRoom()
        {
            InitializeComponent();
            sqldb = new IO.DbInterface.MySqlDb();
            SelectHotel.Room_Exit += (se, ev) => this.Close();
        }

        private void SelectRoom_Load(object sender, EventArgs e)
        {
            hotel_title.Text = this.CityName.ToUpper() + "-" + this.HotelName.ToUpper();
            T_PriceUnit = PriceUnit;

            viewListRoom = Room_Info_View();

            this.dgvRoomList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomList.AutoGenerateColumns = true;

            BindingSource bi = new BindingSource();
            bi.DataSource = viewListRoom;
            dgvRoomList.DataSource = bi;

            dgvRoomList_Resize();

            for (int i = 0; i < Select_Priceunit.Items.Count; i++)
            {
                if (PriceUnit == Select_Priceunit.Items[i].ToString().Substring(0, 3))
                {
                    Select_Priceunit.SetSelected(i, true);
                    break;
                }
            }

            Currency_json = (JObject)JsonConvert.DeserializeObject(WebRequestGet("https://tw.rter.info/capi.php"));
        }

        private void Select_Priceunit_MouseClick(Object sender, EventArgs e)
        {
            double exchange_rate = exchange_rate_Convert(PriceUnit, Select_Priceunit.SelectedItem.ToString().Substring(0, 3));
            if (dgvRoomList.Columns.Count > 0)
            {
                for (int i = 0; i < dgvRoomList.Rows.Count; i++)
                {
                    dgvRoomList.Rows[i].Cells[(int)dgvRoomList_ColumnIndex.Price].Value = Math.Round(Room_Price[i] * exchange_rate, 2);
                }
            }
            dgvRoomList_Resize();
        }

        private void dgvRoomList_Resize()
        {
            dgvRoomList.AutoResizeColumns();
            dgvRoomList.AutoResizeRows();
            if (dgvRoomList.Columns.Count > 0)
            {
                dgvRoomList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvRoomList.ClearSelection();
        }

        private void Select_Room_Closing(Object sender, FormClosedEventArgs e)
        {
            if (Updated != null)
            {
                Updated(sender, new EventArgs());
            }
        }

        private ArrayList Room_Info_View()
        {
            ArrayList List = new ArrayList();

            RoomReservation.name_abbr = HotelAbbr;

            sqldb.Sqlstmt = "SELECT * FROM room_info WHERE hotel_name_abbr = '" + HotelAbbr + "';";

            ArrayList room_data = sqldb.RoomInfo_Select();
            foreach (RoomInfo ri in room_data)
            {
                byte[][] Room_Pic = { ri.Pic1, ri.Pic2, ri.Pic3, ri.Pic4 };
                string[] Room_Name = { ri.Room1, ri.Room2, ri.Room3, ri.Room4 };
                Room_Price = new float[] { ri.Price1, ri.Price2, ri.Price3, ri.Price4 };
                for (int i = 0; i < Room_Name.Count<string>(); i++)
                {
                    List.Add(new View.RoomView { 
                        Roompic = IO.ImageProcess.resizeImage(Room_Pic[i], new Size(200, 400)), 
                        Name = Room_Name[i], 
                        Price = Math.Round(Room_Price[i], 2) 
                    });
                }
            }
            return List;
        }

        private double exchange_rate_Convert(string original, string arget)
        {
            T_PriceUnit = arget;

            if (original != "USD")
            {
                double Currenly = 1 / Convert.ToDouble(Currency_json["USD" + original]["Exrate"]);
                double Aim = Convert.ToDouble(Currency_json["USD" + arget]["Exrate"]);

                return Currenly * Aim;
            }
            else
            {
                return Convert.ToDouble(Currency_json["USD" + arget]["Exrate"]);
                //return Convert.ToDouble(CurrentyToExrate["USD" + arget]);
            }
        }

        private string WebRequestGet(string Url)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(Url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        private void reservation_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int Select_Row = dgvRoomList.SelectedCells[0].RowIndex;

                RoomReservation room_Reservation = new RoomReservation();
                room_Reservation.Room_Image = (Image)dgvRoomList.Rows[Select_Row].Cells[(int)dgvRoomList_ColumnIndex.Roompic].Value;
                room_Reservation.Room_name = (string)dgvRoomList.Rows[Select_Row].Cells[(int)dgvRoomList_ColumnIndex.Name].Value;
                room_Reservation.Price_num = (float)Convert.ToDouble(dgvRoomList.Rows[Select_Row].Cells[(int)dgvRoomList_ColumnIndex.Price].Value);
                room_Reservation.Currency = T_PriceUnit;

                room_Reservation.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("請選取房間", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comment_btn_Click(object sender, EventArgs e)
        {
            UserComment userComment = new UserComment();
            userComment.hotel_name = HotelName;
            userComment.Rating = "Fair";
            userComment.nameabbr = HotelAbbr;
            userComment.ShowDialog();
        }
    }
}
