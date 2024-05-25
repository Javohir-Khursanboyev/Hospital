using AutoMapper;
using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Doctors;
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
    }
}