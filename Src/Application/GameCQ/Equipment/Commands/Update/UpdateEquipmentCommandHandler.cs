using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GameCQ.Equipment.Commands.Update
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IFFDbContext context;
        private readonly EquipmentHandler equipmentHandler;
        private readonly StatSum statSum;

        public UpdateEquipmentCommandHandler(IFFDbContext context, EquipmentHandler equipmentHandler, StatSum statSum)
        {
            this.context = context;
            this.equipmentHandler = equipmentHandler;
            this.statSum = statSum;
        }
        public async Task<MediatR.Unit> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            var item = unit.Inventory.Items.FirstOrDefault(i => i.Id == request.ItemId);

            if (request.Command == "equip")
            {
                this.equipmentHandler.EquipOption.Equip(unit, item, statSum);

                await this.context.SaveChangesAsync(cancellationToken);

                return MediatR.Unit.Value;
            }
            else 
            {
                this.equipmentHandler.UnEquipOption.UnEquip(unit, item, statSum);

                await this.context.SaveChangesAsync(cancellationToken);

                return MediatR.Unit.Value;
            }
        }
    }
}
