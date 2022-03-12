using EwalletAlifTech.Modules.Accounts.DbConfigurations;
using EwalletAlifTech.Modules.Accounts.Entities;
using EwalletAlifTech.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using EwalletAlifTech.Modules.Users.Modules.Attestations.Entities;
using EwalletAlifTech.Modules.Transactions.Entities;
using EwalletAlifTech.Modules.Transactions.DbConfigurations;
using EwalletAlifTech.Modules.Users.DbConfigurations;
using EwalletAlifTech.Modules.Settings.DbConfigurations;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Settings.Entities;

namespace EwalletAlifTech.Modules.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Attestation> Attestations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Setting> Settings { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public AppDbContext(DbContextOptions<AppDbContext> options,
            ILoggerFactory loggerFactory) : base(options)
        {
            this._loggerFactory = loggerFactory;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttestationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SettingEntityTypeConfiguration());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            var now = DateTime.Now;

            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                item.Property("CreatedAt").CurrentValue = now;
            }

            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                item.Property("UpdatedAt").CurrentValue = now;
            }

            return await base.SaveChangesAsync(true,cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(this._loggerFactory);
        }
    }
}
