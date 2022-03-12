using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Users.Entities;
using EwalletAlifTech.Modules.Core.Repositories;

namespace EwalletAlifTech.Modules.Users.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        new Task<User> FindByIdAsync(Guid id);
        Task<User> FindByUsernameAsync(string username);
        Task<User> FindByPhoneNumberAsync(string phoneNumber);
    }
}
