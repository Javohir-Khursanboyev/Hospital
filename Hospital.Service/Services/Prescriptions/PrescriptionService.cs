using AutoMapper;
using Hospital.Data.Repositories.Prescriptions;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.DTOs.Users;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;
using Hospital.Service.Mappers;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Prescriptions;
public class PrescriptionService(
        IMapper mapper, IPrescriptionRepository prescriptionRepository, IDoctorService doctorService, IUserService userService) : IPrescriptionService
{

    public async Task<PrescriptionViewModel> CreateAsync(PrescriptionCreateModel model)
    {
        var existDoctor = doctorService.GetByIdAsync(model.DoctorId);
        var existUser = userService.GetByIdAsync(model.UserId);

        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.UserId == model.UserId && p.DoctorId == model.DoctorId && p.DateTime == model.DateTime && !p.IsDeleted)
            ?? throw new AlreadyExistException($"Prescription is already exist with this User {model.UserId} Id and Doctor {model.DoctorId} Id from {model.DateTime}");

        var mappedPrescription = mapper.Map<Prescription>(model);
        var createdPrescription = await prescriptionRepository.InsertAsync(mappedPrescription);
        await prescriptionRepository.SaveAsync();

        return mapper.Map<PrescriptionViewModel>(mappedPrescription);
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

    public async Task<IEnumerable<PrescriptionViewModel>> GetAllAsync(PaginationParams @params)
    {
        var prescriptions = await prescriptionRepository.SelectAllAsQuerableAsync();

        prescriptions = prescriptions.ToPaginate(@params);

        return mapper.Map<IEnumerable<PrescriptionViewModel>>(prescriptions);
    }

    public async Task<PrescriptionViewModel> GetByIdAsync(long id)
    {
        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync()).FirstOrDefault(p => p.Id == id && !p.IsDeleted)
            ?? throw new NotFoundException($"Prescription is not found with this Id {id}");

        return mapper.Map<PrescriptionViewModel>(existPrescription);
    }

    public async Task<PrescriptionViewModel> UpdateAsync(long id, PrescriptionUpdateModel model)
    {
        var existPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync()).FirstOrDefault(p => p.Id == id && !p.IsDeleted)
         ?? throw new NotFoundException($"Prescription is not found with this id: {id}");

        var notUpdatedPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.Id != id && !p.IsDeleted && p.DoctorId == model.DoctorId && p.DateTime == model.DateTime);
        if (notUpdatedPrescription is not null)
            throw new AlreadyExistException($"This Prescription is not updated, because the Doctor from {model.DoctorId} Id is bisy from {model.DateTime} time");

        mapper.Map(model, existPrescription);
        existPrescription.UpdatedAt = DateTime.UtcNow;

        var updatedPrescription = await prescriptionRepository.UpdateAsync(existPrescription);
        await prescriptionRepository.SaveAsync();

        return mapper.Map<PrescriptionViewModel>(updatedPrescription);
    }
}
