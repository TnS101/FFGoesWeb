namespace Application.CQ.Social.Topics.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DeleteTopicCommandHandler : UserHandler, IRequestHandler<DeleteTopicCommand, string>
    {
        public DeleteTopicCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var topicToRemove = await this.Context.Topics.FindAsync(request.TopicId);

            if (user.Id == topicToRemove.UserId)
            {
                var topicTickets = await this.Context.Tickets.Where(t => t.TopicId == topicToRemove.Id).ToListAsync();

                var comments = await this.Context.Comments.Where(c => c.TopicId == topicToRemove.Id).ToListAsync();

                if (comments.Count() > 0)
                {
                    foreach (var ticket in this.Context.Tickets)
                    {
                        foreach (var comment in comments)
                        {
                            if (ticket.CommentId == comment.Id)
                            {
                                return GConst.InModerationRedirect;
                            }
                        }
                    }

                    this.Context.Comments.RemoveRange(comments);

                    await this.Context.SaveChangesAsync(cancellationToken);

                    this.Context.Topics.Remove(topicToRemove);

                    await this.Context.SaveChangesAsync(cancellationToken);

                    return GConst.TopicCommandRedirect;
                }

                if (topicTickets.Count() > 0)
                {
                    return GConst.InModerationRedirect;
                }

                this.Context.Comments.RemoveRange(comments);

                await this.Context.SaveChangesAsync(cancellationToken);

                this.Context.Topics.Remove(topicToRemove);

                await this.Context.SaveChangesAsync(cancellationToken);

                return GConst.TopicCommandRedirect;
            }

            return GConst.ErrorRedirect;
        }
    }
}
