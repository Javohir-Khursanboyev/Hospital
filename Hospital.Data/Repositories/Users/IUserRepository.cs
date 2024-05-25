using Hospital.Domain.Entities;

namespace Hospital.Data.Repositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);   
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task<User> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<User>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
    Task<IQueryable<User>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
    Task<bool> SaveAsync();
}