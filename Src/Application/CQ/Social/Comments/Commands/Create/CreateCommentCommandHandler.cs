namespace Application.CQ.Social.Comments.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;

    public class CreateCommentCommandHandler : BaseHandler, IRequestHandler<CreateCommentCommand, string>
    {
        public CreateCommentCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

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
