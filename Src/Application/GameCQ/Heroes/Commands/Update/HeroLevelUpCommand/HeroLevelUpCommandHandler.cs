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

        public HeroLevelUpCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(HeroLevelUpCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.HeroId);

            if (request.StatPick == "Attack")
            {

            }
            else if (request.StatPick == "Health")
            {

            }
            else if (request.StatPick == "Mana")
            {

            }
            else if (request.StatPick == "Magic Power")
            {
                hero.
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
