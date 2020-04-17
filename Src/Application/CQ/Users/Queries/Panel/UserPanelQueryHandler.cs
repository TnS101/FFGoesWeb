namespace Application.CQ.Users.Queries.Panel
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

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

            var units = this.context.Heroes.Where(u => u.UserId == user.Id);

            var topics = this.context.Topics.Where(t => t.UserId == user.Id);

            var feedbacks = this.context.Feedbacks.Where(f => f.UserId == user.Id);

            var friends = this.context.AppUsers.Where(f => f.FriendId == user.Id);

            var statuses = await this.context.Statuses.ToListAsync();

            if (!this.context.UserStatuses.Any(u => u.UserId == user.Id))
            {
                var status = this.context.Statuses.FirstOrDefault(s => s.DisplayName == "UnSet");

                var userStatus = new UserStatus
                {
                    StatusId = status.Id,
                    UserId = user.Id,
                };

                this.context.UserStatuses.Add(userStatus);
                this.SumForumPoints(user);

                await this.context.SaveChangesAsync(cancellationToken);

                return new UserPanelViewModel
                {
                    UserName = user.UserName,
                    Stars = user.Stars,
                    StatusIClass = status.IClass,
                    MasteryPoints = user.MasteryPoints,
                    Warnings = user.Warnings,
                    Topics = topics.Count(),
                    Feedbacks = feedbacks.Count(),
                    ForumPoints = user.ForumPoints,
                    Friends = friends.Count(),
                    Units = units.Count(),
                    Statuses = statuses,
                };
            }
            else
            {
                var userStatus = this.context.UserStatuses.FirstOrDefault(u => u.UserId == user.Id);

                var status = this.context.Statuses.FirstOrDefault(s => s.Id == userStatus.StatusId);

                this.SumForumPoints(user);

                if (units.Count() == 0)
                {
                    user.MasteryPoints = 0;
                }
                else
                {
                    user.MasteryPoints = units.Sum(u => u.Mastery);
                }

                return new UserPanelViewModel
                {
                    UserName = user.UserName,
                    Stars = user.Stars,
                    StatusIClass = status.IClass,
                    MasteryPoints = user.MasteryPoints,
                    Warnings = user.Warnings,
                    Topics = topics.Count(),
                    Feedbacks = feedbacks.Count(),
                    ForumPoints = user.ForumPoints,
                    Friends = friends.Count(),
                    Units = units.Count(),
                    Statuses = statuses,
                };
            }
        }

        private void SumForumPoints(AppUser user)
        {
            var topics = this.context.Topics.Where(t => t.UserId == user.Id && !t.IsRemoved);

            var comments = this.context.Comments.Where(c => c.UserId == user.Id && !c.IsRemoved);

            user.ForumPoints = topics.Sum(t => t.Likes) + comments.Sum(c => c.Likes);
        }
    }
}
