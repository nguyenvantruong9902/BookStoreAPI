using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace DataBusiness
{
    public class ImageService
    {
        private static readonly int maxImageWidth = int.Parse(ConfigurationManager.AppSettings["MaxImageWidth"]);
        private static readonly int maxImageHeight = int.Parse(ConfigurationManager.AppSettings["MaxImageHeight"]);
        private static readonly string imagePath = ConfigurationManager.AppSettings["CoverUrl"];
        
        public static string SaveImage(byte[] content)
        {
            var fileName = $"{Guid.NewGuid()}.jpg";
            var filePath = Path.Combine(GetImageFolder(), fileName);

            CreateScaledImage(content)
                .Save(filePath, ImageFormat.Jpeg);

            return fileName;
        }

        private static string GetImageFolder()
        {
            
            var physicalPath = HttpContext.Current.Server.MapPath(imagePath);
            if (Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(physicalPath);
            }
            
            return physicalPath;
        }

        private static Bitmap CreateScaledImage(byte[] content)
        {
            var img = new Bitmap(new MemoryStream(content));

            return ScaleImage(img, maxImageHeight, maxImageWidth);
        }

        private static Bitmap ScaleImage(Bitmap img, int maxImageHeight, int maxImageWidth)
        {
            if (img.Width > maxImageWidth || img.Height > maxImageHeight)
            {
                var ratio = Math.Min((double)maxImageHeight / img.Height, (double)maxImageWidth / img.Width);
                return new Bitmap(img, (int)(img.Width * ratio), (int)(img.Height * ratio));
            }

            return img;
        }
    }
}
