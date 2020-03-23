namespace Application.GameCQ.Treasure.Commands.Delete
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Domain.Entities.Game;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class OpenTreasureCommandHandler : IRequestHandler<OpenTreasureCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public OpenTreasureCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(OpenTreasureCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasureKey = unit.Inventory.Items.Select(k => new TreasureKey 
            {
                Rarity = request.Rarity
            }).FirstOrDefault();

            var treasure = unit.Inventory.Items.Select(t => new Treasure
            {
                Rarity = request.Rarity
            }).FirstOrDefault();

            unit.Inventory.Items.Remove(treasureKey);

            unit.Inventory.Items.Remove(treasure);

            unit.GoldAmount += treasure.Reward;

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
