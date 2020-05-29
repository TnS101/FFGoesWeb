namespace Application.CQ.Admin.GameContent.Spells.Queries.GetAllSpellsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllSpellsQueryHandler : MapperHandler, IRequestHandler<GetAllSpellsQuery, SpellListViewModel>
    {
        public GetAllSpellsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<SpellListViewModel> Handle(GetAllSpellsQuery request, CancellationToken cancellationToken)
        {
            if (request.FightingClassId == 0)
            {
                return new SpellListViewModel
                {
                    Spells = await this.Context.Spells.ProjectTo<SpellMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }

            return new SpellListViewModel
            {
                Spells = await this.Context.Spells.Where(s => s.FightingClassId == request.FightingClassId).ProjectTo<SpellMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
