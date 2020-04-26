namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using global::Common;
    using Microsoft.EntityFrameworkCore;

    public class EquipOption
    {
        public EquipOption()
        {
        }

        public async Task<string> Equip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            string wh = hero.EquipmentId;

            var heroEquipment = await context.Equipments.FirstOrDefaultAsync(e => e.Id == hero.EquipmentId);

            if (item.ClassType != "Any" && hero.ClassType != item.ClassType)
            {
                return GConst.ErrorRedirect;
            }
            else
            {
                if (item.Slot == "Weapon" && item.Level <= hero.Level && !heroEquipment.WeaponSlot)
                {
                    var weapon = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.InventoryId == hero.InventoryId);

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

                    hero.Equipment.WeaponSlot = false;
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Weapon" && item.Level <= hero.Level && hero.Equipment.WeaponSlot)
                {
                    var weapon = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.InventoryId == hero.InventoryId);

                    var equippedWeapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.WeaponId == item.Id && w.EquipmentId == hero.EquipmentId);

                    context.WeaponsEquipments.Remove(equippedWeapon);

                    if (weapon.Count > 1)
                    {
                        weapon.Count--;
                    }
                    else
                    {
                        context.WeaponsInventories.Remove(weapon);
                    }

                    if (context.WeaponsInventories.Any(w => w.WeaponId == equippedWeapon.WeaponId && w.InventoryId == hero.InventoryId))
                    {
                        var weaponInInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == equippedWeapon.WeaponId && w.InventoryId == hero.InventoryId);
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

                    return "/SlotTaken";
                }

                if (item.Slot == "Trinket" && item.Level <= hero.Level && !hero.Equipment.TrinketSlot)
                {
                    var trinket = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.InventoryId == hero.InventoryId);

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

                    hero.Equipment.TrinketSlot = false;
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Trinket" && item.Level <= hero.Level && hero.Equipment.TrinketSlot)
                {
                    var trinket = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.InventoryId == hero.InventoryId);

                    var equippedTrinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.TrinketId == item.Id && t.EquipmentId == hero.EquipmentId);

                    context.TrinketEquipments.Remove(equippedTrinket);

                    if (trinket.Count > 1)
                    {
                        trinket.Count--;
                    }
                    else
                    {
                        context.TrinketsInventories.Remove(trinket);
                    }

                    if (context.TrinketsInventories.Any(t => t.TrinketId == equippedTrinket.TrinketId && t.InventoryId == hero.InventoryId))
                    {
                        var trinketInInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == equippedTrinket.TrinketId && t.InventoryId == hero.InventoryId);
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

                    return "/SlotTaken";
                }

                if (item.Slot != "Weapon" && item.Slot != "Trinket" && item.Level <= hero.Level)
                {
                    var armor = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == item.Id && a.InventoryId == hero.InventoryId);

                    if (item.Slot == "Helmet" && !hero.Equipment.HelmetSlot)
                    {
                        hero.Equipment.HelmetSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Helmet" && hero.Equipment.HelmetSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Chestplate" && !hero.Equipment.ChestplateSlot)
                    {
                        hero.Equipment.ChestplateSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Chestplate" && hero.Equipment.ChestplateSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Shoulder" && !hero.Equipment.ShoulderSlot)
                    {
                        hero.Equipment.ShoulderSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Shoulder" && hero.Equipment.ShoulderSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
                    {
                        hero.Equipment.BracerSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Bracer" && hero.Equipment.BracerSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Boots" && !hero.Equipment.BootsSlot)
                    {
                        hero.Equipment.BootsSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Boots" && hero.Equipment.BootsSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Leggings" && !hero.Equipment.LeggingsSlot)
                    {
                        hero.Equipment.LeggingsSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Leggings" && hero.Equipment.LeggingsSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Gloves" && !hero.Equipment.GlovesSlot)
                    {
                        hero.Equipment.GlovesSlot = false;

                        this.EquipArmor(hero, context, armor);

                        return "/Equipment";
                    }
                    else if (item.Slot == "Gloves" && hero.Equipment.GlovesSlot)
                    {
                        await this.ReplaceArmor(hero, context, armor);

                        return "/SlotTaken";
                    }

                    await statSum.Sum(hero, context, heroEquipment);
                }
                else if (item.Level > hero.Level)
                {
                    // Item level is too high!
                    return GConst.ErrorRedirect;
                }
            }

            return string.Empty;
        }

        private void EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                EquipmentId = hero.EquipmentId,
                ArmorId = armor.ArmorId,
            });

            if (armor.Count > 1)
            {
                armor.Count--;
            }
            else
            {
                context.ArmorsInventories.Remove(armor);
            }
        }

        private async Task ReplaceArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            var equippedArmor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.ArmorId == armor.ArmorId && a.EquipmentId == hero.EquipmentId);

            context.ArmorsEquipments.Remove(equippedArmor);

            if (armor.Count > 1)
            {
                armor.Count--;
            }
            else
            {
                context.ArmorsInventories.Remove(armor);
            }

            if (context.ArmorsInventories.Any(a => a.ArmorId == equippedArmor.ArmorId && a.InventoryId == hero.InventoryId))
            {
                var armorInInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == equippedArmor.ArmorId && a.InventoryId == hero.InventoryId);
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
        }
    }
}
