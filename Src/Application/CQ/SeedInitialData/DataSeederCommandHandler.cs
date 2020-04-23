namespace Application.SeedInitialData
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;

    public class DataSeederCommandHandler : BaseHandler, IRequestHandler<DataSeederCommand>
    {
        public DataSeederCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(DataSeederCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(this.Context);

            await seeder.SeedAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
