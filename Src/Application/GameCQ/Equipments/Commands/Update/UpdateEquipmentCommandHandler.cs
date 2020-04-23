namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.EquipmentOptions;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Contracts.Items;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class UpdateEquipmentCommandHandler : UserHandler, IRequestHandler<UpdateEquipmentCommand, string>
    {
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context,userManager)
        {
            this.statSum = new StatSum();
        }

        public async Task<string> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            string result = string.Empty;

            if (request.Command == "Equip")
            {
                var equipOption = new EquipOption();

                result = await equipOption.Equip(hero, await this.EquipableItem(request), this.statSum, this.Context);
            }
            else
            {
                var unEquipOption = new UnEquipOption();

                result = await unEquipOption.UnEquip(hero, await this.EquipableItem(request), this.statSum, this.Context);
            }

            this.Context.Equipments.Update(hero.Equipment);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format("/Equipment", result);
        }

        private async Task<IEquipableItem> EquipableItem(UpdateEquipmentCommand request)
        {
            if (request.Slot == "Weapon")
            {
                return await this.Context.Weapons.FindAsync(request.ItemId);
            }
            else if (request.Slot == "Trinket")
            {
                return await this.Context.Trinkets.FindAsync(request.ItemId);
            }
            else
            {
                return await this.Context.Armors.FindAsync(request.ItemId);
            }
        }
    }
}
