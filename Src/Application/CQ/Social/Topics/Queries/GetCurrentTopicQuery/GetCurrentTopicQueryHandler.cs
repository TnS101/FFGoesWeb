namespace Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentTopicQueryHandler : IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>
    {
        private readonly IFFDbContext context;

        public GetCurrentTopicQueryHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<TopicFullViewModel> Handle(GetCurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await this.context.Topics.FindAsync(request.TopicId);

            topic.Comments = await this.context.Comments.Where(c => c.TopicId == topic.Id).ToListAsync();

            var topicTickets = await this.context.Tickets.Where(t => t.TopicId == topic.Id).ToListAsync();

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

            await this.context.SaveChangesAsync(cancellationToken);

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
            };
        }
    }
}
