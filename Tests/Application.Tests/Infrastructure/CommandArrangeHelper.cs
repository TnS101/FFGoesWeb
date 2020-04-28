namespace Application.Tests.Infrastructure
{
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.OneToOne;
    using Domain.Entities.Moderation;
    using Domain.Entities.Social;
    using Persistence.Context;
    using System;
    using System.Linq;

    public static class CommandArrangeHelper
    {
        public static string GetHeroId(FFDbContext context)
        {
            var hero = new Hero { Id = Guid.NewGuid().ToString(), Name = "validname" };

            context.Heroes.Add(hero);
            context.SaveChanges();

            return context.Heroes.Find(hero.Id).Id;
        }

        public static string GetUserId(FFDbContext context)
        {
            var user = new AppUser { Id = Guid.NewGuid().ToString(), UserName = "validname" };

            context.AppUsers.Add(user);
            context.SaveChanges();

            return context.AppUsers.Find(user.Id).Id;
        }

        public static string GetTopicId(FFDbContext context)
        {
            var topic = new Topic { Id = Guid.NewGuid().ToString(), Title = "validtitle" };

            context.Topics.Add(topic);
            context.SaveChanges();

            return context.Topics.Find(topic.Id).Id;
        }

        public static string GetCommentId(FFDbContext context)
        {
            var comment = new Comment { Id = Guid.NewGuid().ToString(), Content = "validcontent" };

            context.Comments.Add(comment);
            context.SaveChanges();

            return context.Comments.Find(comment.Id).Id;
        }

        public static string GetMessageId(FFDbContext context)
        {
            var message = new Message { Id = Guid.NewGuid().ToString(), Content = "validcontent" };

            context.Messages.Add(message);
            context.SaveChanges();

            return context.Messages.Find(message.Id).Id;
        }

        public static int GetStatusId(FFDbContext context)
        {
            var status = new Status { Id = 1 };

            context.Statuses.Add(status);
            context.SaveChanges();

            return context.Statuses.Find(status.Id).Id;
        }

        public static string GetEquipementId(FFDbContext context)
        {
            var heroId = GetHeroId(context);

            var equipment = new Equipment(heroId) { Id = Guid.NewGuid().ToString() };

            context.Equipments.Add(equipment);
            context.SaveChanges();

            return context.Equipments.Find(equipment.Id).Id;
        }

        public static string GetInventoryId(FFDbContext context)
        {
            var heroId = GetHeroId(context);

            var inventory = new Inventory(heroId) { Id = Guid.NewGuid().ToString() };

            context.Inventories.Add(inventory);
            context.SaveChanges();

            return context.Inventories.Find(inventory.Id).Id;
        }

        public static string GetArmorId(FFDbContext context)
        {
            var armor = new Armor { Id = Guid.NewGuid().ToString() };

            context.Armors.Add(armor);
            context.SaveChanges();

            return context.Armors.Find(armor.Id).Id;
        }

        public static string GetWeaponId(FFDbContext context)
        {
            var weapon = new Weapon { Id = Guid.NewGuid().ToString() };

            context.Weapons.Add(weapon);
            context.SaveChanges();

            return context.Weapons.Find(weapon.Id).Id;
        }

        public static string GetTrinketId(FFDbContext context)
        {
            var trinket = new Trinket { Id = Guid.NewGuid().ToString() };

            context.Trinkets.Add(trinket);
            context.SaveChanges();

            return context.Trinkets.Find(trinket.Id).Id;
        }

        public static int GetMaterialId(FFDbContext context)
        {
            var material = new Material { Id = 1 };

            context.Materials.Add(material);
            context.SaveChanges();

            return context.Materials.Find(material.Id).Id;
        }

        public static int GetToolId(FFDbContext context)
        {
            var tool = new Tool { Id = 1 };

            context.Tools.Add(tool);
            context.SaveChanges();

            return context.Tools.Find(tool.Id).Id;
        }

        public static int GetTreasureId(FFDbContext context)
        {
            var treasure = new Treasure { Id = 1 };

            context.Treasures.Add(treasure);
            context.SaveChanges();

            return context.Treasures.Find(treasure.Id).Id;
        }

        public static int GetTreasureKeyId(FFDbContext context)
        {
            var treasureKey = new TreasureKey { Id = 1 };

            context.TreasureKeys.Add(treasureKey);
            context.SaveChanges();

            return context.TreasureKeys.Find(treasureKey.Id).Id;
        }

        public static int GetSpellId(FFDbContext context)
        {
            var spell = new Spell { Id = 1 };

            context.Spells.Add(spell);
            context.SaveChanges();

            return context.Spells.Find(spell.Id).Id;
        }

        public static int GetMonsterId(FFDbContext context)
        {
            var monster = new Monster { Id = 1 };

            context.Monsters.Add(monster);
            context.SaveChanges();

            return context.Monsters.Find(monster.Id).Id;
        }

        public static string GetFriendId(FFDbContext context)
        {
            var friend = new Friend { Id = Guid.NewGuid().ToString() };

            context.Friends.Add(friend);
            context.SaveChanges();

            return context.Friends.Find(friend.Id).Id;
        }

        public static string[] GetUserStatusIds(FFDbContext context)
        {
            var userId = GetUserId(context);

            var statusId = GetStatusId(context);

            var userStatus = new UserStatus { UserId = userId, StatusId = statusId };

            context.UserStatuses.Add(userStatus);
            context.SaveChanges();

            return new string[] { userId, statusId.ToString() };
        }

        public static int GetFriendRequestId(FFDbContext context)
        {
            var friendRequest = new FriendRequest { Id = 1 };

            context.FriendRequests.Add(friendRequest);
            context.SaveChanges();

            return context.FriendRequests.Find(friendRequest.Id).Id;
        }

        public static string GetLikeId(FFDbContext context)
        {
            var like = new Like { Id = Guid.NewGuid().ToString() };

            context.Likes.Add(like);
            context.SaveChanges();

            return context.Friends.Find(like.Id).Id;
        }

        public static string GetNotificationId(FFDbContext context)
        {
            var notification = new Notification { Id = Guid.NewGuid().ToString() };

            context.Notifications.Add(notification);
            context.SaveChanges();

            return context.Notifications.Find(notification.Id).Id;
        }

        public static int GetMonsterRarityId(FFDbContext context)
        {
            var monsterRarity = new MonsterRarity { Id = 1 };

            context.MonstersRarities.Add(monsterRarity);
            context.SaveChanges();

            return context.MonstersRarities.Find(monsterRarity.Id).Id;
        }

        public static string[] GetArmorEquipmentIds(FFDbContext context)
        {
            var equipmentId = GetEquipementId(context);

            var armorId = GetArmorId(context);

            var armorEquipment = new ArmorEquipment { EquipmentId = equipmentId, ArmorId = armorId };

            context.ArmorsEquipments.Add(armorEquipment);
            context.SaveChanges();

            return new string[] { equipmentId, armorId };
        }

        public static string[] GetTrinketEquipmentIds(FFDbContext context)
        {
            var equipmentId = GetEquipementId(context);

            var trinketId = GetTrinketId(context);

            var trinketEquipment = new TrinketEquipment { EquipmentId = equipmentId, TrinketId = trinketId };

            context.TrinketEquipments.Add(trinketEquipment);
            context.SaveChanges();

            return new string[] { equipmentId, trinketId };
        }

        public static string[] GetWeaponEquipmentIds(FFDbContext context)
        {
            var equipmentId = GetEquipementId(context);

            var weaponId = GetWeaponId(context);

            var weaponEquipment = new WeaponEquipment { EquipmentId = equipmentId, WeaponId = weaponId };

            context.WeaponsEquipments.Add(weaponEquipment);
            context.SaveChanges();

            return new string[] { equipmentId, weaponId };
        }

        public static string[] GetArmorInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var armorId = GetArmorId(context);

            var armorInventory = new ArmorInventory { InventoryId = inventoryId, ArmorId = armorId };

            context.ArmorsInventories.Add(armorInventory);
            context.SaveChanges();

            return new string[] { inventoryId, armorId };
        }

        public static string[] GetMaterialInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var armorId = GetArmorId(context);

            var armorInventory = new ArmorInventory { InventoryId = inventoryId, ArmorId = armorId };

            context.ArmorsInventories.Add(armorInventory);
            context.SaveChanges();

            return new string[] { inventoryId, armorId };
        }

        public static string[] GetToolInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var toolId = GetToolId(context);

            var toolInventory = new ToolInventory { InventoryId = inventoryId, ToolId = toolId };

            context.ToolsInventories.Add(toolInventory);
            context.SaveChanges();

            return new string[] { inventoryId, toolId.ToString() };
        }

        public static string[] GetTreasureInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var treasureId = GetTreasureId(context);

            var treasureInventory = new TreasureInventory { InventoryId = inventoryId, TreasureId = treasureId };

            context.TreasuresInventories.Add(treasureInventory);
            context.SaveChanges();

            return new string[] { inventoryId, treasureId.ToString() };
        }

        public static string[] GetTreasureKeyInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var treasureKeyId = GetTreasureKeyId(context);

            var treasureKeyInventory = new TreasureKeyInventory { InventoryId = inventoryId, TreasureKeyId = treasureKeyId };

            context.TreasureKeysInventories.Add(treasureKeyInventory);
            context.SaveChanges();

            return new string[] { inventoryId, treasureKeyId.ToString() };
        }

        public static string[] GetTrinketInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var trinketId = GetTrinketId(context);

            var trinketInventory = new TrinketInventory { InventoryId = inventoryId, TrinketId = trinketId };

            context.TrinketsInventories.Add(trinketInventory);
            context.SaveChanges();

            return new string[] { inventoryId, trinketId };
        }

        public static string[] GetWeaponInventoryIds(FFDbContext context)
        {
            var inventoryId = GetInventoryId(context);

            var weaponId = GetWeaponId(context);

            var weaponInventory = new WeaponInventory { InventoryId = inventoryId, WeaponId = weaponId };

            context.WeaponsInventories.Add(weaponInventory);
            context.SaveChanges();

            return new string[] { inventoryId, weaponId };
        }

        public static string GetEnergyChangeId(FFDbContext context)
        {
            var energyChange = new EnergyChange { Id = Guid.NewGuid().ToString() };

            context.EnergyChanges.Add(energyChange);
            context.SaveChanges();

            return context.EnergyChanges.Find(energyChange.Id).Id;
        }

        public static int GetFightingClassId(FFDbContext context)
        {
            var fightingClass = new FightingClass { Id = 1};

            context.FightingClasses.Add(fightingClass);
            context.SaveChanges();

            return context.FightingClasses.Find(fightingClass.Id).Id;
        }

        public static int GetProfessionId(FFDbContext context)
        {
            var profession = new Profession { Id = 1 };

            context.Professions.Add(profession);
            context.SaveChanges();

            return context.Professions.Find(profession.Id).Id;
        }

        public static int GetFeedbackId(FFDbContext context)
        {
            var feedback = new Feedback { Id = 1 };

            context.Feedbacks.Add(feedback);
            context.SaveChanges();

            return context.Feedbacks.Find(feedback.Id).Id;
        }

        public static int GetTicketId(FFDbContext context)
        {
            var ticket = new Ticket { Id = 1 };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            return context.Tickets.Find(ticket.Id).Id;
        }
    }
}
