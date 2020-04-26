namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;

    public class UnEquipOption
    {
        public async Task<string> UnEquip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var heroEquipment = await context.Equipments.FindAsync(hero.EquipmentId);

            if (item.Slot != "Weapon" && item.Slot != "Trinket")
            {
                var armor = await context.ArmorsEquipments.FindAsync(item.Id);

                if (item.Slot == "Helmet" && !hero.Equipment.HelmetSlot)
                {
                    hero.Equipment.HelmetSlot = true;
                }
                else if (item.Slot == "Chestplate" && !hero.Equipment.ChestplateSlot)
                {
                    hero.Equipment.ChestplateSlot = true;
                }
                else if (item.Slot == "Bracer" && !hero.Equipment.BracerSlot)
                {
                    hero.Equipment.BracerSlot = true;
                }
                else if (item.Slot == "Boots" && !hero.Equipment.BootsSlot)
                {
                    hero.Equipment.BootsSlot = true;
                }
                else if (item.Slot == "Leggings" && !hero.Equipment.LeggingsSlot)
                {
                    hero.Equipment.LeggingsSlot = true;
                }
                else if (item.Slot == "Gloves" && !hero.Equipment.GlovesSlot)
                {
                    hero.Equipment.GlovesSlot = true;
                }

                context.ArmorsEquipments.Where(a => a.EquipmentId == hero.EquipmentId).ToList().Remove(armor);

                context.ArmorsInventories.Add(new ArmorInventory
                {
                    InventoryId = hero.InventoryId,
                    ArmorId = item.Id,
                });

                await statSum.Sum(hero, context, heroEquipment);

                return "/Equipment";
            }
            else if (item.Slot == "Weapon")
            {
                var weapon = await context.WeaponsEquipments.FindAsync(item.Id);

                hero.Equipment.WeaponSlot = true;

                context.WeaponsEquipments.Where(w => w.EquipmentId == hero.EquipmentId).ToList().Remove(weapon);

                context.WeaponsInventories.Add(new WeaponInventory
                {
                    InventoryId = hero.InventoryId,
                    WeaponId = weapon.WeaponId,
                });

                await statSum.Sum(hero, context, heroEquipment);
                return "/Equipment";
            }
            else
            {
                var trinket = await context.TrinketEquipments.FindAsync(item.Id);

                hero.Equipment.TrinketSlot = true;

                context.TrinketEquipments.Where(t => t.EquipmentId == hero.EquipmentId).ToList().Remove(trinket);

                context.TrinketsInventories.Add(new TrinketInventory
                {
                    InventoryId = hero.InventoryId,
                    TrinketId = trinket.TrinketId,
                });

                await statSum.Sum(hero, context, heroEquipment);
                return "/Equipment";
            }
        }
    }
}
