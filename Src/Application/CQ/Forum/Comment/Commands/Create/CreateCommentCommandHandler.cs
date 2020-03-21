namespace Application.CQ.Forum.Comment.Create
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateCommentCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            this.context.Comments.Add(new Domain.Entities.Common.Social.Comment
            {
                Content = request.Content,
                UserId = user.Id,
                CreatedOn = DateTime.UtcNow,
                Likes = 0,
                Replies = new List<Domain.Entities.Common.Social.Comment>(),
                TopicId = request.TopicId
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect,request.TopicId);
        }
    }
}
