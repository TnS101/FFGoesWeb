namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.EquipmentOptions;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.statSum = new StatSum();
        }

        public async Task<string> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            string result = string.Empty;

            if (request.Command == "Equip")
            {
                var equipOption = new EquipOption();

                result = await equipOption.Equip(hero, await this.BaseItem(request), this.statSum, this.context);
            }
            else
            {
                var unEquipOption = new UnEquipOption();

                result = await unEquipOption.UnEquip(hero, await this.BaseItem(request), this.statSum, this.context);
            }

            this.context.Equipments.Update(hero.Equipment);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format("/Equipment", result);
        }

        private async Task<IBaseItem> BaseItem(UpdateEquipmentCommand request)
        {
            if (request.Slot == "Weapon")
            {
                return await this.context.Weapons.FindAsync(request.ItemId);
            }
            else if (request.Slot == "Trinket")
            {
                return await this.context.Trinkets.FindAsync(request.ItemId);
            }
            else
            {
                return await this.context.Armors.FindAsync(request.ItemId);
            }
        }
    }
}
