namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, UnitListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public GetUnitListQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<UnitListViewModel> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new UnitListViewModel
            {
                Units = await this.context.Heroes.Where(u => u.UserId == user.Id).ProjectTo<UnitMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
