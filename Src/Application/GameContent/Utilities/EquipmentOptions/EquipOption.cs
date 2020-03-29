namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Base;
    using Domain.Contracts.Items.AdditionalTypes;
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
                    hero.Equipment.WeaponEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).WeaponId = item.Id; // May not be working
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
                    hero.Equipment.TrinketEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).TrinketId = item.Id;
                    hero.Equipment.TrinketSlot = false;
                    await statSum.Sum(hero, context);
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Trinket" && item.Level <= hero.Level && !hero.Equipment.TrinketSlot)
                {
                    // Slot is already taken!
                    return "/SlotTaken";
                }

                if (item.Slot == "Armor" && item.Level <= hero.Level)
                {
                    if (item.Slot == "Helmet" && hero.Equipment.HelmetSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.HelmetSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Helmet" && !hero.Equipment.HelmetSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Chestplate" && hero.Equipment.ChestplateSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.ChestplateSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Chestplate" && !hero.Equipment.ChestplateSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Shoulder" && hero.Equipment.ShoulderSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.ShoulderSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Shoulder" && !hero.Equipment.ShoulderSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Bracer" && hero.Equipment.BracerSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.BracerSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Boots" && hero.Equipment.BootsSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.BootsSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Boots" && !hero.Equipment.BootsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Leggings" && hero.Equipment.LeggingsSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.LeggingsSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Leggings" && !hero.Equipment.LeggingsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Gloves" && hero.Equipment.GlovesSlot)
                    {
                        hero.Equipment.ArmorEquipments.FirstOrDefault(c => c.EquipmentId == hero.EquipmentId).ArmorId = item.Id;
                        hero.Equipment.GlovesSlot = false;
                        await statSum.Sum(hero, context);
                        return "/ItemEquipped";
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
    }
}
