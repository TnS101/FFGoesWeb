namespace Persistence
{
    using Application.Common.Interfaces;
    using Domain.Base;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using global::Domain.Entities.Common;
    using global::Domain.Entities.Common.Social;
    using global::Domain.Entities.Moderation;
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

        public DbSet<UserTopics> UsersTopics { get; set; }

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

        public DbSet<MonsterRarity> MonsterRarities { get; set; }

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
           .HasOne(h => h.Hero)
           .WithOne(e => e.Equipment)
           .HasForeignKey<Equipment>(h => h.HeroId);

            modelBuilder.Entity<Inventory>()
           .HasOne(u => u.Hero)
           .WithOne(i => i.Inventory)
           .HasForeignKey<Inventory>(u => u.HeroId);

            modelBuilder.Entity<MonsterRarity>()
           .HasOne(m => m.Monster)
           .WithOne(mr => mr.MonsterRarity)
           .HasForeignKey<MonsterRarity>(mr => mr.MonsterId);

            modelBuilder.Entity<UserTopics>()
           .HasKey(k => new { k.UserId, k.TopicId });

            modelBuilder.Entity<UserTopics>()
           .HasOne(u => u.User)
           .WithMany(t => t.UserTopics)
           .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserTopics>()
           .HasOne(t => t.Topic)
           .WithMany(u => u.UserTopics)
           .HasForeignKey(t => t.TopicId);

            modelBuilder.Entity<UserStatus>().HasKey(k => new { k.UserId });

            modelBuilder.Entity<AppUser>().ToTable("Users");

            modelBuilder.Entity<Comment>()
            .HasMany(p => p.Replies)
            .WithOne(t => t.Reply)
            .OnDelete(DeleteBehavior.Restrict);

            // Armor Equipment
            modelBuilder.Entity<ArmorEquipments>()
                .HasKey(ae => new { ae.ArmorId, ae.EquipmentId });

            modelBuilder.Entity<ArmorEquipments>()
                .HasOne(a => a.Armor)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(a => a.ArmorId);

            modelBuilder.Entity<ArmorEquipments>()
                .HasOne(e => e.Equipment)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Trinket Equipment
            modelBuilder.Entity<TrinketEquipments>()
                .HasKey(te => new { te.TrinketId, te.EquipmentId });

            modelBuilder.Entity<TrinketEquipments>()
                .HasOne(t => t.Trinket)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(t => t.TrinketId);

            modelBuilder.Entity<TrinketEquipments>()
                .HasOne(e => e.Equipment)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Weapon Equipment
            modelBuilder.Entity<WeaponEquipments>()
                .HasKey(we => new { we.WeaponId, we.EquipmentId });

            modelBuilder.Entity<WeaponEquipments>()
                .HasOne(w => w.Weapon)
                .WithMany(we => we.WeaponEquipments)
                .HasForeignKey(w => w.WeaponId);

            modelBuilder.Entity<WeaponEquipments>()
                .HasOne(e => e.Equipment)
                .WithMany(we => we.WeaponEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Armor Inventories
            modelBuilder.Entity<ArmorInventories>()
                .HasKey(ai => new { ai.ArmorId, ai.InventoryId });

            modelBuilder.Entity<ArmorInventories>()
                .HasOne(a => a.Armor)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(a => a.ArmorId);

            modelBuilder.Entity<ArmorInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(i => i.InventoryId);

            // Material Inventories
            modelBuilder.Entity<MaterialInventories>()
                .HasKey(mi => new { mi.MaterialId, mi.InventoryId });

            modelBuilder.Entity<MaterialInventories>()
                .HasOne(m => m.Material)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(m => m.MaterialId);

            modelBuilder.Entity<MaterialInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(i => i.InventoryId);

            // Treasure Inventories
            modelBuilder.Entity<TreasureInventories>()
                .HasKey(ti => new { ti.TreasureId, ti.InventoryId });

            modelBuilder.Entity<TreasureInventories>()
                .HasOne(t => t.Treasure)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(t => t.TreasureId);

            modelBuilder.Entity<TreasureInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(i => i.InventoryId);

            // Treasure Key Inventories
            modelBuilder.Entity<TreasureKeyInventories>()
                .HasKey(ti => new { ti.TreasureKeyId, ti.InventoryId });

            modelBuilder.Entity<TreasureKeyInventories>()
                .HasOne(t => t.TreasureKey)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(t => t.TreasureKeyId);

            modelBuilder.Entity<TreasureKeyInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(i => i.InventoryId);

            // Trinket Inventories
            modelBuilder.Entity<TrinketInventories>()
                .HasKey(ti => new { ti.TrinketId, ti.InventoryId });

            modelBuilder.Entity<TrinketInventories>()
                .HasOne(t => t.Trinket)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(t => t.TrinketId);

            modelBuilder.Entity<TrinketInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(i => i.InventoryId);

            // Weapon Inventories
            modelBuilder.Entity<WeaponInventories>()
                .HasKey(wi => new { wi.WeaponId, wi.InventoryId });

            modelBuilder.Entity<WeaponInventories>()
                .HasOne(w => w.Weapon)
                .WithMany(w => w.WeaponInventories)
                .HasForeignKey(w => w.WeaponId);

            modelBuilder.Entity<WeaponInventories>()
                .HasOne(i => i.Inventory)
                .WithMany(wi => wi.WeaponInventories)
                .HasForeignKey(i => i.InventoryId);

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
