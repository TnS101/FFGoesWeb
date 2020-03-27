namespace Application.GameCQ.Unit.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;
        private readonly UserManager<AppUser> userManager;

        public CreateUnitCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.validatorHandler = new ValidatorHandler();
            this.userManager = userManager;
        }

        public async Task<string> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = new Domain.Entities.Game.Unit
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id,
                Type = "Player",
                ImageURL = this.context.Images.FirstOrDefault(i => i.Name == request.ClassType).Path,
                IsSelected = false,
            };

            unit.Inventory = new Domain.Entities.Game.Inventory(unit.Id);

            unit.Equipment = new Domain.Entities.Game.Equipment(unit.Id);

            this.validatorHandler.FightingClassCheck.Check(unit, request.ClassType);

            this.validatorHandler.RaceCheck.Check(unit, request.Race);

            await this.context.Units.AddAsync(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
