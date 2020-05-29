namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using global::Common;
    using Microsoft.EntityFrameworkCore;

    public class UnEquipOption
    {
        public async Task<string> UnEquip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var heroEquipment = await context.Equipments.FindAsync(hero.EquipmentId);

            string itemSlot;
            if (item.Slot == "Weapon")
            {
                var weapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == hero.EquipmentId && w.WeaponId == item.Id);

                heroEquipment.WeaponSlot = false;

                context.WeaponsEquipments.Remove(weapon);

                context.WeaponsInventories.Add(new WeaponInventory
                {
                    InventoryId = hero.InventoryId,
                    WeaponId = weapon.WeaponId,
                });

                itemSlot = "Weapon";
            }
            else if (item.Slot == "Trinket")
            {
                var trinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.EquipmentId && t.TrinketId == item.Id);

                heroEquipment.TrinketSlot = false;

                context.TrinketEquipments.Remove(trinket);

                context.TrinketsInventories.Add(new TrinketInventory
                {
                    InventoryId = hero.InventoryId,
                    TrinketId = trinket.TrinketId,
                });

                itemSlot = "Trinket";
            }
            else
            {
                var armor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.EquipmentId == hero.EquipmentId && a.ArmorId == item.Id);

                if (item.Slot == "Helmet" && heroEquipment.HelmetSlot)
                {
                    heroEquipment.HelmetSlot = false;
                }
                else if (item.Slot == "Chestplate" && heroEquipment.ChestplateSlot)
                {
                    heroEquipment.ChestplateSlot = false;
                }
                else if (item.Slot == "Bracer" && heroEquipment.BracerSlot)
                {
                    heroEquipment.BracerSlot = false;
                }
                else if (item.Slot == "Boots" && heroEquipment.BootsSlot)
                {
                    heroEquipment.BootsSlot = false;
                }
                else if (item.Slot == "Leggings" && heroEquipment.LeggingsSlot)
                {
                    heroEquipment.LeggingsSlot = false;
                }
                else if (item.Slot == "Gloves" && heroEquipment.GlovesSlot)
                {
                    heroEquipment.GlovesSlot = false;
                }

                context.ArmorsEquipments.Remove(armor);

                context.ArmorsInventories.Add(new ArmorInventory
                {
                    InventoryId = hero.InventoryId,
                    ArmorId = item.Id,
                });

                itemSlot = "Armor";
            }

            await statSum.ReverseSum(hero, context, item.Id, item.Slot);

            context.Equipments.Update(heroEquipment);

            return string.Format(GConst.EquipmentCommandRedirect, hero.Id, itemSlot);
        }
    }
}
