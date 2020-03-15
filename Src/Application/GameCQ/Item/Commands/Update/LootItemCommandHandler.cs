using Application.GameCQ.Unit.Queries;
using AutoMapper;
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
        private readonly IMapper mapper;

        public LootItemCommandHandler(IFFDbContext context, ItemGenerator itemGenerator, IMapper mapper)
        {
            this.context = context;
            this.itemGenerator = itemGenerator;
            this.mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var unit = await this.context.Units.FindAsync(request.UnitId);

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.itemGenerator.Generate(this.mapper.Map<UnitFullViewModel>(unit)));

            await this.context.SaveChangesAsync(cancellationToken);

            return MediatR.Unit.Value;
        }
    }
}
