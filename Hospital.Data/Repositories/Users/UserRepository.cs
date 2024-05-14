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

    public async Task<User> SelectAsync(long id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<IEnumerable<User>> SelectAllAsEnumerableAsync()
    {
        return await context.Users.Where(user => !user.IsDeleted).ToListAsync();
    }

    public async Task<IQueryable<User>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Users.AsQueryable().Where(user => !user.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
       return (await context.SaveChangesAsync()) > 0;
    }
}