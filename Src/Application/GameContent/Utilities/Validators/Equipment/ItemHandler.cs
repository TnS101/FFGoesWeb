namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class ItemHandler
    {
        private readonly Random rng;
        private readonly FightingClassStatCheck fightingClassStatCheck;

        public ItemHandler()
        {
            this.rng = new Random();
            this.fightingClassStatCheck = new FightingClassStatCheck();
        }

        public async Task Execute(int fightingClassNumber, int slotNumber, int[] stats, int fightingClassStatNumber, IFFDbContext context, long HeroId, Monster monster, string zoneName, CancellationToken cancellationToken)
        {
            if (slotNumber == 0)
            {
                await this.WeaponGenerate(fightingClassNumber, fightingClassStatNumber, stats, context, HeroId, cancellationToken);
            }
            else if (slotNumber == 1)
            {
                await this.TrinketGenerate(stats, context, HeroId, cancellationToken);
            }
            else if (slotNumber > 1 && slotNumber < 4)
            {
                await this.ArmorGenerate(stats, fightingClassNumber, fightingClassStatNumber, context, HeroId, cancellationToken);
            }
            else if (slotNumber > 3 && slotNumber < 6)
            {
                await this.LootKeyGenerate(context, HeroId);
            }
            else if (slotNumber > 5 && slotNumber < 7)
            {
                await this.RelicGenerate(stats, context, HeroId, cancellationToken);
            }
            else if (slotNumber > 6 && slotNumber < 10)
            {
                await this.ConsumeableGenerate(zoneName, context, HeroId);
            }
            else if (slotNumber > 9 && slotNumber < 12)
            {
                await this.CardGenerate(stats, context, HeroId, cancellationToken);
            }
            else
            {
                await this.MaterialGenerate(context, HeroId, zoneName);
            }
        }

        private async Task WeaponGenerate(int fightingClassNumber, int fightingClassStatNumber, int[] stats, IFFDbContext context, long HeroId, CancellationToken cancellationToken)
        {
            var templateWeapon = new Weapon
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

            var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.HeroId == HeroId && w.WeaponId == weaponId);

            if (weaponInventory != null)
            {
                weaponInventory.Count++;
            }
            else
            {
                context.WeaponsInventories.Add(new WeaponInventory
                {
                    HeroId = HeroId,
                    WeaponId = weaponId,
                });
            }
        }

        private async Task TrinketGenerate(int[] stats, IFFDbContext context, long HeroId, CancellationToken cancellationToken)
        {
            var effect = this.EffectGenerator("Trinket")[0];

            var duration = this.rng.Next(1, 4);

            var templateTrinket = new Trinket
            {
                Name = $"Trinket of {effect}",
                Level = stats[0],
                Stamina = stats[1],
                Intellect = stats[2],
                Spirit = stats[3],
                Agility = stats[4],
                Strength = stats[5],
                Slot = "Trinket",
                ImagePath = "https://gamepedia.cursecdn.com/wowpedia/4/43/Inv_trinket_80_alchemy02.png?version=95bdfece62d89349b5effa0bf80956d3",
                MaterialType = "Wood",
                Effect = effect,
                EffectPower = int.Parse(this.EffectGenerator("Trinket")[1]) / 100,
                IsPositive = bool.Parse(this.EffectGenerator("Trinket")[2]),
                Duration = duration,
            };

            templateTrinket.SellPrice = this.SellPriceCalculation(templateTrinket);

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

            var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.TrinketId == trinketId);

            if (trinketInventory != null)
            {
                trinketInventory.Count++;
            }
            else
            {
                context.TrinketsInventories.Add(new TrinketInventory
                {
                    HeroId = HeroId,
                    TrinketId = trinketId,
                });
            }
        }

        private async Task RelicGenerate(int[] stats, IFFDbContext context, long HeroId, CancellationToken cancellationToken)
        {
            var effect = this.EffectGenerator("Relic")[0];

            var templateRelic = new Relic()
            {
                Level = stats[0],
                Spirit = stats[1],
                Strength = stats[2],
                Stamina = stats[3],
                Agility = stats[4],
                Intellect = stats[5],
                Slot = "Relic",
                EffectPower = int.Parse(this.EffectGenerator("Relic")[1]) / 100,
                Effect = effect,
                MaterialType = "Stone",
                Name = $"Relic of {effect}",
                ImagePath = "https://gamepedia.cursecdn.com/wowpedia/d/da/Inv_relics_6orunestone_ogremissive.png?version=7c1047730b8614176a63133aada863fe",
                IsPositive = bool.Parse(this.EffectGenerator("Relic")[2]),
            };

            templateRelic.SellPrice = this.SellPriceCalculation(templateRelic);

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

            var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.RelicId == relicId);

            if (relicInventory != null)
            {
                relicInventory.Count++;
            }
            else
            {
                context.RelicsInventories.Add(new RelicInventory
                {
                    HeroId = HeroId,
                    RelicId = relicId,
                });
            }
        }

        private async Task ArmorGenerate(int[] stats, int fightingClassNumber, int fightingClassStatNumber, IFFDbContext context, long HeroId, CancellationToken cancellationToken)
        {
            var templateArmor = new Armor
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

            var armorInventory = await context.ArmorsInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.ArmorId == armorId);

            if (armorInventory != null)
            {
                armorInventory.Count++;
            }
            else
            {
                context.ArmorsInventories.Add(new ArmorInventory
                {
                    HeroId = HeroId,
                    ArmorId = armorId,
                });
            }
        }

        private async Task LootKeyGenerate(IFFDbContext context, long HeroId)
        {
            var rarityNumber = this.rng.Next(10);

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

            var treasureKey = await context.LootKeysInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.LootKeyId == treasureKeyId);

            if (treasureKey != null)
            {
                treasureKey.Count++;
            }
            else
            {
                context.LootKeysInventories.Add(new LootKeyInventory
                {
                    HeroId = HeroId,
                    LootKeyId = treasureKeyId,
                });
            }
        }

        private async Task CardGenerate(int[] stats, IFFDbContext context, long HeroId, CancellationToken cancellationToken)
        {
            var fightingClasses = await context.FightingClasses.ToArrayAsync();
            var fightingClass = fightingClasses[this.rng.Next(fightingClasses.Count())];

            var spells = await context.Spells.Where(s => s.FightingClassId == fightingClass.Id).ToArrayAsync();

            var spell = spells[this.rng.Next(spells.Length)];

            string effect = string.Empty;
            string effectType = string.Empty;
            string effectTarget = string.Empty;
            string mathOperator = string.Empty;

            string effectTargetDescription = string.Empty;
            string mathOperatorDescription = string.Empty;
            string effectTypeDescription = string.Empty;

            double effectPower = this.rng.Next(15, 51);

            switch (this.rng.Next(3))
            {
                case 0: effectTarget = "Spell"; mathOperator = "+"; mathOperatorDescription = "Increase"; effectTargetDescription = "Spell's"; break;
                case 1: effectTarget = "Self"; mathOperator = "+"; mathOperatorDescription = "Increase"; break;
                case 2: effectTarget = "Enemy"; mathOperator = "-"; mathOperatorDescription = "Decrease"; effectTargetDescription = "Enemy's"; break;
            }

            if (effectTarget == "Spell")
            {
                switch (this.rng.Next(3))
                {
                    case 0: effectType = "Power"; break;
                    case 1: effectType = "ResistanceAffect"; break;
                    case 2: effectType = "ManaRequirement"; effectPower += 30; break;
                }
            }
            else
            {
                this.ConditionEffectGenerate(effectType, effectPower, effectTypeDescription);
            }

            var templateCard = new Card
            {
                Level = stats[0],
                Spirit = stats[1],
                Strength = stats[2],
                Stamina = stats[3],
                Agility = stats[4],
                Intellect = stats[5],
                SpellId = spell.Id,
                MaterialType = "Paper",
                ClassType = fightingClass.Type,
                ImagePath = $"/images/Cards/Template-{fightingClass.Type}.png",
                Condition = $"Self,CurrentHP,>,1{effectTarget},{effectType},{mathOperator},{effectTarget}",
                Slot = "Card",
                Name = $"Card of {spell.Name}",
                Description = $"Using this card with {spell.Name} will {mathOperatorDescription} your {effectTargetDescription} {effectTypeDescription} by {effectPower}%.",
            };

            templateCard.SellPrice = this.SellPriceCalculation(templateCard);

            var card = await context.Cards.FirstOrDefaultAsync(c => c.Level == templateCard.Level && c.Spirit == templateCard.Spirit && c.Strength == templateCard.Strength
            && c.Stamina == templateCard.Stamina && c.Agility == templateCard.Agility && c.Intellect == templateCard.Intellect && c.SpellId == spell.Id && c.ClassType ==
            templateCard.ClassType && c.Condition == templateCard.Condition);

            long cardId;

            if (card == null)
            {
                context.Cards.Add(card);
                await context.SaveChangesAsync(cancellationToken);
                cardId = templateCard.Id;
            }
            else
            {
                cardId = card.Id;
            }

            var cardInvetory = await context.CardsInventories.FirstOrDefaultAsync(ci => ci.HeroId == HeroId && ci.CardId == cardId);

            if (cardInvetory != null)
            {
                cardInvetory.Count++;
            }
            else
            {
                context.CardsInventories.Add(new CardInventory
                {
                    CardId = cardId,
                    HeroId = HeroId,
                });
            }
        }

        private void ConditionEffectGenerate(string effectType, double effectPower, string effectTypeDescription)
        {
            switch (this.rng.Next(8))
            {
                case 0: effectType = "CurrentHP"; effectPower = this.rng.Next(8, 16); effectTypeDescription = "Current Health Points"; break;
                case 1: effectType = "CurrentMana"; effectPower = this.rng.Next(15, 31); effectTypeDescription = "Current Mana Points"; break;
                case 2: effectType = "CurrentArmor"; effectTypeDescription = "Current Armor Value"; break;
                case 3: effectType = "CurrentResistance"; effectTypeDescription = "Current Resistance Value"; break;
                case 4: effectType = "CurrentHealthRegen"; effectPower = this.rng.Next(60, 101); effectTypeDescription = "Current Health Regen"; break;
                case 5: effectType = "CurrentManaRegen"; effectPower = this.rng.Next(60, 101); effectTypeDescription = "Current Mana Regen"; break;
                case 6: effectType = "CurrentCritChance"; effectPower = this.rng.Next(6, 17); effectTypeDescription = "Current Critical Chance"; break;
                case 7: effectType = "CurrentAttackPower"; effectPower = this.rng.Next(5, 13); effectTypeDescription = "Current Attack Power"; break;
                case 8: effectType = "CurrentMagicPower"; effectPower = this.rng.Next(5, 13); effectTypeDescription = "Current Magic Power"; break;
            }
        }

        private async Task ConsumeableGenerate(string zoneName, IFFDbContext context, long HeroId)
        {
            var consumeables = await context.Consumeables.Where(c => c.ZoneName == zoneName || c.ZoneName == "Any").ToArrayAsync();

            var consumeableId = consumeables[this.rng.Next(consumeables.Length)].Id;

            var consumeableInventory = await context.ConsumeablesInventories.FirstOrDefaultAsync(ci => ci.HeroId == HeroId && ci.ConsumeableId == consumeableId);

            if (consumeableInventory != null)
            {
                consumeableInventory.Count++;
            }
            else
            {
                context.ConsumeablesInventories.Add(new ConsumeableInventory
                {
                    ConsumeableId = consumeableId,
                    HeroId = HeroId,
                });
            }
        }

        private string[] EffectGenerator(string slot)
        {
            var effect = string.Empty;
            var effectRng = this.rng.Next(7);
            var effectPower = slot == "Relic" ? this.rng.Next(5, 15) : this.rng.Next(2, 10);
            var statBonus = slot == "Relic" ? 5 : 2;
            var isPositive = this.rng.Next(2) == 0 ? true : false;

            switch (effectRng)
            {
                case 0: effect = "Stamina"; effectPower += statBonus; break;
                case 1: effect = "Intellect"; effectPower += statBonus; break;
                case 2: effect = "Spirit"; break;
                case 3: effect = "Strength"; break;
                case 4: effect = "Agility"; break;
                case 5: effect = "Armor"; effectPower += statBonus; break;
                case 6: effect = "Resistance"; effectPower += statBonus; break;
            }

            return new string[] { effect, effectPower.ToString(), isPositive.ToString() };
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
            else if (item.Slot != "Weapon" && item.Slot != "Trinket" && item.Slot != "Relic" && item.Slot != "Card")
            {
                var armor = (Armor)item;

                goldAmount += armor.ArmorValue + armor.ResistanceValue;
            }

            return (int)Math.Floor(goldAmount / 5);
        }

        private async Task MaterialGenerate(IFFDbContext context, long HeroId, string zoneName)
        {
            var materials = await context.Materials.Where(m => m.DroppedFrom == zoneName && !m.RequiresProfession).OrderBy(m => m.Rarity).ToArrayAsync();
            var professionMaterials = await context.Materials.Where(m => m.DroppedFrom == zoneName && m.RequiresProfession).OrderBy(m => m.Rarity).ToArrayAsync();

            var materialId = this.GetMainMaterial(materials).Id;
            var professionMaterialId = professionMaterials[this.rng.Next(professionMaterials.Length)].Id;

            var materialInventory = await context.MaterialsInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.MaterialId == materialId);
            var professionMaterialInventory = await context.MaterialsInventories.FirstOrDefaultAsync(t => t.HeroId == HeroId && t.MaterialId == professionMaterialId);

            if (materialInventory != null)
            {
                materialInventory.Count++;
            }
            else
            {
                context.MaterialsInventories.Add(new MaterialInventory
                {
                    HeroId = HeroId,
                    MaterialId = materialId,
                });
            }

            if (professionMaterialInventory != null)
            {
                professionMaterialInventory.Count++;
            }
            else
            {
                context.MaterialsInventories.Add(new MaterialInventory
                {
                    HeroId = HeroId,
                    MaterialId = professionMaterialId,
                });
            }
        }

        private Material GetMainMaterial(Material[] materials)
        {
            int rarityNumber = this.rng.Next(12);

            if (rarityNumber >= 0 && rarityNumber < 8)
            {
                return materials[this.rng.Next(materials.Length - 2)];
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
    }
}
