using System.Threading.Tasks;
using EwalletAlifTech.Modules.Settings.Entities;
using EwalletAlifTech.Modules.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using EwalletAlifTech.Modules.Core;

namespace EwalletAlifTech.Modules.Settings.Repositories
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public async Task<Setting> GetByKeyAsync(string key)
        {
            return await _dbContext.Settings.FromSqlRaw($"select * from settings where `key` = {key} FOR UPDATE")
                .AsNoTracking()
                .SingleOrDefaultAsync();  
        }
    }
}
