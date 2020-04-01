namespace Application.GameCQ.Items.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class LootItemCommandHandler : IRequestHandler<LootItemCommand>
    {
        private readonly IFFDbContext context;
        private readonly ItemGenerator itemGenerator;
        private readonly UserManager<AppUser> userManager;

        public LootItemCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.itemGenerator = new ItemGenerator();
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var user = await this.userManager.GetUserAsync(request.User);

            var monster = await this.context.Monsters.FindAsync(request.MonsterId);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            await this.itemGenerator.Generate(hero, this.context, monster, request.ZoneName);

            this.context.Inventories.Update(hero.Inventory);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
