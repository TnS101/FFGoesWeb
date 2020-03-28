namespace Application.GameCQ.Unit.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteUnitCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.UnitId);

            this.context.Inventories.Remove(hero.Inventory);

            this.context.Equipments.Remove(hero.Equipment);

            this.context.Heroes.Remove(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
