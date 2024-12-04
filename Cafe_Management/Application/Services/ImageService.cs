using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Cafe_Management.Application.Services
{
    public class ImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public string SaveImage(string imgStr, string imgName, string _path)
        {
            return _imageRepository.SaveImage(imgStr, imgName, _path);
        }
    }
}
