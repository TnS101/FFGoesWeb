namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteTopicCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var topicToRemove = this.context.Topics.FirstOrDefault(t => t.Id == request.TopicId);

            var comments = this.context.Comments.Where(c => c.TopicId == topicToRemove.Id);

            var replies = this.context.Comments.Where(c => c.Replies.Where(r => r.ReplyId == c.Id).Count() > 0);

            this.context.Comments.RemoveRange(replies.ToList());

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Comments.RemoveRange(comments.ToList());

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Topics.Remove(topicToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
