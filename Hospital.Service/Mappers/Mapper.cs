using Hospital.Domain.Entities;
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
}