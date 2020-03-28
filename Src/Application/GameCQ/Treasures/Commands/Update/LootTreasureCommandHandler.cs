namespace Application.GameCQ.Treasures.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class LootTreasureCommandHandler : IRequestHandler<LootTreasureCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public LootTreasureCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(LootTreasureCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            int treasureNumber = rng.Next(0, 10);

            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            string rarity = string.Empty;

            int reward = 0;

            if (treasureNumber >= 0 && treasureNumber < 5)
            {
                rarity = "Bronze";
                reward = 50;
            }
            else if (treasureNumber >= 5 && treasureNumber < 8)
            {
                rarity = "Silver";
                reward = 100;
            }
            else
            {
                rarity = "Gold";
                reward = 200;
            }

            hero.Inventory.Items.Add(new Domain.Entities.Game.Items.Treasure
            {
                Rarity = rarity,
                Reward = reward,
            });

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }
    }
}
