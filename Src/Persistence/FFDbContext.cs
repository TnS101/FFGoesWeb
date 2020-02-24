namespace FinalFantasyTryoutGoesWeb.Persistence
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class FFDbContext : DbContext, IFFDbContext
    {
        public FFDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Treasure> Treasures { get; set; }

        public DbSet<TreasureKey> TreasureKeys { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
