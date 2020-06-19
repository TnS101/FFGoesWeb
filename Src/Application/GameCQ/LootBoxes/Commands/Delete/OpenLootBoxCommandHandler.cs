namespace Application.GameCQ.LootBoxes.Commands.Delete
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items;
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
                hero.CoinAmount += rng.Next(hero.Level * 2, hero.Level * 3);

                if (lootBox.Type == "Material")
                {
                    var materials = this.Context.Materials.Where(m => m.Type != "Junk");
                }
                else if (lootBox.Type == "Tool")
                {
                    var tools = this.Context.Tools;
                }
                else if (lootBox.Type == "Consumeable")
                {
                    var consumeables = this.Context.Tools;
                }
                else if (lootBox.Type == "Junk")
                {
                    var junk = this.Context.Materials.Where(m => m.Type == "Junk");
                }
                else if (lootBox.Type == "Toy")
                {
                    var toys = this.Context.Toys;
                }
                else if (lootBox.Type == "Key")
                {

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
