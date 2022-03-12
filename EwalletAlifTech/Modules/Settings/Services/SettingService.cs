using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Settings.Repositories;
using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.Users.Modules.Attestations.Helpers;

namespace EwalletAlifTech.Modules.Settings.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<bool> CanReceiveFundsAsync(Guid attestationId, decimal balance, decimal amount)
        {
            string key = attestationId == AttestationHelper.NOT_IDENTIFIED ? "NOT_IDENTIFIED_USER_MAX_BALANCE" : "IDENTIFIED_USER_MAX_BALANCE";

            var setting = await _settingRepository.GetByKeyAsync(key)
                ?? throw new ResourceNotFoundException("From account not found");

            decimal limit = decimal.Parse(setting.Value);

            return balance + amount <= limit;
        }
    }
}
