using Arch.Domain.Entities;
using Arch.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace Arch.Infra.Data
{
    public class ArchContext: DbContext
    {
        public ArchContext(DbContextOptions<ArchContext> options)
            :base(options) {}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}