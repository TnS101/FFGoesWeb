namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteTopicCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var topicToRemove = await this.context.Topics.FindAsync(request.TopicId);

            var topicTickets = await this.context.Tickets.Where(t => t.TopicId == topicToRemove.Id).ToListAsync();

            var comments = await this.context.Comments.Where(c => c.TopicId == topicToRemove.Id).ToListAsync();

            if (comments != null)
            {
                if (this.context.Tickets.Any(t => t.CommentId == comments.FirstOrDefault().Id))
                {
                    return GConst.ErrorRedirect;
                }
                else
                {
                    this.context.Comments.RemoveRange(comments);

                    await this.context.SaveChangesAsync(cancellationToken);

                    this.context.Topics.Remove(topicToRemove);

                    await this.context.SaveChangesAsync(cancellationToken);

                    return GConst.TopicCommandRedirect;
                }
            }

            if (topicTickets != null)
            {
                return GConst.ErrorRedirect;
            }

            this.context.Comments.RemoveRange(comments);

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Topics.Remove(topicToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
