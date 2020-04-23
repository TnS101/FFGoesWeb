namespace Application.GameCQ.TreasureKeys.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class LootTreasureKeyCommandHandler : UserHandler, IRequestHandler<LootTreasureKeyCommand>
    {
        public LootTreasureKeyCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<Unit> Handle(LootTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            this.Context.TreasureKeysInventories.Add(new TreasureKeyInventory
            {
                InventoryId = hero.InventoryId,
                TreasureKeyId = await this.FindKeyId(),
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

            var treasureKey = await this.Context.TreasureKeys.FirstOrDefaultAsync(tk => tk.Rarity == rarity);

            return treasureKey.Id;
        }
    }
}
