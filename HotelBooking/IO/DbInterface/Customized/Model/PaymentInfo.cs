using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.IO.DbInterface.Customized.Model
{
    public class PaymentInfo
    {
        public int id { get; set; }
        public string Name_Abbr { get; set; }
        public string Customer_name { get; set; }
        public string Room { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public UInt16 Total_Reserve_Days { get; set; }
        public string Currency_Code { get; set; }
        public float Price_per_day { get; set; }
        public UInt16 Is_Paid { get; set; }
    }
}
