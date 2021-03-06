﻿namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.ManyToMany;
    using Domain.Entities.Game.Units.OneToOne;
    using global::Domain.Entities.Common;
    using global::Domain.Entities.Moderation;
    using global::Domain.Entities.Social;
    using global::Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IFFDbContext
    {
        DbSet<AppUser> AppUsers { get; set; }

        DbSet<Spell> Spells { get; set; }

        DbSet<LootBox> LootBoxes { get; set; }

        DbSet<LootKey> LootKeys { get; set; }

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

        DbSet<MonsterRarity> MonstersRarities { get; set; }

        DbSet<ArmorEquipment> ArmorsEquipments { get; set; }

        DbSet<TrinketEquipment> TrinketEquipments { get; set; }

        DbSet<WeaponEquipment> WeaponsEquipments { get; set; }

        DbSet<ArmorInventory> ArmorsInventories { get; set; }

        DbSet<MaterialInventory> MaterialsInventories { get; set; }

        DbSet<LootBoxInventory> LootBoxesInventories { get; set; }

        DbSet<LootKeyInventory> LootKeysInventories { get; set; }

        DbSet<TrinketInventory> TrinketsInventories { get; set; }

        DbSet<WeaponInventory> WeaponsInventories { get; set; }

        DbSet<Consumeable> Consumeables { get; set; }

        DbSet<ConsumeableInventory> ConsumeablesInventories { get; set; }

        DbSet<Tool> Tools { get; set; }

        DbSet<ToolInventory> ToolsInventories { get; set; }

        DbSet<EnergyChange> EnergyChanges { get; set; }

        DbSet<Like> Likes { get; set; }

        DbSet<Friend> Friends { get; set; }

        DbSet<Relic> Relics { get; set; }

        DbSet<RelicEquipment> RelicsEquipments { get; set; }

        DbSet<RelicInventory> RelicsInventories { get; set; }

        DbSet<Card> Cards { get; set; }

        DbSet<CardEquipment> CardsEquipments { get; set; }

        DbSet<CardInventory> CardsInventories { get; set; }

        DbSet<Toy> Toys { get; set; }

        DbSet<ToyInventory> ToyInventories { get; set; }

        DbSet<Talent> Talents { get; set; }

        DbSet<HeroTalents> HeroesTalents { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
