using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.DTOs.Users;

namespace Hospital.Service.Mappers;

public static class Mapper
{
    public static User Map(UserCreateModel model)
    {
        return new User 
        { 
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = model.Password
        };
    }

    public static UserViewModel Map(User model)
    {
        return new UserViewModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };
    }

    public static IEnumerable<UserViewModel> Map(IEnumerable<User> models)
    {
        return models.Select(user => new UserViewModel
        {
            Id = user.Id,
            Email = user.Email,
            LastName = user.LastName,
            FirstName = user.FirstName
        });
    }

    public static Doctor Map(DoctorCreateModel model)
    {
        return new Doctor
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = model.Password,
            Position = model.Position
        };
    }

    public static DoctorViewModel Map(Doctor model)
    {
        return new DoctorViewModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Position = model.Position
        };
    }

    public static Doctor Map(DoctorUpdateModel model)
    {
        return new Doctor
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Position = model.Position
        };
    }

    public static AppointmentViewModel Map(Appointment model)
    {
        return new AppointmentViewModel
        {
            Id = model.Id,
            User = Map(model.User),
            DateTime = model.DateTime,
            Doctor = Map(model.Doctor)
        };
    }
}