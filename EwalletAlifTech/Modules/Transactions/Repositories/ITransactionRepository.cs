using EwalletAlifTech.Modules.Transactions.Entities;
using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Repositories;
using EwalletAlifTech.Modules.Transactions.ModelResponses;
using EwalletAlifTech.Modules.Transactions.Enums;

namespace EwalletAlifTech.Modules.Transactions.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        Task<TransactionHistoryModelResponse> GetHistory(Guid accountId,DateTime? startDate, DateTime? endDate, TransactionType transactionType);
    }
}
