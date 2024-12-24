using Microsoft.AspNetCore.Http;
using SupleNet.Application.Responses.CloudMedia;

namespace SupleNet.Application.Interfaces.CloudMedia
{
    public interface ICloudMediaService
    {
        Task<CloudMediaResponse?> UploadImage(IFormFile image);
        Task<CloudMediaResponse?> UploadVideo(IFormFile video);
        void DeleteMedia(string id);
    }
}
