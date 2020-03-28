namespace Application.GameCQ.Unit.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class GetFullUnitQueryHandler : IRequestHandler<GetFullUnitQuery, UnitFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetFullUnitQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UnitFullViewModel> Handle(GetFullUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            return this.mapper.Map<UnitFullViewModel>(unit);
        }
    }
}
