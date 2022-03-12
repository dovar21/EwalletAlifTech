using System.Threading.Tasks;
using EwalletAlifTech.Modules.Transactions.Entities;
using EwalletAlifTech.Modules.Transactions.ModelRequests;
using EwalletAlifTech.Modules.Transactions.ModelResponses;

namespace EwalletAlifTech.Modules.Transactions.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateHandle(CreateTransactionRequestModel model);
        Task<TransactionHistoryModelResponse> GetHistory(TransactionHistoryRequestModel model, string username);
    }
}
