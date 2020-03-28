namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    Application.Common.Interfaces;
    using MediatR;

    public class GetCurrentFeedbackQueryHandler : IRequestHandler<GetCurrentFeedbackQuery, FeedbackFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetCurrentFeedbackQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FeedbackFullViewModel> Handle(GetCurrentFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedback = await this.context.Feedbacks.FindAsync(request.FeedbackId);

            return this.mapper.Map<FeedbackFullViewModel>(feedback);
        }
    }
}
