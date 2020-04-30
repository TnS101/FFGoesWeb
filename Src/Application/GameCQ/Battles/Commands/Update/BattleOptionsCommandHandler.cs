namespace Application.GameCQ.Battles.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Application.GameContent.Utilities.LevelUtility;
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
            var hero = await this.Context.Heroes.FindAsync(request.Player.Id);

            int initialGold = hero.GoldAmount;

            if (request.Enemy.CurrentHP <= -0.00000000000001)
            {
                var endOption = new EndOption();

                request.Enemy.CurrentHP = 0;

                await endOption.End(hero, request.Enemy, request.ZoneName, this.Context, cancellationToken);

                if (hero.XP >= hero.XPCap)
                {
                    var level = new Level();

                    await level.Up(hero, this.Context);

                    this.Context.Heroes.Update(hero);
                    await this.Context.SaveChangesAsync(cancellationToken);

                    return GConst.HeroCommandRedirect;
                }

                this.Context.Heroes.Update(hero);
                await this.Context.SaveChangesAsync(cancellationToken);

                return GConst.End;
            }

            if (hero.CurrentHP <= 0)
            {
                hero.CurrentHP = 0;

                this.Context.Heroes.Update(hero);

                await this.Context.SaveChangesAsync(cancellationToken);

                hero.GoldAmount = initialGold;

                return GConst.UnitKilled;
            }
            else if (request.Enemy.CurrentHP > 0 && request.YourTurn)
            {
                if (request.Command == "Attack")
                {
                    var attackOption = new AttackOption();

                    attackOption.Attack(hero, request.Enemy);
                }

                if (request.Command == "Defend")
                {
                    var defendOption = new DefendOption();

                    defendOption.Defend(hero);
                }

                if (request.Command == "Spell")
                {
                    var spellCastOption = new SpellCastOption();

                    await spellCastOption.SpellCast(hero, request.Enemy, request.SpellName, this.Context);
                }

                if (request.Command == "Escape")
                {
                    var escapeOption = new EscapeOption();

                    escapeOption.Escape(request.Player);
                    await this.Context.SaveChangesAsync(cancellationToken);

                    hero.GoldAmount = initialGold;

                    return GConst.EscapeCommand;
                }

                request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context);

                if (!request.YourTurn)
                {
                    request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context);
                }

                await this.Context.SaveChangesAsync(cancellationToken);

                return GConst.BattleCommand;
            }

            if (request.Enemy.CurrentHP == 0)
            {
                return GConst.End;
            }
            else
            {
                return GConst.BattleCommand;
            }
        }
    }
}
