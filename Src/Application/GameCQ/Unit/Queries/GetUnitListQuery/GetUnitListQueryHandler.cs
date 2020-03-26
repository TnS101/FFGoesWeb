namespace Application.GameCQ.Unit.Queries.GetUnitListQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, UnitListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetUnitListQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<UnitListViewModel> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id);

            var iconURL = string.Empty;

            if (unit != null)
            {
                var icon = this.context.Images.FirstOrDefault(i => i.Name == unit.ClassType);
                iconURL = icon.IconURL;
            }

            return new UnitListViewModel
            {
                Units = await this.context.Units.Where(u => u.UserId == user.Id).Select(u => new UnitMinViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    ClassType = u.ClassType,
                    MaxHP = u.MaxHP,
                    CurrentHP = u.CurrentHP,
                    Level = u.Level,
                    Energy = u.Energy,
                    IconURL = iconURL,
                    IsSelected = u.IsSelected,
                })
                .ToListAsync(),
            };
        }
    }
}
