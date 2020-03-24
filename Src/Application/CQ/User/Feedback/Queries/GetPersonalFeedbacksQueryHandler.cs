namespace Application.CQ.User.Feedback.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalFeedbacksQueryHandler : IRequestHandler<GetPersonalFeedbacksQuery, FeedbackListViewModel>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IFFDbContext context;

        public GetPersonalFeedbacksQueryHandler(UserManager<AppUser> userManager, IFFDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FeedbackListViewModel> Handle(GetPersonalFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new FeedbackListViewModel
            {
                Feedbacks = await this.context.Feedbacks.Where(f => f.UserId == user.Id).ProjectTo<FeedbackFulllViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
