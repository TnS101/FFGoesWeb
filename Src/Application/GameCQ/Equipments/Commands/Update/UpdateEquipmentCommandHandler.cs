namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.EquipmentOptions;
    using Application.GameContent.Utilities.Stats;
    using Domain.Contracts.Items;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateEquipmentCommandHandler : BaseHandler, IRequestHandler<UpdateEquipmentCommand, long>
    {
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.statSum = new StatSum();
        }

        public async Task<long> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            long result;
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
            return request.Slot switch
            {
                "Weapon" => await this.Context.Weapons.FindAsync(request.ItemId),
                "Trinket" => await this.Context.Trinkets.FindAsync(request.ItemId),
                "Relic" => await this.Context.Relics.FindAsync(request.ItemId),
                _ => await this.Context.Armors.FindAsync(request.ItemId),
            };
        }
    }
}
