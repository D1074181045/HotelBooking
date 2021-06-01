using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace HotelBooking.IO
{
    class ImageProcess
    {
        public static Image resizeImage(byte[] buffer, Size size)
        {
            MemoryStream img = new MemoryStream(buffer);
            Bitmap b = new Bitmap(img);
            img.Close();
            return resize(b, size);
        }
        private static Image resize(Image imgToResize, Size size)
        {
            //獲取圖片寬度
            int sourceWidth = imgToResize.Width;
            //獲取圖片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //計算寬度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //計算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            nPercent = (nPercentH < nPercentW) ? nPercentH : nPercentW;

            //期望的寬度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //繪製圖像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }
    }
}
