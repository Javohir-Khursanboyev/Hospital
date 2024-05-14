using Hospital.Data.Repositories;
using Hospital.Service.DTOs.Users;
using Hospital.Service.Mappers;

namespace Hospital.Service.Users;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existUser = (await userRepository.SelectAllAsQuerableAsync()).FirstOrDefault(user => user.Email == model.Email && ! user.isDeleted);
        if (existUser is not null)
            throw new Exception("User is already exist");

        var user = Mapper.Map(model);
        var createdUser = await userRepository.InsertAsync(user);
        await userRepository.SaveAsync();

        return Mapper.Map(createdUser);
    }

    public Task<UserViewModel> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model)
    {
        throw new NotImplementedException();
    }
}