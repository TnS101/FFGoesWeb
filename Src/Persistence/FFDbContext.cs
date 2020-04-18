namespace Persistence
{
    using Application.Common.Interfaces;
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
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FFDbContext : IdentityDbContext<AppUser, ApplicationRole, string>, IFFDbContext
    {
        public FFDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<Treasure> Treasures { get; set; }

        public DbSet<TreasureKey> TreasureKeys { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<UserStatus> UserStatuses { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Armor> Armors { get; set; }

        public DbSet<Trinket> Trinkets { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<FightingClass> FightingClasses { get; set; }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Monster> Monsters { get; set; }

        public DbSet<MonsterRarity> MonstersRarities { get; set; }

        public DbSet<ArmorEquipment> ArmorsEquipments { get; set; }

        public DbSet<TrinketEquipment> TrinketEquipments { get; set; }

        public DbSet<WeaponEquipment> WeaponsEquipments { get; set; }

        public DbSet<ArmorInventory> ArmorsInventories { get; set; }

        public DbSet<MaterialInventory> MaterialsInventories { get; set; }

        public DbSet<TreasureInventory> TreasuresInventories { get; set; }

        public DbSet<TreasureKeyInventory> TreasureKeysInventories { get; set; }

        public DbSet<TrinketInventory> TrinketsInventories { get; set; }

        public DbSet<WeaponInventory> WeaponsInventories { get; set; }

        public DbSet<ConsumeableInventory> ConsumeableInventories { get; set; }

        public DbSet<Consumeable> Consumeables { get; set; }

        public DbSet<ConsumeableInventory> ConsumeablesInventories { get; set; }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<ToolInventory> ToolsInventories { get; set; }

        public DbSet<EnergyChange> EnergyChanges { get; set; }

        public DbSet<HeroSpells> HeroesSpells { get; set; }

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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FFDbContext).Assembly);

            modelBuilder.Entity<AppUser>(appUser =>
            {
                appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                appUser
                    .HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                appUser
                    .HasMany(e => e.Roles)
                    .WithOne()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
