using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GameCQ.Battle.Commands.Update
{
    public class BattleOptionsCommandHandler : IRequestHandler<BattleOptionsCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly BattleHandler battleHandler;
        public BattleOptionsCommandHandler(IFFDbContext context, BattleHandler battleHandler)
        {
            this.context = context;
            this.battleHandler = battleHandler;
        }
        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            if (request.YourTurn)
            {
                if (request.Command == "attack")
                {
                    battleHandler.AttackOption.Attack(request.Player, request.Enemy);
                    return "/Action";
                }
                if (request.Command == "defend")
                {
                    battleHandler.DefendOption.Defend(request.Player);
                    return "/Action";
                }
                if (request.Command == "spellCast")
                {
                    return "/SpellOption";
                }
                if (request.Command == "escape")
                {
                    return "/Escape";
                }
                battleHandler.TurnCheck.Check(request.Player, request.Enemy, battleHandler, context, request.YourTurn);
                request.YourTurn = false;
            }
            if (!request.YourTurn)
            {
                battleHandler.TurnCheck.Check(request.Player, request.Enemy, battleHandler, context, request.YourTurn);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Action";
        }
    }
}
