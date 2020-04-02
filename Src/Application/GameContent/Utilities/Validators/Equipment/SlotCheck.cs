namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class SlotCheck
    {
        private readonly Random rng;
        private readonly string[] woods;
        private readonly string[] ores;
        private readonly string[] leathers;
        private readonly string[] cloths;
        private readonly string[] herbs;
        private readonly string[] essences;
        private readonly string[] scales;
        private readonly string[] vegetables;

        public SlotCheck()
        {
            this.rng = new Random();

            this.woods = new string[] { "Oak Log", "Walnut Log", "Birch Log", "Mahogany Log" };
            this.ores = new string[] { "Coal Ore", "Copper Ore", "Iron Ore", "Gold Ore" };
            this.leathers = new string[] { "Leather Scraps", "Animal Fur", "Light Leather", "Fine Leather" };
            this.cloths = new string[] { "Cotton", "Linen Cloth", "Wool", "Silk Cloth" };
            this.herbs = new string[] { "Mint", "Coriander", "Lavender", "Buttercup" };
            this.essences = new string[] { "Water Essence", "Earth Essence", "Air Essence", "Fire Essence" };
            this.scales = new string[] { "Shiny Scale", "Transparent Scale", "Hard Scale", "Golden Necklace" };
            this.vegetables = new string[] { "Tomato", "Lettuce", "Turnip", "Pumpkin" };
        }

        public async Task Check(int fightingClassNumber, int slotNumber, int[] stats, int fightingClassStatNumber, string fightingClassType, string weaponName, ValidatorHandler validatorHandler, IFFDbContext context, Hero hero, Monster monster, string zoneName)
        {
            if (slotNumber == 0)
            {
                await this.WeaponGenerate(fightingClassNumber, stats, fightingClassStatNumber, fightingClassType, weaponName, validatorHandler, context, hero);
            }
            else if (slotNumber == 1)
            {
                await this.TrinketGenerate(stats, fightingClassStatNumber, fightingClassType, validatorHandler, context, hero);
            }
            else if (slotNumber == 2 || slotNumber == 3)
            {
                await this.ArmorGenerate(stats, slotNumber, fightingClassStatNumber, fightingClassType, validatorHandler, context, hero);
            }
            else if (slotNumber == 4 || slotNumber == 5)
            {
                await this.TreasureKeyGenerate(context, hero.InventoryId);
            }
            else
            {
                await this.ZoneVariety(zoneName, context, hero.InventoryId, monster);
            }
        }

        private async Task WeaponGenerate(int fightingClassNumber, int[] stats, int fightingClassStatNumber, string fightingClassType, string weaponName, ValidatorHandler validatorHandler, IFFDbContext context, Hero hero)
        {
            string imageURL = string.Empty;

            validatorHandler.WeaponCheck.Check(fightingClassNumber, fightingClassType, weaponName, imageURL);

            Weapon templateWeapon = new Weapon
            {
                Name = $"{fightingClassType}'s {weaponName}",
                AttackPower = stats[0],
                ClassType = fightingClassType,
                Agility = stats[1],
                Stamina = stats[2],
                Strength = stats[3],
                Level = stats[4],
                Intellect = stats[5],
                Spirit = stats[6],
                ImageURL = imageURL,
            };

            validatorHandler.FightingClassStatCheck.Check(templateWeapon, fightingClassType, fightingClassStatNumber);

            await context.Weapons.AddAsync(templateWeapon);

            context.WeaponsInventories.Where(w => w.InventoryId == hero.InventoryId).ToList().Add(new WeaponInventory
            {
                InventoryId = hero.InventoryId,
                WeaponId = templateWeapon.Id,
            });
        }

        private async Task TrinketGenerate(int[] stats, int fightingClassStatNumber, string fightingClassType, ValidatorHandler validatorHandler, IFFDbContext context, Hero hero)
        {
            Trinket templateTrinket = new Trinket
            {
                Name = $"{fightingClassType}'s Trinket",
                Strength = stats[0],
                ClassType = fightingClassType,
                Stamina = stats[1],
                Intellect = stats[2],
                Spirit = stats[3],
                Agility = stats[4],
                Level = stats[5],
                ImageURL = "https://gamepedia.cursecdn.com/wowpedia/4/43/Inv_trinket_80_alchemy02.png?version=95bdfece62d89349b5effa0bf80956d3",
            };
            validatorHandler.FightingClassStatCheck.Check(templateTrinket, fightingClassType, fightingClassStatNumber);

            await context.Trinkets.AddAsync(templateTrinket);

            context.TrinketsInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Add(new TrinketInventory
            {
                InventoryId = hero.InventoryId,
                TrinketId = templateTrinket.Id,
            });
        }

        private async Task ArmorGenerate(int[] stats, int slotNumber, int fightingClassStatNumber, string fightingClassType, ValidatorHandler validatorHandler, IFFDbContext context, Hero hero)
        {
            Armor templateArmor = new Armor
            {
                Name = $"{fightingClassType}'s Armor",
                ArmorValue = stats[0],
                ClassType = fightingClassType,
                RessistanceValue = stats[1],
                Level = stats[2],
                Spirit = stats[3],
                Strength = stats[4],
                Stamina = stats[5],
                Agility = stats[6],
                Intellect = stats[7],
            };

            validatorHandler.ArmorCheck.Check(templateArmor, slotNumber, fightingClassType, stats[0]);

            validatorHandler.FightingClassStatCheck.Check(templateArmor, fightingClassType, fightingClassStatNumber);

            await context.Armors.AddAsync(templateArmor);

            context.ArmorsInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Add(new ArmorInventory
            {
                InventoryId = hero.InventoryId,
                ArmorId = templateArmor.Id,
            });
        }

        private async Task TreasureKeyGenerate(IFFDbContext context, string inventoryId)
        {
            var rarityNumber = this.rng.Next(0, 10);

            int treasureKeyId;

            if (rarityNumber == 0)
            {
                treasureKeyId = 1; // Gold
            }
            else if (rarityNumber == 1 || rarityNumber == 2 || rarityNumber == 3)
            {
                treasureKeyId = 2; // Silver
            }
            else
            {
                treasureKeyId = 3; // Bronze
            }

            await context.TreasureKeysInventories.AddAsync(new TreasureKeyInventory
            {
                InventoryId = inventoryId,
                TreasureKeyId = treasureKeyId,
            });
        }

        private async Task ZoneVariety(string zoneName, IFFDbContext context, string inventoryId, Monster monster)
        {
            if (zoneName == "World")
            {
                await this.MainMaterialsGenerate(context, inventoryId, monster);
            }
            else
            {
                await this.ProffesionMaterialsGenerate(context, inventoryId, monster, zoneName);
            }
        }

        private async Task MainMaterialsGenerate(IFFDbContext context, string inventoryId, Monster monster)
        {
            var materialName = this.AllMaterialsVariety(monster);

            var material = await context.Materials.SingleOrDefaultAsync(m => m.Name == materialName);

            await context.MaterialsInventories.AddAsync(new MaterialInventory
            {
                InventoryId = inventoryId,
                MaterialId = material.Id,
            });
        }

        private async Task ProffesionMaterialsGenerate(IFFDbContext context, string invetoryId, Monster monster, string zoneName)
        {
            var mainMaterialName = string.Empty;

            var secondaryMaterialName = string.Empty;

            if (zoneName == "Tainted Forest")
            {
                mainMaterialName = this.MainMaterialVariety(this.woods);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Dry Branch", "Green Leaves", "Tree Stump", "Acorn" });
            }
            else if (zoneName == "Endless Mine")
            {
                mainMaterialName = this.MainMaterialVariety(this.ores);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Granite", "Marble", "Quartzite", "Obsidian" });
            }
            else if (zoneName == "The Wilderness")
            {
                mainMaterialName = this.MainMaterialVariety(this.leathers);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Animal Stomach", "Animal Skull", "Animal Bones", "Fangs" });
            }
            else if (zoneName == "Vile City")
            {
                mainMaterialName = this.MainMaterialVariety(this.cloths);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "T-Shirt", "Shoes", "Pants", "Human Soul" });
            }
            else if (zoneName == "Magic Flower Shop")
            {
                mainMaterialName = this.MainMaterialVariety(this.herbs);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Rose", "Daisy", "Clay Pot", "Plastic Vase" });
            }
            else if (zoneName == "The Core")
            {
                mainMaterialName = this.MainMaterialVariety(this.essences);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Life Essence", "Light Essence", "Shadow Essence", "Death Essence" });
            }
            else if (zoneName == "Rocky Basin")
            {
                mainMaterialName = this.MainMaterialVariety(this.scales);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "String", "Puffer Fish", "Turtle Eggs", "Bottled Message" });
            }
            else if (zoneName == "Happy Garden")
            {
                mainMaterialName = this.MainMaterialVariety(this.vegetables);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Potato", "Corn", "Garden Shovel", "Watering Can" });
            }
            else if (zoneName == "Scrap Terminal")
            {
                mainMaterialName = this.JunkVariety(monster);

                secondaryMaterialName = this.ProffesionMaterialsVariety(new string[] { "Broken Glass Cup", "Stale Hotdog", "Crushed Can", "Rubber Band" });
            }

            var mainMaterial = await context.Materials.SingleOrDefaultAsync(m => m.Name == mainMaterialName);

            var secondaryMaterial = context.Materials.SingleOrDefault(m => m.Name == secondaryMaterialName);

            await context.MaterialsInventories.AddAsync(new MaterialInventory
            {
                InventoryId = invetoryId,
                MaterialId = mainMaterial.Id,
            });

            context.MaterialsInventories.Add(new MaterialInventory
            {
                InventoryId = invetoryId,
                MaterialId = secondaryMaterial.Id,
            });
        }

        private string AllMaterialsVariety(Monster monster)
        {
            int materialNumber = this.rng.Next(0, 10);

            var materialName = string.Empty;

            while (true)
            {
                if (materialNumber > 7 && materialNumber < 11)
                {
                    this.JunkVariety(monster);
                    break;
                }
                else if (materialNumber == 0)
                {
                    // wood
                    materialName = this.MainMaterialVariety(this.woods);
                }
                else if (materialNumber == 1)
                {
                    // ore
                    materialName = this.MainMaterialVariety(this.ores);
                }
                else if (materialNumber == 2)
                {
                    // leather
                    if (monster.Type == "Beast")
                    {
                        materialName = this.MainMaterialVariety(this.leathers);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (materialNumber == 3)
                {
                    // cloth
                    if (monster.Type == "Humanoid")
                    {
                        materialName = this.MainMaterialVariety(this.cloths);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (materialNumber == 4)
                {
                    // herb
                    materialName = this.MainMaterialVariety(this.herbs);
                }
                else if (materialNumber == 5)
                {
                    // essence
                    if (monster.Type == "Elemental")
                    {
                        materialName = this.MainMaterialVariety(this.essences);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (materialNumber == 6)
                {
                    // scale
                    if (monster.Type == "Reptile" || monster.Type == "Pisces")
                    {
                        materialName = this.MainMaterialVariety(this.scales);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (materialNumber == 7)
                {
                    if (monster.Type == "Plant")
                    {
                        materialName = this.MainMaterialVariety(this.vegetables);
                    }
                    else
                    {
                        continue;
                    }
                }

                break;
            }

            return materialName;
        }

        private string JunkVariety(Monster monster)
        {
            int junkNumber = this.rng.Next(0, 3);

            string[] junks = { };

            if (monster.Type == "Beast")
            {
                junks[0] = "Animal Blood";
                junks[1] = "Dead Critters";
                junks[2] = "Broken Skull";
            }

            if (monster.Type == "Humanoid")
            {
                junks[0] = "Broken Watch";
                junks[1] = "Empty Plastic Bottle";
                junks[2] = "Broken Skull";
            }

            if (monster.Type == "Mechanical")
            {
                junks[0] = "Broken Cogs";
                junks[1] = "Rusty Pipes";
                junks[2] = "Dead Battery";
            }

            if (monster.Type == "Elemental")
            {
                junks[0] = "Cracked Water Orb";
                junks[1] = "Coal Piece";
                junks[2] = "Water Flask";
            }

            if (monster.Type == "Reptile" || monster.Type == "Pisces")
            {
                junks[0] = "Worm";
                junks[1] = "Dead Critters";
                junks[2] = "Water Flask";
            }

            if (monster.Type == "Plant")
            {
                junks[0] = "Withered Roots";
                junks[1] = "Mud";
                junks[2] = "Broken Branches";
            }

            if (junkNumber == 0)
            {
                return junks[0];
            }
            else if (junkNumber == 1)
            {
                return junks[1];
            }
            else
            {
                return junks[2];
            }
        }

        private string MainMaterialVariety(string[] materials)
        {
            int rarityNumber = this.rng.Next(0, 12);

            if (rarityNumber >= 0 && rarityNumber < 4)
            {
                return materials[0];
            }
            else if (rarityNumber >= 4 && rarityNumber < 8)
            {
                return materials[1];
            }
            else if (rarityNumber >= 8 && rarityNumber < 11)
            {
                return materials[2];
            }
            else
            {
                return materials[3];
            }
        }

        private string ProffesionMaterialsVariety(string[] materials)
        {
            var itemNumber = this.rng.Next(0, 4);

            if (itemNumber == 0)
            {
                return materials[0];
            }
            else if (itemNumber == 1)
            {
                return materials[1];
            }
            else if (itemNumber == 2)
            {
                return materials[2];
            }
            else
            {
                return materials[3];
            }
        }
    }
}
