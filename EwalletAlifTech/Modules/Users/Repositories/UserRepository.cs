using System;
using System.Linq;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Repositories;
using EwalletAlifTech.Modules.Users.Entities;
using EwalletAlifTech.Modules.Core;
using Microsoft.EntityFrameworkCore;

namespace EwalletAlifTech.Modules.Users.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public new async Task<User> FindByIdAsync(Guid id)
        {
            return await _dbContext.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _dbContext.Users.Where(u => u.UserName == username && u.IsActive).SingleOrDefaultAsync();
        }
        public async Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbContext.Users.Where(u => u.PhoneNumber == phoneNumber && u.IsActive).SingleOrDefaultAsync();
        }
    }
}
