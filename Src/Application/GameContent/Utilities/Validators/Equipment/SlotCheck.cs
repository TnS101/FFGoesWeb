namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class SlotCheck
    {
        private readonly Random rng;
        private readonly FightingClassStatCheck fightingClassStatCheck;
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
            this.fightingClassStatCheck = new FightingClassStatCheck();

            this.woods = new[] { "Oak Log", "Walnut Log", "Birch Log", "Mahogany Log" };
            this.ores = new[] { "Coal Ore", "Copper Ore", "Iron Ore", "Gold Ore" };
            this.leathers = new[] { "Leather Scraps", "Animal Fur", "Light Leather", "Fine Leather" };
            this.cloths = new[] { "Cotton", "Linen Cloth", "Wool", "Silk Cloth" };
            this.herbs = new[] { "Mint", "Coriander", "Lavender", "Buttercup" };
            this.essences = new[] { "Water Essence", "Earth Essence", "Air Essence", "Fire Essence" };
            this.scales = new[] { "Shiny Scale", "Transparent Scale", "Hard Scale", "Golden Necklace" };
            this.vegetables = new[] { "Tomato", "Lettuce", "Turnip", "Pumpkin" };
        }

        public async Task Check(int fightingClassNumber, int slotNumber, int[] stats, int fightingClassStatNumber, IFFDbContext context, Hero hero, Monster monster, string zoneName, CancellationToken cancellationToken)
        {
            if (zoneName == "World")
            {
                if (slotNumber == 0)
                {
                    await this.WeaponGenerate(fightingClassNumber, fightingClassStatNumber, stats, context, hero.InventoryId, cancellationToken);
                }
                else if (slotNumber == 1)
                {
                    await this.TrinketGenerate(stats, fightingClassNumber, context, hero.InventoryId, cancellationToken);
                }
                else if (slotNumber == 2 || slotNumber == 3)
                {
                    await this.ArmorGenerate(stats, fightingClassNumber, fightingClassStatNumber, context, hero.InventoryId, cancellationToken);
                }
                else if (slotNumber == 4 || slotNumber == 5)
                {
                    await this.TreasureKeyGenerate(context, hero.InventoryId);
                }
                else if (slotNumber == 6)
                {
                    await this.RelicGenerate(stats, fightingClassNumber, fightingClassStatNumber, context, hero.InventoryId, cancellationToken);
                }
                else
                {
                    await this.ZoneVariety(zoneName, context, hero.InventoryId, monster);
                }
            }
            else
            {
                await this.ZoneVariety(zoneName, context, hero.InventoryId, monster);
            }
        }

        private async Task WeaponGenerate(int fightingClassNumber, int fightingClassStatNumber, int[] stats, IFFDbContext context, long inventoryId, CancellationToken cancellationToken)
        {
            Weapon templateWeapon = new Weapon
            {
                Level = stats[0],
                Agility = stats[1],
                Stamina = stats[2],
                Strength = stats[3],
                AttackPower = stats[4],
                Intellect = stats[5],
                Spirit = stats[6],
                Slot = "Weapon",
            };

            templateWeapon.SellPrice = this.SellPriceCalculation(templateWeapon);

            this.fightingClassStatCheck.Check(templateWeapon, fightingClassNumber, fightingClassStatNumber, this.rng);

            long weaponId;

            var weapon = await context.Weapons.FirstOrDefaultAsync(w => w.Name == templateWeapon.Name
                && w.ClassType == templateWeapon.ClassType && w.AttackPower == templateWeapon.AttackPower
                && w.Agility == templateWeapon.Agility && w.Stamina == templateWeapon.Stamina && w.Strength == templateWeapon.Strength
                && w.Level == templateWeapon.Level && w.Intellect == templateWeapon.Intellect && w.Spirit == templateWeapon.Spirit);

            if (weapon == null)
            {
                context.Weapons.Add(templateWeapon);
                await context.SaveChangesAsync(cancellationToken);
                weaponId = templateWeapon.Id;
            }
            else
            {
                weaponId = weapon.Id;
            }

            var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.InventoryId == inventoryId && w.WeaponId == weaponId);

            if (weaponInventory != null)
            {
                weaponInventory.Count++;
            }
            else
            {
                context.WeaponsInventories.Add(new WeaponInventory
                {
                    InventoryId = inventoryId,
                    WeaponId = weaponId,
                });
            }
        }

        private async Task TrinketGenerate(int[] stats, int fightingClassNumber, IFFDbContext context, long inventoryId, CancellationToken cancellationToken)
        {
            Trinket templateTrinket = new Trinket
            {
                Name = "Trinket",
                Level = stats[0],
                Stamina = stats[1],
                Intellect = stats[2],
                Spirit = stats[3],
                Agility = stats[4],
                Strength = stats[5],
                Slot = "Trinket",
                ImagePath = "https://gamepedia.cursecdn.com/wowpedia/4/43/Inv_trinket_80_alchemy02.png?version=95bdfece62d89349b5effa0bf80956d3",
                MaterialType = "Wood",
            };

            templateTrinket.SellPrice = this.SellPriceCalculation(templateTrinket);

            this.fightingClassStatCheck.Check(templateTrinket, fightingClassNumber, 0, this.rng);

            long trinketId;

            var trinket = await context.Trinkets.FirstOrDefaultAsync(t => t.Name == templateTrinket.Name
               && t.Agility == templateTrinket.Agility && t.Stamina == templateTrinket.Stamina
               && t.Strength == templateTrinket.Strength
               && t.Level == templateTrinket.Level && t.Intellect == templateTrinket.Intellect && t.Spirit == templateTrinket.Spirit);

            if (trinket == null)
            {
                context.Trinkets.Add(templateTrinket);
                await context.SaveChangesAsync(cancellationToken);
                trinketId = templateTrinket.Id;
            }
            else
            {
                trinketId = trinket.Id;
            }

            var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.InventoryId == inventoryId && t.TrinketId == trinketId);

            if (trinketInventory != null)
            {
                trinketInventory.Count++;
            }
            else
            {
                context.TrinketsInventories.Add(new TrinketInventory
                {
                    InventoryId = inventoryId,
                    TrinketId = trinketId,
                });
            }
        }

        private async Task RelicGenerate(int[] stats, int fightingClassNumber, int fightingClassStatNumber, IFFDbContext context, long inventoryId, CancellationToken cancellationToken)
        {
            var effect = string.Empty;

            var effectRng = this.rng.Next(0, 7);

            var effectPower = this.rng.Next(5, 15);

            switch (effectRng)
            {
                case 0: effect = "Stamina"; effectPower += 5; break;
                case 1: effect = "Intellect"; effectPower += 6; break;
                case 2: effect = "Spirit"; break;
                case 3: effect = "Strength"; break;
                case 4: effect = "Agility"; break;
                case 5: effect = "Armor"; effectPower += 5; break;
                case 6: effect = "Resistance"; effectPower += 5; break;
            }

            Relic templateRelic = new Relic()
            {
                Level = stats[0],
                Spirit = stats[1],
                Strength = stats[2],
                Stamina = stats[3],
                Agility = stats[4],
                Intellect = stats[5],
                Slot = "Relic",
                EffectPower = effectPower,
                Effect = effect,
                MaterialType = "Stone",
                ImagePath = "https://gamepedia.cursecdn.com/wowpedia/d/da/Inv_relics_6orunestone_ogremissive.png?version=7c1047730b8614176a63133aada863fe",
            };

            templateRelic.SellPrice = this.SellPriceCalculation(templateRelic);

            this.fightingClassStatCheck.Check(templateRelic, fightingClassNumber, fightingClassStatNumber, this.rng);

            long relicId;

            var relic = await context.Relics.FirstOrDefaultAsync(r => r.Name == templateRelic.Name
                && r.Agility == templateRelic.Agility && r.Stamina == templateRelic.Stamina && r.Strength == templateRelic.Strength
                && r.Level == templateRelic.Level && r.Intellect == templateRelic.Intellect && r.Spirit == templateRelic.Spirit && r.Effect == templateRelic.Effect
                && r.EffectPower == templateRelic.EffectPower);

            if (relic == null)
            {
                context.Relics.Add(templateRelic);

                await context.SaveChangesAsync(cancellationToken);

                relicId = templateRelic.Id;
            }
            else
            {
                relicId = relic.Id;
            }

            var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(t => t.InventoryId == inventoryId && t.RelicId == relicId);

            if (relicInventory != null)
            {
                relicInventory.Count++;
            }
            else
            {
                context.RelicsInventories.Add(new RelicInventory
                {
                    InventoryId = inventoryId,
                    RelicId = relicId,
                });
            }
        }

        private async Task ArmorGenerate(int[] stats, int fightingClassNumber, int fightingClassStatNumber, IFFDbContext context, long inventoryId, CancellationToken cancellationToken)
        {
            Armor templateArmor = new Armor
            {
                Level = stats[0],
                ResistanceValue = stats[1],
                ArmorValue = stats[2],
                Spirit = stats[3],
                Strength = stats[4],
                Stamina = stats[5],
                Agility = stats[6],
                Intellect = stats[7],
                Slot = "Armor",
            };

            templateArmor.SellPrice = this.SellPriceCalculation(templateArmor);

            this.fightingClassStatCheck.Check(templateArmor, fightingClassNumber, fightingClassStatNumber, this.rng);

            long armorId;

            var armor = await context.Armors.FirstOrDefaultAsync(a => a.Name == templateArmor.Name
                && a.ClassType == templateArmor.ClassType && a.ArmorValue == templateArmor.ArmorValue && a.ResistanceValue == templateArmor.ResistanceValue
                && a.Agility == templateArmor.Agility && a.Stamina == templateArmor.Stamina && a.Strength == templateArmor.Strength
                && a.Level == templateArmor.Level && a.Intellect == templateArmor.Intellect && a.Spirit == templateArmor.Spirit);

            if (armor == null)
            {
                context.Armors.Add(templateArmor);

                await context.SaveChangesAsync(cancellationToken);

                armorId = templateArmor.Id;
            }
            else
            {
                armorId = armor.Id;
            }

            var armorInventory = await context.ArmorsInventories.FirstOrDefaultAsync(t => t.InventoryId == inventoryId && t.ArmorId == armorId);

            if (armorInventory != null)
            {
                armorInventory.Count++;
            }
            else
            {
                context.ArmorsInventories.Add(new ArmorInventory
                {
                    InventoryId = inventoryId,
                    ArmorId = armorId,
                });
            }
        }

        private int SellPriceCalculation(IEquipableItem item)
        {
            double goldAmount = 0;

            goldAmount += item.Agility + item.Intellect + item.Level + item.Spirit + item.Stamina + item.Strength;

            if (item.Slot == "Weapon")
            {
                var weapon = (Weapon)item;

                goldAmount += weapon.AttackPower;
            }
            else if (item.Slot != "Weapon" && item.Slot != "Trinket" && item.Slot != "Relic")
            {
                var armor = (Armor)item;

                goldAmount += armor.ArmorValue + armor.ResistanceValue;
            }

            return (int)Math.Floor(goldAmount / 5);
        }

        private async Task TreasureKeyGenerate(IFFDbContext context, long inventoryId)
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

            var treasureKey = await context.TreasureKeysInventories.FirstOrDefaultAsync(t => t.InventoryId == inventoryId && t.TreasureKeyId == treasureKeyId);

            if (treasureKey != null)
            {
                treasureKey.Count++;
            }
            else
            {
                context.TreasureKeysInventories.Add(new TreasureKeyInventory
                {
                    InventoryId = inventoryId,
                    TreasureKeyId = treasureKeyId,
                });
            }
        }

        private async Task ZoneVariety(string zoneName, IFFDbContext context, long inventoryId, Monster monster)
        {
            await this.MainMaterialsGenerate(context, inventoryId, monster);

            //if (zoneName == "World")
            //{
            //}
            //else
            //{
            //    await this.ProffesionMaterialsGenerate(context, inventoryId, monster, zoneName);
            //}
        }

        private async Task MainMaterialsGenerate(IFFDbContext context, long inventoryId, Monster monster)
        {
            var materialName = this.AllMaterialsVariety(monster);

            var material = await context.Materials.FirstOrDefaultAsync(m => m.Name == materialName);

            var materialInventory = await context.MaterialsInventories.FirstOrDefaultAsync(t => t.InventoryId == inventoryId && t.MaterialId == material.Id);

            if (materialInventory != null)
            {
                materialInventory.Count++;
            }
            else
            {
                context.MaterialsInventories.Add(new MaterialInventory
                {
                    InventoryId = inventoryId,
                    MaterialId = material.Id,
                });
            }
        }

        private async Task ProffesionMaterialsGenerate(IFFDbContext context, long invetoryId, Monster monster, string zoneName)
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
            else if (zoneName == "Magical Flower Shop")
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

            context.MaterialsInventories.Add(new MaterialInventory
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

            string materialName = string.Empty;

            while (true)
            {
                if (materialNumber == 0)
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
                else if (materialNumber > 7 && materialNumber < 11)
                {
                    materialName = this.JunkVariety(monster);
                    break;
                }

                break;
            }

            return materialName;
        }

        private string JunkVariety(Monster monster)
        {
            int junkNumber = this.rng.Next(0, 3);

            var junks = new List<string>();

            if (monster.Type == "Beast")
            {
                junks.Add("Animal Blood");
                junks.Add("Dead Critters");
                junks.Add("Broken Skull");
            }

            if (monster.Type == "Humanoid")
            {
                junks.Add("Broken Watch");
                junks.Add("Empty Plastic Bottle");
                junks.Add("Broken Skull");
            }

            if (monster.Type == "Mechanical")
            {
                junks.Add("Broken Cogs");
                junks.Add("Rusty Pipes");
                junks.Add("Dead Battery");
            }

            if (monster.Type == "Elemental")
            {
                junks.Add("Cracked Water Orb");
                junks.Add("Coal Piece");
                junks.Add("Water Flask");
            }

            if (monster.Type == "Reptile")
            {
                junks.Add("Worm");
                junks.Add("Dead Critters");
                junks.Add("Water Flask");
            }

            if (monster.Type == "Plant")
            {
                junks.Add("Withered Roots");
                junks.Add("Mud");
                junks.Add("Broken Branches");
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
