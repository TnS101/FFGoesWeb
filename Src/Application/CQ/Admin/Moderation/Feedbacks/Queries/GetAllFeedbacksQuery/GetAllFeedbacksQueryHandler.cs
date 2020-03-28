namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, FeedbacksListViewModel>
    {
        private readonly IFFDbContext context;

        public GetAllFeedbacksQueryHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<FeedbacksListViewModel> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            return new FeedbacksListViewModel
            {
                Feedbacks = await this.context.Feedbacks.Where(f => !f.IsAccepted).Select(f => new FeedbackPartialViewModel
                {
                    SenderName = f.User.UserName,
                    SentOn = f.SentOn,
                })
                .OrderBy(t => t.SentOn)
                .ToListAsync(),
            };
        }
    }
}
