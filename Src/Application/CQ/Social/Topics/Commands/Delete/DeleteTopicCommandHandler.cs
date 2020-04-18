﻿namespace Application.CQ.Social.Topics.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
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

            if (comments.Count() > 0)
            {
                foreach (var ticket in this.context.Tickets)
                {
                    foreach (var comment in comments)
                    {
                        if (ticket.CommentId == comment.Id)
                        {
                            return GConst.InModerationRedirect;
                        }
                    }
                }

                this.context.Comments.RemoveRange(comments);

                await this.context.SaveChangesAsync(cancellationToken);

                this.context.Topics.Remove(topicToRemove);

                await this.context.SaveChangesAsync(cancellationToken);

                return GConst.TopicCommandRedirect;
            }

            if (topicTickets.Count() > 0)
            {
                return GConst.InModerationRedirect;
            }

            this.context.Comments.RemoveRange(comments);

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Topics.Remove(topicToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
