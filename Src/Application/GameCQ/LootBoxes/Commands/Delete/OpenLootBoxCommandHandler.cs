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
                    var materials = await this.Context.Materials.Where(m => m.Type != "Junk" && !m.IsCraftable).ToListAsync();

                    for (int i = 0; i < 3; i++)
                    {
                        var materialId = rng.Next(1, materials.Count() + 1);

                        if (materials[materialId] != null)
                        {
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
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                }
                else if (lootBox.Type == "Tool")
                {
                    var tools = await this.Context.Tools.Where(t => !t.IsCraftable).ToListAsync();

                    int toolId;
                    while (true)
                    {
                        toolId = rng.Next(1, tools.Count + 1);

                        if (tools[toolId] != null)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

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
                    var consumeables = await this.Context.Tools.Where(t => !t.IsCraftable).ToListAsync();

                    for (int i = 0; i < 3; i++)
                    {
                        var consumeableId = rng.Next(1, consumeables.Count + 1);

                        if (consumeables[consumeableId] != null)
                        {
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
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                }
                else if (lootBox.Type == "Junk")
                {
                    var junk = await this.Context.Materials.Where(m => m.Type == "Junk").ToListAsync();
                }
                else if (lootBox.Type == "Toy")
                {
                    var toys = await this.Context.Toys.Where(t => !t.IsCraftable).ToListAsync();

                    int toyId;

                    while (true)
                    {
                        toyId = rng.Next(1, toys.Count + 1);

                        if (toys[toyId] != null)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

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
                    var keys = await this.Context.LootKeys.ToListAsync();

                    int keyId;

                    while (true)
                    {
                        keyId = rng.Next(1, keys.Count + 1);

                        if (keys[keyId] != null)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

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
                }

                this.Context.LootBoxesInventories.Remove(lootBoxToRemove);
            }
            else
            {
                var lootKeyToRemove = await this.Context.LootKeysInventories.FirstOrDefaultAsync(t => t.LootKeyId == lootKey.Id);

                if (lootKeyToRemove != null)
                {
                    hero.CoinAmount += rng.Next(hero.Level * 4, hero.Level * 8);

                    this.Context.LootKeysInventories.Remove(lootKeyToRemove);

                    this.Context.LootBoxesInventories.Remove(lootBoxToRemove);
                }
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
