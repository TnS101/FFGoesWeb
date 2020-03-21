namespace Application.CQ.Forum.Topic.Commands.Create
{
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateTopicCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            await this.context.Topics.AddAsync(new Domain.Entities.Common.Social.Topic 
            {
                Title = request.Title,
                Category = request.Category,
                Content = request.Content,
                UserId = user.Id,
                Comments = new List<Comment>(),
                Likes = 0,
                CreateOn = DateTime.UtcNow
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Home";
        }
    }
}
