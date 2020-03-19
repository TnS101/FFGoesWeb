namespace Application.CQ.Admin.Treasure.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTreasureCommandHandler : IRequestHandler<DeleteTreasureCommand>
    {
        private readonly IFFDbContext context;
        public DeleteTreasureCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DeleteTreasureCommand request, CancellationToken cancellationToken)
        {
            var treasure = await this.context.Items.FindAsync(request.Id);

            this.context.Items.Remove(treasure);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
