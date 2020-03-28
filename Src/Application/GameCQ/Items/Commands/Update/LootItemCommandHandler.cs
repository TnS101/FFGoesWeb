namespace Application.GameCQ.Item.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class LootItemCommandHandler : IRequestHandler<LootItemCommand>
    {
        private readonly IFFDbContext context;
        private readonly ItemGenerator itemGenerator;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public LootItemCommandHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.itemGenerator = new ItemGenerator();
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            hero.Inventory.Items.Add(this.itemGenerator.Generate(this.mapper.Map<UnitFullViewModel>(hero)));

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
