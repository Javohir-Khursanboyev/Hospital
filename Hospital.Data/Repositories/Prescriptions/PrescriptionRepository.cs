using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories.Prescriptions;

public class PrescriptionRepository : IPrescriptionRepository
{
    private AppDbContext context;
    public PrescriptionRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Prescription> InsertAsync(Prescription prescription)
    {
        return (await context.Prescriptions.AddAsync(prescription)).Entity;
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;  //  we use > 0 🧘
    }

    public async Task<IEnumerable<Prescription>> SelectAllAsEnumerableAsync()
    {
        return await context.Prescriptions.Where(pr => !pr.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<Prescription>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Prescriptions.AsQueryable().Where(pr => !pr.IsDeleted));
    }

    public async Task<Prescription> SelectAsync(long id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await context.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Prescription> UpdateAsync(Prescription prescription)
    {
        context.Prescriptions.Update(prescription);
        return await Task.FromResult(prescription);
    }
    public async Task<Prescription> DeleteAsync(Prescription prescription)
    {
        prescription.IsDeleted = true;
        context.Prescriptions.Update(prescription);
        return await Task.FromResult(prescription);
    }

}
