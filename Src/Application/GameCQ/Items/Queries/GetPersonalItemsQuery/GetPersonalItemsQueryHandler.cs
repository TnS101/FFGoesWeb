﻿namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalItemsQueryHandler : IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetPersonalItemsQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<ItemListViewModel> Handle(GetPersonalItemsQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.HeroId);

            if (request.Slot == "Weapon")
            {
                return this.GetWeapons(hero);
            }
            else if (request.Slot == "Armor")
            {
                return this.GetArmors(hero);
            }
            else if (request.Slot == "Trinket")
            {
                return this.GetTrinkets(hero);
            }
            else if (request.Slot == "Treasure")
            {
                return this.GetTreasures(hero);
            }
            else if (request.Slot == "Treasure Key")
            {
                return this.GetTreasureKeys(hero);
            }
            else
            {
                return this.GetMaterials(hero);
            }
        }

        private ItemListViewModel GetWeapons(Hero hero)
        {
            var inventory = this.context.WeaponsInventories.Where(wi => wi.InventoryId == hero.InventoryId);

            var weapons = new List<Weapon>();

            foreach (var baseWeapon in this.context.Weapons)
            {
                foreach (var item in inventory)
                {
                    if (item.WeaponId == baseWeapon.Id)
                    {
                        weapons.Add(baseWeapon);
                    }
                }
            }

            return new ItemListViewModel
            {
                Items = weapons.Select(i => new ItemMinViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    ImageURL = i.ImageURL,
                }),
            };
        }

        private ItemListViewModel GetArmors(Hero hero)
        {
            var inventory = this.context.ArmorsInventories.Where(ai => ai.InventoryId == hero.InventoryId);

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
                    ImageURL = i.ImageURL,
                }),
            };
        }

        private ItemListViewModel GetTrinkets(Hero hero)
        {
            var inventory = this.context.TrinketsInventories.Where(ti => ti.InventoryId == hero.InventoryId);

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
                    ImageURL = i.ImageURL,
                }),
            };
        }

        private ItemListViewModel GetTreasures(Hero hero)
        {
            var inventory = this.context.TreasuresInventories.Where(ti => ti.InventoryId == hero.InventoryId);

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
                    Id = i.Id,
                    Name = i.Name,
                    ImageURL = i.ImageURL,
                }),
            };
        }

        private ItemListViewModel GetTreasureKeys(Hero hero)
        {
            var inventory = this.context.TreasureKeysInventories.Where(ti => ti.InventoryId == hero.InventoryId);

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
                    Id = i.Id,
                    Name = i.Name,
                    ImageURL = i.ImageURL,
                }),
            };
        }

        private ItemListViewModel GetMaterials(Hero hero)
        {
            var inventory = this.context.MaterialsInventories.Where(mi => mi.InventoryId == hero.InventoryId);

            var materials = new List<Material>();

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

            return new ItemListViewModel
            {
                Items = materials.Select(i => new ItemMinViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    ImageURL = i.ImageURL,
                }),
            };
        }
    }
}
