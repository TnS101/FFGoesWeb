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
            var hero = await this.context.Heroes.FindAsync(request.HeroId);

            this.level.Up(hero);

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
