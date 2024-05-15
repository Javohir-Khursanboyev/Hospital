using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.PrescriptionItems;

public interface IPrescriptionItemRepo
{
    Task<PrescriptionItem> InsertAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> UpdateAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> DeleteAsync(PrescriptionItem prescriptionItem);
    Task<PrescriptionItem> SelectAsync(long id);
    Task<IEnumerable<PrescriptionItem>> SelectAllAsEnumerableAsync();
    Task<IQueryable<PrescriptionItem>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
