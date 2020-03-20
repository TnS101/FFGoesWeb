using Application.GameCQ.Unit.Queries;
using AutoMapper;
using Domain.Entities.Common;
using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;

        public LootItemCommandHandler(IFFDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.itemGenerator = new ItemGenerator();
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<MediatR.Unit> Handle(LootItemCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(this.itemGenerator.Generate(this.mapper.Map<UnitFullViewModel>(unit)));

            await this.context.SaveChangesAsync(cancellationToken);

            return MediatR.Unit.Value;
        }
    }
}
