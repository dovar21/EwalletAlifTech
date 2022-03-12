using EwalletAlifTech.Modules.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EwalletAlifTech.Modules.Settings.DbConfigurations
{
    public class SettingEntityTypeConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Key).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Value).HasMaxLength(100).IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at").IsRequired();

            builder.ToTable("settings").HasData(
                     new Setting
                     {
                         Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d121"),
                         Key = "NOT_IDENTIFIED_USER_MAX_BALANCE",
                         Value = "10000",
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now
                     },
                     new Setting
                     {
                         Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d122"),
                         Key = "IDENTIFIED_USER_MAX_BALANCE",
                         Value = "100000",
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now
                     }
                );
        }
    }
}
