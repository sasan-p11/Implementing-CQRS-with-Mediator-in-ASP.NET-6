using Domain.DTO;
using Microsoft.AspNetCore.Http;

namespace Domain.Data.Interfaces;
public interface IPhotoAccessor
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
}