namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentTopicQueryHandler : IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetCurrentTopicQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<TopicFullViewModel> Handle(GetCurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await this.context.Topics.FindAsync(request.TopicId);

            var viewer = await this.userManager.GetUserAsync(request.User);

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
                ViewerId = viewer.Id,
            };
        }
    }
}
