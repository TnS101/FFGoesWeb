namespace Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentMonsterQueryHandler : MapperHandler, IRequestHandler<GetCurrentMonsterQuery, MonsterFullViewModel>
    {
        public GetCurrentMonsterQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<MonsterFullViewModel> Handle(GetCurrentMonsterQuery request, CancellationToken cancellationToken)
        {
            var monster = await this.Context.Monsters.FindAsync(request.MonsterId);

            return this.Mapper.Map<MonsterFullViewModel>(monster);
        }
    }
}
