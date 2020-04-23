namespace Application.CQ.Social.Comments.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateCommentCommandHandler : UserHandler, IRequestHandler<CreateCommentCommand, string>
    {
        public CreateCommentCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = string.Format(GConst.NullCommentError, user.UserName);
            }

            this.Context.Comments.Add(new Comment
            {
                Content = request.Content,
                UserId = user.Id,
                CreatedOn = DateTime.UtcNow,
                Likes = new List<Like>(),
                Replies = new List<Comment>(),
                TopicId = request.TopicId,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, request.TopicId);
        }
    }
}
