namespace Application.GameCQ.Treasure.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LootTreasureCommandHandler : IRequestHandler<LootTreasureCommand>
    {
        private readonly IFFDbContext context;
        public LootTreasureCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(LootTreasureCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            int treasureNumber = rng.Next(0, 10);

            var unit = await this.context.Units.FindAsync(request.UnitId);

            string rarity = "";

            if (treasureNumber >= 0 && treasureNumber < 5)
            {
                rarity = "Bronze";
            }
            else if (treasureNumber >= 5 && treasureNumber < 8)
            {
                rarity = "Silver";
            }
            else
            {
                rarity = "Gold";
            }

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.context.Treasures.FirstOrDefault(t => t.Rarity == rarity));

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
