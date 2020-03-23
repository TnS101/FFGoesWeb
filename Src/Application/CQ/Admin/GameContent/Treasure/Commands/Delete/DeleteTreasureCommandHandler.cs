namespace Application.CQ.Admin.Treasure.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;

    public class DeleteTreasureCommandHandler : IRequestHandler<DeleteTreasureCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteTreasureCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteTreasureCommand request, CancellationToken cancellationToken)
        {
            var treasure = await this.context.Items.FindAsync(request.Id);

            this.context.Items.Remove(treasure);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Treasures";
        }
    }
}
