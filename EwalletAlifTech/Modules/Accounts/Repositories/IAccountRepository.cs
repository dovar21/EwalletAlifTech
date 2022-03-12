using EwalletAlifTech.Modules.Accounts.Entities;
using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Repositories;

namespace EwalletAlifTech.Modules.Accounts.Repositories
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<Account> FindEwalletAccountAsync(string phoneNumber);
        Task<Account> FindLockForUpdateAsync(Guid userId);
        Task<Account> FindLockForUpdateAsync(string phoneNumber);
    }
}
