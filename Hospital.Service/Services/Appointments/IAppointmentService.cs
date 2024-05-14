using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Users;

namespace Hospital.Service.Services.Appointments
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<Appointment> UpdateAsync(long id, Appointment appointment);
        Task<bool> DeleteAsync(long id);
        Task<Appointment> GetByIdAsync(long id);
        Task<IEnumerable<Appointment>> GetAllAsync();
    }
}
