using AutoMapper;
using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.DTOs.PrescriptionItems;
using Hospital.Service.DTOs.Users;

namespace Hospital.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();

        CreateMap<DoctorCreateModel, Doctor>().ReverseMap();
        CreateMap<DoctorUpdateModel, Doctor>().ReverseMap();
        CreateMap<Doctor, DoctorViewModel>().ReverseMap();

        CreateMap<AppointmentCreateModel, Appointment>().ReverseMap();
        CreateMap<AppointmentUpdateModel, Appointment>().ReverseMap();
        CreateMap<Appointment, AppointmentViewModel>().ReverseMap();

        CreateMap<PrescriptionCreateModel, Prescription>().ReverseMap();
        CreateMap<PrescriptionUpdateModel, Prescription>().ReverseMap();
        CreateMap<Prescription, PrescriptionViewModel>().ReverseMap();

        CreateMap<PrescriptionItemCreateModel, PrescriptionItem>().ReverseMap();
        CreateMap<PrescriptionItemUpdateModel, PrescriptionItem>().ReverseMap();
        CreateMap<PrescriptionItem, PrescriptionItemViewModel>().ReverseMap();

    }
}