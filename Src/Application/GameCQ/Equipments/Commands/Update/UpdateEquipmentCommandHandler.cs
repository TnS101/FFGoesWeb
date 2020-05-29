namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.EquipmentOptions;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using MediatR;

    public class UpdateEquipmentCommandHandler : BaseHandler, IRequestHandler<UpdateEquipmentCommand, string>
    {
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.statSum = new StatSum();
        }

        public async Task<string> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            string result;
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

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<IEquipableItem> EquipableItem(UpdateEquipmentCommand request)
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
