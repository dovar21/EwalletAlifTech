using EwalletAlifTech.Modules.Core.Entities;
using EwalletAlifTech.Modules.Accounts.Entities;
using EwalletAlifTech.Modules.Users.Entities;
using System;

namespace EwalletAlifTech.Modules.Transactions.Entities
{
    public class Transaction : EntityBase
    {
        public Guid FromAccountId { get; set; }
        public Account FromAccount { get; set; }
        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public Guid ToAccountId { get; set; }
        public Account ToAccount { get; set; }
        public decimal Amount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
