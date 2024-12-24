using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SupleNet.Application.Interfaces.CloudMedia;
using SupleNet.Application.Responses.CloudMedia;
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
        public void DeleteMedia(string id)
        {
            _cloduinary.DeleteResources(id);
        }

        public async Task<CloudMediaResponse?> UploadImage(IFormFile image)
        {
            using var stream = image.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription
                {
                    FileName = image.FileName,
                    Stream = stream
                },
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = false,
            };
            var uploadImageResult = await _cloduinary.UploadAsync(uploadParams);
            if (uploadImageResult is null)
                return null;
            return new CloudMediaResponse(uploadImageResult.PublicId, uploadImageResult.Url.ToString());
        }

        public async Task<CloudMediaResponse?> UploadVideo(IFormFile video)
        {
            using var stream = video.OpenReadStream();

            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription
                {
                    FileName = video.FileName,
                    Stream = stream
                },
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = false
            };
            var uploadVideoResult = await _cloduinary.UploadAsync(uploadParams);
            if (uploadVideoResult is null)
                return null;
            return new CloudMediaResponse(uploadVideoResult.PublicId, uploadVideoResult.Url.ToString());
        }
    }
}
