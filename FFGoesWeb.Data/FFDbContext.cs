using FinalFantasyTryoutGoesWeb.Data.Entities;
using FinalFantasyTryoutGoesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalFantasyTryoutGoesWeb.Data
{
    public class FFDbContext : DbContext
    {
        public FFDbContext()
        {

        }

        public FFDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
           .HasOne(e => e.Unit)
           .WithOne(u => u.Equipment)
           .HasForeignKey<Unit>(u => u.EquipmentId);
        }
    }
}
