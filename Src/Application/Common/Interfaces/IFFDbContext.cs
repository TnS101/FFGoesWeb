namespace FinalFantasyTryoutGoesWeb.Application.Common.Interfaces
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Domain.Entities.Game;
    using global::Domain.Entities.Common;
    using global::Domain.Entities.Common.Social;
    using global::Domain.Entities.Moderation;

    public interface IFFDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }

        DbSet<Equipment> Equipments { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Spell> Spells { get; set; }

        DbSet<Unit> Units { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Treasure> Treasures { get; set; }

        DbSet<TreasureKey> TreasureKeys { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Comment> Comments { get; set; }

        DbSet<FriendRequest> FriendRequests { get; set; }

        DbSet<Message> Messages { get; set; }

        DbSet<Topic> Topics { get; set; }

        DbSet<Ticket> Tickets { get; set; }

        DbSet<Feedback> Feedbacks { get; set; }
    }
}
