namespace Application.GameCQ.Monsters.Queries.GetAllMonstersQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllMonstersQueryHandler : MapperHandler, IRequestHandler<GetAllMonstersQuery, MonsterListViewModel>
    {
        public GetAllMonstersQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<MonsterListViewModel> Handle(GetAllMonstersQuery request, CancellationToken cancellationToken)
        {
            return new MonsterListViewModel
            {
                Monsters = await this.Context.Monsters.ProjectTo<MonsterMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
