namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    Application.Common.Interfaces;
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
            var topicToRemove = await this.context.Topics.FindAsync(request.TopicId);

            var comments = this.context.Comments.Where(c => c.TopicId == topicToRemove.Id);

            this.context.Comments.RemoveRange(comments.ToList());

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Topics.Remove(topicToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
