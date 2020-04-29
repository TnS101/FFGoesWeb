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
                new Armor { Id = "1", Slot = "Chestplate", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "2", Slot = "Bracer", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "3", Slot = "Leggings", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "4", Slot = "Shoulder", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "5", Slot = "Boots", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "6", Slot = "Helmet", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
                new Armor { Id = "7", Slot = "Gloves", ClassType = "Warrior", Level = 1, Agility = 1, Strength = 1, Intellect = 1, Stamina = 1, Spirit = 1, ArmorValue = 1, ResistanceValue = 1, Type = "Armor" },
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
                new Material { Id = 1, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Material",
                IsCraftable = true,
                FuelCount = 1,
                RelatedMaterials = "Something,some",
                ImagePath = "smee",
                ToolId = 1, },
                new Material { Id = 2,Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Material",
                IsCraftable = true,
                FuelCount = 1,
                RelatedMaterials = "Something,some",
                ImagePath = "smee",
                ToolId = 1, },
                new Material { Id = 3, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Material",
                IsCraftable = true,
                FuelCount = 1,
                RelatedMaterials = "Something,some",
                ImagePath = "smee",
                ToolId = 1, },
            };

            context.Materials.AddRange(materials);
            context.SaveChanges();
        }

        public static void AddTools(FFDbContext context)
        {
            var tools = new List<Tool>
            {
                new Tool { Id = 1, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Tool",
                IsCraftable = true,
                ImagePath = "smee",
                Durability = 1, },
                new Tool { Id = 2, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Tool",
                IsCraftable = true,
                ImagePath = "smee",
                Durability = 1, },
                new Tool { Id = 3, Name = "1",
                BuyPrice = 10,
                SellPrice = 10,
                Slot = "Tool",
                IsCraftable = true,
                ImagePath = "smee",
                Durability = 1, },
            };

            context.Tools.AddRange(tools);
            context.SaveChanges();
        }

        public static void AddTreasures(FFDbContext context)
        {
            var treasures = new List<Treasure>
            {
                new Treasure { Id = 1, Name = "1",
             ImagePath = "1", Rarity = "1", Reward = 10, Slot = "Treasure" },
                new Treasure { Id = 2, Name = "1",
             ImagePath = "1", Rarity = "1", Reward = 10, Slot = "Treasure" },
                new Treasure { Id = 3, Name = "1",
             ImagePath = "1", Rarity = "1", Reward = 10, Slot = "Treasure" },
            };

            context.Treasures.AddRange(treasures);
            context.SaveChanges();
        }

        public static void AddTreasureKeys(FFDbContext context)
        {
            var treasureKeys = new List<TreasureKey>
            {
                new TreasureKey { Id = 1, Slot = "Treasure Key", Rarity = "1", ImagePath = "1", Name = "1" },
                new TreasureKey { Id = 2, Slot = "Treasure Key", Rarity = "1", ImagePath = "1", Name = "1" },
                new TreasureKey { Id = 3, Slot = "Treasure Key", Rarity = "1", ImagePath = "1", Name = "1" },
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
            var energyChange = new EnergyChange { HeroId = "1", LastChangedOn = DateTime.UtcNow, Id = "1", Type = "asdads" };

            context.EnergyChanges.Add(energyChange);
            context.SaveChanges();
        }

        public static void AddFightingClasses(FFDbContext context)
        {
            var fightingClasses = new List<FightingClass>
            {
                new FightingClass { Id = 9, Type = "Warrior", Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10},

                new FightingClass { Id = 8, Type = "Hunter",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                new FightingClass { Id = 7, Type = "Mage",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                 new FightingClass { Id = 6, Type = "Naturalist",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                 new FightingClass { Id = 5, Type = "Necroid",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                  new FightingClass { Id = 4, Type = "Paladin",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                 new FightingClass { Id = 3, Type = "Priest",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                new FightingClass { Id = 2, Type = "Rogue",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },

                new FightingClass { Id = 1, Type = "Shaman",Description = "sdawd", ImagePath = "adawda",
                ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP=1000, ManaRegen = 1, MaxMana = 10 },
               
            };

            context.FightingClasses.AddRange(fightingClasses);
            context.SaveChanges();
        }

        public static void AddHeroes(FFDbContext context)
        {
            var heroes = new List<Hero>
            {
                new Hero { Id = "1", Name = "validname", FightingClassId = 1, UserId = "1", GoldAmount = 100, InventoryId = "1", XPCap = 100, XP = 0, CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                ClassType = "Warrior", Type = "Player", ImagePath = "asdasad", CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1, Energy = 30, EquipmentId = "1", EquipmentScore = 0, IsSelected = true, Level = 1, Mastery = 0 ,
                ProfessionEnergy = 10, ProfessionId = 1, ProfessionLevel = 1, ProffesionXP = 0, ProffesionXPCap = 100, PvPEnergy = 15,
                PvPPoints = 0 ,Race = "random", },

                new Hero { Id = "2", Name = "validname", FightingClassId = 1, UserId = "1", GoldAmount = 100, InventoryId = "2", XPCap = 100, XP = 0, CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                ClassType = "Warrior", Type = "Player", ImagePath = "asdasad", CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1, Energy = 30, EquipmentId = "1", EquipmentScore = 0, IsSelected = false, Level = 1, Mastery = 0 ,
                ProfessionEnergy = 10, ProfessionId = 1, ProfessionLevel = 1, ProffesionXP = 0, ProffesionXPCap = 100, PvPEnergy = 15,
                PvPPoints = 0 ,Race = "random", },

                new Hero { Id = "3", FightingClassId = 1, UserId = "1", GoldAmount = 100, InventoryId = "2", XPCap = 100, XP = 0, CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                IconPath = "awdawdwad", MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                ClassType = "Warrior", Type = "Player", ImagePath = "asdasad", CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1, Energy = 30, EquipmentId = "1", EquipmentScore = 0, IsSelected = false, Level = 1, Mastery = 0 ,
                ProfessionEnergy = 10, ProfessionId = 1, ProfessionLevel = 1, ProffesionXP = 0, ProffesionXPCap = 100, PvPEnergy = 15,
                PvPPoints = 0 ,Race = "random", },
            };

            context.Heroes.AddRange(heroes);
            context.SaveChanges();
        }

        public static void AddMonsters(FFDbContext context)
        {
            var monsters = new List<Monster>
            {
                new Monster { Id = 9, Type = "Beast", Name = "Bear", ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 9, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                   new Monster { Id = 8, Type = "Reptile", Name = "Reptile" , ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                      new Monster { Id = 7, Type = "Humanoid", Name = "Zombie" , ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                       new Monster { Id = 6, Type = "Humanoid", Name = "Skeleton" , ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                        new Monster { Id = 5, Type = "Reptile", Name = "Wyrm" , ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                          new Monster { Id = 4, Type = "Mechanical", Name = "Giant", ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,   },

                 new Monster { Id = 3, Type = "Beast", Name = "Gryphon", ImagePath = "somethingimagemaidmaw", CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },

                new Monster { Id = 2, Type = "Elemental", Name = "Saint", ImagePath = "somethingimagemaidmaw", CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1, },

                new Monster { Id = 1, Type = "Elemental", Name = "Demon" , ImagePath = "somethingimagemaidmaw",CurrentHP = 100, ArmorValue = 1, ResistanceValue = 1, AttackPower = 1, CritChance = 1, HealthRegen = 1 ,
                MagicPower = 1, MaxHP = 1000, ManaRegen = 1, MaxMana = 10, CurrentArmorValue = 1, CurrentAttackPower = 10, CurrentCritChance = 5,
                 CurrentHealthRegen = 1, CurrentMagicPower = 10, CurrentMana = 100,
                CurrentManaRegen = 1, CurrentResistanceValue = 1,  },
            };

            context.Monsters.AddRange(monsters);
            context.SaveChanges();
        }

        public static void AddSpells(FFDbContext context)
        {
            var spells = new List<Spell>
            {
                new Spell { Id = 1, ClassType = "Warrior", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "somepsld", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123"},

                new Spell { Id = 2, ClassType = "Warrior", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "somepsld", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 3, ClassType = "Warrior", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "somepsld", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 4, ClassType = "Warrior", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "somepsld", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 5, ClassType = "Bear", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "Slap", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 6, ClassType = "Bear", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "Slap", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 7, ClassType = "Bear", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "Slap", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },

                new Spell { Id = 8, ClassType = "Bear", EffectPower = 1, AdditionalEffect = "sda",
                BuffOrEffectTarget = "asdas", ManaRequirement = 10, Name = "Slap", ResistanceAffect = 1,
                SecondaryPower = 10, Power = 1, Type = "123123" },
            };

            context.Spells.AddRange(spells);
            context.SaveChanges();
        }

        // Moderation
        public static void AddTickets(FFDbContext context)
        {
            var tickets = new List<Ticket>
            {
                new Ticket { Id = 1, MessageId = "1", UserId = "1", AdditionalInformation = "sinetu"
                , Category = "Hate", Content = "somes", SentOn = DateTime.UtcNow, ReportedUserId = "2"
                , Type = "Message", Stars = 1, },

                 new Ticket { Id = 2, TopicId = "1", UserId = "1", AdditionalInformation = "sinetu"
                , Category = "Hate", Content = "somes", SentOn = DateTime.UtcNow, ReportedUserId = "2"
                , Type = "Topic", Stars = 1 },

                  new Ticket { Id = 3, CommentId = "1", UserId = "1", AdditionalInformation = "sinetu"
                , Category = "Hate", Content = "somes", SentOn = DateTime.UtcNow, ReportedUserId = "2"
                , Type = "Comment", Stars = 1 },
            };

            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }

        public static async Task AddFeedbacks(FFDbContext context)
        {
            var userId = await CommandArrangeHelper.GetUserId(context);

            var feedbacks = new List<Feedback>
            {
                new Feedback { Id = 1, UserId = userId, Content = "sewew", IsAccepted = false, Rate = 0, SentOn = DateTime.UtcNow,
                Stars = 0},

                new Feedback { Id = 2, UserId = userId, Content = "sewew", IsAccepted = false, Rate = 0, SentOn = DateTime.UtcNow,
                Stars = 0 },

                new Feedback { Id = 3, UserId = userId, Content = "sewew", IsAccepted = false, Rate = 0, SentOn = DateTime.UtcNow,
                Stars = 0 },
            };

            context.Feedbacks.AddRange(feedbacks);
            context.SaveChanges();
        }

        public static void AddComments(FFDbContext context)
        {
            var comments = new List<Comment>
            {
                new Comment { Id = "1", UserId = "1", Content = "sewew", CreatedOn = DateTime.UtcNow, EditedOn = DateTime.UtcNow, IsRemoved = false,
                 ReplyId = "1", TopicId = "1"},

                new Comment { Id = "2", UserId = "1", Content = "sewew", CreatedOn = DateTime.UtcNow, EditedOn = DateTime.UtcNow, IsRemoved = false,
                 ReplyId = "1", TopicId = "1" },

                new Comment { Id = "3", UserId = "1", Content = "sewew", CreatedOn = DateTime.UtcNow, EditedOn = DateTime.UtcNow, IsRemoved = false,
                 ReplyId = "1", TopicId = "1" },
            };

            context.Comments.AddRange(comments);
            context.SaveChanges();
        }

        public static void AddFriends(FFDbContext context)
        {
            var friends = new List<Friend>
            {
                new Friend { Id = "1", UserId = "1" },
                new Friend { Id = "2", UserId = "1" },
                new Friend { Id = "3", UserId = "1" },
            };

            context.Friends.AddRange(friends);
            context.SaveChanges();
        }

        public static void AddFriendRequests(FFDbContext context)
        {
            var friends = new List<FriendRequest>
            {
                new FriendRequest { Id = 1, UserId = "1", SenderName = "sdaasd", SentOn = DateTime.UtcNow },
                new FriendRequest { Id = 2, UserId = "1", SenderName = "sdaasd", SentOn = DateTime.UtcNow },
                new FriendRequest { Id = 3, UserId = "1", SenderName = "sdaasd", SentOn = DateTime.UtcNow },
            };

            context.FriendRequests.AddRange(friends);
            context.SaveChanges();
        }

        public static void AddLikes(FFDbContext context)
        {
            var likes = new List<Like>
            {
                new Like { Id = "1", TopicId = "1", CommentId = "1", UserId = "1" },
                new Like { Id = "2", TopicId = "1", CommentId = "1", UserId = "1" },
                new Like { Id = "3", TopicId = "1", CommentId = "1", UserId = "1" },
                new Like { Id = "4", TopicId = "1", CommentId = "1", UserId = "1" },
            };

            context.Likes.AddRange(likes);
            context.SaveChanges();
        }

        public static void AddMessages(FFDbContext context)
        {
            var messages = new List<Message>
            {
                new Message { Id = "1", UserId = "1", Content = "sewew", SentOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow, IsRemoved = false, SenderName = "Somdwad"},

                new Message { Id = "2", UserId = "1", Content = "sewew", SentOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow, IsRemoved = false, SenderName = "Somdwad" },

                new Message { Id = "3", UserId = "1", Content = "sewew", SentOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow, IsRemoved = false, SenderName = "Somdwad" },

                new Message { Id = "4", UserId = "1", Content = "sewew", SentOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow, IsRemoved = false, SenderName = "Somdwad" },
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
                new Status { Id = 1, DisplayName = "1", IClass = "1" },
                new Status { Id = 2, DisplayName = "1", IClass = "1" },
                new Status { Id = 3, DisplayName = "1", IClass = "1" },
                new Status { Id = 4, DisplayName = "1", IClass = "1" },
            };

            context.Statuses.AddRange(statuses);
            context.SaveChanges();
        }

        public static void AddTopics(FFDbContext context)
        {
            var topics = new List<Topic>
            {
                new Topic { Id = "1", UserId = "1", Content = "sewew", Category = "asd", IsRemoved = false,
                 CreateOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow,
                Title = "ssd"},

                new Topic { Id = "2", UserId = "1", Content = "sewew",Category = "asd", IsRemoved = false,
                 CreateOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow,
                Title = "ssd" },

                new Topic { Id = "3", UserId = "2", Content = "sewew",Category = "asd", IsRemoved = false,
                 CreateOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow,
                Title = "ssd" },

                new Topic { Id = "4", UserId = "2", Content = "sewew",Category = "asd", IsRemoved = false,
                 CreateOn = DateTime.UtcNow
                , EditedOn = DateTime.UtcNow,
                Title = "ssd" },
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
                new ArmorEquipment { EquipmentId = "1", ArmorId = "2" },
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
            var materialInventory = new MaterialInventory { InventoryId = "1", MaterialId = 1, Count = 2 };

            context.MaterialsInventories.Add(materialInventory);
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

        public static void AddMonsterRarities(FFDbContext context)
        {
            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Bear-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Bear-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Demon-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Demon-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Giant-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Giant-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Gryphon-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Gryphon-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Reptile-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Reptile-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Saint-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Saint-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Skeleton-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Skeleton-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Wyrm-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Wyrm-Heroic.png",
                StatAmplifier = 0.2,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Rare",
                ImagePath = "/images/Monsters/Zombie-Rare.png",
                StatAmplifier = 0.1,
            });

            context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Heroic",
                ImagePath = "/images/Monsters/Zombie-Heroic.png",
                StatAmplifier = 0.2,
            });
            context.SaveChanges();
        }
    }
}
