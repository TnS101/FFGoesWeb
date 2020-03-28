namespace Application.GameContent.Utilities.EquipmentOptions
{
    using Domain.Base;
    using Application.GameContent.Utilities.FightingClassUtilites;

    public class UnEquipOption
    {
        public string UnEquip(Unit player, Item item, StatSum statSum)
        {
            if (item.Slot == "Helmet" && !player.Equipment.HelmetSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.HelmetSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }
            else if (item.Slot == "Chestplate" && !player.Equipment.ChestplateSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.ChestplateSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }
            else if (item.Slot == "Bracer" && !player.Equipment.BracerSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.BracerSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }
            else if (item.Slot == "Boots" && !player.Equipment.BootsSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.BootsSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }
            else if (item.Slot == "Leggings" && !player.Equipment.LeggingsSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.LeggingsSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }
            else if (item.Slot == "Gloves" && !player.Equipment.GlovesSlot)
            {
                player.Equipment.Items.Remove(item);
                player.Equipment.GlovesSlot = true;
                statSum.Sum(player);
                return "ItemUnEquipped";
            }

            return string.Empty;
        }
    }
}
