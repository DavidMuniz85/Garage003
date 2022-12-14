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
        public DbSet<Garage> Garage { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ItemZone> ItemZones { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Item Model
            modelBuilder.Entity<Item>()
                .Property(s => s.ItemId)
                .HasColumnName("ItemId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
            //Item
            modelBuilder.Entity<Item>()
            .HasOne<Category>(s => s.Category)
            .WithMany(g => g.Items)
            .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Item>()
            .HasOne<Status>(s => s.Status)
            .WithMany(g => g.Items)
            .HasForeignKey(s => s.StatusId);

            //Zone Model
            modelBuilder.Entity<Zone>()
                .Property(s => s.ZoneId)
                .HasColumnName("ZoneId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            //Category Model
            modelBuilder.Entity<Category>()
                .Property(s => s.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
            
            //Garage Model
            modelBuilder.Entity<Garage>()
                .Property(s => s.GarageId)
                .HasColumnName("GarageId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            //Status Model
            modelBuilder.Entity<Status>()
                .Property(s => s.StatusId)
                .HasColumnName("StatusId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemZone>()
                .HasKey(iz => new { iz.ItemId, iz.ZoneId });

            modelBuilder.Entity<ItemZone>()
                .HasOne<Item>(i => i.Item)
                .WithMany(iz => iz.ItemsZones)
                .HasForeignKey(i => i.ItemId);


            modelBuilder.Entity<ItemZone>()
                .HasOne<Zone>(z => z.Zone)
                .WithMany(iz => iz.ItemsZones)
                .HasForeignKey(z => z.ZoneId);
        }
              
        
        
    }
}