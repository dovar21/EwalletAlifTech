using EwalletAlifTech.Modules.Accounts.ModelRequests;
using EwalletAlifTech.Modules.Accounts.Services;
using EwalletAlifTech.Modules.Core.Controllers;
using EwalletAlifTech.Modules.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.Accounts
{
    [Route("api/accounts")]
    public class AccountController : AuthorizeControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Route("exist")]
        [HttpPost]
        public async Task<IActionResult> GetEwalletAccount([FromBody] CheckEwalletAccountModelRequest model)
        {
            var data = await _accountService.FindEwalletAccountAsync(model.PhoneNumber);

            return new SuccessJsonObjectResult(data: data);
        }
        [Route("balance")]
        [HttpPost]
        public async Task<IActionResult> GetEwalletAccountBalance()
        {
            var data = await _accountService.CheckEwalletAccountBalanceAsync(GetAuthorizedUsername());

            return new SuccessJsonObjectResult(data: data);
        }
        [Route("replenish")]
        [HttpPost]
        public async Task<IActionResult> ReplenishEwalletAccount([FromBody] ReplenishEwalletAccountModelRequest model)
        {
            var data = await _accountService.ReplenishEwalletAccountAsync(model, GetAuthorizedUsername());

            return new SuccessJsonObjectResult(data: data);
        }
    }
}