namespace Application.GameCQ.Battles.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using MediatR;

    public class BattleOptionsCommandHandler : IRequestHandler<BattleOptionsCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly BattleHandler battleHandler;

        public BattleOptionsCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.battleHandler = new BattleHandler();
        }

        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.Player.Id);

            if (request.YourTurn && request.Enemy.CurrentHP > 0)
            {
                if (request.Command == "Attack")
                {
                    this.battleHandler.AttackOption.Attack(hero, request.Enemy);
                }

                if (request.Command == "Defend")
                {
                    this.battleHandler.DefendOption.Defend(hero);
                }

                if (request.Command == "SpellCast")
                {
                    this.battleHandler.SpellCastOption.SpellCast(hero, request.Enemy, request.SpellName, this.context);
                }

                if (request.Command == "Escape")
                {
                    this.battleHandler.EscapeOption.Escape(request.Player);
                    await this.context.SaveChangesAsync(cancellationToken);
                    return @"\Escape";
                }

                request.YourTurn = this.battleHandler.TurnCheck.Check(hero, request.Enemy, this.battleHandler, request.YourTurn, this.context);

                if (!request.YourTurn)
                {
                   request.YourTurn = this.battleHandler.TurnCheck.Check(hero, request.Enemy, this.battleHandler, request.YourTurn, this.context);
                }

                await this.context.SaveChangesAsync(cancellationToken);

                return @"\Command";
            }
            else
            {
                request.Enemy.CurrentHP = 0;
                await this.battleHandler.EndOption.End(hero, request.Enemy, request.ZoneName, this.context);
                this.context.Heroes.Update(hero);
                await this.context.SaveChangesAsync(cancellationToken);
                return @"\End";
            }
        }
    }
}
