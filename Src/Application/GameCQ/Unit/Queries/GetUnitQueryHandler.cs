﻿namespace Application.GameCQ.Unit.Queries
{
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUnitQueryHandler : IRequestHandler<GetUnitQuery, UnitViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetUnitQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UnitViewModel> Handle(GetUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            return this.mapper.Map<UnitViewModel>(unit);
        }
    }
}
