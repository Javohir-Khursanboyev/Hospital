using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories.Doctors;

public class DoctorRepository : IDoctorRepository
{
    private AppDbContext context;
    public DoctorRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Doctor> InsertAsync(Doctor doctor)
    {
        return (await context.Doctors.AddAsync(doctor)).Entity;
    }

    public async Task<IEnumerable<Doctor>> SelectAllAsEnumerableAsync()
    {
        return await context.Doctors.Where(doctor => !doctor.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<Doctor>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Doctors.AsQueryable().Where(doctor => !doctor.IsDeleted));
    }

    public async Task<Doctor> SelectAsync(long id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        context.Doctors.Update(doctor);
        return await Task.FromResult(doctor);
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

    public async Task<Doctor> DeleteAsync(Doctor doctor)
    {
        doctor.IsDeleted = true;
        context.Doctors.Update(doctor);
        return await Task.FromResult(doctor);
    }
}
