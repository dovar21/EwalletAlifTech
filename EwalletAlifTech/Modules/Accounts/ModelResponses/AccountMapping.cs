using AutoMapper;
using EwalletAlifTech.Modules.Accounts.Entities;
using EwalletAlifTech.Modules.Accounts.ModelResponses;

namespace ApiWalletServer.Modules.Accounts._Self.ModelResponses
{
    public class AccountMapping : Profile
    {
        public AccountMapping()
        {
            CreateMap<Account, CheckEwalletAccountModelResponse>()
                .ForMember(vm => vm.PhoneNumber, opt => opt.MapFrom(src => src.Number));

            CreateMap<Account, CheckEwalletAccountBalanceModelResponse>()
                .ForMember(vm => vm.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(vm => vm.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(vm => vm.BalanceLimit, opt => opt.MapFrom(src => src.BalanceLimit));
        }
    }
}
