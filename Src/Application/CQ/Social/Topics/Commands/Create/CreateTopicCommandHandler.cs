namespace Application.CQ.Forum.Topic.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public CreateTopicCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            await this.context.Topics.AddAsync(new Topic
            {
                Title = request.Title,
                Category = request.Category,
                Content = request.Content,
                UserId = user.Id,
                Comments = new List<Comment>(),
                Likes = 0,
                CreateOn = DateTime.UtcNow,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
