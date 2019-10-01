using Arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Infra.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(_ => _.Name, cm =>
            {
                cm.Property(n => n.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);
                cm.Property(n => n.LastName)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            builder.Property(_ => _.Email)
                    .IsRequired()
                    .HasMaxLength(150);

            builder.OwnsOne(s => s.Address, cm =>
              {
                  cm.Property(c => c.Street)
                      .HasMaxLength(120);
                  cm.Property(c => c.Number)
                      .HasMaxLength(20);
                  cm.Property(c => c.City)
                      .HasMaxLength(100);
                  cm.Property(c => c.ZipCode)
                      .HasMaxLength(30);
              });
        }
    }
}