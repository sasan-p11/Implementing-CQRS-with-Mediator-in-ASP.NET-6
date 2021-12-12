using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Data.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.Photos;
public class PhotoAccessor : IPhotoAccessor
{
    private readonly Cloudinary _cloudinary;
    public PhotoAccessor(IOptions<CloudinarySettings> config)
    {
        var account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
        );
        _cloudinary = new Cloudinary(account);
    }

    public async Task<PhotoUploadResult> AddPhoto(IFormFile file)
    {
        if (file.Length > 7077888)
        {
            throw new Exception("File size is too big");
        }

        string ext = System.IO.Path.GetExtension(file.FileName);
        if (ext.ToUpper().Trim() != ".JPG" && ext.ToUpper() != ".PNG" && ext.ToUpper() != ".GIF" && ext.ToUpper() != ".JPEG")
        {
            throw new Exception("Please choose only .jpg, .png and .gif image types!");
        }
        
        if (file.Length > 0)
        {
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            return new PhotoUploadResult
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString()
            };
        }

        return null;
    }

    public async Task<string> DeletePhoto(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deleteParams);
        return result.Result == "ok" ? result.Result : null;
    }
}