using System.Threading.Tasks;
using EwalletAlifTech.Modules.Settings.Entities;
using EwalletAlifTech.Modules.Core.Repositories;

namespace EwalletAlifTech.Modules.Settings.Repositories
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        Task<Setting> GetByKeyAsync(string key);
    }
}
