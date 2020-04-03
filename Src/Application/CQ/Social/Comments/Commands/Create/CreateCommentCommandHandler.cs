namespace Application.CQ.Social.Comments.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateCommentCommandHandler : PageModel, IRequestHandler<CreateCommentCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public CreateCommentCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = string.Format(GConst.NullCommentError, user.UserName);
            }

            this.context.Comments.Add(new Comment
            {
                Content = request.Content,
                UserId = user.Id,
                CreatedOn = DateTime.UtcNow,
                Likes = 0,
                Replies = new List<Comment>(),
                TopicId = request.TopicId,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, request.TopicId);
        }
    }
}
