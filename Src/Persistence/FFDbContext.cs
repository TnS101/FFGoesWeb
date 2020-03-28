namespace Persistence
{
    using Application.Common.Interfaces;
    using Domain.Base;
    using Domain.Entities.Game.Items;
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
