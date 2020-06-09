namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using global::Common;
    using Microsoft.EntityFrameworkCore;

    public class EquipOption
    {
        public async Task<string> Equip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var heroEquipment = await context.Equipments.FirstOrDefaultAsync(e => e.Id == hero.EquipmentId);

            var fightingClass = await context.FightingClasses.FirstOrDefaultAsync(fc => fc.Type == item.ClassType);

            string itemSlot = string.Empty;

            if ((item.ClassType != "Any" && hero.FightingClassId != fightingClass.Id) || item.Level > hero.Level)
            {
                return GConst.ErrorRedirect;
            }

            if (item.Slot == "Weapon")
            {
                var weapon = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.InventoryId == hero.InventoryId);

                if (!heroEquipment.WeaponSlot)
                {
                    context.WeaponsEquipments.Add(new WeaponEquipment
                    {
                        EquipmentId = hero.EquipmentId,
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
                    var equippedWeapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == hero.EquipmentId);

                    context.WeaponsEquipments.Remove(equippedWeapon);

                    if (weapon.Count > 1)
                    {
                        weapon.Count--;
                    }
                    else
                    {
                        context.WeaponsInventories.Remove(weapon);
                    }

                    var weaponInInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == equippedWeapon.WeaponId && w.InventoryId == hero.InventoryId);

                    if (weaponInInventory != null)
                    {
                        weaponInInventory.Count++;
                    }
                    else
                    {
                        context.WeaponsInventories.Add(new WeaponInventory
                        {
                            InventoryId = hero.InventoryId,
                            WeaponId = equippedWeapon.WeaponId,
                        });
                    }

                    context.WeaponsEquipments.Add(new WeaponEquipment
                    {
                        EquipmentId = hero.EquipmentId,
                        WeaponId = weapon.WeaponId,
                    });

                    await statSum.ReverseSum(hero, context, equippedWeapon.WeaponId, "Weapon");
                }

                itemSlot = "Weapon";
            }
            else if (item.Slot == "Trinket")
            {
                var trinket = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.InventoryId == hero.InventoryId);

                if (!heroEquipment.TrinketSlot)
                {
                    context.TrinketEquipments.Add(new TrinketEquipment
                    {
                        EquipmentId = hero.EquipmentId,
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
                    var equippedTrinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.EquipmentId);

                    context.TrinketEquipments.Remove(equippedTrinket);

                    if (trinket.Count > 1)
                    {
                        trinket.Count--;
                    }
                    else
                    {
                        context.TrinketsInventories.Remove(trinket);
                    }

                    var trinketInInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == equippedTrinket.TrinketId && t.InventoryId == hero.InventoryId);

                    if (trinketInInventory != null)
                    {
                        trinketInInventory.Count++;
                    }
                    else
                    {
                        context.TrinketsInventories.Add(new TrinketInventory
                        {
                            InventoryId = hero.InventoryId,
                            TrinketId = equippedTrinket.TrinketId,
                        });
                    }

                    context.TrinketEquipments.Add(new TrinketEquipment
                    {
                        EquipmentId = hero.EquipmentId,
                        TrinketId = trinket.TrinketId,
                    });

                    await statSum.ReverseSum(hero, context, equippedTrinket.TrinketId, "Trinket");
                }

                itemSlot = "Trinket";
            }
            else if (item.Slot == "Relic")
            {
                var relic = await context.RelicsInventories.FirstOrDefaultAsync(t => t.RelicId == item.Id && t.InventoryId == hero.InventoryId);

                if (!heroEquipment.RelicSlot)
                {
                    context.RelicsEquipments.Add(new RelicEquipment
                    {
                        EquipmentId = hero.EquipmentId,
                        RelicId = relic.RelicId,
                    });

                    heroEquipment.RelicSlot = true;
                }
                else
                {
                    var equippedRelic = await context.RelicsEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.EquipmentId);

                    context.RelicsEquipments.Remove(equippedRelic);

                    var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(r => r.RelicId == equippedRelic.RelicId && r.InventoryId == hero.InventoryId);

                    if (relicInventory != null)
                    {
                        relicInventory.Count++;
                    }
                    else
                    {
                        context.RelicsInventories.Add(new RelicInventory
                        {
                            InventoryId = hero.InventoryId,
                            RelicId = equippedRelic.RelicId,
                        });
                    }

                    context.RelicsEquipments.Add(new RelicEquipment
                    {
                        EquipmentId = hero.EquipmentId,
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
                var armor = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == item.Id && a.InventoryId == hero.InventoryId);

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
                else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
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

            return string.Format(GConst.EquipmentCommandRedirect, hero.Id, itemSlot);
        }

        private void EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                EquipmentId = hero.EquipmentId,
                ArmorId = armor.ArmorId,
            });
        }

        private async Task ReplaceArmor(Hero hero, IFFDbContext context, ArmorInventory armor, StatSum statSum)
        {
            var equippedArmor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.ArmorId == armor.ArmorId && a.EquipmentId == hero.EquipmentId);

            context.ArmorsEquipments.Remove(equippedArmor);

            var armorInInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == equippedArmor.ArmorId && a.InventoryId == hero.InventoryId);

            if (armorInInventory != null)
            {
                armorInInventory.Count++;
            }
            else
            {
                context.ArmorsInventories.Add(new ArmorInventory
                {
                    InventoryId = hero.InventoryId,
                    ArmorId = equippedArmor.ArmorId,
                });
            }

            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                EquipmentId = hero.EquipmentId,
                ArmorId = armor.ArmorId,
            });

            await statSum.ReverseSum(hero, context, equippedArmor.ArmorId, "Armor");
        }
    }
}
