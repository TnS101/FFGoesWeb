namespace Application.GameCQ.Treasures.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class OpenTreasureCommandHandler : IRequestHandler<OpenTreasureCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenTreasureCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenTreasureCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasureKey = unit.Inventory.TreasureKeys.Select(k => new TreasureKey
            {
                Rarity = request.Rarity,
            }).FirstOrDefault();

            var treasure = unit.Inventory.Treasures.Select(t => new Treasure
            {
                Rarity = request.Rarity,
            }).FirstOrDefault();

            unit.Inventory.TreasureKeys.Remove(treasureKey);

            unit.Inventory.Treasures.Remove(treasure);

            unit.GoldAmount += treasure.Reward;

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
