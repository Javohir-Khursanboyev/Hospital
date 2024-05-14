using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Doctors;

public interface IDoctorRepository
{
    Task<Doctor> InsertAsync(Doctor doctor);
    Task<Doctor> UpdateAsync(Doctor doctor);
    Task<Doctor> DeleteAsync(Doctor doctor);
    Task<Doctor> SelectAsync(long id);
    Task<IEnumerable<Doctor>> SelectAllAsEnumerableAsync();
    Task<IQueryable<Doctor>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
