using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SupleNet.Application.Interfaces.CloudMedia;
using SupleNet.Cloudinary.Models;

namespace SupleNet.Cloudinary.Services
{
    internal class CloudinaryService : ICloudMediaService
    {
        private CloudinarySettings _settings;
        private CloudinaryDotNet.Cloudinary _cloduinary;
        public CloudinaryService(IOptions<CloudinarySettings> options)
        {
            _settings = options.Value;
            Account account = new Account(_settings.CloudName, _settings.ApiKey, _settings.ApiSecret);
            _cloduinary = new CloudinaryDotNet.Cloudinary(account);
        }
        public Task DeleteMedia(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string?> UploadImage(IFormFile image)
        {
            throw new NotImplementedException();
        }

        public Task<string?> UploadVideo(IFormFile video)
        {
            var uploadVideoParams = new VideoUploadParams()
            {
                fi
            }
        }
    }
}
