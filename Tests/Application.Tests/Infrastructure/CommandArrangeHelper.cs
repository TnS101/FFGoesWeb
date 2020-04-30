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
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Persistence.Context;
    using System;
    using System.Threading.Tasks;

    public static class CommandArrangeHelper
    {
        public static string GetHeroId(FFDbContext context)
        {
            var hero = new Hero
            {
                Id = "1",
                Name = "validname",
                FightingClassId = 1,
                GoldAmount = 100,
                InventoryId = "1"
                ,
                XPCap = 100,
                XP = 0,
                CurrentHP = 100,
                UserId = "1",
                EquipmentId = "1",
                CurrentAttackPower = 10,
                CurrentMagicPower = 10
                ,
                CurrentArmorValue = 10,
                CurrentResistanceValue = 10,
                CurrentCritChance = 5,
                CurrentHealthRegen = 1,
                CurrentMana = 100,
                CurrentManaRegen = 1,
                ClassType = "Warrior",
                AttackPower = 10,
                MagicPower = 10,
                ArmorValue = 1,
                ResistanceValue = 1,
                MaxMana = 100,
                MaxHP = 100,
            };

            context.Heroes.Add(hero);
            context.SaveChanges();

            return context.Heroes.Find(hero.Id).Id;
        }

        public static async Task<string> GetUserId(FFDbContext context)
        {
            var user = new AppUser { Id = "1", UserName = "validname", SecurityStamp = "2" };

            var userManager = MockHelpers.TestUserManager<AppUser>();

            await userManager.CreateAsync(user);
            context.AppUsers.Add(user);
            context.SaveChanges();

            return context.AppUsers.Find(user.Id).Id;
        }

        public static string GetTopicId(FFDbContext context)
        {
            var topic = new Topic { Id = "1", Title = "validtitle", Category = "Somedwawd"
            , Content = "cwscs", EditedOn = DateTime.UtcNow, CreateOn = DateTime.UtcNow, IsRemoved = false,
             UserId = "1",};

            context.Topics.Add(topic);
            context.SaveChanges();

            return context.Topics.Find(topic.Id).Id;
        }

        public static string GetCommentId(FFDbContext context)
        {
            var comment = new Comment { Id = "1", Content = "validcontent", TopicId = "1",
                EditedOn = DateTime.UtcNow,
                IsRemoved = false,
                UserId = "1",
                CreatedOn = DateTime.UtcNow,
                ReplyId = "1",
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            return context.Comments.Find(comment.Id).Id;
        }

        public static string GetMessageId(FFDbContext context)
        {
            var message = new Message { Id = "1", Content = "validcontent",
                EditedOn = DateTime.UtcNow,
                IsRemoved = false,
                UserId = "1",
                SenderName = "Smese",
                SentOn = DateTime.UtcNow,
            };

            context.Messages.Add(message);
            context.SaveChanges();

            return context.Messages.Find(message.Id).Id;
        }

        public static int GetStatusId(FFDbContext context)
        {
            var status = new Status { Id = 1, DisplayName = "SKdasda", IClass = "asdasd" };

            context.Statuses.Add(status);
            context.SaveChanges();

            return context.Statuses.Find(status.Id).Id;
        }

        public static string GetEquipementId(FFDbContext context)
        {
            var equipment = new Equipment("1") { Id = "1",
                BootsSlot = true,
                BracerSlot = true,
                ChestplateSlot = true,
                GlovesSlot = true,
                Capacity = 9,
                HelmetSlot = true,
                LeggingsSlot = true,
                ShoulderSlot = true,
                TrinketSlot = true,
                WeaponSlot = true,
                HeroId = "1",
            };

            context.Equipments.Add(equipment);
            context.SaveChanges();

            return context.Equipments.Find(equipment.Id).Id;
        }

        public static string GetInventoryId(FFDbContext context)
        {
            var inventory = new Inventory("1") { Id = "1", Capacity = 50, HeroId = "1", };

            context.Inventories.Add(inventory);
            context.SaveChanges();

            return context.Inventories.Find(inventory.Id).Id;
        }

        public static string GetArmorId(FFDbContext context)
        {
            var armor = new Armor { Id = "1",
                Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Chestplate",
                IsCraftable = true,
                ImagePath = "1",
                Agility = 1,
                ClassType = "1",
                Intellect = 1,
                Level = 1,
                Spirit = 1,
                Stamina = 1,
                Strength = 1,
                Type = "1",
                ArmorValue = 1,
                ResistanceValue = 1,
            };

            context.Armors.Add(armor);
            context.SaveChanges();

            return context.Armors.Find(armor.Id).Id;
        }

        public static string GetWeaponId(FFDbContext context)
        {
            var weapon = new Weapon
            {
                Id = "1",
                Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Weapon",
                IsCraftable = true,
                ImagePath = "1",
                Agility = 1,
                ClassType = "1",
                Intellect = 1,
                Level = 1,
                Spirit = 1,
                Stamina = 1,
                Strength = 1,
                Type = "1",
                AttackPower = 10,
            };

            context.Weapons.Add(weapon);
            context.SaveChanges();

            return context.Weapons.Find(weapon.Id).Id;
        }

        public static string GetTrinketId(FFDbContext context)
        {
            var trinket = new Trinket
            {
                Id = "1",
                Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Trinket",
                IsCraftable = true,
                ImagePath = "1",
                Agility = 1,
                ClassType = "1",
                Intellect = 1,
                Level = 1,
                Spirit = 1,
                Stamina = 1,
                Strength = 1,
                Type = "1",
            };

            context.Trinkets.Add(trinket);
            context.SaveChanges();

            return context.Trinkets.Find(trinket.Id).Id;
        }

        public static int GetMaterialId(FFDbContext context)
        {
            var material = new Material
            {
                Id = 1,
                Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Material",
                IsCraftable = true,
                FuelCount = 1,
                RelatedMaterials = "1",
                ImagePath = "1",
                ToolId = 1,
                IsDisolveable = false,
                IsRefineable = false,
                Type = "1",
            };

            context.Materials.Add(material);
            context.SaveChanges();

            return context.Materials.Find(material.Id).Id;
        }

        public static int GetToolId(FFDbContext context)
        {
            var tool = new Tool { Id = 1, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Tool",
                IsCraftable = true,
                ImagePath = "1",
                Durability = 1,
            };

            context.Tools.Add(tool);
            context.SaveChanges();

            return context.Tools.Find(tool.Id).Id;
        }

        public static int GetTreasureId(FFDbContext context)
        {
            var treasure = new Treasure { Id = 1, Name = "1",
             ImagePath = "1", Rarity = "1", Reward = 10, Slot = "Treasure"};

            context.Treasures.Add(treasure);
            context.SaveChanges();

            return context.Treasures.Find(treasure.Id).Id;
        }

        public static int GetTreasureKeyId(FFDbContext context)
        {
            var treasureKey = new TreasureKey { Id = 1, Slot = "Treasure Key", Rarity = "1", ImagePath = "1", Name = "1" };

            context.TreasureKeys.Add(treasureKey);
            context.SaveChanges();

            return context.TreasureKeys.Find(treasureKey.Id).Id;
        }

        public static int GetSpellId(FFDbContext context)
        {
            var spell = new Spell { Id = 1,
                ClassType = "1",
                EffectPower = 1,
                AdditionalEffect = "1",
                BuffOrEffectTarget = "1",
                ManaRequirement = 10,
                Name = "1",
                ResistanceAffect = 1,
                SecondaryPower = 10,
                Power = 1,
                Type = "1",
            };

            context.Spells.Add(spell);
            context.SaveChanges();

            return context.Spells.Find(spell.Id).Id;
        }

        public static int GetMonsterId(FFDbContext context)
        {
            var monster = new Monster { Id = 1, Type = "Elemental", Name = "Saint", ImagePath = "somethingimagemaidmaw" };

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
            var userStatus = new UserStatus { UserId = "1", StatusId = 1 };

            context.UserStatuses.Add(userStatus);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static int GetFriendRequestId(FFDbContext context)
        {
            var friendRequest = new FriendRequest { Id = 1, SenderName = "asdas", SentOn = DateTime.UtcNow, UserId = "2" };

            context.FriendRequests.Add(friendRequest);
            context.SaveChanges();

            return context.FriendRequests.Find(friendRequest.Id).Id;
        }

        public static string GetLikeId(FFDbContext context)
        {
            var like = new Like { Id = "1" };

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
            var armorEquipment = new ArmorEquipment { EquipmentId = "1", ArmorId = "1" };

            context.ArmorsEquipments.Add(armorEquipment);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetTrinketEquipmentIds(FFDbContext context)
        {
            var trinketEquipment = new TrinketEquipment { EquipmentId = "1", TrinketId = "1" };

            context.TrinketEquipments.Add(trinketEquipment);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetWeaponEquipmentIds(FFDbContext context)
        {
            var weaponEquipment = new WeaponEquipment { EquipmentId = "1", WeaponId = "1" };

            context.WeaponsEquipments.Add(weaponEquipment);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetArmorInventoryIds(FFDbContext context)
        {
            var armorInventory = new ArmorInventory { InventoryId = "1", ArmorId = "1", Count = 2 };

            context.ArmorsInventories.Add(armorInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetMaterialInventoryIds(FFDbContext context)
        {
            var armorInventory = new ArmorInventory { InventoryId = "1", ArmorId = "1", Count = 2 };

            context.ArmorsInventories.Add(armorInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetToolInventoryIds(FFDbContext context)
        {
            var toolInventory = new ToolInventory { InventoryId = "1", ToolId = 1, Count = 2 };

            context.ToolsInventories.Add(toolInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetTreasureInventoryIds(FFDbContext context)
        {
            var treasureInventory = new TreasureInventory { InventoryId = "1", TreasureId = 1, Count = 2 };

            context.TreasuresInventories.Add(treasureInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetTreasureKeyInventoryIds(FFDbContext context)
        {
            var treasureKeyInventory = new TreasureKeyInventory { InventoryId = "1", TreasureKeyId = 1, Count = 2 };

            context.TreasureKeysInventories.Add(treasureKeyInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetTrinketInventoryIds(FFDbContext context)
        {
            var trinketInventory = new TrinketInventory { InventoryId = "1", TrinketId = "1", Count = 2 };

            context.TrinketsInventories.Add(trinketInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
        }

        public static string[] GetWeaponInventoryIds(FFDbContext context)
        {
            var weaponInventory = new WeaponInventory { InventoryId = "1", WeaponId = "1", Count = 2 };

            context.WeaponsInventories.Add(weaponInventory);
            context.SaveChanges();

            return new string[] { "1", "1" };
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
            var fightingClass = new FightingClass { Id = 1,
                ArmorValue = 1,
                ResistanceValue = 1,
                AttackPower = 1,
                CritChance = 1,
                HealthRegen = 1,
                IconPath = "1",
                MagicPower = 1,
                MaxHP = 1000,
                ManaRegen = 1,
                MaxMana = 10,
                Type = "Warrior",
                ImagePath = "asdasad",
                Description = "description",
            };

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
            var ticket = new Ticket
            {
                Id = 1,
                ReportedUserId = "2",
                Category = "Hate",
                Content = "Somethingaosmdwaomdomwadom"
                ,
                TopicId = "1",
                Type = "Topic"
                ,
                AdditionalInformation = "He doesnt",
                SentOn = DateTime.UtcNow,
                UserId = "1",
                Stars = 1,
                CommentId = "1",
                MessageId = "1",
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            return context.Tickets.Find(ticket.Id).Id;
        }
    }
}
