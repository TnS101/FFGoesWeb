﻿namespace Application.CQ.Social.Topics.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class EditTopicCommandHandler : BaseHandler, IRequestHandler<EditTopicCommand, string>
    {
        public EditTopicCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(EditTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await this.Context.Topics.FindAsync(request.Id);

            if (request.UserId == topic.UserId)
            {
                if (!string.IsNullOrWhiteSpace(request.NewTitle))
                {
                    topic.Title = request.NewTitle;
                }

                if (!string.IsNullOrWhiteSpace(request.NewCategory))
                {
                    topic.Category = request.NewCategory;
                }

                if (!string.IsNullOrWhiteSpace(request.NewContent))
                {
                    topic.Content = request.NewContent;
                }

                topic.EditedOn = DateTime.UtcNow;

                this.Context.Topics.Update(topic);

                await this.Context.SaveChangesAsync(cancellationToken);

                return GConst.TopicCommandRedirect;
            }

            return GConst.ErrorRedirect;
        }
    }
}
