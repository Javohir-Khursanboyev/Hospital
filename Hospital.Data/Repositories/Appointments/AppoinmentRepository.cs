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

        public async Task<Appointment> SelectAsync(long id, string[] includes = null)
        {
            var appointments = context.Appointments;
            if(includes is not null) 
                foreach(var include in includes)
                    appointments.Include(include);

            var appointment = await appointments.Where(app => !app.IsDeleted).FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> SelectAllAsEnumerableAsync()
        {
            var appointments = context.Appointments.Include("User").Include("Doctor");
            return await appointments.Where(appointment => !appointment.IsDeleted).ToListAsync();
        }

        public async Task<IQueryable<Appointment>> SelectAllAsQuerableAsync()
        {
            var appointments = context.Appointments.Include("User").Include("Doctor");
            return await Task.FromResult(appointments.AsQueryable().Where(appointment => !appointment.IsDeleted));
        }

        public async Task<bool> SaveAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
