namespace Application.GameCQ.Item.Commands.Create
{
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        

        public CreateItemCommandHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = this.mapper.Map<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Item>(request);

            this.context.Items.Add(item);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
