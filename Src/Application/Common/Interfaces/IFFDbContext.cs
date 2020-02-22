namespace FinalFantasyTryoutGoesWeb.Application.Common.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFFDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
