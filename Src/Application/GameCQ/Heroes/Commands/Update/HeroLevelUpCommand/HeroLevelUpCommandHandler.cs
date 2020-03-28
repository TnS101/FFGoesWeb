namespace Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.LevelUtility;
    using MediatR;

    public class HeroLevelUpCommandHandler : IRequestHandler<HeroLevelUpCommand>
    {
        private readonly IFFDbContext context;
        private readonly Level level;

        public HeroLevelUpCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.level = new Level();
        }

        public async Task<Unit> Handle(HeroLevelUpCommand request, CancellationToken cancellationToken)
        {
            this.level.Up(await this.context.Heroes.FindAsync(request.HeroId));

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
