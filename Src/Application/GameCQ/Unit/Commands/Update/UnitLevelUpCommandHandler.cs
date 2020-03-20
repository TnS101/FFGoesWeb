namespace Application.GameCQ.Unit.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.LevelUtility;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitLevelUpCommandHandler : IRequestHandler<UnitLevelUpCommand>
    {
        private readonly IFFDbContext context;
        private readonly Level level;

        public UnitLevelUpCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.level = new Level();
        }

        public async Task<Unit> Handle(UnitLevelUpCommand request, CancellationToken cancellationToken)
        {
            this.level.Up(await this.context.Units.FindAsync(request.UnitId));

            return Unit.Value;
        }
    }
}
