using EwalletAlifTech.Modules.Transactions.Entities;
using AutoMapper;

namespace EwalletAlifTech.Modules.Transactions.ModelResponses
{
    public class TransactionMapping : Profile
    {
        public TransactionMapping()
        {
            CreateMap<Transaction, TransactionModelResponse>()
                .ForMember(vm => vm.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(vm => vm.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
