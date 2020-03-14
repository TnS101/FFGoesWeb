﻿namespace Application.GameCQ.Unit.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;

        public CreateUnitCommandHandler(IFFDbContext context, ValidatorHandler validatorHandler)
        {
            this.context = context;
            this.validatorHandler = validatorHandler;
        }
        public async Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit
            {
                Name = request.Name,
                UserId = request.UserId,
                Type = "Player",
                Equipment = new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Equipment(),
                GoldAmount = 100,
                Level = 1,
                XPCap = 100
            };

            this.validatorHandler.FightingClassCheck.Check(unit,request.ClassType);

            this.validatorHandler.RaceCheck.Check(unit, request.Race);

            this.context.Units.Add(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
