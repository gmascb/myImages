using Microsoft.EntityFrameworkCore;
using MyImages.Uow;
using MyImages.Data;
using MyImages.Repositories;
using MyImages.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using MyImages.Models;

namespace MyImages.Services
{
    public interface IImageServices
    {
        bool ValidNumberOfImagesUploaded(ImageUow uow);

        byte[] RenderImage200PX(byte[] image, int width, int height);

        bool ValidPngFile(IFormFile File);

        void BuildImagesByteArray(ImageModel ModelOnly, IFormFile Image, IImageServices service);
    }
}
