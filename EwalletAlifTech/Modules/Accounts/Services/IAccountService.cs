using System.Threading.Tasks;
using EwalletAlifTech.Modules.Accounts.ModelRequests;
using EwalletAlifTech.Modules.Accounts.ModelResponses;
using EwalletAlifTech.Modules.Transactions.ModelResponses;

namespace EwalletAlifTech.Modules.Accounts.Services
{
    public interface IAccountService
    {
        Task<CheckEwalletAccountModelResponse> FindEwalletAccountAsync(string phoneNumber);
        Task<CheckEwalletAccountBalanceModelResponse> CheckEwalletAccountBalanceAsync(string username);
        Task<TransactionModelResponse> ReplenishEwalletAccountAsync(ReplenishEwalletAccountModelRequest model, string username);
    }
}
