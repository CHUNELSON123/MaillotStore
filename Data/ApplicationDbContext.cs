using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaillotStore.Models;

namespace MaillotStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add the new tables (DbSets) here
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            builder.Entity<Influencer>()
                .HasMany(i => i.Commissions)
                .WithOne(c => c.Influencer)
                .HasForeignKey(c => c.InfluencerId);

            builder.Entity<Commission>()
                .HasOne(c => c.Order)
                .WithMany()
                .HasForeignKey(c => c.OrderId)
                .IsRequired(false);

            builder.Entity<Order>()
                .HasOne(o => o.Influencer)
                .WithMany()
                .HasForeignKey(o => o.InfluencerId)
                .IsRequired(false);
        }
    }
}