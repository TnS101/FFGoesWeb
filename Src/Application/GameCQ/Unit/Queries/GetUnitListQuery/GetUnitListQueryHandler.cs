﻿namespace Application.GameCQ.Unit.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, UnitListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetUnitListQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UnitListViewModel> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new UnitListViewModel
            {
                Units = await this.context.Units.Where(u => u.UserId == user.Id).ProjectTo<UnitPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
