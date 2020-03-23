namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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

            this.context.Comments.RemoveRange(topicToRemove.Comments.SelectMany(c => c.Replies));

            this.context.Comments.RemoveRange(topicToRemove.Comments);

            this.context.Topics.Remove(topicToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
