namespace Application.CQ.Social.Topics.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateTopicCommandHandler : UserHandler, IRequestHandler<CreateTopicCommand>
    {
        public CreateTopicCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<Unit> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            this.Context.Topics.Add(new Topic
            {
                Title = request.Title,
                Category = request.Category,
                Content = request.Content,
                UserId = user.Id,
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                CreateOn = DateTime.UtcNow,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
