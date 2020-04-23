namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ToDoListHandler : MapperHandler, IRequestHandler<ToDoList, FeedbackTaskListViewModel>
    {
        public ToDoListHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FeedbackTaskListViewModel> Handle(ToDoList request, CancellationToken cancellationToken)
        {
            return new FeedbackTaskListViewModel
            {
                Tasks = await this.Context.Feedbacks.Where(f => f.IsAccepted).ProjectTo<FeedbackTaskViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
