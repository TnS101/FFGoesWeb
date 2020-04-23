namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class GetPartialUnitQueryHandler : FullHandler, IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>
    {
        public GetPartialUnitQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public async Task<UnitPartialViewModel> Handle(GetPartialUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var unit = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            return this.Mapper.Map<UnitPartialViewModel>(unit);
        }
    }
}
