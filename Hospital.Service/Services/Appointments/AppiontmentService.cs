using AutoMapper;
using Hospital.Data.Repositories.Appointments;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Appointments
{
    public class AppiontmentService
        (IMapper mapper,
        IAppointmentRepository appointmentRepository,
        IUserService userService,
        IDoctorService doctorService) : IAppiontmentService
    {

        public async Task<AppointmentViewModel> CreateAsync(AppointmentCreateModel model)
        {
            var existDoctor = doctorService.GetByIdAsync(model.DoctorId);
            var existUser = userService.GetByIdAsync(model.UserId);

            var existAppointment = (await appointmentRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(a => a.UserId == model.UserId && a.DoctorId == model.DoctorId && a.DateTime == model.DateTime)
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

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAsync(PaginationParams @params)
        {
            var appointments = await appointmentRepository.SelectAllAsQuerableAsync(["Doctor", "User"], isTraking: false);

            appointments = appointments.ToPaginate(@params);

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