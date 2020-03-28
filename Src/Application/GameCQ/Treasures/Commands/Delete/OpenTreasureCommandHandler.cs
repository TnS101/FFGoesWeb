namespace Application.GameCQ.Treasures.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
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

            var treasureKey = unit.Inventory.Items.Select(k => new Domain.Entities.Game.Items.TreasureKey
            {
                Rarity = request.Rarity,
            }).FirstOrDefault();

            var treasure = unit.Inventory.Items.Select(t => new Domain.Entities.Game.Items.Treasure
            {
                Rarity = request.Rarity,
            }).FirstOrDefault();

            unit.Inventory.Items.Remove(treasureKey);

            unit.Inventory.Items.Remove(treasure);

            unit.GoldAmount += treasure.Reward;

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
