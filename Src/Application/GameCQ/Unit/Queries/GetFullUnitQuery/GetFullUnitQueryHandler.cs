namespace Application.GameCQ.Unit.Queries
{
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFullUnitQueryHandler : IRequestHandler<GetFullUnitQuery, UnitFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        public GetFullUnitQueryHandler(IFFDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<UnitFullViewModel> Handle(GetFullUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = await this.context.Units.Where(u => u.UserId == user.Id && u.IsSelected).MinAsync(cancellationToken);

            return this.mapper.Map<UnitFullViewModel>(unit);
        }
    }
}
