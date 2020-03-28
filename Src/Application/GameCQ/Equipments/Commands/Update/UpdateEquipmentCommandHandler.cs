namespace Application.GameCQ.Equipment.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly EquipmentHandler equipmentHandler;
        private readonly UserManager<AppUser> userManager;
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.equipmentHandler = new EquipmentHandler();
            this.userManager = userManager;
            this.statSum = new StatSum();
        }

        public async Task<string> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var item = unit.Inventory.Items.FirstOrDefault(i => i.Id == request.ItemId);

            if (request.Command == "equip")
            {
                this.equipmentHandler.EquipOption.Equip(unit, item, this.statSum);

                await this.context.SaveChangesAsync(cancellationToken);

                return "/Equipment";
            }
            else
            {
                this.equipmentHandler.UnEquipOption.UnEquip(unit, item, this.statSum);

                await this.context.SaveChangesAsync(cancellationToken);

                return "/Equipment";
            }
        }
    }
}
