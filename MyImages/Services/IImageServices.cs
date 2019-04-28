using MyImages.Uow;
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
