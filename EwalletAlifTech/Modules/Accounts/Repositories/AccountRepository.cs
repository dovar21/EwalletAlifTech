using EwalletAlifTech.Modules.Accounts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core;
using EwalletAlifTech.Modules.Core.Repositories;
using EwalletAlifTech.Modules.Accounts.Enums;

namespace EwalletAlifTech.Modules.Accounts.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
           
        }
        public async Task<Account> FindEwalletAccountAsync(string phoneNumber)
        {
            return await _dbContext.Accounts
                .Where(a => a.User.PhoneNumber == phoneNumber && a.AccountType == AccountType.Ewallet && a.IsActive)
                .SingleOrDefaultAsync();
        }
        public async Task<Account> FindLockForUpdateAsync(Guid userId)
        {
            return await _dbContext.Accounts
                .FromSqlRaw($@"SELECT * FROM `accounts` WHERE `user_id` = '{userId}' AND is_active=1 FOR UPDATE")
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<Account> FindLockForUpdateAsync(string phoneNumber)
        {
            return await _dbContext.Accounts
                .FromSqlRaw($@"SELECT a.* FROM `accounts` a, users u WHERE a.`user_id` = u.id  AND a.is_active=1 AND u.phone_number = '{phoneNumber}' FOR UPDATE")
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
