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
        public static string SaveImage(byte[] content, string originFileName)
        {
            Directory.CreateDirectory(GetImageFolder());
            var newFileName = $"{Guid.NewGuid()}.{Path.GetExtension(originFileName)}";
            CheckImage(content, newFileName, GetImageFolder());
            return newFileName;
        }

        public static string GetImageFolder()
        {
            var imagePath = ConfigurationManager.AppSettings["CoverUrl"];
            var physicalPath = HttpContext.Current.Server.MapPath(imagePath);
            if (Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(physicalPath);
            }
            return physicalPath;
        }

        public static void CheckImage(byte[] content, string newFileName, string physicalPath)
        {
            var maxImageWidth = 800;
            var maxImageHeight = 800;
            MemoryStream ms = new MemoryStream(content);
            Image img = Image.FromStream(ms);
            if (img.Width > maxImageWidth || img.Height > maxImageHeight)
            {
                var ratioX = (double)maxImageWidth / img.Width;
                var ratioY = (double)maxImageHeight / img.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(img.Width * ratio);
                var newHeight = (int)(img.Height * ratio);

                var newImage = new Bitmap(newWidth, newHeight);
                using (var graphics = Graphics.FromImage(newImage))
                    graphics.DrawImage(img, 0, 0, newWidth, newHeight);
                newImage.Save(Path.Combine(physicalPath, newFileName));
            }
            else
            {
                img.Save(Path.Combine(physicalPath, newFileName));
            }
        }
    }
}
