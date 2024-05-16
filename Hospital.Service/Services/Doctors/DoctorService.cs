using Hospital.Data.Repositories;
using Hospital.Data.Repositories.Doctors;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.Exceptions;
using Hospital.Service.Mappers;

namespace Hospital.Service.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository doctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }
    public async Task<DoctorViewModel> CreateAsync(DoctorCreateModel model)
    {
        var existDoctor = (await doctorRepository.SelectAllAsQuerableAsync()).FirstOrDefault(doctor => doctor.Email == model.Email && !doctor.IsDeleted);
        if (existDoctor is not null)
            throw new AlreadyExistException($"Doctor is already exist with this email {model.Email}");
        var doctor = Mapper.Map(model);
        var createdDoctor = await doctorRepository.InsertAsync(doctor);
        await doctorRepository.SaveAsync();

        return Mapper.Map(createdDoctor);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDoctor = (await doctorRepository.SelectAllAsQuerableAsync()).FirstOrDefault(doctor => doctor.Id == id && !doctor.IsDeleted)
          ?? throw new NotFoundException($"Doctor is not found with this Id {id}");

        existDoctor.DeletedAt = DateTime.UtcNow;
        await doctorRepository.DeleteAsync(existDoctor);
        await doctorRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<DoctorViewModel>> GetAllAsync()
    {
        var doctors = await doctorRepository.SelectAllAsEnumerableAsync();
        return Mapper.Map(doctors);
    }

    public async Task<DoctorViewModel> GetByIdAsync(long id)
    {
        var existDoctor = (await doctorRepository.SelectAllAsQuerableAsync()).FirstOrDefault(doctor => doctor.Id == id && !doctor.IsDeleted)
            ?? throw new NotFoundException($"Doctor is not found with this id: {id}");

        return Mapper.Map(existDoctor);
    }

    public async Task<DoctorViewModel> UpdateAsync(long id, DoctorUpdateModel model)
    {
        var existDoctor = (await doctorRepository.SelectAllAsQuerableAsync()).FirstOrDefault(doctor => doctor.Id == id && !doctor.IsDeleted)
            ?? throw new NotFoundException($"Doctor is not found with this id: {id}");

        existDoctor.Email = model.Email;
        existDoctor.LastName = model.LastName;
        existDoctor.FirstName = model.FirstName;
        existDoctor.Position = model.Position;
        existDoctor.UpdatedAt = DateTime.UtcNow;

        var updatedDoctor = await doctorRepository.UpdateAsync(existDoctor);
        await doctorRepository.SaveAsync();

        return Mapper.Map(updatedDoctor);
    }
}
