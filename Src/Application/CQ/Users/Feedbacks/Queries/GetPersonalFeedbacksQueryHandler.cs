namespace Application.CQ.Users.Feedbacks.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalFeedbacksQueryHandler : FullHandler, IRequestHandler<GetPersonalFeedbacksQuery, FeedbackListViewModel>
    {
        public GetPersonalFeedbacksQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public async Task<FeedbackListViewModel> Handle(GetPersonalFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            return new FeedbackListViewModel
            {
                Feedbacks = await this.Context.Feedbacks.Where(f => f.UserId == user.Id).ProjectTo<FeedbackFulllViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
