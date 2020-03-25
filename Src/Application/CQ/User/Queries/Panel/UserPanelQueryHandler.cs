namespace Application.CQ.User.Queries.Panel
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class UserPanelQueryHandler : IRequestHandler<UserPanelQuery, UserPanelViewModel>
    {
        private readonly UserManager<AppUser> userManager;

        public UserPanelQueryHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserPanelViewModel> Handle(UserPanelQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new UserPanelViewModel
            {
                UserName = user.UserName,
                Stars = user.Stars,
                Status = user.Status,
                MasteryPoints = user.MasteryPoints,
                Warnings = user.Warnings,
                UserTopics = user.UserTopics.Count,
                Feedbacks = user.Feedbacks.Count,
                ForumPoints = user.ForumPoints,
                Friends = user.Friends.Count,
                Units = user.Units.Count,
            };
        }
    }
}
