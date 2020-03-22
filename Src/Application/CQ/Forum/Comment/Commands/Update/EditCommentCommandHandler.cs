namespace Application.CQ.Forum.Comment.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, string>
    {
        private readonly IFFDbContext context;
        public EditCommentCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await this.context.Comments.FindAsync(request.CommentId);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = comment.Content;
            }

            comment.Content = request.Content;
            comment.EditedOn = DateTime.UtcNow;

            this.context.Comments.Update(comment);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect,request.TopicId);
        }
    }
}
