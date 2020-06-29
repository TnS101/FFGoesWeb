namespace Application.CQ.Social.Comments.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class EditCommentCommandHandler : BaseHandler, IRequestHandler<EditCommentCommand, string>
    {
        public EditCommentCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await this.Context.Comments.FindAsync(request.CommentId);

            if (!string.IsNullOrWhiteSpace(request.Content))
            {
                comment.Content = request.Content;
            }

            comment.EditedOn = DateTime.UtcNow;

            this.Context.Comments.Update(comment);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, comment.TopicId);
        }
    }
}
