using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace P0_ClassLibrary.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile image, string folderName);
        Task<string> UploadImageAsync(Stream stream, string fileName, string folderName);
        Task<string> UploadVideoAsync(IFormFile video, string folderName);
        Task<string> UploadVideoAsync(Stream stream, string fileName, string folderName);
    }
}
