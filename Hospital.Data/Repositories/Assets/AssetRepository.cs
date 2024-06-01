using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories.Assets;

public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext context;
    public AssetRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Asset> SelectAsync(long id)
    {
        return await context.Assets.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
    }


    public async Task<Asset> InsertAsync(Asset asset)
    {
       return (await context.Assets.AddAsync(asset)).Entity;
    }

    public async Task<bool> DeleteAsync(Asset asset)
    {
        asset.IsDeleted = true;
        await Task.FromResult(context.Update(asset));

        return true;
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}