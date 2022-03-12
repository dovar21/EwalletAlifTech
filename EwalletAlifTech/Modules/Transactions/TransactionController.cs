using EwalletAlifTech.Modules.Core.Controllers;
using EwalletAlifTech.Modules.Core.Responses;
using EwalletAlifTech.Modules.Transactions.ModelRequests;
using EwalletAlifTech.Modules.Transactions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.Accounts
{
    [Route("api/transactions")]
    public class TransactionController : AuthorizeControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [Route("history")]
        [HttpPost]
        public async Task<IActionResult> ReplenishEwalletAccount([FromBody] TransactionHistoryRequestModel model)
        {
            var data = await _transactionService.GetHistory(model, GetAuthorizedUsername());

            return new SuccessJsonObjectResult(data: data);
        }
    }
}