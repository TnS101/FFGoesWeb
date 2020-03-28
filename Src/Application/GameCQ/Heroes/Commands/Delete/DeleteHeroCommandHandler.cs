namespace Application.GameCQ.Heroes.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

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

            this.context.Inventories.Remove(hero.Inventory);

            this.context.Equipments.Remove(hero.Equipment);

            this.context.Heroes.Remove(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
