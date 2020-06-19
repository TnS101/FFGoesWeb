namespace Application.GameCQ.LootKeys.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class LootLootKeyCommandHandler : BaseHandler, IRequestHandler<LootLootKeyCommand>
    {
        public LootLootKeyCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(LootLootKeyCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            this.Context.TreasureKeysInventories.Add(new LootKeyInventory
            {
                InventoryId = hero.InventoryId,
                LootKeyId = await this.FindKeyId(),
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<int> FindKeyId()
        {
            var rng = new Random();
            int generationNumber = rng.Next(0, 10);

            string rarity = string.Empty;

            if (generationNumber >= 0 && generationNumber < 5)
            {
                rarity = "Bronze";
            }
            else if (generationNumber >= 5 && generationNumber < 8)
            {
                rarity = "Silver";
            }
            else
            {
                rarity = "Gold";
            }

            var treasureKey = await this.Context.LootKeys.FirstOrDefaultAsync(tk => tk.Rarity == rarity);

            return treasureKey.Id;
        }
    }
}
