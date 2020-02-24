using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers;
using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GameCQ.Item.Commands.Update
{
    public class LootItemCommandHandler : IRequestHandler<LootItemCommand>
    {
        private readonly IFFDbContext context;
        private readonly ValidatorHandler validatorHandler;
        private readonly FightingClassStatCheck fightingClassStatCheck;

        public LootItemCommandHandler(IFFDbContext context, ValidatorHandler validatorHandler, FightingClassStatCheck fightingClassStatCheck)
        {
            this.context = context;
            this.validatorHandler = validatorHandler;
            this.fightingClassStatCheck = fightingClassStatCheck;
        }

        public async Task<Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var unit = await this.context.Units.FindAsync(request.UnitId);

            var stats = new List<int>();
            int fightingClassStatNumber = rng.Next(unit.Level, unit.Level + 5);
            int regularStatNumber = 0;
            int slotNumber = rng.Next(0, 10);
            string fightingClassType = "";
            string weaponName = "";

            for (int i = 0; i < 8; i++)
            {
                regularStatNumber = rng.Next(unit.Level, unit.Level + 2);
                stats.Add(regularStatNumber);
            }

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.validatorHandler.SlotCheck.Check(fightingClassStatNumber, slotNumber, stats, fightingClassStatNumber, fightingClassType, weaponName, validatorHandler));

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
