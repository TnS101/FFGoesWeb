namespace Application.GameCQ.Unit.Commands.Create
{
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;
        private readonly IMapper mapper;

        public CreateUnitCommandHandler(IFFDbContext context, ValidatorHandler validatorHandler, IMapper mapper)
        {
            this.context = context;
            this.validatorHandler = validatorHandler;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = this.mapper.Map<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit>(request);

            this.validatorHandler.FightingClassCheck.Check(this.mapper.Map<UnitFullViewModel>(unit),request.ClassType);

            this.validatorHandler.RaceCheck.Check(unit, request.Race);

            this.context.Units.Add(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
