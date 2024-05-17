using Hospital.Service.DTOs.Appointments;

namespace Hospital.Service.Services.Appointments
{
    public interface IAppiontmentService
    {
        Task<AppointmentViewModel> CreateAsync(AppointmentCreateModel model);
        Task<AppointmentViewModel> UpdateAsync(long id, AppointmentUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<AppointmentViewModel> GetByIdAsync(long id);
        Task<IEnumerable<AppointmentViewModel>> GetAllAsync();
    }
}
