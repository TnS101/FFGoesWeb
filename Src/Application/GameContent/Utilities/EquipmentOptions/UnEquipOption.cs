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
            if (item.Slot == "Weapon")
            {
                var weapon = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.HeroId == hero.Id && w.WeaponId == item.Id);

                hero.WeaponSlot = false;

                context.WeaponsEquipments.Remove(weapon);

                var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.HeroId == hero.Id && w.WeaponId == item.Id);

                if (weaponInventory != null)
                {
                    weaponInventory.Count++;
                }
                else
                {
                    context.WeaponsInventories.Add(new WeaponInventory
                    {
                        HeroId = hero.Id,
                        WeaponId = item.Id,
                    });
                }
            }
            else if (item.Slot == "Trinket")
            {
                var trinket = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.HeroId == hero.Id && t.TrinketId == item.Id);

                hero.TrinketSlot = false;

                context.TrinketEquipments.Remove(trinket);

                var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.HeroId == hero.Id && t.TrinketId == item.Id);

                if (trinketInventory != null)
                {
                    trinketInventory.Count++;
                }
                else
                {
                    context.TrinketsInventories.Add(new TrinketInventory
                    {
                        HeroId = hero.Id,
                        TrinketId = item.Id,
                    });
                }
            }
            else if (item.Slot == "Relic")
            {
                var relic = await context.RelicsEquipments.FirstOrDefaultAsync(r => r.HeroId == hero.Id && r.RelicId == item.Id);

                hero.RelicSlot = false;

                context.RelicsEquipments.Remove(relic);

                var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(r => r.HeroId == hero.Id && r.RelicId == item.Id);

                if (relicInventory != null)
                {
                    relicInventory.Count++;
                }
                else
                {
                    context.RelicsInventories.Add(new RelicInventory
                    {
                        HeroId = hero.Id,
                        RelicId = item.Id,
                    });
                }
            }
            else if (item.Slot == "Card")
            {
                var cardEquipment = await context.CardsEquipments.FirstOrDefaultAsync(c => c.HeroId == hero.Id && c.CardId == item.Id);

                hero.CardSlots++;

                if (hero.CardSlots > 3)
                {
                    hero.CardSlots = 3;
                }

                context.CardsEquipments.Remove(cardEquipment);

                var cardInventory = await context.CardsInventories.FirstOrDefaultAsync(c => c.HeroId == hero.Id && c.CardId == item.Id);

                if (cardInventory != null)
                {
                    cardInventory.Count++;
                }
                else
                {
                    context.CardsInventories.Add(new CardInventory
                    {
                        HeroId = hero.Id,
                        CardId = item.Id,
                    });
                }
            }
            else
            {
                var armor = await context.ArmorsEquipments.FirstOrDefaultAsync(a => a.HeroId == hero.Id && a.ArmorId == item.Id);

                if (item.Slot == "Helmet" && hero.HelmetSlot)
                {
                    hero.HelmetSlot = false;
                }
                else if (item.Slot == "Chestplate" && hero.ChestplateSlot)
                {
                    hero.ChestplateSlot = false;
                }
                else if (item.Slot == "Bracer" && hero.BracerSlot)
                {
                    hero.BracerSlot = false;
                }
                else if (item.Slot == "Boots" && hero.BootsSlot)
                {
                    hero.BootsSlot = false;
                }
                else if (item.Slot == "Leggings" && hero.LeggingsSlot)
                {
                    hero.LeggingsSlot = false;
                }
                else if (item.Slot == "Gloves" && hero.GlovesSlot)
                {
                    hero.GlovesSlot = false;
                }

                context.ArmorsEquipments.Remove(armor);

                var armorInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.HeroId == hero.Id && a.ArmorId == item.Id);

                if (armorInventory != null)
                {
                    armorInventory.Count++;
                }
                else
                {
                    context.ArmorsInventories.Add(new ArmorInventory
                    {
                        HeroId = hero.Id,
                        ArmorId = item.Id,
                    });
                }
            }

            await statSum.ReverseSum(hero, context, item.Id, item.Slot);

            context.Heroes.Update(hero);

            return item.Id;
        }
    }
}
