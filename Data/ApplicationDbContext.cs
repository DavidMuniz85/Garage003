using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Garage003.Models;

namespace Garage003.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<Category> Category { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(s => s.ItemId)
                .HasColumnName("ItemId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zone>()
                .Property(s => s.ZoneId)
                .HasColumnName("ZoneId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(s => s.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        
    }
}