using AutoMapper;
using Hospital.Data.Repositories.Prescriptions;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.DTOs.Users;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.Service.Services.Prescriptions;
public class PrescriptionService(
    IMapper mapper, 
    IPrescriptionRepository prescriptionRepository,
    IDoctorService doctorService,
    IUserService userService) : IPrescriptionService
{
        public async Task<PrescriptionViewModel> CreateAsync(PrescriptionCreateModel model)
        {
            var existUser = userService.GetByIdAsync(model.UserId);
            var existDoctor = doctorService.GetByIdAsync(model.DoctorId);

            var existPrescription = (await prescriptionRepository
                .SelectAllAsQuerableAsync())
                .FirstOrDefault(prescription => prescription.DoctorId == prescription.DoctorId
                && prescription.DateTime == model.DateTime);
            if (existPrescription is not null)
                throw new AlreadyExistException($"Prescription is already exist with this Doctor Id {model.DoctorId} and Date {model.DateTime}");

            var prescription = mapper.Map<Prescription>(model);
            var createdPrescription = await prescriptionRepository.InsertAsync(prescription);
            await prescriptionRepository.SaveAsync();

            return mapper.Map<PrescriptionViewModel>(createdPrescription);
        }

        public async Task<PrescriptionViewModel> UpdateAsync(long id, PrescriptionUpdateModel model)
        {
            var existUser = await userService.GetByIdAsync(model.UserId);
            var existDoctor = await doctorService.GetByIdAsync(model.DoctorId);

            var existPrescription = await prescriptionRepository.SelectAsync(id)
             ?? throw new NotFoundException($"Prescription is not found with this id: {id}");

            var alreadyExistPrescription = (await prescriptionRepository.SelectAllAsQuerableAsync())
                .FirstOrDefault(p => p.Id != id && !p.IsDeleted && p.DoctorId == model.DoctorId && p.DateTime == model.DateTime);

            if (alreadyExistPrescription is not null)
                throw new AlreadyExistException($"Prescription is already exist in PrescriptionId {id}");

            mapper.Map<Prescription>(model);
            existPrescription.UpdatedAt = DateTime.UtcNow;

            var updatedPrescription = await prescriptionRepository.UpdateAsync(existPrescription);
            await prescriptionRepository.SaveAsync();

            return mapper.Map<PrescriptionViewModel>(updatedPrescription);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existPrescription = await prescriptionRepository.SelectAsync(id)
               ?? throw new NotFoundException($"Prescription is not found with this Id {id}");

            existPrescription.DeletedAt = DateTime.UtcNow;
            await prescriptionRepository.DeleteAsync(existPrescription);
            await prescriptionRepository.SaveAsync();

            return true;
        }

        public async Task<PrescriptionViewModel> GetByIdAsync(long id)
        {
            var existPrescription = await prescriptionRepository.SelectAsync(id, includes: ["User", "Doctor", "Items"])
                ?? throw new NotFoundException($"Prescription is not found with this Id {id}");

            return mapper.Map<PrescriptionViewModel>(existPrescription);
        }

        public async Task<IEnumerable<PrescriptionViewModel>> GetAllAsync(PaginationParams @params)
        {
            var prescriptions = await prescriptionRepository.SelectAllAsQuerableAsync(["User", "Doctor", "Items"], isTracking: false);

            prescriptions = prescriptions.ToPaginate(@params);

            return mapper.Map<IEnumerable<PrescriptionViewModel>>(prescriptions);
        }
   
}