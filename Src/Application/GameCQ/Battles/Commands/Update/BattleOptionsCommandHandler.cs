namespace Application.GameCQ.Battles.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Application.GameContent.Utilities.Validators.Battle;
    using AutoMapper;
    using global::Common;
    using MediatR;

    public class BattleOptionsCommandHandler : MapperHandler, IRequestHandler<BattleOptionsCommand, string>
    {
        private readonly TurnCheck turnCheck;

        public BattleOptionsCommandHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            this.turnCheck = new TurnCheck();
        }

        public async Task<string> Handle(BattleOptionsCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            if (request.Enemy.CurrentHP > 0 && request.YourTurn)
            {
                if (hero.StunDuration == 0)
                {
                    if (request.Command == "Attack" && hero.BlindDuration == 0)
                    {
                        if (hero.ConfusionDuration == 0)
                        {
                            new AttackOption().Attack(hero, request.Enemy);
                        }
                        else
                        {
                            if (new Random().Next(2) == 1)
                            {
                                new AttackOption().Attack(hero, request.Enemy);
                            }
                        }
                    }

                    if (request.Command == "Defend" && hero.ProvokeDuration == 0)
                    {
                        new DefendOption().Defend(hero);
                    }

                    if (request.Command == "Spell" && hero.SilenceDuration == 0 && request.SpellId != 0)
                    {
                        await new SpellCastOption().SpellCast(hero, request.Enemy, request.SpellId, this.Context, this.Mapper);
                    }
                }

                request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context, this.Mapper);

                if (!request.YourTurn)
                {
                    request.YourTurn = await this.turnCheck.Check(hero, request.Enemy, request.YourTurn, this.Context, this.Mapper);
                }

                await this.Context.SaveChangesAsync(cancellationToken);
            }

            request.TurnCount++;

            return GConst.BattleCommand;
        }
    }
}
