namespace Application.CQ.Forum.Comment.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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

            if (!string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = string.Format(GConst.NullCommentError);
            }

            this.context.Comments.Add(new Domain.Entities.Common.Social.Comment
            {
                Content = request.Content,
                UserId = user.Id,
                CreatedOn = DateTime.UtcNow,
                Likes = 0,
                Replies = new List<Domain.Entities.Common.Social.Comment>(),
                TopicId = request.TopicId,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, request.TopicId);
        }
    }
}
