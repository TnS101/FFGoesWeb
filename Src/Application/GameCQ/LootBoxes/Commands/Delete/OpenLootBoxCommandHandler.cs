namespace Application.GameCQ.LootBoxes.Commands.Delete
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OpenLootBoxCommandHandler : BaseHandler, IRequestHandler<OpenLootBoxCommand, string>
    {
        public OpenLootBoxCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(OpenLootBoxCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var lootBox = await this.Context.LootBoxes.FindAsync(request.Id);

            var lootKey = await this.Context.LootKeys.FirstOrDefaultAsync(t => t.Type == lootBox.Type);

            return await this.OpenChest(hero, lootKey, lootBox, cancellationToken);
        }

        private async Task<string> OpenChest(Hero hero, LootKey lootKey, LootBox lootBox, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var lootBoxToRemove = await this.Context.LootBoxesInventories.FirstOrDefaultAsync(t => t.LootBoxId == lootBox.Id);

            if (lootKey == null)
            {
                if (lootBox.Type == "Material")
                {
                    var materials = await this.Context.Materials.Where(m => m.Type != "Junk" && !m.IsCraftable).ToArrayAsync();

                    var materialId = materials[rng.Next(materials.Length)].Id;

                    var materialInventory = await this.Context.MaterialsInventories.FirstOrDefaultAsync(mi => mi.InventoryId == hero.InventoryId && mi.MaterialId == materialId);

                    if (materialInventory != null)
                    {
                        materialInventory.Count++;
                    }
                    else
                    {
                        this.Context.MaterialsInventories.Add(new MaterialInventory
                        {
                            MaterialId = materialId,
                            InventoryId = hero.InventoryId,
                        });
                    }
                }
                else if (lootBox.Type == "Tool")
                {
                    var tools = await this.Context.Tools.Where(t => !t.IsCraftable).ToArrayAsync();

                    var toolId = tools[rng.Next(tools.Length)].Id;

                    var toolInventory = await this.Context.ToolsInventories.FirstOrDefaultAsync(ti => ti.InventoryId == hero.InventoryId && ti.ToolId == toolId);

                    if (toolInventory != null)
                    {
                        toolInventory.Count++;
                    }
                    else
                    {
                        this.Context.ToolsInventories.Add(new ToolInventory
                        {
                            ToolId = toolId,
                            InventoryId = hero.InventoryId,
                        });
                    }
                }
                else if (lootBox.Type == "Consumeable")
                {
                    var consumeables = await this.Context.Tools.Where(t => !t.IsCraftable).ToArrayAsync();

                    var consumeableId = consumeables[rng.Next(consumeables.Length)].Id;

                    var consumeableInventory = await this.Context.ConsumeablesInventories.FirstOrDefaultAsync(ci => ci.InventoryId == hero.InventoryId && ci.ConsumeableId == consumeableId);

                    if (consumeableInventory != null)
                    {
                        consumeableInventory.Count++;
                    }
                    else
                    {
                        this.Context.ConsumeablesInventories.Add(new ConsumeableInventory
                        {
                            ConsumeableId = consumeableId,
                            InventoryId = hero.InventoryId,
                        });
                    }
                }
                else if (lootBox.Type == "Junk")
                {
                    var junks = await this.Context.Materials.Where(m => m.Type == "Junk").ToArrayAsync();

                    var junkId = junks[rng.Next(junks.Length)].Id;

                    var junkInventory = await this.Context.MaterialsInventories.FirstOrDefaultAsync(mi => mi.InventoryId == hero.InventoryId && mi.MaterialId == junkId);

                    if (junkInventory != null)
                    {
                        junkInventory.Count++;
                    }
                    else
                    {
                        this.Context.MaterialsInventories.Add(new MaterialInventory
                        {
                            MaterialId = junkId,
                            InventoryId = hero.InventoryId,
                        });
                    }
                }
                else if (lootBox.Type == "Toy")
                {
                    var toys = await this.Context.Toys.Where(t => !t.IsCraftable).ToArrayAsync();

                    var toyId = toys[rng.Next(toys.Length)].Id;

                    var toyInventory = await this.Context.ToyInventories.FirstOrDefaultAsync(ti => ti.InventoryId == hero.InventoryId && ti.ToyId == toyId);

                    if (toyInventory != null)
                    {
                        toyInventory.Count++;
                    }
                    else
                    {
                        this.Context.ToyInventories.Add(new ToyInventory
                        {
                            ToyId = toyId,
                            InventoryId = hero.InventoryId,
                        });
                    }
                }
                else if (lootBox.Type == "Key")
                {
                    var keys = await this.Context.LootKeys.ToArrayAsync();

                    var keyId = keys[rng.Next(keys.Length)].Id;

                    var keyInventory = await this.Context.LootKeysInventories.FirstOrDefaultAsync(ki => ki.InventoryId == hero.InventoryId && ki.LootKeyId == keyId);

                    if (keyInventory != null)
                    {
                        keyInventory.Count++;
                    }
                    else
                    {
                        this.Context.LootKeysInventories.Add(new LootKeyInventory
                        {
                            LootKeyId = keyId,
                            InventoryId = hero.InventoryId,
                        });
                    }

                    this.Context.LootBoxesInventories.Remove(lootBoxToRemove);
                }
                else
                {
                    var lootKeyToRemove = await this.Context.LootKeysInventories.FirstOrDefaultAsync(t => t.LootKeyId == lootKey.Id);

                    if (lootKeyToRemove != null)
                    {
                        hero.CoinAmount += rng.Next(hero.Level * lootBox.RewardAmplifier, hero.Level * lootBox.RewardAmplifier * 2);

                        this.Context.LootKeysInventories.Remove(lootKeyToRemove);

                        this.Context.LootBoxesInventories.Remove(lootBoxToRemove);
                    }
                }

                await this.Context.SaveChangesAsync(cancellationToken);
            }

            return "/Inventory";
        }
    }
}
