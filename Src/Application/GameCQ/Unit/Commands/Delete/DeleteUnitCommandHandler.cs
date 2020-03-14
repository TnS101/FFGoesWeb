namespace Application.GameCQ.Unit.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand>
    {
        private readonly IFFDbContext context;
        public DeleteUnitCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            this.context.Units.Remove(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
