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

    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        context.Doctors.Update(doctor);
        return await Task.FromResult(doctor);
    }

    public async Task<Doctor> DeleteAsync(Doctor doctor)
    {
        doctor.IsDeleted = true;
        context.Doctors.Update(doctor);
        return await Task.FromResult(doctor);
    }

    public async Task<Doctor> SelectAsync(long id, string[] includes = null)
    {
        var doctors = context.Doctors;

        if(includes is not null) 
            foreach(var include in includes) 
                doctors.Include(include);

        return await doctors.Where(doctor => !doctor.IsDeleted && doctor.Id == id).FirstOrDefaultAsync();    
    }
    public async Task<IEnumerable<Doctor>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true)
    {
        var doctors = context.Doctors;

        if (includes is not null)
            foreach (var include in includes)
                doctors.Include(include);

        if (!isTraking)
            doctors.AsNoTracking();

        return await doctors.Where(doctor => !doctor.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<Doctor>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true)
    {
        var doctors = context.Doctors;

        if (includes is not null)
            foreach (var include in includes)
                doctors.Include(include);

        if (!isTraking)
            doctors.AsNoTracking();

        return await Task.FromResult(doctors.AsQueryable().Where(doctor => !doctor.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }
}
