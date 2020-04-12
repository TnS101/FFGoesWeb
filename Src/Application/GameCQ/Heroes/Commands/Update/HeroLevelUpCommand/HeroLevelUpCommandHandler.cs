namespace Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
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
                hero.AttackPower += 2 * hero.Level;
                hero.CurrentAttackPower = hero.AttackPower;
            }
            else if (request.StatPick == "Health")
            {
                hero.MaxHP += 9 * hero.Level;
                hero.CurrentHP = hero.MaxHP;
            }
            else if (request.StatPick == "Mana")
            {
                hero.MaxMana += 9.3 * hero.Level;
                hero.CurrentMana = hero.MaxMana;
            }
            else if (request.StatPick == "Magic Power")
            {
                hero.MagicPower += 2.15 * hero.Level;
                hero.CurrentMagicPower = hero.MagicPower;
            }

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
