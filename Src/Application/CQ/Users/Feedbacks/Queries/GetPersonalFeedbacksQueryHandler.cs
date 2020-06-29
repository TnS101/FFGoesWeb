﻿namespace Application.CQ.Users.Feedbacks.Queries
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

    public class GetPersonalFeedbacksQueryHandler : MapperHandler, IRequestHandler<GetPersonalFeedbacksQuery, FeedbackListViewModel>
    {
        public GetPersonalFeedbacksQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FeedbackListViewModel> Handle(GetPersonalFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            return new FeedbackListViewModel
            {
                Feedbacks = await this.Context.Feedbacks.Where(f => f.UserId == user.Id).AsNoTracking().ProjectTo<FeedbackFulllViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
