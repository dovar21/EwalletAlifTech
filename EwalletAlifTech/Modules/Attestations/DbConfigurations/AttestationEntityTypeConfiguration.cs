using EwalletAlifTech.Modules.Users.Modules.Attestations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EwalletAlifTech.Modules.Accounts.DbConfigurations
{
    public class AttestationEntityTypeConfiguration : IEntityTypeConfiguration<Attestation>
    {
        public void Configure(EntityTypeBuilder<Attestation> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Users)
                .WithOne(a => a.Attestation).HasForeignKey(a=>a.AttestationId);
            
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Code).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at").IsRequired();

            builder.ToTable("attestations").HasData(
                     new Attestation
                     {
                         Id = Guid.Parse("5ee95dcb-a078-11e8-904b-b06ebfbfa234"),
                         Code = "NOT_IDENTIFIED",
                         Name = "Неидентифицированный",
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now
                     },
                     new Attestation
                     {
                         Id = Guid.Parse("5ee95dcb-a078-11e8-904b-b06ebfbfa235"),
                         Code = "IDENTIFIED",
                         Name = "Идентифицированный",
                         CreatedAt = DateTime.Now,
                         UpdatedAt = DateTime.Now
                     }
                );

        }
    }
}
