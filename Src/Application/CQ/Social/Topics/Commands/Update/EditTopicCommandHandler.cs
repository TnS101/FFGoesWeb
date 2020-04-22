namespace Application.CQ.Social.Topics.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class EditTopicCommandHandler : IRequestHandler<EditTopicCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public EditTopicCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(EditTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var topic = await this.context.Topics.FindAsync(request.Id);

            if (user.Id == topic.UserId)
            {
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

            return GConst.ErrorRedirect;
        }
    }
}
