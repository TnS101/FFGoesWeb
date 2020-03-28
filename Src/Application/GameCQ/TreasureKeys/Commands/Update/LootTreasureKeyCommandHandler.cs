namespace Application.GameCQ.TreasureKeys.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

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
            var rng = new Random();
            int generationNumber = rng.Next(0, 10);

            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

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

            hero.Inventory.Items.Add(new Domain.Entities.Game.Items.TreasureKey
            {
                Rarity = rarity,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
