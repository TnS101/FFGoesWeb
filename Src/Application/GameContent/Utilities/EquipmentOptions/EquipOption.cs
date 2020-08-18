namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class EquipOption
    {
        public async Task<long> Equip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var fightingClass = await context.FightingClasses.FirstOrDefaultAsync(fc => fc.Type == item.ClassType);

            string itemSlot = string.Empty;

            if ((item.ClassType != "Any" && hero.FightingClassId != fightingClass.Id) || item.Level > hero.Level)
            {
                return 0;
            }

            if (item.Slot == "Weapon")
            {
                var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.HeroId == hero.Id);

                if (hero.WeaponSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                if (weaponInventory.Count > 1)
                {
                    weaponInventory.Count--;
                }
                else
                {
                    context.WeaponsInventories.Remove(weaponInventory);
                }

                context.WeaponsEquipments.Add(new WeaponEquipment
                {
                    HeroId = hero.Id,
                    WeaponId = weaponInventory.WeaponId,
                });

                hero.WeaponSlot = true;

                itemSlot = "Weapon";
            }
            else if (item.Slot == "Trinket")
            {
                var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.HeroId == hero.Id);

                if (hero.TrinketSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.TrinketEquipments.Add(new TrinketEquipment
                {
                    HeroId = hero.Id,
                    TrinketId = trinketInventory.TrinketId,
                });

                if (trinketInventory.Count > 1)
                {
                    trinketInventory.Count--;
                }
                else
                {
                    context.TrinketsInventories.Remove(trinketInventory);
                }

                hero.TrinketSlot = true;

                itemSlot = "Trinket";
            }
            else if (item.Slot == "Relic")
            {
                var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(t => t.RelicId == item.Id && t.HeroId == hero.Id);

                if (hero.RelicSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.RelicsEquipments.Add(new RelicEquipment
                {
                    HeroId = hero.Id,
                    RelicId = relicInventory.RelicId,
                });

                if (relicInventory.Count > 1)
                {
                    relicInventory.Count--;
                }
                else
                {
                    context.RelicsInventories.Remove(relicInventory);
                }

                hero.RelicSlot = true;

                itemSlot = "Relic";
            }
            else
            {
                var armor = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == item.Id && a.HeroId == hero.Id);

                if (item.Slot == "Helmet")
                {
                    if (hero.HelmetSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.HelmetSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Chestplate")
                {
                    if (hero.ChestplateSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.ChestplateSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Shoulder")
                {
                    if (hero.ShoulderSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.ShoulderSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Bracer")
                {
                    if (hero.BracerSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.BracerSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Boots")
                {
                    if (hero.BootsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.BootsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Leggings")
                {
                    if (hero.LeggingsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.LeggingsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Gloves")
                {
                    if (hero.GlovesSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.GlovesSlot = true;

                    this.EquipArmor(hero, context, armor);
                }

                if (armor.Count > 1)
                {
                    armor.Count--;
                }
                else
                {
                    context.ArmorsInventories.Remove(armor);
                }

                itemSlot = "Armor";
            }

            context.Heroes.Update(hero);

            await context.SaveChangesAsync(CancellationToken.None);

            await statSum.Sum(hero, context);

            return item.Id;
        }

        private void EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                HeroId = hero.Id,
                ArmorId = armor.ArmorId,
            });
        }
    }
}
