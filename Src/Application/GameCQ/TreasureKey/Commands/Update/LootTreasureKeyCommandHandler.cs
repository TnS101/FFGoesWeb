namespace Application.GameCQ.TreasureKey.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LootTreasureKeyCommandHandler : IRequestHandler<LootTreasureKeyCommand>
    {
        private readonly IFFDbContext context;
        public LootTreasureKeyCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(LootTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            int generationNumber = rng.Next(0, 10);

            var unit = await this.context.Units.FindAsync(request.UnitId);

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
