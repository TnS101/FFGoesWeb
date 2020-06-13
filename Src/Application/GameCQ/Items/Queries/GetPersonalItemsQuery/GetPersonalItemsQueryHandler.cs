﻿namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalItemsQueryHandler : BaseHandler, IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>
    {
        public GetPersonalItemsQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<ItemListViewModel> Handle(GetPersonalItemsQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            var fightingClass = await this.Context.FightingClasses.FindAsync(hero.FightingClassId);

            if (request.Slot == "Weapon")
            {
                return await this.GetWeapons(hero, fightingClass.Type);
            }
            else if (request.Slot == "Armor")
            {
                return await this.GetArmors(hero, fightingClass.Type);
            }
            else if (request.Slot == "Trinket")
            {
                return await this.GetTrinkets(hero);
            }
            else if (request.Slot == "Relic")
            {
                return await this.GetRelics(hero);
            }
            else if (request.Slot == "Treasure")
            {
                return await this.GetTreasures(hero);
            }
            else if (request.Slot == "Treasure Key")
            {
                return await this.GetTreasureKeys(hero);
            }
            else
            {
                return await this.GetMaterials(hero);
            }
        }

        private async Task<ItemListViewModel> GetRelics(Hero hero)
        {
            var inventory = await this.Context.RelicsInventories.Where(ri => ri.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel { HeroClass = "Any", HeroLevel = hero.Level };

                if (inventory.Count() > 0)
                {
                    foreach (var baseRelic in this.Context.Relics.ToList())
                    {
                        foreach (var item in inventory)
                        {
                            if (item.RelicId == baseRelic.Id)
                            {
                                result.Items.ToList().Add(new ItemMinViewModel
                                {
                                    Id = baseRelic.Id,
                                    Name = baseRelic.Name,
                                    ImagePath = baseRelic.ImagePath,
                                    Slot = baseRelic.Slot,
                                    Level = baseRelic.Level,
                                    ClassType = baseRelic.ClassType,
                                    SellPrice = baseRelic.SellPrice,
                                    Count = item.Count,
                                });
                            }
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetWeapons(Hero hero, string className)
        {
            var inventory = await this.Context.WeaponsInventories.Where(wi => wi.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel() { HeroClass = className, HeroLevel = hero.Level };

                if (inventory.Count() > 0)
                {
                    foreach (var baseWeapon in this.Context.Weapons.ToList())
                    {
                        foreach (var item in inventory)
                        {
                            if (item.WeaponId == baseWeapon.Id)
                            {
                                result.Items.Add(new ItemMinViewModel
                                {
                                    Id = baseWeapon.Id,
                                    Name = baseWeapon.Name,
                                    ImagePath = baseWeapon.ImagePath,
                                    Slot = baseWeapon.Slot,
                                    Level = baseWeapon.Level,
                                    ClassType = baseWeapon.ClassType,
                                    SellPrice = baseWeapon.SellPrice,
                                    Count = item.Count,
                                });
                            }
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetArmors(Hero hero, string className)
        {
            var inventory = await this.Context.ArmorsInventories.Where(ai => ai.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel() { HeroClass = className, HeroLevel = hero.Level };

                foreach (var baseArmor in this.Context.Armors)
                {
                    foreach (var item in inventory)
                    {
                        if (item.ArmorId == baseArmor.Id)
                        {
                            result.Items.Add(new ItemMinViewModel
                            {
                                Id = baseArmor.Id,
                                Name = baseArmor.Name,
                                ImagePath = baseArmor.ImagePath,
                                Slot = baseArmor.Slot,
                                Level = baseArmor.Level,
                                ClassType = baseArmor.ClassType,
                                SellPrice = baseArmor.SellPrice,
                                Count = item.Count,
                            });
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTrinkets(Hero hero)
        {
            var inventory = await this.Context.TrinketsInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel() { HeroClass = "Any", HeroLevel = hero.Level };

                foreach (var baseTrinket in this.Context.Trinkets)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TrinketId == baseTrinket.Id)
                        {
                            result.Items.Add(new ItemMinViewModel
                            {
                                Id = baseTrinket.Id,
                                Name = baseTrinket.Name,
                                ImagePath = baseTrinket.ImagePath,
                                Slot = baseTrinket.Slot,
                                Level = baseTrinket.Level,
                                ClassType = baseTrinket.ClassType,
                                SellPrice = baseTrinket.SellPrice,
                                Count = item.Count,
                            });
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTreasures(Hero hero)
        {
            var inventory = await this.Context.TreasuresInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel();

                foreach (var baseTreasure in this.Context.Treasures)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureId == baseTreasure.Id)
                        {
                            result.Items.Add(new ItemMinViewModel
                            {
                                Id = baseTreasure.Id,
                                Name = baseTreasure.Name,
                                ImagePath = baseTreasure.ImagePath,
                                Slot = baseTreasure.Slot,
                                Count = item.Count,
                            });
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTreasureKeys(Hero hero)
        {
            var inventory = await this.Context.TreasureKeysInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel();

                foreach (var baseTreasureKey in this.Context.TreasureKeys)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureKeyId == baseTreasureKey.Id)
                        {
                            result.Items.Add(new ItemMinViewModel
                            {
                                Id = baseTreasureKey.Id,
                                Name = baseTreasureKey.Name,
                                ImagePath = baseTreasureKey.ImagePath,
                                Slot = baseTreasureKey.Slot,
                                Count = item.Count,
                            });
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetMaterials(Hero hero)
        {
            var inventory = await this.Context.MaterialsInventories.Where(mi => mi.InventoryId == hero.InventoryId).ToListAsync();

            if (inventory != null)
            {
                var result = new ItemListViewModel();

                if (inventory.Count > 0)
                {
                    foreach (var baseMaterial in this.Context.Materials)
                    {
                        foreach (var item in inventory)
                        {
                            if (item.MaterialId == baseMaterial.Id)
                            {
                                result.Items.Add(new ItemMinViewModel
                                {
                                    Id = baseMaterial.Id,
                                    Name = baseMaterial.Name,
                                    ImagePath = baseMaterial.ImagePath,
                                    Slot = baseMaterial.Slot,
                                    SellPrice = baseMaterial.SellPrice,
                                    Count = item.Count,
                                });
                            }
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
