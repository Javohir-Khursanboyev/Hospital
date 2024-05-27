using AutoMapper;
using Hospital.Data.Repositories.PrescriptionItems;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.PrescriptionItems;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;

namespace Hospital.Service.Services.PrescriptionItems;
public class PrescriptionItemService(IMapper mapper, IPrescriptionItemRepo prescriptionItemRepo) : IPrescriptionItemService
{
    public async Task<PrescriptionItemViewModel> CreateAsync(PrescriptionItemCreateModel model)
    {
        var existPrescriptionItem = (await prescriptionItemRepo.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.MedicineName == model.MedicineName && p.PrescriptionId == model.PrescriptionId)
            ?? throw new AlreadyExistException($"Prescription Item is already exist with this Medicine name{model.MedicineName}");

        var mappedPrescriptionItem = mapper.Map<PrescriptionItem>(model);
        var createdPrescriptionItem = await prescriptionItemRepo.InsertAsync(mappedPrescriptionItem);
        await prescriptionItemRepo.SaveAsync();

        return mapper.Map<PrescriptionItemViewModel>(mappedPrescriptionItem);
    }

    public async Task<PrescriptionItemViewModel> UpdateAsync(long id, PrescriptionItemUpdateModel model)
    {
        var existPrescriptionItem = await prescriptionItemRepo.SelectAsync(id)
            ?? throw new NotFoundException($"Appointment is not found with this id: {id}");

        var alreadyExistPrescriptionItem = (await prescriptionItemRepo.SelectAllAsQuerableAsync())
            .FirstOrDefault(p => p.Id != id && p.PrescriptionId == model.PrescriptionId);

        if (alreadyExistPrescriptionItem is not null)
            throw new AlreadyExistException($"Prescription Item is already exist with PrescriptionId {model.PrescriptionId}");

        mapper.Map(model, existPrescriptionItem);
        existPrescriptionItem.UpdatedAt = DateTime.UtcNow;

        var updatedPrescriptionItem = await prescriptionItemRepo.UpdateAsync(existPrescriptionItem);
        await prescriptionItemRepo.SaveAsync();

        return mapper.Map<PrescriptionItemViewModel>(updatedPrescriptionItem);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existPrescriptionItem = await prescriptionItemRepo.SelectAsync(id)
            ?? throw new NotFoundException($"Prescription Item is not found with this Id {id}");

        existPrescriptionItem.DeletedAt = DateTime.UtcNow;
        await prescriptionItemRepo.DeleteAsync(existPrescriptionItem);
        await prescriptionItemRepo.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<PrescriptionItemViewModel>> GetAllAsync(PaginationParams @params)
    {
        var prescriptionItems = await prescriptionItemRepo.SelectAllAsQuerableAsync();

        prescriptionItems = prescriptionItems.ToPaginate(@params);

        return mapper.Map<IEnumerable<PrescriptionItemViewModel>>(prescriptionItems);
    }

    public async Task<PrescriptionItemViewModel> GetByIdAsync(long id)
    {
        var existPrescriptionItem = await prescriptionItemRepo.SelectAsync(id)
            ?? throw new NotFoundException($"Prescription Item is not found with this Id {id}");

        return mapper.Map<PrescriptionItemViewModel>(existPrescriptionItem);
    }

    
}
