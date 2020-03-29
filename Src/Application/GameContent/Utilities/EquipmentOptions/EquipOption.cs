namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Base;
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;

    public class EquipOption
    {
        public EquipOption()
        {
        }

        public async Task<string> Equip(Hero hero, IBaseItem item, StatSum statSum, IFFDbContext context)
        {
            if (hero.ClassType != item.ClassType)
            {
                // Item not available for player(wrong class)
                return "/WrongClass";
            }
            else
            {
                if (item.Slot == "Weapon" && item.Level <= hero.Level && hero.Equipment.WeaponSlot)
                {
                    var weapon = await context.WeaponsInventories.FindAsync(item.Id);

                    await context.WeaponsEquipments.AddAsync(new WeaponEquipment
                    {
                        EquipmentId = hero.EquipmentId,
                        WeaponId = weapon.WeaponId,
                    });

                    context.WeaponsInventories.Where(wi => wi.InventoryId == hero.InventoryId).ToList().Remove(weapon);

                    hero.Equipment.WeaponSlot = false;
                    await statSum.Sum(hero, context);
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Weapon" && item.Level <= hero.Level && !hero.Equipment.WeaponSlot)
                {
                    // Slot is already taken!
                    return "/SlotTaken";
                }

                if (item.Slot == "Trinket" && item.Level <= hero.Level && hero.Equipment.TrinketSlot)
                {
                    var trinket = await context.TrinketsInventories.FindAsync(item.Id);

                    await context.TrinketEquipments.AddAsync(new TrinketEquipment
                    {
                        EquipmentId = hero.EquipmentId,
                        TrinketId = trinket.TrinketId,
                    });

                    context.TrinketsInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToList().Remove(trinket);

                    hero.Equipment.TrinketSlot = false;
                    await statSum.Sum(hero, context);
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Trinket" && item.Level <= hero.Level && !hero.Equipment.TrinketSlot)
                {
                    // Slot is already taken!
                    return "/SlotTaken";
                }

                if (item.Slot != "Weapon" && item.Slot != "Trinket" && item.Level <= hero.Level)
                {
                    var armor = await context.ArmorsInventories.FindAsync(item.Id);

                    if (item.Slot == "Helmet" && hero.Equipment.HelmetSlot)
                    {
                        hero.Equipment.HelmetSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Helmet" && !hero.Equipment.HelmetSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Chestplate" && hero.Equipment.ChestplateSlot)
                    {
                        hero.Equipment.ChestplateSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Chestplate" && !hero.Equipment.ChestplateSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Shoulder" && hero.Equipment.ShoulderSlot)
                    {
                        hero.Equipment.ShoulderSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Shoulder" && !hero.Equipment.ShoulderSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Bracer" && hero.Equipment.BracerSlot)
                    {
                        hero.Equipment.BracerSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Boots" && hero.Equipment.BootsSlot)
                    {
                        hero.Equipment.BootsSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Boots" && !hero.Equipment.BootsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Leggings" && hero.Equipment.LeggingsSlot)
                    {
                        hero.Equipment.LeggingsSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Leggings" && !hero.Equipment.LeggingsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Gloves" && hero.Equipment.GlovesSlot)
                    {
                        hero.Equipment.GlovesSlot = false;

                        await this.EquipArmor(hero, context, armor);

                        await statSum.Sum(hero, context);
                        return "/Equipment";
                    }
                    else if (item.Slot == "Gloves" && !hero.Equipment.GlovesSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                }
                else if (item.Level > hero.Level)
                {
                    // Item level is too high!
                    return "/LevelHigh";
                }
            }

            return string.Empty;
        }

        private async Task EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            await context.ArmorsEquipments.AddAsync(new ArmorEquipment
            {
                EquipmentId = hero.EquipmentId,
                ArmorId = armor.ArmorId,
            });

            context.ArmorsInventories.Where(ai => ai.InventoryId == hero.InventoryId).ToList().Remove(armor);
        }
    }
}
