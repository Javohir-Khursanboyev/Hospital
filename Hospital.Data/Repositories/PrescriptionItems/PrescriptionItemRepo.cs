using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<PrescriptionItem> SelectAsync(long id, string[] includes = null)
    {
        var prescriptionItems = context.PrescriptionItems;

        if (includes != null)
            foreach (var include in includes)
                prescriptionItems.Include(include);
                   
        var prescriptionItem = await prescriptionItems.Where(prItem => !prItem.IsDeleted && prItem.Id == id).FirstOrDefaultAsync();

        return  prescriptionItem;
    }

    public async Task<IEnumerable<PrescriptionItem>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true)
    {
        var prescriptionItems = context.PrescriptionItems;

        if (includes != null)
            foreach (var include in includes)
                prescriptionItems.Include(include);

        if (!isTraking)
            prescriptionItems.AsNoTracking();

        return await prescriptionItems.Where(prItem => !prItem.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<PrescriptionItem>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true)
    {
        var prescriptionItems = context.PrescriptionItems;

        if (includes != null)
            foreach (var include in includes)
                prescriptionItems.Include(include);

        if (!isTraking)
            prescriptionItems.AsNoTracking();

        return await Task.FromResult(prescriptionItems.AsQueryable().Where(prItem => !prItem.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }
}
