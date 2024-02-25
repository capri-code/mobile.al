using CloudinaryDotNet.Actions;

namespace mobile.al.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<List<ImageUploadResult>> AddPhotoAsync(List<IFormFile> files);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}