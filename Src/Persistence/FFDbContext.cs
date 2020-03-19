namespace FinalFantasyTryoutGoesWeb.Persistence
{
    using global::Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using Microsoft.EntityFrameworkCore;
    using global::Domain.Entities.Game;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using global::Domain.Models;

    public class FFDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IFFDbContext
    {
        public FFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Treasure> Treasures { get; set; }

        public DbSet<TreasureKey> TreasureKeys { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var connection = new Connection();

                optionsBuilder
                    .UseSqlServer(connection.String);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>()
           .HasOne(u => u.Unit)
           .WithOne(e => e.Equipment)
           .HasForeignKey<Unit>(e => e.EquipmentId);

            modelBuilder.Entity<Inventory>()
           .HasOne(u => u.Unit)
           .WithOne(i => i.Inventory)
           .HasForeignKey<Inventory>(u => u.UnitId);
        }
    }
}
