using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Doctors;

public interface IDoctorRepository
{
    Task<Doctor> InsertAsync(Doctor doctor);
    Task<Doctor> UpdateAsync(Doctor doctor);
    Task<Doctor> DeleteAsync(Doctor doctor);
    Task<Doctor> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<Doctor>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
    Task<IQueryable<Doctor>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
    Task<bool> SaveAsync();
}
