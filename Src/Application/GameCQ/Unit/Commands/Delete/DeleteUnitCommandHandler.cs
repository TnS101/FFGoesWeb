namespace Application.GameCQ.Unit.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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
            var unit = await this.context.Units.FindAsync(request.UnitId);

            this.context.Units.Remove(unit);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Profile/PersonalUnits";
        }
    }
}
