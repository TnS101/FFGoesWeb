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

        public UnitLevelUpCommandHandler(IFFDbContext context, Level level)
        {
            this.context = context;
            this.level = level;
        }

        public async Task<MediatR.Unit> Handle(UnitLevelUpCommand request, CancellationToken cancellationToken)
        {
            this.level.Up(await this.context.Units.FindAsync(request.UnitId));

            return MediatR.Unit.Value;
        }
    }
}
