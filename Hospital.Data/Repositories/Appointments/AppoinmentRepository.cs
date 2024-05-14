using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories.Appointments
{
    public class AppoinmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext context;
        public AppoinmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Appointment> InsertAsync(Appointment appointment)
        {
            return (await context.Appointments.AddAsync(appointment)).Entity;
        }

        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            return await Task.FromResult(appointment);
        }

        public async Task<Appointment> DeleteAsync(Appointment appointment)
        {
            appointment.IsDeleted = true;
            context.Appointments.Update(appointment);
            return await Task.FromResult(appointment);
        }

        public async Task<Appointment> SelectAsync(long id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Appointment>> SelectAllAsEnumerableAsync()
        {
            return await context.Appointments.Where(appointment => !appointment.IsDeleted).ToListAsync();
        }

        public async Task<IQueryable<Appointment>> SelectAllAsQuerableAsync()
        {
            return await Task.FromResult(context.Appointments.AsQueryable().Where(appointment => !appointment.IsDeleted));
        }

        public async Task<bool> SaveAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
