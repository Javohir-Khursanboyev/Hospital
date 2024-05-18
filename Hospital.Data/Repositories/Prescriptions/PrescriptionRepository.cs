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

    public async Task<Prescription> SelectAsync(long id, string include = null)
    {
        var prescriptions = context.Prescriptions;
        if (include is not null)
            prescriptions.Include(include);

        var prescription = await prescriptions.Where(pr => !pr.IsDeleted && pr.Id == id).FirstOrDefaultAsync();

        return prescription;
    }

    public async Task<IEnumerable<Prescription>> SelectAllAsEnumerableAsync()
    {
        var prescriptions = context.Prescriptions.Include("Items");
        return await prescriptions.Where(pr => !pr.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<Prescription>> SelectAllAsQuerableAsync()
    {
        var prescriptions = context.Prescriptions.Include("Items");
        return await Task.FromResult(prescriptions.AsQueryable().Where(pr => !pr.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;  //  we use > 0 🧘
    }
}
