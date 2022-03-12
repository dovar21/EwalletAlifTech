using System.Threading.Tasks;
using EwalletAlifTech.Modules.Accounts.Repositories;
using EwalletAlifTech.Modules.Users.Repositories;
using EwalletAlifTech.Modules.Core.Exceptions;
using AutoMapper;
using EwalletAlifTech.Modules.Accounts.ModelResponses;
using EwalletAlifTech.Modules.Accounts.ModelRequests;
using EwalletAlifTech.Modules.Transactions.Services;
using EwalletAlifTech.Modules.Transactions.ModelRequests;
using EwalletAlifTech.Modules.Transactions.ModelResponses;

namespace EwalletAlifTech.Modules.Accounts.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ITransactionService transactionService
            )
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _transactionService = transactionService;
        }
        public async Task<CheckEwalletAccountModelResponse> FindEwalletAccountAsync(string phoneNumber)
        {
            //Check ewallet account
            var account = await _accountRepository.FindEwalletAccountAsync(phoneNumber) ??
                throw new LogicException("Account not found");

            //Get mapped ewallet account
            return _mapper.Map<CheckEwalletAccountModelResponse>(account);
        }

        public async Task<CheckEwalletAccountBalanceModelResponse> CheckEwalletAccountBalanceAsync(string username)
        {
            //Get authorized user
            var user = await _userRepository.FindByUsernameAsync(username) ??
                throw new LogicException("User not found");

            //Check ewallet account
            var account = await _accountRepository.FindEwalletAccountAsync(user.PhoneNumber) ??
                throw new LogicException("Account not found");

            //Get mapped ewallet account
            return _mapper.Map<CheckEwalletAccountBalanceModelResponse>(account);
        }
        public async Task<TransactionModelResponse> ReplenishEwalletAccountAsync(ReplenishEwalletAccountModelRequest model, string username)
        {
            //Get authorized user
            var user = await _userRepository.FindByUsernameAsync(username) ??
                throw new LogicException("User not found");

            //Create from Ewallet to Ewallet transaction
            var transaction = await _transactionService.CreateHandle(new CreateTransactionRequestModel
            {
                FromUser = user,
                PhoneNumber = model.PhoneNumber,
                Amount = model.Amount
            });

            //Get mapped transaction
            return _mapper.Map<TransactionModelResponse>(transaction);
        }
    }
}
