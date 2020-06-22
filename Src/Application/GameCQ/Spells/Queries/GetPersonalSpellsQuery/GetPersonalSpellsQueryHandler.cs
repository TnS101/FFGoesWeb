namespace Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalSpellsQueryHandler : MapperHandler, IRequestHandler<GetPersonalSpellsQuery, SpellListViewModel>
    {
        public GetPersonalSpellsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<SpellListViewModel> Handle(GetPersonalSpellsQuery request, CancellationToken cancellationToken)
        {
            return new SpellListViewModel
            {
                Spells = await this.Context.Spells.Where(s => s.FightingClassId == request.FightingClassId).ProjectTo<SpellMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
