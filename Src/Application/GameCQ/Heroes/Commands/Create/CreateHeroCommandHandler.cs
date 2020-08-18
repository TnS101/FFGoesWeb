namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.UnitCreation;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateHeroCommandHandler : BaseHandler, IRequestHandler<CreateHeroCommand, string>
    {
        private readonly FightingClassCheck fightingClassCheck;

        public CreateHeroCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.fightingClassCheck = new FightingClassCheck();
        }

        public async Task<string> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var heroes = this.Context.Heroes.Where(h => h.UserId == user.Id);

            if (heroes.Count() == user.AllowedHeroes)
            {
                return GConst.HeroCreationErrorRedirect;
            }
            else if (heroes.Count() > 0)
            {
                foreach (var unit in heroes)
                {
                    unit.IsSelected = false;
                }

                this.Context.Heroes.UpdateRange(heroes);
            }

            var hero = new Hero
            {
                Name = request.Name,
                Race = request.Race,
                UserId = user.Id,
                ImagePath = string.Empty,
                IsSelected = true,
            };

            new RaceCheck().Check(hero, request.Race);

            await this.fightingClassCheck.Check(hero, request.ClassId, this.Context);

            this.Context.Heroes.Add(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.HeroCommandRedirect;
        }
    }
}
