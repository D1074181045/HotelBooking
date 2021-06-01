using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.IO.DbInterface.Customized.Model
{
    public class RatingInfo
    {
        public int id { get; set; }
        public string Name_abbr { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
