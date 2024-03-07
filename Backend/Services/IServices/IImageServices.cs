//using CloudinaryDotnet.Actions;

using CloudinaryDotNet.Actions;

namespace BackEnd.Services.IServices
{
    public interface IImageServices
    {
        ImageUploadResult? UploadFile(Stream fileStream, string filename);
        bool DeleteFile(string publicId);
    }
}
