using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Accounts.Repositories;
using EwalletAlifTech.Modules.Transactions.Entities;
using EwalletAlifTech.Modules.Transactions.ModelRequests;
using EwalletAlifTech.Modules.Transactions.Repositories;
using EwalletAlifTech.Modules.Users.Repositories;
using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.Core;
using EwalletAlifTech.Modules.Transactions.ModelResponses;

namespace EwalletAlifTech.Modules.Transactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(
            AppDbContext appDbContext,
            IUserRepository userRepository,
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository)
        {
            _appDbContext = appDbContext;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionHistoryModelResponse> GetHistory(TransactionHistoryRequestModel model, string username)
        {
            //Get authorized user
            var user = await _userRepository.FindByUsernameAsync(username) ??
                throw new LogicException("User not found");

            //Get user account
            var account = await _accountRepository.FindEwalletAccountAsync(user.PhoneNumber)
                ?? throw new LogicException("From account not found");

            return await _transactionRepository.GetHistory(account.Id,model.StartDate, model.EndDate, model.TransactionType);
        }
        public async Task<Transaction> CreateHandle(CreateTransactionRequestModel model)
        {
            using (var atomaric = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    //Get from account
                    var fromAccount = await _accountRepository.FindLockForUpdateAsync(model.FromUser.Id)
                        ?? throw new LogicException("From account not found");

                    //Get user who getting funds
                    var toUser = await _userRepository.FindByPhoneNumberAsync(model.PhoneNumber)
                        ?? throw new LogicException("To user not found");

                    //Get user account who getting funds
                    var toAccount = await _accountRepository.FindLockForUpdateAsync(model.PhoneNumber)
                        ?? throw new LogicException("To account not found");

                    //Withdraw
                    fromAccount.Withdraw(model.Amount);

                    await _accountRepository.Update(fromAccount);

                    //Replenish
                    toAccount.Replenish(model.Amount);

                    await _accountRepository.Update(toAccount);

                    //Create transaction
                    var transaction = new Transaction()
                    {
                        Id = Guid.NewGuid(),
                        FromAccountId = fromAccount.Id,
                        Amount = model.Amount,
                        AccountBalance = fromAccount.Balance,
                        CreatedByUserId = model.FromUser.Id,
                        ToAccountId = toAccount.Id
                    };

                    await _transactionRepository.Create(transaction);

                    //Commit and return transaction
                    atomaric.Commit();
                    return transaction;

                }
                catch (Exception)
                {
                    atomaric.Rollback();

                    throw;
                }
            }
        }
    }
}