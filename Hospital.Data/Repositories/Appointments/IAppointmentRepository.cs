using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Appointments
{
    public interface IAppointmentRepository
    {
        Task<Appointment> InsertAsync(Appointment appointment);
        Task<Appointment> UpdateAsync(Appointment appointment);
        Task<Appointment> DeleteAsync(Appointment appointment);
        Task<Appointment> SelectAsync(long id);
        Task<IEnumerable<Appointment>> SelectAllAsEnumerableAsync();
        Task<IQueryable<Appointment>> SelectAllAsQuerableAsync();
        Task<bool> SaveAsync();
    }
}
