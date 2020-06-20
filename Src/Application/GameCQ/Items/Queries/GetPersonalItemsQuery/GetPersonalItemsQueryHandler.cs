namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
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
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            var fightingClass = await this.Context.FightingClasses.FindAsync(hero.FightingClassId);

            if (request.Slot == "Weapon")
            {
                return await this.GetWeapons(hero.InventoryId, fightingClass.Type, hero.Level);
            }
            else if (request.Slot == "Armor")
            {
                return await this.GetArmors(hero.InventoryId, fightingClass.Type, hero.Level);
            }
            else if (request.Slot == "Trinket")
            {
                return await this.GetTrinkets(hero.InventoryId, hero.Level);
            }
            else if (request.Slot == "Relic")
            {
                return await this.GetRelics(hero.InventoryId, hero.Level);
            }
            else if (request.Slot == "Loot Box")
            {
                return await this.GetLootBoxes(hero.InventoryId);
            }
            else if (request.Slot == "Loot Key")
            {
                return await this.GetLootKeys(hero);
            }
            else
            {
                return await this.GetMaterials(hero);
            }
        }

        private async Task<ItemListViewModel> GetRelics(long inventoryId, int heroLevel)
        {
            var inventory = await this.Context.RelicsInventories.Where(ri => ri.InventoryId == inventoryId).Select(ri => new ItemMinViewModel
            {
                Id = ri.Relic.Id,
                Name = ri.Relic.Name,
                ImagePath = ri.Relic.ImagePath,
                Slot = ri.Relic.Slot,
                Level = ri.Relic.Level,
                ClassType = ri.Relic.ClassType,
                SellPrice = ri.Relic.SellPrice,
                Count = ri.Count,
            }).ToListAsync();

            return new ItemListViewModel { HeroClass = "Any", HeroLevel = heroLevel, Items = inventory };
        }

        private async Task<ItemListViewModel> GetWeapons(long inventoryId, string className, int heroLevel)
        {
            var inventory = await this.Context.WeaponsInventories
                .Where(wi => wi.InventoryId == inventoryId)
                .Select(r => new ItemMinViewModel
                {
                    Id = r.Weapon.Id,
                    Name = r.Weapon.Name,
                    ImagePath = r.Weapon.ImagePath,
                    Slot = r.Weapon.Slot,
                    Level = r.Weapon.Level,
                    ClassType = r.Weapon.ClassType,
                    SellPrice = r.Weapon.SellPrice,
                    Count = r.Count,
                }).ToListAsync();

            return new ItemListViewModel() { HeroClass = className, HeroLevel = heroLevel, Items = inventory };
        }

        private async Task<ItemListViewModel> GetArmors(long inventoryId, string className, int heroLevel)
        {
            var inventory = await this.Context.ArmorsInventories.Where(ai => ai.InventoryId == inventoryId).Select(ai => new ItemMinViewModel
            {
                Id = ai.Armor.Id,
                Name = ai.Armor.Name,
                ImagePath = ai.Armor.ImagePath,
                Slot = ai.Armor.Slot,
                Level = ai.Armor.Level,
                ClassType = ai.Armor.ClassType,
                SellPrice = ai.Armor.SellPrice,
                Count = ai.Count,
            }).ToListAsync();

            return new ItemListViewModel() { HeroClass = className, HeroLevel = heroLevel, Items = inventory };
        }

        private async Task<ItemListViewModel> GetTrinkets(long inventoryId, int heroLevel)
        {
            var inventory = await this.Context.TrinketsInventories.Where(ti => ti.InventoryId == inventoryId).Select(ti => new ItemMinViewModel
            {
                Id = ti.Trinket.Id,
                Name = ti.Trinket.Name,
                ImagePath = ti.Trinket.ImagePath,
                Slot = ti.Trinket.Slot,
                Level = ti.Trinket.Level,
                ClassType = ti.Trinket.ClassType,
                SellPrice = ti.Trinket.SellPrice,
                Count = ti.Count,
            }).ToListAsync();

            return new ItemListViewModel() { HeroClass = "Any", HeroLevel = heroLevel, Items = inventory };
        }

        private async Task<ItemListViewModel> GetLootBoxes(long inventoryId)
        {
            var inventory = await this.Context.LootBoxesInventories.Where(ti => ti.InventoryId == inventoryId).Select(li => new ItemMinViewModel
            {
                Id = li.LootBox.Id,
                Name = li.LootBox.Name,
                ImagePath = li.LootBox.ImagePath,
                Slot = li.LootBox.Slot,
                Count = li.Count,
            }).ToListAsync();

            return new ItemListViewModel() { Items = inventory };
        }

        private async Task<ItemListViewModel> GetLootKeys(Hero hero)
        {
            var inventory = await this.Context.LootKeysInventories.Where(ti => ti.InventoryId == hero.InventoryId).Select(li => new ItemMinViewModel
            {
                Id = li.LootKey.Id,
                Name = li.LootKey.Name,
                ImagePath = li.LootKey.ImagePath,
                Slot = li.LootKey.Slot,
                Count = li.Count,
            }).ToListAsync();

            return new ItemListViewModel() { Items = inventory };
        }

        private async Task<ItemListViewModel> GetMaterials(Hero hero)
        {
            var inventory = await this.Context.MaterialsInventories.Where(mi => mi.InventoryId == hero.InventoryId).Select(mi => new ItemMinViewModel
            {
                Id = mi.Material.Id,
                Name = mi.Material.Name,
                ImagePath = mi.Material.ImagePath,
                Slot = mi.Material.Slot,
                SellPrice = mi.Material.SellPrice,
                Count = mi.Count,
            }).ToListAsync();

            return new ItemListViewModel() { Items = inventory };
        }
    }
}
