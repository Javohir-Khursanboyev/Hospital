using AutoMapper;
using Hospital.Data.Repositories.Appointments;
using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.Exceptions;
using Hospital.Service.Mappers;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Appointments
{
    public class AppiontmentService : IAppiontmentService
    {
        private readonly IMapper mapper;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IUserService userService;
        private readonly IDoctorService doctorService;
        public AppiontmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService, IUserService userService, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.userService = userService;
            this.doctorService = doctorService;
            this.mapper = mapper;
        }

        public async Task<AppointmentViewModel> CreateAsync(AppointmentCreateModel model)
        {
            var existDoctor = doctorService.GetByIdAsync(model.DoctorId);
            var existUser = userService.GetByIdAsync(model.UserId);

            var existAppointment = (await appointmentRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.UserId == model.UserId && a.DoctorId == model.DoctorId && a.DateTime == model.DateTime && !a.IsDeleted)
                    ?? throw new AlreadyExistException($"Appointment is already exist with this User {model.UserId} Id and Doctor {model.DoctorId} Id from {model.DateTime}");

            var mappedAppointment = mapper.Map<Appointment>(model);
            var createdAppointment = await appointmentRepository.InsertAsync(mappedAppointment);
            await appointmentRepository.SaveAsync();

            return mapper.Map<AppointmentViewModel>(createdAppointment);
        }

        public async Task<AppointmentViewModel> UpdateAsync(long id, AppointmentUpdateModel model)
        {
            var existAppointment = await appointmentRepository.SelectAsync(id)
                ?? throw new NotFoundException($"Appointment is not found with this id: {id}");

            var alreadyExistAppointment = (await appointmentRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.DoctorId == model.DoctorId && a.DateTime == model.DateTime && a.Id != id);

            if (alreadyExistAppointment is not null)
                throw new AlreadyExistException($"This Appointment is already exist with this DoctorId {model.DoctorId} and this time {model.DateTime}");

            existAppointment.UpdatedAt = DateTime.UtcNow;
            mapper.Map(model, existAppointment);

            var updatedAppointment = await appointmentRepository.UpdateAsync(existAppointment);
            await appointmentRepository.SaveAsync();

            return mapper.Map<AppointmentViewModel>(updatedAppointment);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existAppointment = await appointmentRepository.SelectAsync(id)
                ?? throw new NotFoundException($"Appointment is not found with this Id {id}");

            existAppointment.DeletedAt = DateTime.UtcNow;
            await appointmentRepository.DeleteAsync(existAppointment);
            await appointmentRepository.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAsync()
        {
            var appointments = await appointmentRepository.SelectAllAsEnumerableAsync();
            return mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }

        public async Task<AppointmentViewModel> GetByIdAsync(long id)
        {
            var existAppointment = await appointmentRepository.SelectAsync(id)
                ?? throw new NotFoundException($"Appointment is not found with this Id {id}");

            return mapper.Map<AppointmentViewModel>(existAppointment);
        }
    }
}