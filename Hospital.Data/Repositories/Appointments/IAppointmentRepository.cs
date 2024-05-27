using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories.Appointments
{
    public interface IAppointmentRepository
    {
        Task<Appointment> InsertAsync(Appointment appointment);
        Task<Appointment> UpdateAsync(Appointment appointment);
        Task<Appointment> DeleteAsync(Appointment appointment);
        Task<Appointment> SelectAsync(long id, string[] includes = null);
        Task<IEnumerable<Appointment>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
        Task<IQueryable<Appointment>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
        Task<bool> SaveAsync();
    }
}
