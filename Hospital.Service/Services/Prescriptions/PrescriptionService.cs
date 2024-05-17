using Hospital.Data.Repositories.Prescriptions;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.Exceptions;
using Hospital.Service.Mappers;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Prescriptions;
public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository prescriptionRepository;
    private readonly IUserService userService;
    private readonly IDoctorService doctorService;
    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IDoctorService doctorService, IUserService userService)
    {
        this.prescriptionRepository = prescriptionRepository;
        this.userService = userService;
        this.doctorService = doctorService;
    }


    public async Task<PrescriptionViewModel> CreateAsync(PrescriptionCreateModel model)
    {
        var existDoctor = doctorService.GetByIdAsync(model.DoctorId);
        var existUser = userService.GetByIdAsync(model.UserId);

        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.UserId == model.UserId && p.DoctorId == model.DoctorId && p.DateTime == model.DateTime && !p.IsDeleted)
            ?? throw new AlreadyExistException($"Prescription is already exist with this User {model.UserId} Id and Doctor {model.DoctorId} Id from {model.DateTime}");

        var mappedPrescription = Mapper.Map(model);
        var createdPrescription = await prescriptionRepository.InsertAsync(mappedPrescription);
        await prescriptionRepository.SaveAsync();

        return Mapper.Map(createdPrescription);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync()).FirstOrDefault(p => p.Id == id && !p.IsDeleted)
       ?? throw new NotFoundException($"Prescription is not found with this Id {id}");

        existPrescription.DeletedAt = DateTime.UtcNow;
        await prescriptionRepository.DeleteAsync(existPrescription);
        await prescriptionRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<PrescriptionViewModel>> GetAllAsync()
    {
        var prescriptions = await prescriptionRepository.SelectAllAsEnumerableAsync();
        return Mapper.Map(prescriptions);
    }

    public async Task<PrescriptionViewModel> GetByIdAsync(long id)
    {
        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync()).FirstOrDefault(p => p.Id == id && !p.IsDeleted)
      ?? throw new NotFoundException($"Prescription is not found with this Id {id}");

        return Mapper.Map(existPrescription);
    }

    public async Task<PrescriptionViewModel> UpdateAsync(long id, PrescriptionUpdateModel model)
    {
        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync()).FirstOrDefault(p => p.Id == id && !p.IsDeleted)
         ?? throw new NotFoundException($"Prescription is not found with this id: {id}");

        var notUpdatedPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.Id != id && !p.IsDeleted && p.DoctorId == model.DoctorId && p.DateTime == model.DateTime);
        if (notUpdatedPrescription is not null)
            throw new AlreadyExistException($"This Prescription is not updated, because the Doctor from {model.DoctorId} Id is bisy from {model.DateTime} time");

        existPrescription.DateTime = model.DateTime;
        existPrescription.DoctorId = model.DoctorId;
        existPrescription.UserId = model.UserId;
        existPrescription.UpdatedAt = DateTime.UtcNow;

        var updatedPrescription = await prescriptionRepository.UpdateAsync(existPrescription);
        await prescriptionRepository.SaveAsync();

        return Mapper.Map(updatedPrescription);
    }
}
