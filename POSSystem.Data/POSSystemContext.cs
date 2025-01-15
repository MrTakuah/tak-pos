using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Models;

namespace POSSystem.Data
{
    public class POSSystemContext : DbContext
    {
        public POSSystemContext(DbContextOptions<POSSystemContext> options) : base(options) { }

        public DbSet<MenuItem>? MenuItems { get; set; }
        public DbSet<Order>? Orders {get; set;}
        public DbSet<OrderItem>? OrderItems {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Category).HasMaxLength(50);
            });
        }
    }
}