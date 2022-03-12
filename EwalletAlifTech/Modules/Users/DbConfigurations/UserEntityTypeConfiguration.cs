using EwalletAlifTech.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EwalletAlifTech.Modules.Users.DbConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Accounts)
                .WithOne(a => a.User);

            builder.HasOne(a => a.Attestation)
                .WithMany(a => a.Users).HasForeignKey(a => a.AttestationId);

            builder.Property(a => a.AttestationId).HasColumnName("attestation_id");
            builder.Property(a => a.UserName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.PhoneNumber).HasColumnName("phone_number").HasMaxLength(15).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.FullName).HasColumnName("full_name").HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(b => b.IsActive).HasColumnName("is_active").IsRequired();

            builder.HasAlternateKey(a => a.UserName);
            builder.HasAlternateKey(a => a.PhoneNumber);
            builder.HasAlternateKey(a => a.Email);

            builder.ToTable("users").HasData(
                     new User
                     {
                         Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d111"),
                         UserName = "user1",
                         PhoneNumber = "992938640102",
                         Email = "user1@gmail.com",
                         Password = "user1",
                         Hash = "",
                         FullName = "User1",
                         AttestationId = Guid.Parse("5ee95dcb-a078-11e8-904b-b06ebfbfa235"),
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now,
                         IsActive = true
                     },
                     new User
                     {
                         Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d112"),
                         UserName = "user2",
                         PhoneNumber = "992938640103",
                         Email = "user2@gmail.com",
                         Password = "user2",
                         Hash = "",
                         FullName = "User2",
                         AttestationId = Guid.Parse("5ee95dcb-a078-11e8-904b-b06ebfbfa234"),
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now,
                         IsActive = true
                     },
                     new User
                     {
                         Id = Guid.Parse("1ca06b7b-13fa-5952-827b-2fef6e40d113"),
                         UserName = "user3",
                         PhoneNumber = "992938640104",
                         Email = "user3@gmail.com",
                         Password = "user3",
                         Hash = "",
                         FullName = "User3",
                         AttestationId = Guid.Parse("5ee95dcb-a078-11e8-904b-b06ebfbfa235"),
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now,
                         IsActive = true
                     }
                );
        }
    }
}
