namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ToDoListHandler : IRequestHandler<ToDoList, FeedbackTaskListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public ToDoListHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FeedbackTaskListViewModel> Handle(ToDoList request, CancellationToken cancellationToken)
        {
            return new FeedbackTaskListViewModel
            {
                Tasks = await this.context.Feedbacks.Where(f => f.IsAccepted).ProjectTo<FeedbackTaskViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
