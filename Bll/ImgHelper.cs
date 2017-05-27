using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Bll
{
    public class ImgHelper
    {

        /// <summary>
        /// 图片缩放压缩
        /// </summary>
        /// <param name="path"></param>
        public static byte[] ImgZoomCompression(string path)
        {
            byte[] by = null;
            if (!File.Exists(path)) return by;
            Image img = Image.FromFile(path);
            Bitmap newimg = new Bitmap(320, 180);
            Graphics g = Graphics.FromImage(newimg);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.Low;
            g.DrawImage(img, new Rectangle(0, 0, newimg.Width, newimg.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            EncoderParameters ep = new EncoderParameters(1);
            EncoderParameter eparameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L);
            ep.Param[0] = eparameter;
            try
            {
                ImageCodecInfo[] imginfos = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo imginfo = null;
                foreach (ImageCodecInfo item in imginfos)
                {
                    if (item.FormatDescription.Equals("JPEG"))
                    {
                        imginfo = item;
                        break;
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    if (imginfo != null)
                    {
                        newimg.Save(ms, imginfo, ep);
                    }
                    else
                    {
                        newimg.Save(ms, img.RawFormat);
                    }
                    by = new byte[ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(by, 0, by.Length);
                }
            }
            finally
            {
                g.Dispose();
                img.Dispose();
                newimg.Dispose();
            }
            return by;
        }

    }
}
