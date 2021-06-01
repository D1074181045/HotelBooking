using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.IO.DbInterface.Customized.Model
{
    public class HotelInfo
    {
        public string NameAbbr { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte[] Pic1 { get; set; }
        public byte[] Pic2 { get; set; }
        public byte[] Pic3 { get; set; }
        public byte[] Pic4 { get; set; }
        public string PriceUnit { get; set; }
        public char Rating { get; set; }
    }
}
