namespace FinalFantasyTryoutGoesWeb.Application.Common.Interfaces
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFFDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Equipment> Equipments { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Spell> Spells { get; set; }

        DbSet<Unit> Units { get; set; }

        DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
