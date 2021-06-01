using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.IO.DbInterface.Customized.Model
{
    public class RoomInfo
    {
        public string HotelNameAbbr { get; set; }
        public string Room1 { get; set; }
        public float Price1 { get; set; }
        public byte[] Pic1 { get; set; }
        public string Room2 { get; set; }
        public float Price2 { get; set; }
        public byte[] Pic2 { get; set; }
        public string Room3 { get; set; }
        public float Price3 { get; set; }
        public byte[] Pic3 { get; set; }
        public string Room4 { get; set; }
        public float Price4 { get; set; }
        public byte[] Pic4 { get; set; }
    }
}
