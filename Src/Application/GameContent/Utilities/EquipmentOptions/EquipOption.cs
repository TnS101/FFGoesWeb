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
            var heroEquipment = await context.Equipments.FindAsync(hero.Id);

            var fightingClass = await context.FightingClasses.FirstOrDefaultAsync(fc => fc.Type == item.ClassType);

            string itemSlot = string.Empty;

            if ((item.ClassType != "Any" && hero.FightingClassId != fightingClass.Id) || item.Level > hero.Level)
            {
                return 0;
            }

            if (item.Slot == "Weapon")
            {
                var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.InventoryId == hero.Id);

                if (heroEquipment.WeaponSlot)
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
                    EquipmentId = hero.Id,
                    WeaponId = weaponInventory.WeaponId,
                });

                heroEquipment.WeaponSlot = true;

                itemSlot = "Weapon";
            }
            else if (item.Slot == "Trinket")
            {
                var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.InventoryId == hero.Id);

                if (heroEquipment.TrinketSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.TrinketEquipments.Add(new TrinketEquipment
                {
                    EquipmentId = hero.Id,
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

                heroEquipment.TrinketSlot = true;

                itemSlot = "Trinket";
            }
            else if (item.Slot == "Relic")
            {
                var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(t => t.RelicId == item.Id && t.InventoryId == hero.Id);

                if (heroEquipment.RelicSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.RelicsEquipments.Add(new RelicEquipment
                {
                    EquipmentId = hero.Id,
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

                heroEquipment.RelicSlot = true;

                itemSlot = "Relic";
            }
            else
            {
                var armor = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == item.Id && a.InventoryId == hero.Id);

                if (item.Slot == "Helmet")
                {
                    if (heroEquipment.HelmetSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.HelmetSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Chestplate")
                {
                    if (heroEquipment.ChestplateSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.ChestplateSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Shoulder")
                {
                    if (heroEquipment.ShoulderSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.ShoulderSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Bracer")
                {
                    if (heroEquipment.BracerSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.BracerSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Boots")
                {
                    if (heroEquipment.BootsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.BootsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Leggings")
                {
                    if (heroEquipment.LeggingsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.LeggingsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Gloves")
                {
                    if (heroEquipment.GlovesSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    heroEquipment.GlovesSlot = true;

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

            context.Equipments.Update(heroEquipment);

            await context.SaveChangesAsync(CancellationToken.None);

            await statSum.Sum(hero, context, heroEquipment);

            return item.Id;
        }

        private void EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                EquipmentId = hero.Id,
                ArmorId = armor.ArmorId,
            });
        }
    }
}
