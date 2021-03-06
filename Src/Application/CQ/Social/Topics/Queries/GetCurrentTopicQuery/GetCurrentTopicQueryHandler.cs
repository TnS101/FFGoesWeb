﻿namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentTopicQueryHandler : BaseHandler, IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>
    {
        public GetCurrentTopicQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<TopicFullViewModel> Handle(GetCurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await this.Context.Topics.FindAsync(request.TopicId);

            topic.Comments = await this.Context.Comments.Where(c => c.TopicId == topic.Id).AsNoTracking().ToArrayAsync();

            var topicReportersIds = await this.Context.Tickets.Where(t => t.TopicId == topic.Id).AsNoTracking().Select(t => t.UserId).ToArrayAsync();

            var commentReportersIds = await this.Context.Comments.Where(c => c.TopicId == topic.Id).AsNoTracking()
                .SelectMany(c => c.Tickets).Select(t => t.UserId).ToArrayAsync();

            var result = new TopicFullViewModel()
            {
                Category = topic.Category,
                Comments = topic.Comments,
                Content = topic.Content,
                CreateOn = topic.CreateOn,
                Likes = topic.Likes,
                Title = topic.Title,
                UserId = topic.UserId,
                Id = topic.Id,
                TopicTicketsIds = topicReportersIds,
                ViewerId = request.UserId,
                CommentTicketsIds = commentReportersIds,
            };

            return result;
        }
    }
}
