using EwalletAlifTech.Modules.Accounts.Enums;
using EwalletAlifTech.Modules.Core.Entities;
using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.Transactions.Entities;
using EwalletAlifTech.Modules.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EwalletAlifTech.Modules.Accounts.Entities
{
    public class Account : EntityBase
    {
        public string Number { get; set; }
        public decimal Balance { get; private set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal BalanceLimit { get; private set; }
        public DateTime BalanceLimitUpdatedAt { get; private set; }
        public AccountType AccountType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public List<Transaction> FromAccountTransactions { get; set; }
        [NotMapped]
        public List<Transaction> ToAccountTransactions { get; set; }
        private static bool CanReceiveAsync(decimal balanceLimit, decimal amount)
        {
            return amount <= balanceLimit;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new LogicException("Min max ammount not match");

            if (!CanReplenish(Balance, amount))
                throw new LogicException("Balance not enough");

            Balance -= amount;
        }
        public void UpdateBalanceLimit(decimal balance)
        {
            if (balance < 0)
                throw new LogicException("Min balance not match");

            BalanceLimit = balance;
            BalanceLimitUpdatedAt = DateTime.Now;
        }
        public void Replenish(decimal amount)
        {
            if (amount <= 0)
                throw new LogicException("Min max ammount not match");

            if (!CanReceiveAsync(BalanceLimit, amount))
                throw new LogicException("Month limit is reached");

            Balance += amount;
            BalanceLimit -= amount;
            BalanceLimitUpdatedAt = DateTime.Now;
        }
        private static bool CanReplenish(decimal balance, decimal amount)
        {
            return balance - amount >= 0;
        }
    }

}
