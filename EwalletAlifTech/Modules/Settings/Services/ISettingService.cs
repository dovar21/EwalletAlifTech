using System;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.Settings.Services
{
    public interface ISettingService
    {
        Task<bool> CanReceiveFundsAsync(Guid attestationId, decimal balance, decimal amount);
    }
}
