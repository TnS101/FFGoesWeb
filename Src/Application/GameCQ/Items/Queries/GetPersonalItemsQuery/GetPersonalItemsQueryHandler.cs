namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalItemsQueryHandler : IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetPersonalItemsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<ItemListViewModel> Handle(GetPersonalItemsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = await this.context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            if (request.Slot == "Weapon")
            {
                return await this.GetWeapons(hero);
            }
            else if (request.Slot == "Armor")
            {
                return await this.GetArmors(hero);
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

        private async Task<ItemListViewModel> GetWeapons(Hero hero)
        {
            if (this.context.WeaponsInventories.Any(wi => wi.InventoryId == hero.InventoryId))
            {
                var inventory = await this.context.WeaponsInventories.Where(wi => wi.InventoryId == hero.InventoryId).ToListAsync();

                var weapons = new List<Weapon>();

                if (inventory.Count() > 0)
                {
                    foreach (var baseWeapon in this.context.Weapons.ToList())
                    {
                        foreach (var item in inventory)
                        {
                            if (item.WeaponId == baseWeapon.Id)
                            {
                                weapons.Add(baseWeapon);
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
                    }),
                    HeroClass = hero.ClassType,
                    HeroLevel = hero.Level,
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<ItemListViewModel> GetArmors(Hero hero)
        {
            if (await this.context.ArmorsInventories.AnyAsync(ai => ai.InventoryId == hero.InventoryId))
            {
                var inventory = await this.context.ArmorsInventories.Where(ai => ai.InventoryId == hero.InventoryId).ToListAsync();

                var armors = new List<Armor>();

                foreach (var baseArmor in this.context.Armors)
                {
                    foreach (var item in inventory)
                    {
                        if (item.ArmorId == baseArmor.Id)
                        {
                            armors.Add(baseArmor);
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
                    }),
                    HeroClass = hero.ClassType,
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
            if (await this.context.TrinketsInventories.AnyAsync(ti => ti.InventoryId == hero.Id))
            {
                var inventory = await this.context.TrinketsInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var trinkets = new List<Trinket>();

                foreach (var baseTrinket in this.context.Trinkets)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TrinketId == baseTrinket.Id)
                        {
                            trinkets.Add(baseTrinket);
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
                    }),
                    HeroClass = hero.ClassType,
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
            if (await this.context.TreasuresInventories.AnyAsync(ti => ti.InventoryId == hero.InventoryId))
            {
                var inventory = await this.context.TreasuresInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var treasures = new List<Treasure>();

                foreach (var baseTreasure in this.context.Treasures)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureId == baseTreasure.Id)
                        {
                            treasures.Add(baseTreasure);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = treasures.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id.ToString(),
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
            if (this.context.TreasureKeysInventories.Any(ti => ti.InventoryId == hero.InventoryId))
            {
                var inventory = await this.context.TreasureKeysInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToListAsync();

                var treasureKeys = new List<TreasureKey>();

                foreach (var baseTreasureKey in this.context.TreasureKeys)
                {
                    foreach (var item in inventory)
                    {
                        if (item.TreasureKeyId == baseTreasureKey.Id)
                        {
                            treasureKeys.Add(baseTreasureKey);
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = treasureKeys.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id.ToString(),
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
            if (this.context.MaterialsInventories.ToList().Any(mi => mi.InventoryId == hero.InventoryId))
            {
                var inventory = await this.context.MaterialsInventories.Where(mi => mi.InventoryId == hero.InventoryId).ToListAsync();

                var materials = new List<Material>();

                if (inventory.Count > 0)
                {
                    foreach (var baseMaterial in this.context.Materials)
                    {
                        foreach (var item in inventory)
                        {
                            if (item.MaterialId == baseMaterial.Id)
                            {
                                materials.Add(baseMaterial);
                            }
                        }
                    }
                }

                return new ItemListViewModel
                {
                    Items = materials.Select(i => new ItemMinViewModel
                    {
                        Id = i.Id.ToString(),
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
