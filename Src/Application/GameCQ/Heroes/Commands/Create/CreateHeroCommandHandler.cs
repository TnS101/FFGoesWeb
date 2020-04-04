namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, string[]>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;
        private readonly UserManager<AppUser> userManager;

        public CreateHeroCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.validatorHandler = new ValidatorHandler();
            this.userManager = userManager;
        }

        public async Task<string[]> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (this.context.Heroes.Where(h => h.UserId == user.Id).Count() == user.AllowedHeroes)
            {
                return new string[] { GConst.UnitCreationErrorRedirect, string.Format(GConst.AllowedUnitsError, user.AllowedHeroes) };
            }

            if (request.Name.Length < 5 || request.Name.Length > 20)
            {
                return new string[] { GConst.UnitCreationErrorRedirect, string.Format(GConst.LengthException, 5, 20) };
            }

            var hero = new Hero
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id,
                ImageURL = string.Empty,
            };

            hero.Inventory = new Inventory(hero.Id);

            hero.Equipment = new Equipment(hero.Id);

            hero.EquipmentId = hero.Equipment.Id;

            hero.InventoryId = hero.Inventory.Id;

            await this.validatorHandler.FightingClassCheck.Check(hero, request.ClassType, this.context);

            this.validatorHandler.RaceCheck.Check(hero, request.Race);

            await this.context.Heroes.AddAsync(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return new string[] { GConst.UnitCommandRedirect };
        }
    }
}
