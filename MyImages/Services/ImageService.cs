using MyImages.Uow;
using System;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Amr;
using MyImages.Models;

namespace MyImages.Services
{
    public class ImageService : IImageServices
    {
        public bool ValidNumberOfImagesUploaded(ImageUow ImageUow)
        {
            return ImageUow.Repository.FindAll().Count() < 8;
        }

        public byte[] RenderImage200PX(byte[] image, int width = 200, int height = 200)
        {
            using (var stream = new MemoryStream(image))
            {
                var img = System.Drawing.Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return thumbStream.GetBuffer();
                }
            }
        }

        public bool ValidPngFile(IFormFile File)
        {
            if (File.Length > 0)
            {
                return Path.GetExtension(File.FileName).Contains(".png");
            }
            else
            {
                return false;
            }
        }

        public void BuildImagesByteArray(ImageModel ModelOnly, IFormFile Image, IImageServices service)
        {
            using (var stream = new MemoryStream())
            {
                Image.CopyToAsync(stream);
                ModelOnly.Image = stream.ToArray();
                ModelOnly.Image = service.RenderImage200PX(ModelOnly.Image, 200, 200);
            }
        }
    }
}
