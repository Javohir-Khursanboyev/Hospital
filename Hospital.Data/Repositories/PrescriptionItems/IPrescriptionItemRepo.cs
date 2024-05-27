using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.PrescriptionItems;

public interface IPrescriptionItemRepo
{
    Task<PrescriptionItem> InsertAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> UpdateAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> DeleteAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<PrescriptionItem>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
    Task<IQueryable<PrescriptionItem>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
    Task<bool> SaveAsync();
}
