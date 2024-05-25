using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Prescriptions;

public interface IPrescriptionRepository
{
    Task<Prescription> InsertAsync(Prescription prescription);
    Task<Prescription> UpdateAsync(Prescription prescription);
    Task<Prescription> DeleteAsync(Prescription prescription);
    Task<Prescription> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<Prescription>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTracking = true);
    Task<IQueryable<Prescription>> SelectAllAsQuerableAsync(string[] includes = null, bool isTracking = true);
    Task<bool> SaveAsync();
}
