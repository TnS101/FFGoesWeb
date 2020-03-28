namespace Application.CQ.Admin.Item.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
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
                var weapon = await this.context.Weapons.FindAsync(request.ItemId);
                this.context.Weapons.Remove(weapon);
            }

            if (request.Slot == "Armor")
            {
                var armor = await this.context.Armors.FindAsync(request.ItemId);
                this.context.Armors.Remove(armor);
            }

            if (request.Slot == "Trinket")
            {
                var trinket = await this.context.Trinkets.FindAsync(request.ItemId);
                this.context.Trinkets.Remove(trinket);
            }

            if (request.Slot == "Material")
            {
                var material = await this.context.Materials.FindAsync(request.ItemId);
                this.context.Materials.Remove(material);
            }

            if (request.Slot == "Treasure")
            {
                var treasure = await this.context.Treasures.FindAsync(request.ItemId);
                this.context.Treasures.Remove(treasure);
            }

            if (request.Slot == "TreasureKey")
            {
                var treasureKey = await this.context.TreasureKeys.FindAsync(request.ItemId);
                this.context.TreasureKeys.Remove(treasureKey);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirect,request.Slot);
        }
    }
}
