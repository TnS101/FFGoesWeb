namespace Application.CQ.Forum.Topic.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class EditTopicCommandHandler : IRequestHandler<EditTopicCommand, string>
    {
        private readonly IFFDbContext context;

        public EditTopicCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(EditTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await this.context.Topics.FindAsync(request.TopicId);

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                request.Title = topic.Title;
            }

            if (string.IsNullOrWhiteSpace(request.Category))
            {
                request.Category = topic.Category;
            }

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = topic.Content;
            }

            topic.Title = request.Title;

            topic.Category = request.Category;

            topic.Content = request.Content;

            topic.EditedOn = DateTime.UtcNow;

            this.context.Topics.Update(topic);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
