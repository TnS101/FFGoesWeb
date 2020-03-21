namespace Application.GameCQ.Battle.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Looting;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class BattleOptionsCommandHandler : IRequestHandler<BattleOptionsCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly BattleHandler battleHandler;
        private readonly Loot loot;
        public BattleOptionsCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.battleHandler = new BattleHandler();
            this.loot = new Loot();
        }
        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            if (request.YourTurn && request.Enemy.CurrentHP > 0)
            {
                if (request.Command == "attack")
                {
                    battleHandler.AttackOption.Attack(request.Player, request.Enemy);
                }
                if (request.Command == "defend")
                {
                    battleHandler.DefendOption.Defend(request.Player);
                }
                if (request.Command == "spellCast")
                {
                    battleHandler.SpellCastOption.PlayerSpellCast(request.Player, request.Enemy,request.SpellName,this.context);
                }
                if (request.Command == "escape")
                {
                    this.battleHandler.EscapeOption.Escape(request.Player);
                    await this.context.SaveChangesAsync(cancellationToken);
                    return @"\Escape";
                }

                battleHandler.TurnCheck.Check(request.Player, request.Enemy, battleHandler, request.YourTurn, this.context);

                if (!request.YourTurn)
                {
                    battleHandler.TurnCheck.Check(request.Player, request.Enemy, battleHandler, request.YourTurn, this.context);
                }
                await this.context.SaveChangesAsync(cancellationToken);

                return @"\Action";
            }
            else
            {
                request.Enemy.CurrentHP = 0;
                this.battleHandler.EndOption.End(request.Player, request.Enemy, loot);
                await this.context.SaveChangesAsync(cancellationToken);
                return @"\End";
            }
        }
    }
}
