using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hospital.Data.Repositories.PrescriptionItems;

public class PrescriptionItemRepo : IPrescriptionItemRepo
{
    private readonly AppDbContext context;
    public PrescriptionItemRepo(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<PrescriptionItem> InsertAsync(PrescriptionItem prescriptionItem)
    {
        return (await context.PrescriptionItems.AddAsync(prescriptionItem)).Entity;
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

    public async Task<IEnumerable<PrescriptionItem>> SelectAllAsEnumerableAsync()
    {
        return await context.PrescriptionItems.Where(prItem => !prItem.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<PrescriptionItem>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.PrescriptionItems.AsQueryable().Where(prItem => !prItem.IsDeleted));
    }

    public async Task<PrescriptionItem> SelectAsync(long id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await context.PrescriptionItems.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<PrescriptionItem> UpdateAsync(PrescriptionItem prescriptionItem)
    {
        context.PrescriptionItems.Update(prescriptionItem);
        return await Task.FromResult(prescriptionItem);
    }
    public async Task<PrescriptionItem> DeleteAsync(PrescriptionItem prescriptionItem)
    {
        prescriptionItem.IsDeleted = true;
        context.PrescriptionItems.Update(prescriptionItem);
        return await Task.FromResult(prescriptionItem);
    }
}
