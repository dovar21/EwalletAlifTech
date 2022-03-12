using EwalletAlifTech.Modules.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EwalletAlifTech.Modules.Transactions.DbConfigurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder )
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.CreatedByUser)
                .WithMany(a => a.Transactions);

            builder.HasOne(a => a.FromAccount)
                .WithMany(a => a.FromAccountTransactions).HasForeignKey(a => a.FromAccountId);

            builder.HasOne(a => a.ToAccount)
                .WithMany(a => a.ToAccountTransactions).HasForeignKey(a => a.ToAccountId);

            builder.Property(a => a.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(a => a.FromAccountId).HasColumnName("from_account_id");
            builder.Property(a => a.ToAccountId).HasColumnName("to_account_id");
            builder.Property(a => a.Amount).HasPrecision(18, 2).IsRequired();
            builder.Property(b => b.AccountBalance).HasPrecision(18, 2).HasColumnName("account_balance").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at").IsRequired();

            builder.ToTable("transactions");
        }
    }
}
