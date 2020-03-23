﻿namespace Application.CQ.Admin.TreasureKey.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;

    public class CreateTreasureKeyCommandHandler : IRequestHandler<CreateTreasureKeyCommand, string>
    {
        private readonly IFFDbContext context;

        public CreateTreasureKeyCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(CreateTreasureKeyCommand request, CancellationToken cancellationToken)
        {
            this.context.Items.Add(new Domain.Entities.Game.TreasureKey
            {
                Rarity = request.Rarity,
                ImageURL = request.ImageURL,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Treasures";
        }
    }
}
