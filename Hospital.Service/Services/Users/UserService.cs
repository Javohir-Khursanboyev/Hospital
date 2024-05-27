using AutoMapper;
using Hospital.Data.Repositories;
using Hospital.Domain.Entities;
using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Commons;
using Hospital.Service.DTOs.Users;
using Hospital.Service.Exceptions;
using Hospital.Service.Extensions;
using Hospital.Service.Helpers;

namespace Hospital.Service.Users;

public class UserService 
    (IMapper mapper, 
    IUserRepository userRepository) : IUserService
{
    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existUser = (await userRepository.SelectAllAsQuerableAsync()).FirstOrDefault(user => user.Email == model.Email && !user.IsDeleted);
        if (existUser is not null)
            throw new AlreadyExistException($"User is already exist with this email {model.Email}");

        var user = mapper.Map<User>(model);
        user.Password = PasswordHasher.Hash(model.Password);
        var createdUser = await userRepository.InsertAsync(user);
        await userRepository.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model)
    {
        var existUser = await userRepository.SelectAsync(id)
            ?? throw new NotFoundException($"User is not found with this id: {id}");

        mapper.Map(model, existUser);
        existUser.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await userRepository.UpdateAsync(existUser);
        await userRepository.SaveAsync();

        return mapper.Map<UserViewModel>(updatedUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id)
           ?? throw new NotFoundException($"User is not found with this Id {id}");

        existUser.DeletedAt = DateTime.UtcNow;
        await userRepository.DeleteAsync(existUser);
        await userRepository.SaveAsync();

        return true;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id, includes: ["Appointments" , "Contact", "Prescriptions"])
           ?? throw new NotFoundException($"User is not found with this Id {id}");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var users = await userRepository.SelectAllAsQuerableAsync(["Appointments", "Contact", "Prescriptions"], isTraking: false);

        users = users.ToPaginate(@params);

        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async Task<UserViewModel> ChangePasswordAysnc(long id, ChangePasswordModel changePassword)
    {
        var existUser = await userRepository.SelectAsync(id, includes: ["Appointments", "Contact", "Prescriptions"])
           ?? throw new NotFoundException($"User is not found with this Id {id}");

        if (!PasswordHasher.Verify(changePassword.OldPassword, existUser.Password))
            throw new CustomException(400, "Password is incorrect");

        if (changePassword.NewPassword != changePassword.ConfirmPassword)
            throw new CustomException(400, "");

        existUser.Password = PasswordHasher.Hash(changePassword.NewPassword);
        existUser.UpdatedAt = DateTime.UtcNow;
        var updatedUser = await userRepository.UpdateAsync(existUser);
        await userRepository.SaveAsync();

        return mapper.Map<UserViewModel>(updatedUser);
    }
}