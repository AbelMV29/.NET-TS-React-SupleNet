using Microsoft.AspNetCore.Http;

namespace SupleNet.Application.Interfaces.CloudMedia
{
    public interface ICloudMediaService
    {
        Task<string?> UploadImage(IFormFile image);
        Task<string?> UploadVideo(IFormFile video);
        Task DeleteMedia(string id);
    }
}
