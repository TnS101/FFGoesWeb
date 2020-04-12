namespace Application.GameCQ.Battles.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Application.GameContent.Utilities.LevelUtility;
    using Application.GameContent.Utilities.Validators.Battle;
    using global::Common;
    using MediatR;

    public class BattleOptionsCommandHandler : IRequestHandler<BattleOptionsCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly TurnCheck turnCheck;

        public BattleOptionsCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.turnCheck = new TurnCheck();
        }

        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.Player.Id);

            int initialGold = hero.GoldAmount;

            if (request.Enemy.CurrentHP <= -0.00000000000001)
            {
                var endOption = new EndOption();

                request.Enemy.CurrentHP = 0;

                await endOption.End(hero, request.Enemy, request.ZoneName, this.context);

                if (hero.XP >= hero.XPCap)
                {
                    var level = new Level();

                    await level.Up(hero, this.context);

                    this.context.Heroes.Update(hero);
                    await this.context.SaveChangesAsync(cancellationToken);

                    return GConst.LevelUp;
                }

                this.context.Heroes.Update(hero);
                await this.context.SaveChangesAsync(cancellationToken);

                return GConst.End;
            }

            if (hero.CurrentHP <= 0)
            {
                hero.CurrentHP = 0;

                this.context.Heroes.Update(hero);

                await this.context.SaveChangesAsync(cancellationToken);

                hero.GoldAmount = initialGold;

                return GConst.UnitKilled;
            }
            else if (request.YourTurn && request.Enemy.CurrentHP > 0)
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

                if (request.Command == null)
                {
                    var spellCastOption = new SpellCastOption();

                    await spellCastOption.SpellCast(hero, request.Enemy, request.SpellName, this.context);
                }

                if (request.Command == "Escape")
                {
                    var escapeOption = new EscapeOption();

                    escapeOption.Escape(request.Player);
                    await this.context.SaveChangesAsync(cancellationToken);

                    hero.GoldAmount = initialGold;

                    return GConst.EscapeCommand;
                }

                request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.context);

                if (!request.YourTurn)
                {
                    request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.context);
                }

                await this.context.SaveChangesAsync(cancellationToken);

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
