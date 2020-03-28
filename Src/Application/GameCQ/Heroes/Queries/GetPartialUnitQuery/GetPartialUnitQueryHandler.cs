namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class GetPartialUnitQueryHandler : IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetPartialUnitQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UnitPartialViewModel> Handle(GetPartialUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            return this.mapper.Map<UnitPartialViewModel>(unit);
        }
    }
}
