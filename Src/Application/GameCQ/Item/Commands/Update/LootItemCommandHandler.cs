using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GameCQ.Item.Commands.Update
{
    public class LootItemCommandHandler : IRequestHandler<LootItemCommand>
    {
        private readonly IFFDbContext context;
        private readonly ItemGenerator itemGenerator;

        public LootItemCommandHandler(IFFDbContext context, ItemGenerator itemGenerator)
        {
            this.context = context;
            this.itemGenerator = itemGenerator;
        }

        public async Task<Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var unit = await this.context.Units.FindAsync(request.UnitId);

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.itemGenerator.Generate(unit));

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
