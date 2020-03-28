namespace Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFightingClassesQueryHandler : IRequestHandler<GetAllFightingClassesQuery, FightingClassListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllFightingClassesQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FightingClassListViewModel> Handle(GetAllFightingClassesQuery request, CancellationToken cancellationToken)
        {
            return new FightingClassListViewModel
            {
                FightingClasses = await this.context.FightingClasses.ProjectTo<FightingClassMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
