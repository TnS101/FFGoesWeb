namespace Application.Tests.Infrastructure
{
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.ManyToMany;
    using Domain.Entities.Game.Units.OneToOne;
    using Domain.Entities.Moderation;
    using Domain.Entities.Social;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Persistence.Context;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class QueryArrangeHelper
    {
        public static void AddUsers(FFDbContext context)
        {
            var users = new List<AppUser>
            {
                new AppUser { Id = "1", Email = "someEmail@gmail.com", UserName = "username" },
                new AppUser { Id = "2", Email = "hello@abv.bg", UserName = "username1" },
                new AppUser { Id = "3", Email = "ivan4o@yahoo.com", UserName = "username2"},
            };

            context.AppUsers.AddRange(users);
            context.SaveChanges();
        }

        // Game -> Items
        public static void AddArmors(FFDbContext context)
        {
            var armors = new List<Armor>
            {
                new Armor { Id = "1", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "2", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "3", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "4", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "5", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "6", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
                new Armor { Id = "7", Slot = "Armor", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1 },
            };

            context.Armors.AddRange(armors);
            context.SaveChanges();
        }

        public static void AddEquipments(FFDbContext context)
        {
            var equipement = new Equipment("1")
            {
                Id = "1",
                BootsSlot = false,
                BracerSlot = false,
                ChestplateSlot = false,
                GlovesSlot = false,
                Capacity = 9,
                HelmetSlot = false,
                LeggingsSlot = false,
                ShoulderSlot = false,
                TrinketSlot = false,
                WeaponSlot = false,
                HeroId = "1",
            };

            context.Equipments.Add(equipement);
            context.SaveChanges();
        }

        public static void AddInventory(FFDbContext context)
        {
            var inventory = new Inventory("1") { Id = "1", Capacity = 50, HeroId = "1", };

            context.Inventories.Add(inventory);
            context.SaveChanges();
        }

        public static void AddMaterials(FFDbContext context)
        {
            var materials = new List<Material>
            {
                new Material { Id = 1, Slot = "Material", Name = "Wood" },
                new Material { Id = 2, Slot = "Material", Name = "Stone" },
                new Material { Id = 3, Slot = "Material", Name = "Leather" },
            };

            context.Materials.AddRange(materials);
            context.SaveChanges();
        }

        public static void AddTools(FFDbContext context)
        {
            var tools = new List<Tool>
            {
                new Tool { Id = 1, Slot = "Tool", Name = "Hammer" },
                new Tool { Id = 2, Slot = "Tool", Name = "Axe" },
                new Tool { Id = 3, Slot = "Tool", Name = "Knife" },
            };

            context.Tools.AddRange(tools);
            context.SaveChanges();
        }

        public static void AddTreasures(FFDbContext context)
        {
            var treasures = new List<Treasure>
            {
                new Treasure { Id = 1, Slot = "Treasure", Rarity = "Bronze" },
                new Treasure { Id = 2, Slot = "Treasure", Rarity = "Silver" },
                new Treasure { Id = 3, Slot = "Treasure", Rarity = "Gold" },
            };

            context.Treasures.AddRange(treasures);
            context.SaveChanges();
        }

        public static void AddTreasureKeys(FFDbContext context)
        {
            var treasureKeys = new List<TreasureKey>
            {
                new TreasureKey { Id = 1, Slot = "Treasure Key", Rarity = "Bronze" },
                new TreasureKey { Id = 2, Slot = "Treasure Key", Rarity = "Silver" },
                new TreasureKey { Id = 3, Slot = "Treasure Key", Rarity = "Gold" },
            };

            context.TreasureKeys.AddRange(treasureKeys);
            context.SaveChanges();
        }

        public static void AddTrinkets(FFDbContext context)
        {
            var trinkets = new List<Trinket>
            {
                new Trinket { Id = "1", Slot = "Trinket", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1 },
                new Trinket { Id = "2", Slot = "Trinket", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1 },
                new Trinket { Id = "3", Slot = "Trinket", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1 },
                new Trinket { Id = "4", Slot = "Trinket", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1 },
            };

            context.Trinkets.AddRange(trinkets);
            context.SaveChanges();
        }

        public static void AddWeapons(FFDbContext context)
        {
            var weapons = new List<Weapon>
            {
                new Weapon { Id = "1", Slot = "Weapon", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, AttackPower = 10 },
                new Weapon { Id = "2", Slot = "Weapon", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, AttackPower = 10 },
                new Weapon { Id = "3", Slot = "Weapon", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, AttackPower = 10 },
                new Weapon { Id = "4", Slot = "Weapon", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, AttackPower = 10 },
            };

            context.Weapons.AddRange(weapons);
            context.SaveChanges();
        }

        // Game -> Units
        public static void AddEnergyChanges(FFDbContext context)
        {
            var energyChange = new EnergyChange { HeroId = "1", LastChangedOn = DateTime.UtcNow };

            context.EnergyChanges.Add(energyChange);
            context.SaveChanges();
        }

        public static void AddFightingClasses(FFDbContext context)
        {
            var fightingClasses = new List<FightingClass>
            {
                new FightingClass { Id = 1, Type = "Warrior" },
                new FightingClass { Id = 2, Type = "Mage" },
                new FightingClass { Id = 3, Type = "Hunter" },
                new FightingClass { Id = 4, Type = "Rogue" },
                new FightingClass { Id = 5, Type = "Shaman" },
                new FightingClass { Id = 6, Type = "Paladin" },
                new FightingClass { Id = 7, Type = "Necroid" },
                new FightingClass { Id = 8, Type = "Naturalist" },
                new FightingClass { Id = 9, Type = "Priest" },
            };

            context.FightingClasses.AddRange(fightingClasses);
            context.SaveChanges();
        }

        public static async Task AddHeroes(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var heroes = new List<Hero>
            {
                new Hero { Id = "1", Name = "validname", FightingClassId = 1, UserId = userId, GoldAmount = 100, InventoryId= "1", XPCap = 100, XP = 0, CurrentHP = 100 },
                new Hero { Id = "2", Name = "namevalid", FightingClassId = 2, UserId = userId, GoldAmount = 100, InventoryId= "2", XPCap = 100, XP = 0, CurrentHP = 100 },
                new Hero { Id = "3", Name = "veryvalid", FightingClassId = 3, UserId = userId, GoldAmount = 100, InventoryId= "3", XPCap = 100, XP = 0, CurrentHP = 100 },
            };

            context.Heroes.AddRange(heroes);
            context.SaveChanges();
        }

        public static void AddMonsters(FFDbContext context)
        {
            var monsters = new List<Monster>
            {
                new Monster { Id = 1, Type = "Elemental", Name = "Saint", ImagePath = "somethingimagemaidmaw" },
                new Monster { Id = 2, Type = "Beast", Name = "Bear", ImagePath = "somethingimagemaidmaw"  },
                new Monster { Id = 3, Type = "Elemental", Name = "Demon" , ImagePath = "somethingimagemaidmaw"  },
                new Monster { Id = 4, Type = "Mechanical", Name = "Giant", ImagePath = "somethingimagemaidmaw"   },
                new Monster { Id = 5, Type = "Reptile", Name = "Reptile" , ImagePath = "somethingimagemaidmaw"  },
                new Monster { Id = 6, Type = "Humanoid", Name = "Skeleton" , ImagePath = "somethingimagemaidmaw"  },
                new Monster { Id = 7, Type = "Humanoid", Name = "Zombie" , ImagePath = "somethingimagemaidmaw"  },
                new Monster { Id = 8, Type = "Beast", Name = "Gryphon", ImagePath = "somethingimagemaidmaw"   },
                new Monster { Id = 9, Type = "Reptile", Name = "Wyrm" , ImagePath = "somethingimagemaidmaw"  },
            };

            context.Monsters.AddRange(monsters);
            context.SaveChanges();
        }

        public static void AddSpells(FFDbContext context)
        {
            var spells = new List<Spell>
            {
                new Spell { Id = 1, ClassType = "Warrior" },
                new Spell { Id = 2, ClassType = "Warrior" },
                new Spell { Id = 3, ClassType = "Warrior" },
                new Spell { Id = 4, ClassType = "Warrior" },
                new Spell { Id = 5, ClassType = "Shaman" },
                new Spell { Id = 6, ClassType = "Paladin" },
                new Spell { Id = 7, ClassType = "Necroid" },
                new Spell { Id = 8, ClassType = "Naturalist" },
                new Spell { Id = 9, ClassType = "Priest" },
            };

            context.Spells.AddRange(spells);
            context.SaveChanges();
        }

        // Moderation
        public static async Task AddTickets(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);
            var messageId = CommandArrangeHelper.GetMessageId(context);
            var topicId = CommandArrangeHelper.GetTopicId(context);
            var commentId = CommandArrangeHelper.GetCommentId(context);

            var tickets = new List<Ticket>
            {
                new Ticket { Id = 1, MessageId = messageId, UserId = userId },
                new Ticket { Id = 2, TopicId = topicId, UserId = userId },
                new Ticket { Id = 3, CommentId = commentId, UserId = userId },
            };

            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }

        public static async Task AddFeedbacks(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = 1, UserId = userId },
                new Feedback { Id = 2, UserId = userId },
                new Feedback { Id = 3, UserId = userId },
            };

            context.Feedbacks.AddRange(feedbacks);
            context.SaveChanges();
        }

        public static async Task AddComments(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = 1, UserId = userId },
                new Feedback { Id = 2, UserId = userId },
                new Feedback { Id = 3, UserId = userId },
            };

            context.Feedbacks.AddRange(feedbacks);
            context.SaveChanges();
        }

        public static async Task AddFriends(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var friends = new List<Friend>
            {
                new Friend { Id = "1", UserId = userId },
                new Friend { Id = "2", UserId = userId },
                new Friend { Id = "3", UserId = userId },
            };

            context.Friends.AddRange(friends);
            context.SaveChanges();
        }

        public static async Task AddFriendRequests(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var friends = new List<FriendRequest>
            {
                new FriendRequest { Id = 1, UserId = userId },
                new FriendRequest { Id = 2, UserId = userId },
                new FriendRequest { Id = 3, UserId = userId },
            };

            context.FriendRequests.AddRange(friends);
            context.SaveChanges();
        }

        public static void AddLikes(FFDbContext context)
        {
            var topicId = CommandArrangeHelper.GetTopicId(context);
            var commentId = CommandArrangeHelper.GetCommentId(context);

            var likes = new List<Like>
            {
                new Like { Id = "1", TopicId = topicId },
                new Like { Id = "2", TopicId = topicId },
                new Like { Id = "3", CommentId = commentId },
                new Like { Id = "4", CommentId = commentId },
            };

            context.Likes.AddRange(likes);
            context.SaveChanges();
        }

        public static async Task AddMessages(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var messages = new List<Message>
            {
                new Message { Id = "1", UserId = userId },
                new Message { Id = "2", UserId = userId },
                new Message { Id = "3", UserId = userId },
                new Message { Id = "4", UserId = userId },
            };

            context.Messages.AddRange(messages);
            context.SaveChanges();
        }

        public static async Task AddNotifications(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var notifications = new List<Notification>
            {
                new Notification { Id = "1", UserId = userId },
                new Notification { Id = "2", UserId = userId },
                new Notification { Id = "3", UserId = userId },
                new Notification { Id = "4", UserId = userId },
            };

            context.Notifications.AddRange(notifications);
            context.SaveChanges();
        }

        public static void AddStatuses(FFDbContext context)
        {
            var statuses = new List<Status>
            {
                new Status { Id = 1, DisplayName = "UnSet" },
                new Status { Id = 2, DisplayName = "Star" },
                new Status { Id = 3, DisplayName = "Focus" },
                new Status { Id = 4, DisplayName = "9000+IQ" },
            };

            context.Statuses.AddRange(statuses);
            context.SaveChanges();
        }

        public static async Task AddTopics(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var topics = new List<Topic>
            {
                new Topic { Id = "1", UserId = userId },
                new Topic { Id = "2", UserId = userId },
                new Topic { Id = "3", UserId = userId },
                new Topic { Id = "4", UserId = userId },
            };

            context.Topics.AddRange(topics);
            context.SaveChanges();
        }

        // Relations
        public static async Task UserStatus(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var statusId = CommandArrangeHelper.GetStatusId(context);

            var userStatus = new UserStatus { UserId = userId, StatusId = statusId };

            context.UserStatuses.Add(userStatus);
            context.SaveChanges();
        }

        public static void AddArmorEquipments(FFDbContext context)
        {
            var armorEquipments = new List<ArmorEquipment>
            {
                new ArmorEquipment { EquipmentId = "1", ArmorId = "3" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "4" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "5" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "6" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "7" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "8" },
                new ArmorEquipment { EquipmentId = "1", ArmorId = "9" },
            };

            context.ArmorsEquipments.AddRange(armorEquipments);
            context.SaveChanges();
        }

        public static void AddTrinketEquipment(FFDbContext context)
        {
            var trinketEquipment = new TrinketEquipment { EquipmentId = "1", TrinketId = "3" };

            context.TrinketEquipments.Add(trinketEquipment);
            context.SaveChanges();
        }

        public static void AddWeaponEquipment(FFDbContext context)
        {
            var weaponEquipment = new WeaponEquipment { EquipmentId = "1", WeaponId = "3" };

            context.WeaponsEquipments.Add(weaponEquipment);
            context.SaveChanges();
        }

        public static void AddArmorInventory(FFDbContext context)
        {
            var armorInventory = new List<ArmorInventory>
            {
               new ArmorInventory { InventoryId = "1", ArmorId = "1", Count = 2 },
            };

            context.ArmorsInventories.AddRange(armorInventory);
            context.SaveChanges();
        }

        public static void AddMaterialInventory(FFDbContext context)
        {
            var materialInventory = new List<MaterialInventory>
            {
               new MaterialInventory {InventoryId = "1", MaterialId = 1, Count = 2 },
            };

            context.MaterialsInventories.AddRange(materialInventory);
            context.SaveChanges();
        }

        public static void AddToolInventory(FFDbContext context)
        {
            var toolInventory = new ToolInventory { InventoryId = "1", ToolId = 1, Count = 2 };

            context.ToolsInventories.Add(toolInventory);
            context.SaveChanges();
        }

        public static void AddTreasureInventory(FFDbContext context)
        {
            var treasureInventory = new TreasureInventory { InventoryId = "1", TreasureId = 1, Count = 2 };

            context.TreasuresInventories.Add(treasureInventory);
            context.SaveChanges();
        }

        public static void AddTreasureKeyInventory(FFDbContext context)
        {
            var treasureKeyInventory = new TreasureKeyInventory { InventoryId = "1", TreasureKeyId = 1, Count = 2 };

            context.TreasureKeysInventories.Add(treasureKeyInventory);
            context.SaveChanges();
        }

        public static void AddTrinketInventory(FFDbContext context)
        {
            var trinketInventory = new TrinketInventory { InventoryId = "1", TrinketId = "1", Count = 2 };

            context.TrinketsInventories.Add(trinketInventory);
            context.SaveChanges();
        }

        public static void AddWeaponInventory(FFDbContext context)
        {
            var weaponInventory = new WeaponInventory { InventoryId = "1", WeaponId = "1", Count = 2 };

            context.WeaponsInventories.Add(weaponInventory);
            context.SaveChanges();
        }

        public static void AddHeroSpells(FFDbContext context)
        {
            var heroSpell = new HeroSpell { HeroId = "1", SpellId = 1 };

            context.HeroesSpells.Add(heroSpell);
            context.SaveChanges();
        }

        public static void AddMonsterRarity(FFDbContext context)
        {
            var monsterRarirty = new MonsterRarity { Id = 1, MonsterId = 1 };

            context.MonstersRarities.Add(monsterRarirty);
            context.SaveChanges();
        }
    }
}
