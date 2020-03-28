namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using global::Domain.Entities.Common;
    using global::Domain.Entities.Common.Social;
    using global::Domain.Entities.Moderation;
    using global::Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IFFDbContext
    {
        DbSet<AppUser> AppUsers { get; set; }

        DbSet<Equipment> Equipments { get; set; }

        DbSet<Spell> Spells { get; set; }

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

        DbSet<Status> Statuses { get; set; }

        DbSet<UserStatus> UserStatuses { get; set; }

        DbSet<Weapon> Weapons { get; set; }

        DbSet<Armor> Armors { get; set; }

        DbSet<Trinket> Trinkets { get; set; }

        DbSet<Material> Materials { get; set; }

        DbSet<FightingClass> FightingClasses { get; set; }

        DbSet<Hero> Heroes { get; set; }

        DbSet<Monster> Monsters { get; set; }

        DbSet<Inventory> Inventories { get; set; }

        DbSet<MonsterRarity> MonsterRarities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
