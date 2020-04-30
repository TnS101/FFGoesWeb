namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using System.Collections.Generic;
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

            var viewer = await this.Context.AppUsers.FindAsync(request.UserId);

            topic.Comments = await this.Context.Comments.Where(c => c.TopicId == topic.Id).ToListAsync();

            var topicTickets = await this.Context.Tickets.Where(t => t.TopicId == topic.Id).ToListAsync();

            var topicTicketsIds = topicTickets.Select(t => t.UserId).ToList();

            var commentTicketsIds = new Queue<string>();

            foreach (var ticket in topicTickets)
            {
                foreach (var comment in topic.Comments)
                {
                    if (ticket.CommentId == comment.Id)
                    {
                        commentTicketsIds.Enqueue(ticket.UserId);
                    }
                }
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return new TopicFullViewModel
            {
                Category = topic.Category,
                Comments = topic.Comments,
                Content = topic.Content,
                CreateOn = topic.CreateOn,
                Likes = topic.Likes,
                Title = topic.Title,
                UserId = topic.UserId,
                Id = topic.Id,
                TopicTicketsIds = topicTicketsIds,
                CommentTicketsIds = commentTicketsIds,
                ViewerId = viewer.Id,
            };
        }
    }
}
