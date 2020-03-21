namespace Application.CQ.Admin.TreasureKey.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTreasureKeyCommandHandler : IRequestHandler<DeleteTreasureKeyCommand,string>
    {
        private readonly IFFDbContext context;
        public DeleteTreasureKeyCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(DeleteTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            var key = await this.context.TreasureKeys.FindAsync(request.KeyId);

            this.context.TreasureKeys.Remove(key);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Treasures";
        }
    }
}
