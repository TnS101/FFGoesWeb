namespace Application.CQ.User.Queries.Panel
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class UserPanelQueryHandler : IRequestHandler<UserPanelQuery, UserPanelViewModel>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFFDbContext context;

        public UserPanelQueryHandler(UserManager<AppUser> userManager, IFFDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<UserPanelViewModel> Handle(UserPanelQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var units = this.context.Units.Where(u => u.UserId == user.Id);

            this.SumForumPoints(user);

            user.MasteryPoints = units.Sum(u => u.Mastery);

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
                Units = units.Count(),
            };
        }

        private void SumForumPoints(AppUser user)
        {
            var topics = this.context.Topics.Where(t => t.UserId == user.Id && !t.IsRemoved);

            var comments = this.context.Comments.Where(c => c.UserId == user.Id && !c.IsRemoved);

            user.ForumPoints = topics.Sum(t => t.Likes) + comments.Sum(c => c.Likes);
        }
    }
}
