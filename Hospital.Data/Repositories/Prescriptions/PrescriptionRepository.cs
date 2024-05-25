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

    public async Task<Prescription> SelectAsync(long id, string[] includes = null)
    {
        var prescriptions = context.Prescriptions;

        if (includes is not null)
            foreach (var include in includes)
                prescriptions.Include(include); ;

        var prescription = await prescriptions.Where(pr => !pr.IsDeleted && pr.Id == id).FirstOrDefaultAsync();

        return prescription;
    }

    public async Task<IEnumerable<Prescription>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTracking = true)
    {
        var prescriptions = context.Prescriptions;

        if (includes is not null)
            foreach (var include in includes)
                prescriptions.Include(include);

        if (!isTracking)
            prescriptions.AsNoTracking();

        return await prescriptions.Where(pr => !pr.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<Prescription>> SelectAllAsQuerableAsync(string[] includes = null, bool isTracking = true)
    {
        var prescriptions = context.Prescriptions;

        if(includes is not null)
            foreach (var include in includes)
                prescriptions.Include(include);

        if (!isTracking)
            prescriptions.AsNoTracking();

        return await Task.FromResult(prescriptions.AsQueryable().Where(pr => !pr.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0; 
    }
}