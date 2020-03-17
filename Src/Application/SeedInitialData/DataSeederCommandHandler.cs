﻿namespace Application.SeedInitialData
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DataSeederCommandHandler : IRequestHandler<DataSeederCommand>
    {
        private readonly IFFDbContext context;
        public DataSeederCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DataSeederCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(this.context);

            await seeder.SeedAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
