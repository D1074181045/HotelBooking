using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HotelBooking.View
{
    public class HotelView
    {
        public bool Selected { get; set; }
        public string Name { get; set; }
        public Image Picture { get; set; }
        public string Rating { get; set; }
        public string UsedCurrency { get; set; }
    }
}
