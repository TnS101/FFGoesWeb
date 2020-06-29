namespace Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFightingClassesQueryHandler : MapperHandler, IRequestHandler<GetAllFightingClassesQuery, FightingClassListViewModel>
    {
        public GetAllFightingClassesQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FightingClassListViewModel> Handle(GetAllFightingClassesQuery request, CancellationToken cancellationToken)
        {
            return new FightingClassListViewModel
            {
                FightingClasses = await this.Context.FightingClasses.AsNoTracking().ProjectTo<FightingClassMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
