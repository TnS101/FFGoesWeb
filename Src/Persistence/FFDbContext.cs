using Application.Common.Interfaces;

namespace FinalFantasyTryoutGoesWeb.Persistence
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class FFDbContext : DbContext,IFFDbContext
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
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
