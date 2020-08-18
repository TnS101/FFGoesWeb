namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class UnEquipOption
    {
        public async Task<long> UnEquip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var heroEquipment = await context.Equipments.FindAsync(hero.Id);

            if (item.Slot == "Weapon")
            {
                var weapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.HeroId == hero.Id && w.WeaponId == item.Id);

                heroEquipment.WeaponSlot = false;

                context.WeaponsEquipments.Remove(weapon);

                var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.WeaponId == weapon.WeaponId && w.InventoryId == hero.Id);

                if (weaponInventory != null)
                {
                    weaponInventory.Count++;
                }
                else
                {
                    context.WeaponsInventories.Add(new WeaponInventory
                    {
                        InventoryId = hero.Id,
                        WeaponId = weapon.WeaponId,
                    });
                }
            }
            else if (item.Slot == "Trinket")
            {
                var trinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.HeroId == hero.Id && t.TrinketId == item.Id);

                heroEquipment.TrinketSlot = false;

                context.TrinketEquipments.Remove(trinket);

                var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.TrinketId == trinket.TrinketId && t.InventoryId == hero.Id);

                if (trinketInventory != null)
                {
                    trinketInventory.Count++;
                }
                else
                {
                    context.TrinketsInventories.Add(new TrinketInventory
                    {
                        InventoryId = hero.Id,
                        TrinketId = trinket.TrinketId,
                    });
                }
            }
            else
            {
                var armor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.HeroId == hero.Id && a.ArmorId == item.Id);

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

                var armorInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.ArmorId == armor.ArmorId && a.InventoryId == hero.Id);

                if (armorInventory != null)
                {
                    armorInventory.Count++;
                }
                else
                {
                    context.ArmorsInventories.Add(new ArmorInventory
                    {
                        InventoryId = hero.Id,
                        ArmorId = item.Id,
                    });
                }
            }

            await statSum.ReverseSum(hero, context, item.Id, item.Slot);

            context.Equipments.Update(heroEquipment);

            return item.Id;
        }
    }
}
