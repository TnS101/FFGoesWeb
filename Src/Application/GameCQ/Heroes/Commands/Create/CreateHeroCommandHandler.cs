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
    using Microsoft.EntityFrameworkCore;

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

            var heroes = await this.context.Heroes.Where(h => h.UserId == user.Id).ToListAsync();

            if (heroes.Count() == user.AllowedHeroes)
            {
                return GConst.HeroCreationErrorRedirect;
            }
            else if (heroes.Count > 0)
            {
                foreach (var unit in heroes)
                {
                    unit.IsSelected = false;
                }

                this.context.Heroes.UpdateRange(heroes);
            }

            var hero = new Hero
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id,
                ImagePath = string.Empty,
                IsSelected = true,
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
