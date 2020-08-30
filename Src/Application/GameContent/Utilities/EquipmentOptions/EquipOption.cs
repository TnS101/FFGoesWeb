namespace Application.GameContent.Utilities.EquipmentOptions
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class EquipOption
    {
        public async Task<long> Equip(Hero hero, IEquipableItem item, StatSum statSum, IFFDbContext context)
        {
            var fightingClassId = context.FightingClasses.FirstOrDefault(fc => fc.Type == item.ClassType).Id;

            if ((item.ClassType != "Any" && hero.FightingClassId != fightingClassId) || item.Level > hero.Level)
            {
                return 0;
            }

            if (item.Slot == "Weapon")
            {
                var weaponInventory = await context.WeaponsInventories.FirstOrDefaultAsync(w => w.HeroId == hero.Id && w.WeaponId == item.Id);

                if (hero.WeaponSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                if (weaponInventory.Count > 1)
                {
                    weaponInventory.Count--;
                }
                else
                {
                    context.WeaponsInventories.Remove(weaponInventory);
                }

                context.WeaponsEquipments.Add(new WeaponEquipment
                {
                    HeroId = hero.Id,
                    WeaponId = weaponInventory.WeaponId,
                });

                hero.WeaponSlot = true;
            }
            else if (item.Slot == "Trinket")
            {
                var trinketInventory = await context.TrinketsInventories.FirstOrDefaultAsync(t => t.HeroId == hero.Id && t.TrinketId == item.Id);

                if (hero.TrinketSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.TrinketEquipments.Add(new TrinketEquipment
                {
                    HeroId = hero.Id,
                    TrinketId = trinketInventory.TrinketId,
                });

                if (trinketInventory.Count > 1)
                {
                    trinketInventory.Count--;
                }
                else
                {
                    context.TrinketsInventories.Remove(trinketInventory);
                }

                hero.TrinketSlot = true;
            }
            else if (item.Slot == "Relic")
            {
                var relicInventory = await context.RelicsInventories.FirstOrDefaultAsync(r => r.HeroId == hero.Id && r.RelicId == item.Id);

                if (hero.RelicSlot)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }

                context.RelicsEquipments.Add(new RelicEquipment
                {
                    HeroId = hero.Id,
                    RelicId = relicInventory.RelicId,
                });

                if (relicInventory.Count > 1)
                {
                    relicInventory.Count--;
                }
                else
                {
                    context.RelicsInventories.Remove(relicInventory);
                }

                hero.RelicSlot = true;
            }
            else if (item.Slot == "Card")
            {
                var cardInventory = await context.CardsInventories.FirstOrDefaultAsync(c => c.HeroId == hero.Id && c.CardId == item.Id);

                if (hero.CardSlots == 0)
                {
                    await new UnEquipOption().UnEquip(hero, item, statSum, context);
                }
                else
                {
                    hero.CardSlots--;

                    if (hero.CardSlots < 0)
                    {
                        hero.CardSlots = 0;
                    }
                }

                context.CardsEquipments.Add(new CardEquipment
                {
                    HeroId = hero.Id,
                    CardId = item.Id,
                });

                if (cardInventory.Count > 1)
                {
                    cardInventory.Count--;
                }
                else
                {
                    context.CardsInventories.Remove(cardInventory);
                }
            }
            else
            {
                var armorInventory = await context.ArmorsInventories.FirstOrDefaultAsync(a => a.HeroId == hero.Id && a.ArmorId == item.Id);

                if (item.Slot == "Helmet")
                {
                    if (hero.HelmetSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.HelmetSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Chestplate")
                {
                    if (hero.ChestplateSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.ChestplateSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Shoulder")
                {
                    if (hero.ShoulderSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.ShoulderSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Bracer")
                {
                    if (hero.BracerSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.BracerSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Boots")
                {
                    if (hero.BootsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.BootsSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Leggings")
                {
                    if (hero.LeggingsSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.LeggingsSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }
                else if (item.Slot == "Gloves")
                {
                    if (hero.GlovesSlot)
                    {
                        await new UnEquipOption().UnEquip(hero, item, statSum, context);
                    }

                    hero.GlovesSlot = true;

                    this.EquipArmor(hero, context, armorInventory);
                }

                if (armorInventory.Count > 1)
                {
                    armorInventory.Count--;
                }
                else
                {
                    context.ArmorsInventories.Remove(armorInventory);
                }
            }

            context.Heroes.Update(hero);

            await context.SaveChangesAsync(CancellationToken.None);

            await statSum.Sum(hero, context);

            return item.Id;
        }

        private void EquipArmor(Hero hero, IFFDbContext context, ArmorInventory armor)
        {
            context.ArmorsEquipments.Add(new ArmorEquipment
            {
                HeroId = hero.Id,
                ArmorId = armor.ArmorId,
            });
        }
    }
}
