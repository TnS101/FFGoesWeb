namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
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

            var result = new ItemListViewModel { HeroClass = fightingClass.Type, HeroLevel = hero.Level };

            if (request.Slot == "Weapon")
            {
                result.Inventory = await this.Context.WeaponsInventories
                .Where(wi => wi.InventoryId == hero.Id)
                .Select(r => new ItemMinViewModel
                {
                    Id = r.WeaponId,
                    Name = r.Weapon.Name,
                    ImagePath = r.Weapon.ImagePath,
                    Slot = r.Weapon.Slot,
                    Level = r.Weapon.Level,
                    ClassType = r.Weapon.ClassType,
                    SellPrice = r.Weapon.SellPrice,
                    Count = r.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Armor")
            {
                result.Inventory = await this.Context.ArmorsInventories.Where(ai => ai.InventoryId == hero.Id).Select(ai => new ItemMinViewModel
                {
                    Id = ai.ArmorId,
                    Name = ai.Armor.Name,
                    ImagePath = ai.Armor.ImagePath,
                    Slot = ai.Armor.Slot,
                    Level = ai.Armor.Level,
                    ClassType = ai.Armor.ClassType,
                    SellPrice = ai.Armor.SellPrice,
                    Count = ai.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Trinket")
            {
                result.Inventory = await this.Context.TrinketsInventories.Where(ti => ti.InventoryId == hero.Id).Select(ti => new ItemMinViewModel
                {
                    Id = ti.TrinketId,
                    Name = ti.Trinket.Name,
                    ImagePath = ti.Trinket.ImagePath,
                    Slot = ti.Trinket.Slot,
                    Level = ti.Trinket.Level,
                    ClassType = "Any",
                    SellPrice = ti.Trinket.SellPrice,
                    Count = ti.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Relic")
            {
                result.Inventory = await this.Context.RelicsInventories.Where(ri => ri.InventoryId == hero.Id).Select(ri => new ItemMinViewModel
                {
                    Id = ri.RelicId,
                    Name = ri.Relic.Name,
                    ImagePath = ri.Relic.ImagePath,
                    Slot = ri.Relic.Slot,
                    Level = ri.Relic.Level,
                    ClassType = "Any",
                    SellPrice = ri.Relic.SellPrice,
                    Count = ri.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Loot Box")
            {
                result.Inventory = await this.Context.LootBoxesInventories.Where(ti => ti.InventoryId == hero.Id).Select(li => new ItemMinViewModel
                {
                    Id = li.LootBoxId,
                    Name = li.LootBox.Name,
                    ImagePath = li.LootBox.ImagePath,
                    Slot = li.LootBox.Slot,
                    Count = li.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Loot Key")
            {
                result.Inventory = await this.Context.LootKeysInventories.Where(ti => ti.InventoryId == hero.Id).Select(li => new ItemMinViewModel
                {
                    Id = li.LootKeyId,
                    Name = li.LootKey.Name,
                    ImagePath = li.LootKey.ImagePath,
                    Slot = li.LootKey.Slot,
                    Count = li.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Consumeable")
            {
                result.Inventory = await this.Context.ConsumeablesInventories.Where(ci => ci.InventoryId == hero.Id).Select(ci => new ItemMinViewModel
                {
                    Id = ci.ConsumeableId,
                    Name = ci.Consumeable.Name,
                    ImagePath = ci.Consumeable.ImagePath,
                    Slot = ci.Consumeable.Slot,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Card")
            {
                result.Inventory = await this.Context.CardsInventories.Where(ci => ci.InventoryId == hero.Id).Select(ci => new ItemMinViewModel
                {
                    Id = ci.CardId,
                    Name = ci.Card.Name,
                    ImagePath = ci.Card.ImagePath,
                    Slot = ci.Card.Slot,
                    SellPrice = ci.Card.SellPrice,
                    ClassType = ci.Card.ClassType,
                    Count = ci.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Tool")
            {
                result.Inventory = await this.Context.ToolsInventories.Where(ti => ti.InventoryId == hero.Id).Select(ti => new ItemMinViewModel
                {
                    Id = ti.ToolId,
                    Name = ti.Tool.Name,
                    ImagePath = ti.Tool.Name,
                    Slot = ti.Tool.Name,
                    SellPrice = ti.Tool.SellPrice,
                    Count = ti.Count,
                }).ToArrayAsync();
            }
            else if (request.Slot == "Toy")
            {
                result.Inventory = await this.Context.ToyInventories.Where(ti => ti.InventoryId == hero.Id).Select(ti => new ItemMinViewModel
                {
                    Id = ti.ToyId,
                    Name = ti.Toy.Name,
                    ImagePath = ti.Toy.ImagePath,
                    Slot = ti.Toy.Slot,
                    SellPrice = ti.Toy.SellPrice,
                    Count = ti.Count,
                }).ToArrayAsync();
            }
            else
            {
                result.Inventory = await this.Context.MaterialsInventories.Where(mi => mi.InventoryId == hero.Id).Select(mi => new ItemMinViewModel
                {
                    Id = mi.MaterialId,
                    Name = mi.Material.Name,
                    ImagePath = mi.Material.ImagePath,
                    Slot = mi.Material.Slot,
                    SellPrice = mi.Material.SellPrice,
                    Count = mi.Count,
                }).ToArrayAsync();
            }

            return result;
        }
    }
}
