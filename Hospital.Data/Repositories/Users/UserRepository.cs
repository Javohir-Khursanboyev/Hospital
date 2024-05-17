using Hospital.Data.DbContexts;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories;

public class UserRepository : IUserRepository
{
    private AppDbContext context;
    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<User> InsertAsync(User user)
    {
        return (await context.Users.AddAsync(user)).Entity;
    }

    public async Task<User> UpdateAsync(User user)
    {
        context.Users.Update(user);
        return await Task.FromResult(user);
    }

    public async Task<User> DeleteAsync(User user)
    {
        user.IsDeleted = true;
        context.Users.Update(user);
        return await Task.FromResult(user);
    }

    public async Task<User> SelectAsync(long id, string[] includes = null)
    {
       var users = context.Users;

       if(includes is not null)
            foreach (var include in includes)
                users.Include(include);

        var user = await users.Where(u => u.Id == id && !u.IsDeleted).FirstAsync();

        return user;
    }

    public async Task<IEnumerable<User>> SelectAllAsEnumerableAsync()
    {
        return await context.Users.Where(user => !user.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<User>> SelectAllAsQuerableAsync()
    {
        var users = context.Users.Include("Appointments").Include("Prescriptions").Include("Prescriptions");
        users = await Task.FromResult(users.Where(user => !user.IsDeleted));
        return users;
    }

    public async Task<bool> SaveAsync()
    {
       return (await context.SaveChangesAsync()) > 0;
    }
}