using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Doctors;

namespace Hospital.Service.Services.Doctors;

public interface IDoctorService
{
    Task<DoctorViewModel> CreateAsync(DoctorCreateModel model);
    Task<DoctorViewModel> UpdateAsync(long id, DoctorUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<DoctorViewModel> GetByIdAsync(long id);
    Task<IEnumerable<DoctorViewModel>> GetAllAsync(PaginationParams @params);
}
