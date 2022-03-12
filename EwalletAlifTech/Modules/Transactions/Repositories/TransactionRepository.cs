using EwalletAlifTech.Modules.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Repositories;
using EwalletAlifTech.Modules.Core;
using EwalletAlifTech.Modules.Transactions.ModelResponses;
using EwalletAlifTech.Modules.Transactions.Enums;
using EwalletAlifTech.Modules.Core.Extensions;

namespace EwalletAlifTech.Modules.Transactions.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<TransactionHistoryModelResponse> GetHistory(Guid accountId, DateTime? startDate, DateTime? endDate, TransactionType transactionType)
        {
            var query = this._dbContext.Transactions.AsQueryable();

            //Get start and end dates by default
            if (!startDate.HasValue && !endDate.HasValue)
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.Value.AddMonths(1).AddDays(-1);

            }
            //Filter by start and end dates
            query = query.Where(t => t.CreatedAt >= startDate && t.CreatedAt <= endDate);

            //Filter transaction type
            if(transactionType == TransactionType.Replenishment)
                query = query.Where(t => t.ToAccountId == accountId);
            else
                query = query.Where(t => t.FromAccountId == accountId);

            var result = await query.GroupBy(i => 1)
                .Select(g => new TransactionHistoryModelResponse
                {
                    Total = g.Count(),
                    Amount = g.Sum(i => i.Amount)
                }
            ).FirstOrDefaultAsync();

            result.TransactionType = transactionType.GetDisplayName();

            return result;
        }
    }
}
