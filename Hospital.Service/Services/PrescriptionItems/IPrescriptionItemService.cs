using Hospital.Service.Configurations;
using Hospital.Service.DTOs.PrescriptionItems;

namespace Hospital.Service.Services.PrescriptionItems
{
    public interface IPrescriptionItemService
    {
        Task<PrescriptionItemViewModel> CreateAsync(PrescriptionItemCreateModel model);
        Task<PrescriptionItemViewModel> UpdateAsync(long id, PrescriptionItemUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<PrescriptionItemViewModel> GetByIdAsync(long id);
        Task<IEnumerable<PrescriptionItemViewModel>> GetAllAsync(PaginationParams @params);
    }
}
