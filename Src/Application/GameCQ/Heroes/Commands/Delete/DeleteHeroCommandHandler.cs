namespace Application.GameCQ.Heroes.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteHeroCommandHandler : BaseHandler, IRequestHandler<DeleteHeroCommand, string>
    {
        public DeleteHeroCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            var inventory = await this.Context.Inventories.FindAsync(hero.Id);

            var equipment = await this.Context.Equipments.FindAsync(hero.Id);

            var energyChanges = this.Context.EnergyChanges.Where(ec => ec.HeroId == hero.Id);

            this.Context.Inventories.Remove(inventory);

            this.Context.Equipments.Remove(equipment);

            this.Context.EnergyChanges.RemoveRange(energyChanges);

            this.Context.Heroes.Remove(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.HeroCommandRedirect;
        }
    }
}
