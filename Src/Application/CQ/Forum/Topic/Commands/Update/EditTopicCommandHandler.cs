using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQ.Forum.Topic.Commands.Update
{
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
            if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.Title) && string.IsNullOrWhiteSpace(request.Category))
            {
                request.EditedOn = topic.CreateOn;
            }

            this.context.Topics.Update(topic);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/PersonalTopics";
        }
    }
}
