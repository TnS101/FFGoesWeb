namespace Application.GameCQ.Unit.Commands.Create
{
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateUnitCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.validatorHandler = new ValidatorHandler();
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit 
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id
            };

            this.validatorHandler.FightingClassCheck.Check(this.mapper.Map<UnitFullViewModel>(unit),request.ClassType);

            this.validatorHandler.RaceCheck.Check(unit, request.Race);

            this.context.Units.Add(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
