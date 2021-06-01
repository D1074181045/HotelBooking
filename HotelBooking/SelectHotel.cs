using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using HotelBooking.IO.DbInterface.Customized.Model;

namespace HotelBooking
{
    public partial class SelectHotel : Form
    {
        enum dgvHotelList_ColumnIndex { Selected, Name, Picture, Rating, UsedCurrency, RatingComments };

        private ArrayList viewListHotel = null;
        private IO.DbInterface.MySqlDb sqldb;
        string city;
        static int Temp_Row_Select;
        string[] hotel_abbr;
        public event EventHandler Updated;
        public static event EventHandler Room_Exit;
        public static event EventHandler Comment_Exit;
        public static event EventHandler Paymemt_Exit;
        public static event EventHandler Reservation_Exit;
        public static event EventHandler Rating_Exit;

        public SelectHotel()
        {
            InitializeComponent();
            sqldb = new IO.DbInterface.MySqlDb();
        }

        private void SelectHotel_Closing(Object sender, FormClosedEventArgs e)
        {
            if (Updated != null)
                Updated(sender, new EventArgs());
            if (Room_Exit != null)
                Room_Exit(sender, new EventArgs());
            if (Comment_Exit != null)
                Comment_Exit(sender, new EventArgs());
            if (Paymemt_Exit != null)
                Paymemt_Exit(sender, new EventArgs());
            if (Reservation_Exit != null)
                Reservation_Exit(sender, new EventArgs());
            if (Rating_Exit != null)
                Rating_Exit(sender, new EventArgs());
        }

        private void SelectHotel_Load(object sender, EventArgs e)
        {
            
        }

        private void Find_Click(object sender, EventArgs e)
        {
            bool check_city = false;

            for (int i = 0; i < Select_city.Items.Count; i++)
            {
                if (Select_city.GetSelected(i) == true)
                {
                    check_city = true;
                    break;
                }
            }

            if (check_city)
            {
                Load_btn.Visible = false;
                viewListHotel = Hotel_dgv_View();
                label2.Text = "搜尋結果：" + viewListHotel.Count + "個飯店";
                label2.Visible = true;
                if (viewListHotel.Count > 0)
                {
                    Load_btn.Visible = true;
                    this.dgvHotelList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dgvHotelList.AutoGenerateColumns = true;
                }
            }
            else
            {
                MessageBox.Show("請選取城市");
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private ArrayList Hotel_dgv_View()
        {
            Dictionary<char, string> retes = new Dictionary<char, string>() { { 'A', "Excellent" }, 
                                                                              { 'B', "Good" }, 
                                                                              { 'C', "Fair" }, 
                                                                              { 'D', "Poor" },
                                                                              { 'E', "Not Recommand" },
                                                                              { 'F', "N/A" } };

            ArrayList List = new ArrayList();
            city = Select_city.SelectedItem.ToString();
            sqldb.Sqlstmt = "SELECT * FROM hotel_info WHERE city = '" + city + "';";
            
            ArrayList hotel_data = sqldb.HotelInfo_Select();
            hotel_abbr = new string[hotel_data.Count];
            int m = 0;
            foreach (HotelInfo hi in hotel_data)
            {
                hotel_abbr[m++] = hi.NameAbbr;
                List.Add(new View.HotelView {
                    Selected = false,
                    Name = hi.HotelName,
                    Picture = IO.ImageProcess.resizeImage(hi.Pic1, new Size(200, 400)),
                    Rating = retes[hi.Rating],
                    UsedCurrency = hi.PriceUnit
                });
            }
            return List;
        }

        private void Make_Payment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            dgvHotelList.Columns.Clear();
            dgvHotelList.Rows.Clear();
            dgvHotelList.DataSource = null;
            dgvHotelList.Refresh();

            BindingSource bi = new BindingSource();
            bi.DataSource = viewListHotel;
            dgvHotelList.DataSource = bi;

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Rating Comments";
            bcol.Text = "To view it";
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            this.dgvHotelList.Columns.Add(bcol);

            dgvHotelList.AutoResizeColumns();
            dgvHotelList.AutoResizeRows();
            if (dgvHotelList.Columns.Count > 0)
            {
                dgvHotelList.Columns[(int)dgvHotelList_ColumnIndex.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvHotelList.ClearSelection();
            Load_btn.Visible = false;
        }

        private void dgvHotelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == (int)dgvHotelList_ColumnIndex.Selected)
                if (e.RowIndex >= 0 && e.ColumnIndex != (int)dgvHotelList_ColumnIndex.RatingComments)
                {
                    for (int i = 0; i < dgvHotelList.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            dgvHotelList.Rows[i].Cells[(int)dgvHotelList_ColumnIndex.Selected].Value = false;
                        }
                        else
                        {
                            dgvHotelList.Rows[i].Cells[(int)dgvHotelList_ColumnIndex.Selected].Value = true;
                            dgvHotelList.Rows[i].Cells[(int)dgvHotelList_ColumnIndex.Selected].Selected = false;
                            SelectRoom select_room = new SelectRoom();
                            Temp_Row_Select = i;
                            dgvHotelList.Refresh();
                            select_room.Updated += (se, ev) => dgvHotelList.Rows[Temp_Row_Select].Cells[0].Value = false;
                            select_room.HotelAbbr = hotel_abbr[i];
                            select_room.HotelName = dgvHotelList.Rows[i].Cells[1].Value.ToString();
                            select_room.CityName = this.city;
                            select_room.PriceUnit = this.dgvHotelList.Rows[i].Cells[4].Value.ToString();
                            select_room.Show();
                        }
                    }
                }
                if (e.ColumnIndex == (int)dgvHotelList_ColumnIndex.RatingComments)
                {
                    UserComment userComment = new UserComment();
                    userComment.hotel_name = dgvHotelList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    userComment.Rating = dgvHotelList.Rows[e.RowIndex].Cells[3].Value.ToString();
                    userComment.nameabbr = hotel_abbr[e.RowIndex];
                    userComment.ShowDialog();
                }
            }
            catch
            {

            }
        }
    }
}
