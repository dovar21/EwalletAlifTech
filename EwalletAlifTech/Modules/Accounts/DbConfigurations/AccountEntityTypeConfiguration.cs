using EwalletAlifTech.Modules.Accounts.Entities;
using EwalletAlifTech.Modules.Accounts.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EwalletAlifTech.Modules.Accounts.DbConfigurations
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(y => y.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);

            builder.Property(a => a.UserId).HasColumnName("user_id");
            builder.HasAlternateKey(a => a.Number);
            builder.Property(a => a.Number).HasMaxLength(20).IsRequired();
            builder.Property(b => b.Balance).HasPrecision(18, 2).IsRequired();
            builder.Property(b => b.BalanceLimit).HasPrecision(18, 2).HasColumnName("balance_limit").IsRequired();
            builder.Property(b => b.BalanceLimitUpdatedAt).HasColumnName("balance_limit_updated_at").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(b => b.IsActive).HasColumnName("is_active").IsRequired();
            builder.Property(b => b.AccountType).HasColumnName("account_type").IsRequired();

            var accountsList = new List<Account>();

            //User1 account
            var account = new Account
            {
                Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d111"),
                Number = "20202000000000001",
                UserId = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d111"),
                AccountType = AccountType.Ewallet,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            };
            account.UpdateBalanceLimit(100000);
            account.Replenish(80000);
            accountsList.Add(account);

            //User2 account
            account = new Account
            {
                Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d114"),
                Number = "20202000000000002",
                UserId = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d112"),
                AccountType = AccountType.Ewallet,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            };
            account.UpdateBalanceLimit(10000);
            accountsList.Add(account);
            
            //User3 account
            account = new Account
            {
                Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d115"),
                Number = "20202000000000003",
                UserId = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d113"),
                AccountType = AccountType.Ewallet,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            };
            account.UpdateBalanceLimit(100000);
            account.Replenish(10000);
            accountsList.Add(account);

            builder.ToTable("accounts").HasData(accountsList);

        }
    }
}
