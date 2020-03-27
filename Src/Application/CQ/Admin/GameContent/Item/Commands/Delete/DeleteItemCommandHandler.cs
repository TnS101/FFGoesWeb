namespace Application.CQ.Admin.Item.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {

            }
            if (request.Slot == "Armor")
            {

            }
            if (request.Slot == "Trinket")
            {

            }
            if (request.Slot == "Material")
            {

            }


            var item = this.context.We.FindAsync(request.ItemId);

            this.context.Items.Remove(item.Result);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Items";
        }
    }
}
