namespace Application.GameCQ.LootBoxes.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class LootLootBoxCommandHandler : BaseHandler, IRequestHandler<LootLootBoxCommand, string>
    {
        public LootLootBoxCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(LootLootBoxCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var lootBoxType = this.LootBoxType();

            var lootBox = await this.Context.LootBoxes.FirstOrDefaultAsync(r => r.Type == lootBoxType);

            hero.Inventory.LootBoxInventories.Add(new LootBoxInventory
            {
                InventoryId = hero.InventoryId,
                LootBoxId = lootBox.Id,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }

        private string LootBoxType()
        {
            var rng = new Random();

            int treasureNumber = rng.Next(0, 17);

            if (treasureNumber >= 0 && treasureNumber <= 4)
            {
                return "Bronze";
            }
            else if (treasureNumber >= 5 && treasureNumber <= 8)
            {
                return "Silver";
            }
            else if (treasureNumber >= 9 && treasureNumber <= 11)
            {
                return "Material";
            }
            else if (treasureNumber >= 12 && treasureNumber <= 14)
            {
                return "Consumeable";
            }
            else
            {
                return "Gold";
            }
        }
    }
}
