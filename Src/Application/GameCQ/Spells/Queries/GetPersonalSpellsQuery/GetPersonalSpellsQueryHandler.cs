namespace Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalSpellsQueryHandler : IRequestHandler<GetPersonalSpellsQuery, SpellListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetPersonalSpellsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SpellListViewModel> Handle(GetPersonalSpellsQuery request, CancellationToken cancellationToken)
        {
            return new SpellListViewModel
            {
                Spells = await this.context.Spells.Where(s => s.ClassType == request.ClassType).ProjectTo<SpellFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
