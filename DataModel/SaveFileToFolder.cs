using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataModel
{
    public class SaveFileToFolder
    {
        public static string SaveImage(string fileName)
        {
            var path = Path.Combine(@"C:\Users\HP\Desktop\Trash", fileName);
            var imagePath = ConfigurationManager.AppSettings["CoverUrl"];
            var physicalPath = HttpContext.Current.Server.MapPath(imagePath);
            Directory.CreateDirectory(physicalPath);
            string guid = Guid.NewGuid().ToString();
            return CheckImage(path, guid, physicalPath);
        }

        private static string CheckImage(string fileName, string guid, string physicalPath)
        {
            using (var img = new Bitmap(fileName))
            {
                if (img.Width > 800 || img.Height > 800)
                {
                    var destRect = new Rectangle(0, 0, 800, 800);
                    var destImage = new Bitmap(800, 800);
                    destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    using (var graphics = Graphics.FromImage(destImage))
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        using (var wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                            graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }
                    destImage.Save(Path.Combine(physicalPath, guid + Path.GetExtension(fileName)));
                    return guid + Path.GetExtension(fileName);
                }
                else
                {
                    File.Copy(fileName, Path.Combine(physicalPath, guid + Path.GetExtension(fileName)), true);
                    return guid + Path.GetExtension(fileName);
                }
            }
        }
    }
}
