namespace Application.CQ.Users.Queries.Panel
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UserPanelQueryHandler : BaseHandler, IRequestHandler<UserPanelQuery, UserPanelViewModel>
    {
        public UserPanelQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<UserPanelViewModel> Handle(UserPanelQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var units = this.Context.Heroes.Where(u => u.UserId == user.Id);

            var topics = this.Context.Topics.Where(t => t.UserId == user.Id);

            var feedbacks = this.Context.Feedbacks.Where(f => f.UserId == user.Id);

            var friends = this.Context.Friends.Where(f => f.UserId == user.Id);

            var statuses = await this.Context.Statuses.ToListAsync();

            Status status = null;

            if (!this.Context.UserStatuses.Any(u => u.UserId == user.Id))
            {
                status = this.Context.Statuses.FirstOrDefault(s => s.DisplayName == "UnSet");

                var userStatus = new UserStatus
                {
                    StatusId = status.Id,
                    UserId = user.Id,
                };

                this.Context.UserStatuses.Add(userStatus);

                await this.Context.SaveChangesAsync(cancellationToken);
            }
            else if (this.Context.UserStatuses.Any(u => u.UserId == user.Id))
            {
                var userStatus = this.Context.UserStatuses.FirstOrDefault(u => u.UserId == user.Id);

                status = this.Context.Statuses.FirstOrDefault(s => s.Id == userStatus.StatusId);
            }

            if (user.ForumPoints != this.SumForumPoints(user))
            {
                user.ForumPoints = this.SumForumPoints(user);
                await this.Context.SaveChangesAsync(cancellationToken);
            }

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

        private int SumForumPoints(AppUser user)
        {
            var topics = this.Context.Topics.Where(t => t.UserId == user.Id && !t.IsRemoved);

            var comments = this.Context.Comments.Where(c => c.UserId == user.Id && !c.IsRemoved);

            var topicLikes = new Queue<Like>();

            var commentLikes = new Queue<Like>();

            foreach (var like in this.Context.Likes)
            {
                foreach (var topic in topics)
                {
                    if (like.TopicId == topic.Id)
                    {
                        topicLikes.Enqueue(like);
                    }
                }
            }

            foreach (var like in this.Context.Likes)
            {
                foreach (var comment in comments)
                {
                    if (like.CommentId == comment.Id)
                    {
                        commentLikes.Enqueue(like);
                    }
                }
            }

            return topicLikes.Count + commentLikes.Count;
        }
    }
}
