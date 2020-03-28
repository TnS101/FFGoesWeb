namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.EquipmentOptions
{
    using Domain.Base;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;

    public class EquipOption
    {
        public EquipOption()
        {
        }

        public string Equip(Unit player, Item item, StatSum statSum)
        {
            if (player.ClassType != item.ClassType)
            {
                // Item not available for player(wrong class)
                return "/WrongClass";
            }
            else
            {
                if (item.Slot == "Weapon" && item.Level <= player.Level && player.Equipment.WeaponSlot)
                {
                    player.Equipment.Items.Add(item);
                    player.Equipment.WeaponSlot = false;
                    statSum.Sum(player);
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Weapon" && item.Level <= player.Level && !player.Equipment.WeaponSlot)
                {
                    // Slot is already taken!
                    return "/SlotTaken";
                }

                if (item.Slot == "Trinket" && item.Level <= player.Level && player.Equipment.TrinketSlot)
                {
                    player.Equipment.Items.Add(item);
                    player.Equipment.TrinketSlot = false;
                    statSum.Sum(player);
                    return "/ItemEquipped";
                }
                else if (item.Slot == "Trinket" && item.Level <= player.Level && !player.Equipment.TrinketSlot)
                {
                    // Slot is already taken!
                    return "/SlotTaken";
                }

                if (item.Slot == "Armor" && item.Level <= player.Level)
                {
                    if (item.Slot == "Helmet" && player.Equipment.HelmetSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.HelmetSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Helmet" && !player.Equipment.HelmetSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Chestplate" && player.Equipment.ChestplateSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.ChestplateSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Chestplate" && !player.Equipment.ChestplateSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Shoulder" && player.Equipment.ShoulderSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.ShoulderSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Shoulder" && !player.Equipment.ShoulderSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Bracer" && player.Equipment.BracerSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.BracerSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Bracer" && !player.Equipment.BracerSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Boots" && player.Equipment.BootsSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.BootsSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Boots" && !player.Equipment.BootsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Leggings" && player.Equipment.LeggingsSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.LeggingsSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Leggings" && !player.Equipment.LeggingsSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                    else if (item.Slot == "Gloves" && player.Equipment.GlovesSlot)
                    {
                        player.Equipment.Items.Add(item);
                        player.Equipment.GlovesSlot = false;
                        statSum.Sum(player);
                        return "/ItemEquipped";
                    }
                    else if (item.Slot == "Gloves" && !player.Equipment.GlovesSlot)
                    {
                        // Slot is already taken!
                        return "/SlotTaken";
                    }
                }
                else if (item.Level > player.Level)
                {
                    // Item level is too high!
                    return "/LevelHigh";
                }
            }

            return string.Empty;
        }
    }
}
