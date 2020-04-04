namespace Persistence
{
    using Application.Common.Interfaces;
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

            modelBuilder.Entity<UserStatus>().HasKey(k => new { k.UserId });

            modelBuilder.Entity<AppUser>().ToTable("Users");

            modelBuilder.Entity<Comment>()
            .HasMany(p => p.Replies)
            .WithOne(t => t.Reply)
            .OnDelete(DeleteBehavior.Restrict);

            // Armor Equipment
            modelBuilder.Entity<ArmorEquipment>()
                .HasKey(ae => new { ae.ArmorId, ae.EquipmentId });

            modelBuilder.Entity<ArmorEquipment>()
                .HasOne(a => a.Armor)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(a => a.ArmorId);

            modelBuilder.Entity<ArmorEquipment>()
                .HasOne(e => e.Equipment)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Trinket Equipment
            modelBuilder.Entity<TrinketEquipment>()
                .HasKey(te => new { te.TrinketId, te.EquipmentId });

            modelBuilder.Entity<TrinketEquipment>()
                .HasOne(t => t.Trinket)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(t => t.TrinketId);

            modelBuilder.Entity<TrinketEquipment>()
                .HasOne(e => e.Equipment)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Weapon Equipment
            modelBuilder.Entity<WeaponEquipment>()
                .HasKey(we => new { we.WeaponId, we.EquipmentId });

            modelBuilder.Entity<WeaponEquipment>()
                .HasOne(w => w.Weapon)
                .WithMany(we => we.WeaponEquipments)
                .HasForeignKey(w => w.WeaponId);

            modelBuilder.Entity<WeaponEquipment>()
                .HasOne(e => e.Equipment)
                .WithMany(we => we.WeaponEquipments)
                .HasForeignKey(e => e.EquipmentId);

            // Armor Inventories
            modelBuilder.Entity<ArmorInventory>()
                .HasKey(ai => new { ai.ArmorId, ai.InventoryId });

            modelBuilder.Entity<ArmorInventory>()
                .HasOne(a => a.Armor)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(a => a.ArmorId);

            modelBuilder.Entity<ArmorInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(i => i.InventoryId);

            // Material Inventories
            modelBuilder.Entity<MaterialInventory>()
                .HasKey(mi => new { mi.MaterialId, mi.InventoryId });

            modelBuilder.Entity<MaterialInventory>()
                .HasOne(m => m.Material)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(m => m.MaterialId);

            modelBuilder.Entity<MaterialInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(i => i.InventoryId);

            // Treasure Inventories
            modelBuilder.Entity<TreasureInventory>()
                .HasKey(ti => new { ti.TreasureId, ti.InventoryId });

            modelBuilder.Entity<TreasureInventory>()
                .HasOne(t => t.Treasure)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(t => t.TreasureId);

            modelBuilder.Entity<TreasureInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(i => i.InventoryId);

            // Treasure Key Inventories
            modelBuilder.Entity<TreasureKeyInventory>()
                .HasKey(ti => new { ti.TreasureKeyId, ti.InventoryId });

            modelBuilder.Entity<TreasureKeyInventory>()
                .HasOne(t => t.TreasureKey)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(t => t.TreasureKeyId);

            modelBuilder.Entity<TreasureKeyInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(i => i.InventoryId);

            // Trinket Inventories
            modelBuilder.Entity<TrinketInventory>()
                .HasKey(ti => new { ti.TrinketId, ti.InventoryId });

            modelBuilder.Entity<TrinketInventory>()
                .HasOne(t => t.Trinket)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(t => t.TrinketId);

            modelBuilder.Entity<TrinketInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(i => i.InventoryId);

            // Weapon Inventories
            modelBuilder.Entity<WeaponInventory>()
                .HasKey(wi => new { wi.WeaponId, wi.InventoryId });

            modelBuilder.Entity<WeaponInventory>()
                .HasOne(w => w.Weapon)
                .WithMany(w => w.WeaponInventories)
                .HasForeignKey(w => w.WeaponId);

            modelBuilder.Entity<WeaponInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(wi => wi.WeaponInventories)
                .HasForeignKey(i => i.InventoryId);

            // Consumeable Inventories
            modelBuilder.Entity<ConsumeableInventory>()
                .HasKey(k => new { k.ConsumeableId, k.InventoryId });

            modelBuilder.Entity<ConsumeableInventory>()
                .HasOne(c => c.Consumeable)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(c => c.ConsumeableId);

            modelBuilder.Entity<ConsumeableInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(i => i.InventoryId);

            // Tool Inventories
            modelBuilder.Entity<ToolInventory>()
                .HasKey(k => new { k.ToolId, k.InventoryId });

            modelBuilder.Entity<ToolInventory>()
                .HasOne(t => t.Tool)
                .WithMany(ti => ti.ToolInventories)
                .HasForeignKey(t => t.ToolId);

            modelBuilder.Entity<ToolInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(ti => ti.ToolInventories)
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
