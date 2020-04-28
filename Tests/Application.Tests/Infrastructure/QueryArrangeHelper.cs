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
    using Persistence.Context;
    using System;
    using System.Collections.Generic;

    public class QueryArrangeHelper
    {
        public static void AddUsers(FFDbContext context)
        {
            var users = new List<AppUser>
            {
                new AppUser { Id = Guid.NewGuid().ToString(), Email = "someEmail@gmail.com" },
                new AppUser { Id = Guid.NewGuid().ToString(), Email = "hello@abv.bg" },
                new AppUser { Id = Guid.NewGuid().ToString(), Email = "ivan4o@yahoo.com "},
            };

            context.AppUsers.AddRange(users);
            context.SaveChanges();
        }

        // Game -> Items
        public static void AddArmors(FFDbContext context)
        {
            var armors = new List<Armor>
            {
                new Armor { Id = Guid.NewGuid().ToString(), Slot = "Armor", Level = 1 },
                new Armor { Id = Guid.NewGuid().ToString(), Slot = "Armor", Level = 1 },
                new Armor { Id = Guid.NewGuid().ToString(), Slot = "Armor", Level = 1 },
            };

            context.Armors.AddRange(armors);
            context.SaveChanges();
        }

        public static void AddEquipments(FFDbContext context)
        {
            var heroId = CommandArrangeHelper.GetHeroId(context);

            var equipement = new Equipment(heroId) { Id = Guid.NewGuid().ToString(), };

            context.Equipments.Add(equipement);
            context.SaveChanges();
        }

        public static void AddInventory(FFDbContext context)
        {
            var heroId = CommandArrangeHelper.GetHeroId(context);

            var inventory = new Inventory(heroId) { Id = Guid.NewGuid().ToString() };

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
                new Trinket { Id = Guid.NewGuid().ToString(), Slot = "Trinket", Level = 1 },
                new Trinket { Id = Guid.NewGuid().ToString(), Slot = "Trinket", Level = 1 },
                new Trinket { Id = Guid.NewGuid().ToString(), Slot = "Trinket", Level = 1 },
            };

            context.Trinkets.AddRange(trinkets);
            context.SaveChanges();
        }

        public static void AddWeapons(FFDbContext context)
        {
            var weapons = new List<Weapon>
            {
                new Weapon { Id = Guid.NewGuid().ToString(), Slot = "Weapon", Level = 1 },
                new Weapon { Id = Guid.NewGuid().ToString(), Slot = "Weapon", Level = 1 },
                new Weapon { Id = Guid.NewGuid().ToString(), Slot = "Weapon", Level = 1 },
            };

            context.Weapons.AddRange(weapons);
            context.SaveChanges();
        }

        // Game -> Units
        public static void AddEnergyChanges(FFDbContext context)
        {
            var heroId = CommandArrangeHelper.GetHeroId(context);

            var energyChange = new EnergyChange { HeroId = heroId, LastChangedOn = DateTime.UtcNow };

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

        public static void AddHeroes(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var heroes = new List<Hero>
            {
                new Hero { Id = Guid.NewGuid().ToString(), Name = "validname", FightingClassId = 1, UserId = userId },
                new Hero { Id = Guid.NewGuid().ToString(), Name = "namevalid", FightingClassId = 2, UserId = userId },
                new Hero { Id = Guid.NewGuid().ToString(), Name = "veryvalid", FightingClassId = 3, UserId = userId },
            };

            context.Heroes.AddRange(heroes);
            context.SaveChanges();
        }

        public static void AddMonsters(FFDbContext context)
        {
            var monsters = new List<Monster>
            {
                new Monster { Id = 1, Type = "Saint" },
                new Monster { Id = 2, Type = "Bear" },
                new Monster { Id = 3, Type = "Demon" },
                new Monster { Id = 4, Type = "Giant" },
                new Monster { Id = 5, Type = "Reptile" },
                new Monster { Id = 6, Type = "Skeleton" },
                new Monster { Id = 7, Type = "Zombie" },
                new Monster { Id = 8, Type = "Gryphon" },
                new Monster { Id = 9, Type = "Wyrm" },
            };

            context.Monsters.AddRange(monsters);
            context.SaveChanges();
        }

        public static void AddSpells(FFDbContext context)
        {
            var spells = new List<Spell>
            {
                new Spell { Id = 1, ClassType = "Warrior" },
                new Spell { Id = 2, ClassType = "Mage" },
                new Spell { Id = 3, ClassType = "Hunter" },
                new Spell { Id = 4, ClassType = "Rogue" },
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
        public static void AddTickets(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);
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

        public static void AddFeedbacks(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = 1, UserId = userId },
                new Feedback { Id = 2, UserId = userId },
                new Feedback { Id = 3, UserId = userId },
            };

            context.Feedbacks.AddRange(feedbacks);
            context.SaveChanges();
        }

        public static void AddComments(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = 1, UserId = userId },
                new Feedback { Id = 2, UserId = userId },
                new Feedback { Id = 3, UserId = userId },
            };

            context.Feedbacks.AddRange(feedbacks);
            context.SaveChanges();
        }

        public static void AddFriends(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var friends = new List<Friend>
            {
                new Friend { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Friend { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Friend { Id = Guid.NewGuid().ToString(), UserId = userId },
            };

            context.Friends.AddRange(friends);
            context.SaveChanges();
        }

        public static void AddFriendRequests(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

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
                new Like { Id = Guid.NewGuid().ToString(), TopicId = topicId },
                new Like { Id = Guid.NewGuid().ToString(), TopicId = topicId },
                new Like { Id = Guid.NewGuid().ToString(), CommentId = commentId },
                new Like { Id = Guid.NewGuid().ToString(), CommentId = commentId },
            };

            context.Likes.AddRange(likes);
            context.SaveChanges();
        }

        public static void AddMessages(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var messages = new List<Message>
            {
                new Message { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Message { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Message { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Message { Id = Guid.NewGuid().ToString(), UserId = userId },
            };

            context.Messages.AddRange(messages);
            context.SaveChanges();
        }

        public static void AddNotifications(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var notifications = new List<Notification>
            {
                new Notification { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Notification { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Notification { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Notification { Id = Guid.NewGuid().ToString(), UserId = userId },
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

        public static void AddTopics(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var topics = new List<Topic>
            {
                new Topic { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Topic { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Topic { Id = Guid.NewGuid().ToString(), UserId = userId },
                new Topic { Id = Guid.NewGuid().ToString(), UserId = userId },
            };

            context.Topics.AddRange(topics);
            context.SaveChanges();
        }

        // Relations
        public static void UserStatus(FFDbContext context)
        {
            var userId = CommandArrangeHelper.GetUserId(context);

            var statusId = CommandArrangeHelper.GetStatusId(context);

            var userStatus = new UserStatus { UserId = userId, StatusId = statusId };

            context.UserStatuses.Add(userStatus);
            context.SaveChanges();
        }

        public static void AddArmorEquipments(FFDbContext context)
        {
            var equipmentId = CommandArrangeHelper.GetEquipementId(context);

            var armorId = CommandArrangeHelper.GetArmorId(context);

            var armorEquipments = new List<ArmorEquipment>
            {
                new ArmorEquipment { EquipmentId = equipmentId, ArmorId = armorId },
                new ArmorEquipment { EquipmentId = equipmentId, ArmorId = armorId },
                new ArmorEquipment { EquipmentId = equipmentId, ArmorId = armorId },
            };

            context.ArmorsEquipments.AddRange(armorEquipments);
            context.SaveChanges();
        }

        public static void AddTrinketEquipment(FFDbContext context)
        {
            var equipmentId = CommandArrangeHelper.GetEquipementId(context);

            var trinketId = CommandArrangeHelper.GetTrinketId(context);

            var trinketEquipment = new TrinketEquipment { EquipmentId = equipmentId, TrinketId = trinketId };

            context.TrinketEquipments.Add(trinketEquipment);
            context.SaveChanges();
        }

        public static void AddWeaponEquipment(FFDbContext context)
        {
            var equipmentId = CommandArrangeHelper.GetEquipementId(context);

            var weaponId = CommandArrangeHelper.GetWeaponId(context);

            var weaponEquipment = new WeaponEquipment { EquipmentId = equipmentId, WeaponId = weaponId };

            context.WeaponsEquipments.Add(weaponEquipment);
            context.SaveChanges();
        }

        public static void AddArmorInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var armorId = CommandArrangeHelper.GetArmorId(context);

            var armorInventory = new ArmorInventory { InventoryId = inventoryId, ArmorId = armorId };

            context.ArmorsInventories.Add(armorInventory);
            context.SaveChanges();
        }

        public static void AddMaterialInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var materialId = CommandArrangeHelper.GetMaterialId(context);

            var materialInventory = new MaterialInventory { InventoryId = inventoryId, MaterialId = materialId };

            context.MaterialsInventories.Add(materialInventory);
            context.SaveChanges();
        }

        public static void AddToolInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var toolId = CommandArrangeHelper.GetToolId(context);

            var toolInventory = new ToolInventory { InventoryId = inventoryId, ToolId = toolId };

            context.ToolsInventories.Add(toolInventory);
            context.SaveChanges();
        }

        public static void AddTreasureInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var treasureId = CommandArrangeHelper.GetTreasureId(context);

            var treasureInventory = new TreasureInventory { InventoryId = inventoryId, TreasureId = treasureId };

            context.TreasuresInventories.Add(treasureInventory);
            context.SaveChanges();
        }

        public static void AddTreasureKeyInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var treasureKeyId = CommandArrangeHelper.GetTreasureKeyId(context);

            var treasureKeyInventory = new TreasureKeyInventory { InventoryId = inventoryId, TreasureKeyId = treasureKeyId };

            context.TreasureKeysInventories.Add(treasureKeyInventory);
            context.SaveChanges();
        }

        public static void AddTrinketInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var trinketId = CommandArrangeHelper.GetTrinketId(context);

            var trinketInventory = new TrinketInventory { InventoryId = inventoryId, TrinketId = trinketId };

            context.TrinketsInventories.Add(trinketInventory);
            context.SaveChanges();
        }

        public static void AddWeaponInventory(FFDbContext context)
        {
            var inventoryId = CommandArrangeHelper.GetInventoryId(context);

            var weaponId = CommandArrangeHelper.GetWeaponId(context);

            var weaponInventory = new WeaponInventory { InventoryId = inventoryId, WeaponId = weaponId };

            context.WeaponsInventories.Add(weaponInventory);
            context.SaveChanges();
        }

        public static void AddHeroSpells(FFDbContext context)
        {
            var heroId = CommandArrangeHelper.GetHeroId(context);

            var spellId = CommandArrangeHelper.GetSpellId(context);

            var heroSpell = new HeroSpell { HeroId = heroId, SpellId = spellId };

            context.HeroesSpells.Add(heroSpell);
            context.SaveChanges();
        }

        public static void AddMonsterRarity(FFDbContext context)
        {
            var monsterId = CommandArrangeHelper.GetMonsterId(context);

            var monsterRarirty = new MonsterRarity { Id = 1, MonsterId = monsterId };

            context.MonstersRarities.Add(monsterRarirty);
            context.SaveChanges();
        }
    }
}
