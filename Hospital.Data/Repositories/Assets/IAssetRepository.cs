using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Assets;

public interface IAssetRepository
{
    Task<Asset> InsertAsync(Asset asset);
    Task<bool> DeleteAsync(Asset asset);
    Task<Asset> SelectAsync(long id);
    Task<bool> SaveAsync();
}