using Hospital.Service.DTOs.Users;

namespace Hospital.Service.Users;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreateModel model);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}