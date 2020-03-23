namespace Application.CQ.Admin.Treasure.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTreasureCommandHandler : IRequestHandler<CreateTreasureCommand,string>
    {
        private readonly IFFDbContext context;
        public CreateTreasureCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(CreateTreasureCommand request, CancellationToken cancellationToken)
        {
            this.context.Treasures.Add(new Domain.Entities.Game.Treasure 
            {
                Rarity = request.Rarity,
                Reward = request.Reward,
                ImageURL = request.ImageURL
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Treasures";
        }
    }
}
