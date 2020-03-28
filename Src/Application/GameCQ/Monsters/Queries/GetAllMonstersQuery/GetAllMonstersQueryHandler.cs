namespace Application.GameCQ.Monsters.Queries.GetAllMonstersQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllMonstersQueryHandler : IRequestHandler<GetAllMonstersQuery, MonsterListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllMonstersQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MonsterListViewModel> Handle(GetAllMonstersQuery request, CancellationToken cancellationToken)
        {
            return new MonsterListViewModel
            {
                Monsters = await this.context.Monsters.ProjectTo<MonsterMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
