namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.UnitCreation;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly FightingClassCheck fightingClassCheck;
        private readonly RaceCheck raceCheck;

        public CreateHeroCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.fightingClassCheck = new FightingClassCheck();
            this.raceCheck = new RaceCheck();
        }

        public async Task<string> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (this.context.Heroes.Where(h => h.UserId == user.Id).Count() == user.AllowedHeroes)
            {
                return GConst.UnitCreationErrorRedirect;
            }

            if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length < 5 || request.Name.Length > 20)
            {
                return GConst.UnitCreationErrorRedirect;
            }

            var hero = new Hero
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id,
                ImagePath = string.Empty,
            };

            hero.Inventory = new Inventory(hero.Id);

            hero.Equipment = new Equipment(hero.Id);

            hero.EquipmentId = hero.Equipment.Id;

            hero.InventoryId = hero.Inventory.Id;

            await this.fightingClassCheck.Check(hero, request.ClassType, this.context);

            this.raceCheck.Check(hero, request.Race);

            await this.context.Heroes.AddAsync(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.HeroCommandRedirect;
        }
    }
}
