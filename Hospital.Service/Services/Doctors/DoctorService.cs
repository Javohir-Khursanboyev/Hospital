using AutoMapper;
using Hospital.Data.Repositories.Doctors;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;
using Hospital.Service.Helpers;
namespace Hospital.Service.Services.Doctors;

public class DoctorService
    (IMapper mapper,
    IDoctorRepository doctorRepository) : IDoctorService
{
    public async Task<DoctorViewModel> CreateAsync(DoctorCreateModel model)
    {
        var existDoctor = (await doctorRepository.SelectAllAsQuerableAsync()).FirstOrDefault(doctor => doctor.Email == model.Email);
        if (existDoctor is not null)
            throw new AlreadyExistException($"Doctor is already exist with this email {model.Email}");

        var doctor = mapper.Map<Doctor>(model);
        doctor.Password = PasswordHasher.Hash(model.Password);
        var createdDoctor = await doctorRepository.InsertAsync(doctor);
        await doctorRepository.SaveAsync();

        return mapper.Map<DoctorViewModel>(createdDoctor);
    }

    public async Task<DoctorViewModel> UpdateAsync(long id, DoctorUpdateModel model)
    {
        var existDoctor = await doctorRepository.SelectAsync(id)
            ?? throw new NotFoundException($"Doctor is not found with this id: {id}");

        mapper.Map(model, existDoctor);
        existDoctor.UpdatedAt = DateTime.UtcNow;
        var updatedDoctor = await doctorRepository.UpdateAsync(existDoctor);
        await doctorRepository.SaveAsync();

        return mapper.Map<DoctorViewModel>(updatedDoctor);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDoctor = await doctorRepository.SelectAsync(id)
           ?? throw new NotFoundException($"Doctor is not found with this Id {id}");

        existDoctor.DeletedAt = DateTime.UtcNow;
        await doctorRepository.DeleteAsync(existDoctor);
        await doctorRepository.SaveAsync();

        return true;
    }

    public async Task<DoctorViewModel> GetByIdAsync(long id)
    {
        var existDoctor = await doctorRepository.SelectAsync(id, includes: ["Appointments", "Prescriptions"])
           ?? throw new NotFoundException($"Doctor is not found with this Id {id}");

        return mapper.Map<DoctorViewModel>(existDoctor);
    }

    public async Task<IEnumerable<DoctorViewModel>> GetAllAsync(PaginationParams @params)
    {
        var doctors = await doctorRepository.SelectAllAsQuerableAsync(["Appointments", "Prescriptions"], isTraking: false);
        doctors = doctors.ToPaginate(@params);

        return mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
    }
}
