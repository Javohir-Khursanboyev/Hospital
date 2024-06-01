using AutoMapper;
using Hospital.Data.Repositories.Assets;
using Hospital.Domain.Entities;
using Hospital.Domain.Enums;
using Hospital.Service.DTOs.Assets;
using Hospital.Service.Exceptions;
using Hospital.Service.Helpers;
using Microsoft.AspNetCore.Http;

namespace Hospital.Service.Services.Assets;

public class AssetService
    (IMapper mapper,
    IAssetRepository assetRepository) : IAssetService
{
    public async Task<AssetViewModel> UploadAsync(IFormFile file, FileType fileType)
    {
        var path = Path.Combine(FilePathHelper.WwwrootPath, fileType.ToString());
        var fileName = file.FileName;

        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var fullPath = Path.Combine(path, fileName);

        var stream = File.Create(fullPath);
        await file.CopyToAsync(stream);
        stream.Close();

        var asset = new Asset
        {
            Name = fileName,
            Path = fullPath,
        };

        await assetRepository.InsertAsync(asset);
        await assetRepository.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAsset = await assetRepository.SelectAsync(id)
            ?? throw new NotFoundException("Asset is not found");

        File.Delete(existAsset.Path);

        existAsset.DeletedAt = DateTime.UtcNow;
        await assetRepository.DeleteAsync(existAsset);
        await assetRepository.SaveAsync();

        return true;
    }
}