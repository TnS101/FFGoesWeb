namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFeedbacksQueryHandler : MapperHandler, IRequestHandler<GetAllFeedbacksQuery, FeedbacksListViewModel>
    {
        public GetAllFeedbacksQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FeedbacksListViewModel> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            return new FeedbacksListViewModel
            {
                Feedbacks = await this.Context.Feedbacks.Where(f => !f.IsAccepted).AsNoTracking().ProjectTo<FeedbackFullViewModel>(this.Mapper.ConfigurationProvider)
                 .OrderBy(t => t.SentOn)
                 .ToArrayAsync(),
            };
        }
    }
}
