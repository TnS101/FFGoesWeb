namespace Application.CQ.Admin.TreasureKey.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    class CreateTreasureKeyCommandHandler : IRequestHandler<CreateTreasureKeyCommand>
    {
        private readonly IFFDbContext context;
        public CreateTreasureKeyCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(CreateTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            this.context.Items.Add(new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.TreasureKey 
            {
                Rarity = request.Rarity,
                ImageURL = request.ImageURL
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
