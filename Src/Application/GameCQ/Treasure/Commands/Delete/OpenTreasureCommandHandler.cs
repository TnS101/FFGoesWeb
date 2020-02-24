namespace Application.GameCQ.Treasure.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class OpenTreasureCommandHandler : IRequestHandler<OpenTreasureCommand>
    {
        private readonly IFFDbContext context;
        private readonly FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit unit;

        public OpenTreasureCommandHandler(IFFDbContext context, FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit unit)
        {
            this.context = context;
            this.unit = unit;
        }
        public async Task<MediatR.Unit> Handle(OpenTreasureCommand request, CancellationToken cancellationToken)
        {
            var treasureKey = this.unit.Inventory.Items.Select(k => new TreasureKey 
            {
                Rarity = request.Rarity
            }).FirstOrDefault();

            var treasure = this.unit.Inventory.Items.Select(t => new Treasure
            {
                Rarity = request.Rarity
            }).FirstOrDefault();

            this.unit.Inventory.Items.Remove(treasureKey);

            this.unit.Inventory.Items.Remove(treasure);

            this.unit.GoldAmount += treasure.Reward;

            await this.context.SaveChangesAsync(cancellationToken);

            return MediatR.Unit.Value;
        }
    }
}
