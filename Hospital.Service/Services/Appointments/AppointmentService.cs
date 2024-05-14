using Hospital.Data.Repositories.Appointments;
using Hospital.Domain.Entities;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appoinmentRepository;
        private readonly IUserService userService;
        public AppointmentService(IAppointmentRepository appointmentRepository, IUserService userService)
        {
            this.appoinmentRepository = appointmentRepository;
            this.userService = userService;
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            var existUser = userService.GetByIdAsync(appointment.UserId);

            var existAppointment = (await appoinmentRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.UserId == appointment.UserId && a.DoctorId == appointment.DoctorId && a.DateTime == appointment.DateTime);
            if (existAppointment is not null)
                throw new Exception($"Appoinment is already exist in this datetime {appointment.DateTime} from {appointment.UserId} user Id and {appointment.DoctorId} doctor Id");

            var mappedAppointment = appointment;
            //var mappedAppointment = Mapper.Map(appointment);
            var createdAppointment = await appoinmentRepository.InsertAsync(mappedAppointment);
            await appoinmentRepository.SaveAsync();

            return createdAppointment;
            //return Mapper.Map(createdAppointment);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existAppointment = (await appoinmentRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.Id == id && !a.IsDeleted)
           ?? throw new Exception($"Appointment is not found with this Id {id}");

            existAppointment.DeletedAt = DateTime.UtcNow;
            await appoinmentRepository.DeleteAsync(existAppointment);
            await appoinmentRepository.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            var appointments = await appoinmentRepository.SelectAllAsEnumerableAsync();
            return appointments;
            //return Mapper.Map(appointments);
        }

        public async Task<Appointment> GetByIdAsync(long id)
        {
            var existAppointment = (await appoinmentRepository.SelectAllAsQuerableAsync()).FirstOrDefault(a => a.Id == id && !a.IsDeleted)
          ?? throw new Exception($"Appointment is not found with this Id {id}");

            return existAppointment;
            //return Mapper.Map(existAppointment);
        }

        public async Task<Appointment> UpdateAsync(long id, Appointment appointment)
        {
            var existUser = userService.GetByIdAsync(appointment.UserId);

            var existAppointment = (await appoinmentRepository.SelectAllAsQuerableAsync()).FirstOrDefault(a => a.Id == id && !a.IsDeleted)
           ?? throw new Exception($"Appointment is not found with this Id {id}");

            existAppointment.DateTime = appointment.DateTime;
            existAppointment.DoctorId = appointment.DoctorId;
            existAppointment.UserId = appointment.UserId;
            existAppointment.UpdatedAt = DateTime.UtcNow;

            var updatedAppointment = await appoinmentRepository.UpdateAsync(existAppointment);
            await appoinmentRepository.SaveAsync();


            return updatedAppointment;
            //return Mapper.Map(updatedAppointment);
        }
    }
}
