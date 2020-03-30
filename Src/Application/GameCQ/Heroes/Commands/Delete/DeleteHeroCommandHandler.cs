﻿namespace Application.GameCQ.Heroes.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteHeroCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.HeroId);

            var inventory = await this.context.Inventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id);

            var equipment = await this.context.Equipments.FirstOrDefaultAsync(e => e.HeroId == hero.Id);

            this.context.Inventories.Remove(inventory);

            this.context.Equipments.Remove(equipment);

            this.context.Heroes.Remove(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
