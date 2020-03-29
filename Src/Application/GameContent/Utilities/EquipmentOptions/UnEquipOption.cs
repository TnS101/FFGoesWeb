namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Base;
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public class UnEquipOption
    {
        public async Task<string> UnEquip(Hero hero, IBaseItem item, StatSum statSum, IFFDbContext context)
        {
            if (item.Slot == "Helmet" && !hero.Equipment.HelmetSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.HelmetSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Chestplate" && !hero.Equipment.ChestplateSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.ChestplateSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.BracerSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Boots" && !hero.Equipment.BootsSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.BootsSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Leggings" && !hero.Equipment.LeggingsSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.LeggingsSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Gloves" && !hero.Equipment.GlovesSlot)
            {
                hero.Equipment.ArmorEquipments.Remove((Armor)item);
                hero.Equipment.GlovesSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else if (item.Slot == "Weapon")
            {
                hero.Equipment.WeaponEquipments.Remove((Weapon)item);
                hero.Equipment.WeaponSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
            else
            {
                hero.Equipment.TrinketEquipments.Remove((Trinket)item);
                hero.Equipment.TrinketSlot = true;
                await statSum.Sum(hero, context);
                return "/Equipment";
            }
        }
    }
}
