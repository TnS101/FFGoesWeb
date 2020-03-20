namespace Application.GameCQ.TreasureKey.Commands.Update
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LootTreasureKeyCommandHandler : IRequestHandler<LootTreasureKeyCommand>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public LootTreasureKeyCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(LootTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            int generationNumber = rng.Next(0, 10);

            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            string rarity = ""; 

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

            this.context.TreasureKeys.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.context.TreasureKeys.FirstOrDefault(k => k.Rarity == rarity));

            return Unit.Value;
        }
    }
}
