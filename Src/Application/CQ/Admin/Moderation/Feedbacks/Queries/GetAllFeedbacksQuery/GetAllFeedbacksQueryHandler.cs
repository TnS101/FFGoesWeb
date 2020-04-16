namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, FeedbacksListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllFeedbacksQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FeedbacksListViewModel> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            return new FeedbacksListViewModel
            {
                Feedbacks = await this.context.Feedbacks.Where(f => !f.IsAccepted).ProjectTo<FeedbackFullViewModel>(this.mapper.ConfigurationProvider)
                 .OrderBy(t => t.SentOn)
                 .ToListAsync(),
            };
        }
    }
}
