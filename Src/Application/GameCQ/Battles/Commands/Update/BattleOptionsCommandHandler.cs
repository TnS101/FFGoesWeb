namespace Application.GameCQ.Battles.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Application.GameContent.Utilities.Validators.Battle;
    using global::Common;
    using MediatR;

    public class BattleOptionsCommandHandler : BaseHandler, IRequestHandler<BattleOptionsCommand, string>
    {
        private readonly TurnCheck turnCheck;

        public BattleOptionsCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.turnCheck = new TurnCheck();
        }

        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            hero.CurrentHealthRegen += hero.Hunger * hero.Level / 10;
            hero.CurrentManaRegen += hero.Thirst * hero.Level / 7;

            if (request.Enemy.CurrentHP > 0 && request.YourTurn)
            {
                if (request.Command == "Attack")
                {
                    new AttackOption().Attack(hero, request.Enemy);
                }

                if (request.Command == "Defend")
                {
                    new DefendOption().Defend(hero);
                }

                if (request.Command == "Spell")
                {
                    var spellCastOption = new SpellCastOption();

                    await spellCastOption.SpellCast(hero, request.Enemy, request.SpellId, this.Context);
                }

                request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context);

                if (!request.YourTurn)
                {
                    request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context);
                }

                await this.Context.SaveChangesAsync(cancellationToken);
            }

            return GConst.BattleCommand;
        }
    }
}
