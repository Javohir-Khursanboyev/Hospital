using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Prescription;

namespace Hospital.Service.Services.Prescriptions;
public interface IPrescriptionService
{
    Task<PrescriptionViewModel> CreateAsync(PrescriptionCreateModel model);
    Task<PrescriptionViewModel> UpdateAsync(long id, PrescriptionUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<PrescriptionViewModel> GetByIdAsync(long id);
    Task<IEnumerable<PrescriptionViewModel>> GetAllAsync(PaginationParams @params);

}
