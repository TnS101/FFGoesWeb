namespace Application.GameCQ.Item.Commands.Delete
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DiscardItemCommandHandler : IRequestHandler<DiscardItemCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public DiscardItemCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var itemToRemove = unit.Inventory.Items.FirstOrDefault(i => i.Id == request.ItemId);

            unit.Inventory.Items.Remove(itemToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
