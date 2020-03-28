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
                var item = this.context.Weapons.FindAsync(request.ItemId).Result;
                this.context.Weapons.Remove(item);
            }

            if (request.Slot == "Armor")
            {
                var item = this.context.Armors.FindAsync(request.ItemId).Result;
                this.context.Armors.Remove(item);
            }

            if (request.Slot == "Trinket")
            {
                var item = this.context.Trinkets.FindAsync(request.ItemId).Result;
                this.context.Trinkets.Remove(item);
            }

            if (request.Slot == "Material")
            {
                var item = this.context.Materials.FindAsync(request.ItemId).Result;
                this.context.Materials.Remove(item);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Items";
        }
    }
}
