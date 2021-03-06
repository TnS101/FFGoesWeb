﻿namespace Application.CQ.Users.Queries.Panel
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

            var units = this.Context.Heroes.Where(u => u.UserId == user.Id).AsNoTracking();

            var topics = this.Context.Topics.Where(t => t.UserId == user.Id).AsNoTracking();

            var feedbacks = this.Context.Feedbacks.Where(f => f.UserId == user.Id).AsNoTracking();

            var friends = this.Context.Friends.Where(f => f.UserId == user.Id).AsNoTracking();

            var statuses = this.Context.Statuses.AsNoTracking();

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
                Statuses = statuses.ToList(),
            };
        }

        private int SumForumPoints(AppUser user)
        {
            var topicLikes = this.Context.Topics.Where(t => t.UserId == user.Id && !t.IsRemoved).Select(t => t.Likes);

            var commentLikes = this.Context.Comments.Where(c => c.UserId == user.Id && !c.IsRemoved).Select(c => c.Likes);

            return topicLikes.Count() + commentLikes.Count();
        }
    }
}
