using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Prescriptions;

public interface IPrescriptionRepository
{
    Task<Prescription> InsertAsync(Prescription prescription);
    Task<Prescription> UpdateAsync(Prescription prescription);
    Task<Prescription> DeleteAsync(Prescription prescription);
    Task<Prescription> SelectAsync(long id, string include = null);
    Task<IEnumerable<Prescription>> SelectAllAsEnumerableAsync();
    Task<IQueryable<Prescription>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
