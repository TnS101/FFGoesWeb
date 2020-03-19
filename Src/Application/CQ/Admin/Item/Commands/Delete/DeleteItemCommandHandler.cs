namespace Application.CQ.Admin.Item.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IFFDbContext context;

        public DeleteItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = this.context.Items.FindAsync(request.ItemId);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
