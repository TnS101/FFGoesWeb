namespace Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;

    public class HeroLevelUpCommandHandler : BaseHandler, IRequestHandler<HeroLevelUpCommand>
    {
        public HeroLevelUpCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(HeroLevelUpCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            if (request.StatPick == "Attack")
            {
                hero.AttackPower += 2 * hero.Level;
                hero.CurrentAttackPower = hero.AttackPower;
            }
            else if (request.StatPick == "Health")
            {
                hero.MaxHP += 8 * hero.Level;
                hero.CurrentHP = hero.MaxHP;
            }
            else if (request.StatPick == "Mana")
            {
                hero.MaxMana += 9.3 * hero.Level;
                hero.CurrentMana = hero.MaxMana;
            }
            else if (request.StatPick == "Magic Power")
            {
                hero.MagicPower += 2.1 * hero.Level;
                hero.CurrentMagicPower = hero.MagicPower;
            }

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
