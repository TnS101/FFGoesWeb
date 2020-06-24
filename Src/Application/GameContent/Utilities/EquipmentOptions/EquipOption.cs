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
                var weapon = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.InventoryId == hero.Id);

                if (!heroEquipment.WeaponSlot)
                {
                    context.WeaponsEquipments.Add(new WeaponEquipment
                    {
                        EquipmentId = hero.Id,
                        WeaponId = weapon.WeaponId,
                    });

                    if (weapon.Count > 1)
                    {
                        weapon.Count--;
                    }
                    else
                    {
                        context.WeaponsInventories.Remove(weapon);
                    }

                    heroEquipment.WeaponSlot = true;
                }
                else
                {
                    var equippedWeapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == hero.Id);

                    context.WeaponsEquipments.Remove(equippedWeapon);

                    if (weapon.Count > 1)
                    {
                        weapon.Count--;
                    }
                    else
                    {
                        context.WeaponsInventories.Remove(weapon);
                    }

                    var weaponInInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == equippedWeapon.WeaponId && w.InventoryId == hero.Id);

                    if (weaponInInventory != null)
                    {
                        weaponInInventory.Count++;
                    }
                    else
                    {
                        context.WeaponsInventories.Add(new WeaponInventory
                        {
                            InventoryId = hero.Id,
                            WeaponId = equippedWeapon.WeaponId,
                        });
                    }

                    context.WeaponsEquipments.Add(new WeaponEquipment
                    {
                        EquipmentId = hero.Id,
                        WeaponId = weapon.WeaponId,
                    });

                    await statSum.ReverseSum(hero, context, equippedWeapon.WeaponId, "Weapon");
                }

                itemSlot = "Weapon";
            }
            else if (item.Slot == "Trinket")
            {
                var trinket = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.InventoryId == hero.Id);

                if (!heroEquipment.TrinketSlot)
                {
                    context.TrinketEquipments.Add(new TrinketEquipment
                    {
                        EquipmentId = hero.Id,
                        TrinketId = trinket.TrinketId,
                    });

                    if (trinket.Count > 1)
                    {
                        trinket.Count--;
                    }
                    else
                    {
                        context.TrinketsInventories.Remove(trinket);
                    }

                    heroEquipment.TrinketSlot = true;
                }
                else
                {
                    var equippedTrinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.Id);

                    context.TrinketEquipments.Remove(equippedTrinket);

                    if (trinket.Count > 1)
                    {
                        trinket.Count--;
                    }
                    else
                    {
                        context.TrinketsInventories.Remove(trinket);
                    }

                    var trinketInInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == equippedTrinket.TrinketId && t.InventoryId == hero.Id);

                    if (trinketInInventory != null)
                    {
                        trinketInInventory.Count++;
                    }
                    else
                    {
                        context.TrinketsInventories.Add(new TrinketInventory
                        {
                            InventoryId = hero.Id,
                            TrinketId = equippedTrinket.TrinketId,
                        });
                    }

                    context.TrinketEquipments.Add(new TrinketEquipment
                    {
                        EquipmentId = hero.Id,
                        TrinketId = trinket.TrinketId,
                    });

                    await statSum.ReverseSum(hero, context, equippedTrinket.TrinketId, "Trinket");
                }

                itemSlot = "Trinket";
            }
            else if (item.Slot == "Relic")
            {
                var relic = await context.RelicsInventories.FirstOrDefaultAsync(t => t.RelicId == item.Id && t.InventoryId == hero.Id);

                if (!heroEquipment.RelicSlot)
                {
                    context.RelicsEquipments.Add(new RelicEquipment
                    {
                        EquipmentId = hero.Id,
                        RelicId = relic.RelicId,
                    });

                    heroEquipment.RelicSlot = true;
                }
                else
                {
                    var equippedRelic = await context.RelicsEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.Id);

                    context.RelicsEquipments.Remove(equippedRelic);

                    var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(r => r.RelicId == equippedRelic.RelicId && r.InventoryId == hero.Id);

                    if (relicInventory != null)
                    {
                        relicInventory.Count++;
                    }
                    else
                    {
                        context.RelicsInventories.Add(new RelicInventory
                        {
                            InventoryId = hero.Id,
                            RelicId = equippedRelic.RelicId,
                        });
                    }

                    context.RelicsEquipments.Add(new RelicEquipment
                    {
                        EquipmentId = hero.Id,
                        RelicId = relic.RelicId,
                    });

                    await statSum.ReverseSum(hero, context, equippedRelic.RelicId, "Relic");
                }

                if (relic.Count > 1)
                {
                    relic.Count--;
                }
                else
                {
                    context.RelicsInventories.Remove(relic);
                }

                itemSlot = "Relic";
            }
            else
            {
                var armor = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == item.Id && a.InventoryId == hero.Id);

                if (item.Slot == "Helmet" && !heroEquipment.HelmetSlot)
                {
                    heroEquipment.HelmetSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Helmet" && heroEquipment.HelmetSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Chestplate" && !heroEquipment.ChestplateSlot)
                {
                    heroEquipment.ChestplateSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Chestplate" && heroEquipment.ChestplateSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Shoulder" && !heroEquipment.ShoulderSlot)
                {
                    heroEquipment.ShoulderSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Shoulder" && heroEquipment.ShoulderSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Bracer" && !heroEquipment.BracerSlot)
                {
                    heroEquipment.BracerSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Bracer" && heroEquipment.BracerSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Boots" && !heroEquipment.BootsSlot)
                {
                    heroEquipment.BootsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Boots" && heroEquipment.BootsSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Leggings" && !heroEquipment.LeggingsSlot)
                {
                    heroEquipment.LeggingsSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Leggings" && heroEquipment.LeggingsSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
                }
                else if (item.Slot == "Gloves" && !heroEquipment.GlovesSlot)
                {
                    heroEquipment.GlovesSlot = true;

                    this.EquipArmor(hero, context, armor);
                }
                else if (item.Slot == "Gloves" && heroEquipment.GlovesSlot)
                {
                    await this.ReplaceArmor(hero, context, armor, statSum);
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

        private async Task ReplaceArmor(Hero hero, IFFDbContext context, ArmorInventory armor, StatSum statSum)
        {
            var equippedArmor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.ArmorId == armor.ArmorId && a.EquipmentId == hero.Id);

            context.ArmorsEquipments.Remove(equippedArmor);

            var armorInInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == equippedArmor.ArmorId && a.InventoryId == hero.Id);

            if (armorInInventory != null)
            {
                armorInInventory.Count++;
            }
            else
            {
                context.ArmorsInventories.Add(new ArmorInventory
                {
                    InventoryId = hero.Id,
                    ArmorId = equippedArmor.ArmorId,
                });
            }

            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                EquipmentId = hero.Id,
                ArmorId = armor.ArmorId,
            });

            await statSum.ReverseSum(hero, context, equippedArmor.ArmorId, "Armor");
        }
    }
}
