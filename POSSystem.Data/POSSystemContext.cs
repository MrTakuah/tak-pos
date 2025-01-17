using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Models;

namespace POSSystem.Data
{
    public class POSSystemContext : DbContext
    {
        public POSSystemContext(DbContextOptions<POSSystemContext> options) : base(options) { }

        public DbSet<MenuItem>? MenuItems { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Category).HasMaxLength(50);

                // Seed data - initial menu items that will be created when database is first created
                entity.HasData(
                    new MenuItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cheeseburger",
                        Description = "Classic beef patty with cheese",
                        Price = 9.99m,
                        Category = "Burgers",
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Caesar Salad",
                        Description = "Fresh romaine lettuce with caesar dressing",
                        Price = 7.99m,
                        Category = "Salads",
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow
                    }
                );
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                
                // Configure one-to-many relationship with OrderItems
                entity.HasMany(o => o.OrderItems)
                      .WithOne(oi => oi.Order)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("int(18,2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");

                // Configure relationship with MenuItem
                entity.HasOne(oi => oi.MenuItem)
                      .WithMany(m => m.OrderItems)
                      .HasForeignKey(oi => oi.MenuItemId);
            });
        }
    }
}