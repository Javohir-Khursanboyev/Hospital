using Hospital.Domain.Enums;
using Hospital.Service.DTOs.Assets;
using Microsoft.AspNetCore.Http;

namespace Hospital.Service.Services.Assets;

public interface IAssetService
{
    Task<AssetViewModel> UploadAsync(IFormFile file, FileType fileType);
    Task<bool> DeleteAsync(long id);
}