using Hospital.Data.Repositories.Appointments;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.Exceptions;
using Hospital.Service.Mappers;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Appointments
{
    public class AppiontmentService : IAppiontmentService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IUserService userService;
        private readonly IDoctorService doctorService;
        public AppiontmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService, IUserService userService)
        {
            this.appointmentRepository = appointmentRepository;
            this.userService = userService;
            this.doctorService = doctorService;
        }

        public async Task<AppointmentViewModel> CreateAsync(AppointmentCreateModel model)
        {
            var existDoctor = doctorService.GetByIdAsync(model.DoctorId);
            var existUser = userService.GetByIdAsync(model.UserId);

            var existAppointment = (await appointmentRepository.SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.UserId == model.UserId && a.DoctorId == model.DoctorId && a.DateTime == model.DateTime && !a.IsDeleted)
                ?? throw new AlreadyExistException($"Appointment is already exist with this User {model.UserId} Id and Doctor {model.DoctorId} Id from {model.DateTime}");

            var mappedAppointment = Mapper.Map(model);
            var createdAppointment = await appointmentRepository.InsertAsync(mappedAppointment);
            await appointmentRepository.SaveAsync();

            return Mapper.Map(createdAppointment);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existAppointment = (await appointmentRepository.SelectAllAsQuerableAsync()).FirstOrDefault(a => a.Id == id && !a.IsDeleted)
           ?? throw new NotFoundException($"Appointment is not found with this Id {id}");

            existAppointment.DeletedAt = DateTime.UtcNow;
            await appointmentRepository.DeleteAsync(existAppointment);
            await appointmentRepository.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAsync()
        {
            var appointments = await appointmentRepository.SelectAllAsEnumerableAsync();
            return Mapper.Map(appointments);
        }

        public async Task<AppointmentViewModel> GetByIdAsync(long id)
        {
            var existAppointment = (await appointmentRepository.SelectAllAsQuerableAsync()).FirstOrDefault(a => a.Id == id && !a.IsDeleted)
          ?? throw new NotFoundException($"Appointment is not found with this Id {id}");

            return Mapper.Map(existAppointment);
        }

        public async Task<AppointmentViewModel> UpdateAsync(long id, AppointmentUpdateModel model)
        {
            var existAppointment = (await appointmentRepository.SelectAllAsQuerableAsync()).FirstOrDefault(a => a.Id == id && !a.IsDeleted)
             ?? throw new NotFoundException($"Appointment is not found with this id: {id}");

            var notUpdatedAppointment = (await appointmentRepository.SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.Id != id && !a.IsDeleted && a.DoctorId == model.DoctorId && a.DateTime == model.DateTime);
            if (notUpdatedAppointment is not null)
                throw new AlreadyExistException($"This Appointment is not updated, because the Doctor from {model.DoctorId} Id is bisy from {model.DateTime} time");

            existAppointment.DateTime = model.DateTime;
            existAppointment.DoctorId = model.DoctorId;
            existAppointment.UserId = model.UserId;
            existAppointment.UpdatedAt = DateTime.UtcNow;

            var updatedAppointment = await appointmentRepository.UpdateAsync(existAppointment);
            await appointmentRepository.SaveAsync();

            return Mapper.Map(updatedAppointment);
        }
    }
}
