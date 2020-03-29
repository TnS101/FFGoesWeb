﻿namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, string>
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

        public async Task<string> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = new Hero
            {
                Name = request.Name,
                ClassType = request.ClassType,
                Race = request.Race,
                UserId = user.Id,
                ImageURL = string.Empty,
                IsSelected = false,
            };

            hero.Inventory = new Inventory(hero.Id);

            hero.Equipment = new Equipment(hero.Id);

            await this.validatorHandler.FightingClassCheck.Check(hero, request.ClassType, this.context);

            this.validatorHandler.RaceCheck.Check(hero, request.Race);

            await this.context.Heroes.AddAsync(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}