namespace FinalFantasyTryoutGoesWeb.Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::Domain.Entities.Common;
    using global::Domain.Entities.Common.Social;
    using global::Domain.Entities.Game;
    using global::Domain.Entities.Moderation;
    using global::Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IFFDbContext
    {
        DbSet<AppUser> AppUsers { get; set; }

        DbSet<Equipment> Equipments { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Spell> Spells { get; set; }

        DbSet<Unit> Units { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Treasure> Treasures { get; set; }

        DbSet<TreasureKey> TreasureKeys { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<ApplicationRole> ApplicationRoles { get; set; }

        DbSet<FriendRequest> FriendRequests { get; set; }

        DbSet<Message> Messages { get; set; }

        DbSet<Topic> Topics { get; set; }

        DbSet<Ticket> Tickets { get; set; }

        DbSet<Feedback> Feedbacks { get; set; }

        DbSet<Notification> Notifications { get; set; }

        DbSet<Profession> Professions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
