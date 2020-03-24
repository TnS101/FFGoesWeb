﻿namespace Application.CQ.Admin.Item.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, string>
    {
        private readonly IFFDbContext context;

        public CreateItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            this.context.Items.Add(new Domain.Entities.Game.Item
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                AttackPower = request.AttackPower,
                ArmorValue = request.ArmorValue,
                Slot = request.Slot,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Items";
        }
    }
}