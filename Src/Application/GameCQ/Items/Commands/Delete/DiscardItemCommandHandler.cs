﻿namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class DiscardItemCommandHandler : IRequestHandler<DiscardItemCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public DiscardItemCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var itemToRemove = unit.Inventory.Items.FirstOrDefault(i => i.Id == request.ItemId);

            unit.Inventory.Items.Remove(itemToRemove);

            this.context.Inventories.Update(unit.Inventory);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
