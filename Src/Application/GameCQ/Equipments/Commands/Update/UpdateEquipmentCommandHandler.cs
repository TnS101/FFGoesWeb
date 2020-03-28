namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Entities.Common;
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

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var item = hero.Inventory.Items.FirstOrDefault(i => i.Id == request.ItemId);

            string result = string.Empty;

            if (request.Command == "Equip")
            {
                result = this.equipmentHandler.EquipOption.Equip(hero, item, this.statSum);

                await this.context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                result = this.equipmentHandler.UnEquipOption.UnEquip(hero, item, this.statSum);

                await this.context.SaveChangesAsync(cancellationToken);
            }

            this.context.Equipments.Update(hero.Equipment);

            return string.Format("/Equipment", result);
        }
    }
}
