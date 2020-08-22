namespace Application.CQ.Social.Topics.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;

    public class DeleteTopicCommandHandler : BaseHandler, IRequestHandler<DeleteTopicCommand, string>
    {
        public DeleteTopicCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var topicToRemove = await this.Context.Topics.FindAsync(request.TopicId);

            if (request.UserId == topicToRemove.UserId)
            {
                var topicTickets = this.Context.Tickets.Where(t => t.TopicId == topicToRemove.Id);

                var comments = this.Context.Comments.Where(c => c.TopicId == topicToRemove.Id);

                if (comments.Count() > 0)
                {
                    foreach (var ticket in this.Context.Tickets)
                    {
                        foreach (var comment in comments)
                        {
                            if (ticket.CommentId == comment.Id)
                            {
                                return GConst.InModerationRedirect;
                            }
                        }
                    }

                    await this.RemoveTopic(topicToRemove, comments, cancellationToken);

                    return GConst.TopicCommandRedirect;
                }

                if (topicTickets.Count() > 0)
                {
                    return GConst.InModerationRedirect;
                }

                await this.RemoveTopic(topicToRemove, comments, cancellationToken);

                return GConst.TopicCommandRedirect;
            }

            return GConst.ErrorRedirect;
        }

        private async Task RemoveTopic(Topic topicToRemove, IQueryable<Comment> comments, CancellationToken cancellationToken)
        {
            this.Context.Comments.RemoveRange(comments);

            await this.Context.SaveChangesAsync(cancellationToken);

            this.Context.Topics.Remove(topicToRemove);

            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }
}
