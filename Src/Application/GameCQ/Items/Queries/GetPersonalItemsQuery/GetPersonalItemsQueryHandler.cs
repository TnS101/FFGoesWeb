namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items;
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

        private async Task<ItemListViewModel> GetWeapons(Hero hero, string className)
        {
            if (this.Context.WeaponsInventories.Any(wi => wi.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.WeaponsInventories.Where(wi => wi.InventoryId == hero.InventoryId).ToListAsync();

                var weapons = new Stack<Weapon>();

                if (inventory.Count() > 0)
                {
                    foreach (var baseWeapon in this.Context.Weapons.ToList())
                    {
                        foreach (var item in inventory)
                        {
                            if (item.WeaponId == baseWeapon.Id)
                            {
                                weapons.Push(baseWeapon);
                            }
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = weapons.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = i.Slot,
                        Level = i.Level,
                        ClassType = i.ClassType,
                    }),
                    HeroClass = className,
                    HeroLevel = hero.Level,
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetArmors(Hero hero, string className)
        {
            if (this.Context.ArmorsInventories.Any(ai => ai.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.ArmorsInventories.Where(ai => ai.InventoryId == hero.InventoryId).ToListAsync();

                var armors = new Stack<Armor>();

                foreach (var baseArmor in this.Context.Armors)
                {
                    foreach (var item in inventory)
                    {
                        if (item.ArmorId == baseArmor.Id)
                        {
                            armors.Push(baseArmor);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = armors.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = i.Slot,
                        Level = i.Level,
                        ClassType = i.ClassType,
                    }),
                    HeroClass = className,
                    HeroLevel = hero.Level,
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTrinkets(Hero hero)
        {
            if (this.Context.TrinketsInventories.Any(ti => ti.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.TrinketsInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var trinkets = new Stack<Trinket>();

                foreach (var baseTrinket in this.Context.Trinkets)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TrinketId == baseTrinket.Id)
                        {
                            trinkets.Push(baseTrinket);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = trinkets.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = i.Slot,
                        Level = i.Level,
                        ClassType = i.ClassType,
                    }),
                    HeroClass = "Any",
                    HeroLevel = hero.Level,
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTreasures(Hero hero)
        {
            if (this.Context.TreasuresInventories.Any(ti => ti.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.TreasuresInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var treasures = new Stack<Treasure>();

                foreach (var baseTreasure in this.Context.Treasures)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureId == baseTreasure.Id)
                        {
                            treasures.Push(baseTreasure);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = treasures.Select(i => new ItemMinViewModel
                    {
                        Id = (long)i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = "Treasure",
                    }),
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetTreasureKeys(Hero hero)
        {
            if (this.Context.TreasureKeysInventories.Any(ti => ti.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.TreasureKeysInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var treasureKeys = new Stack<TreasureKey>();

                foreach (var baseTreasureKey in this.Context.TreasureKeys)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureKeyId == baseTreasureKey.Id)
                        {
                            treasureKeys.Push(baseTreasureKey);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = treasureKeys.Select(i => new ItemMinViewModel
                    {
                        Id = (long)i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = "Treasure Key",
                        Level = 1,
                    }),
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetMaterials(Hero hero)
        {
            if (this.Context.MaterialsInventories.ToList().Any(mi => mi.InventoryId == hero.InventoryId))
            {
                var inventory = await this.Context.MaterialsInventories.Where(mi => mi.InventoryId == hero.InventoryId).ToListAsync();

                var materials = new Stack<Material>();

                if (inventory.Count > 0)
                {
                    foreach (var baseMaterial in this.Context.Materials)
                    {
                        foreach (var item in inventory)
                        {
                            if (item.MaterialId == baseMaterial.Id)
                            {
                                materials.Push(baseMaterial);
                            }
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = materials.Select(i => new ItemMinViewModel
                    {
                        Id = (long)i.Id,
                        Name = i.Name,
                        ImagePath = i.ImagePath,
                        Slot = "Material",
                    }),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
