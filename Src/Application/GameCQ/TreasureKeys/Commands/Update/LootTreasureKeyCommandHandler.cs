namespace Application.GameCQ.TreasureKeys.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class LootTreasureKeyCommandHandler : IRequestHandler<LootTreasureKeyCommand>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public LootTreasureKeyCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(LootTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            await this.context.TreasureKeysInventories.AddAsync(new TreasureKeyInventory
            {
                InventoryId = hero.InventoryId,
                TreasureKeyId = await this.FindKeyId(),
            });

            await this.context.SaveChangesAsync(cancellationToken);

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

            var treasureKey = await this.context.TreasureKeys.FirstOrDefaultAsync(tk => tk.Rarity == rarity);

            return treasureKey.Id;
        }
    }
}
