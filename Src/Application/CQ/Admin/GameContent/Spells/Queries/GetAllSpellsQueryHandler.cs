﻿namespace Application.CQ.Admin.GameContent.Spells.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllSpellsQueryHandler : IRequestHandler<GetAllSpellsQuery, SpellListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllSpellsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SpellListViewModel> Handle(GetAllSpellsQuery request, CancellationToken cancellationToken)
        {
            return new SpellListViewModel
            {
                Spells = await this.context.Spells.ProjectTo<SpellFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
