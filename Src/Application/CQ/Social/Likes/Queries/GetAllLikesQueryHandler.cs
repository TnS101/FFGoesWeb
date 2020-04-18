namespace Application.CQ.Social.Likes.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllLikesQueryHandler : IRequestHandler<GetAllLikesQuery, LikesListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllLikesQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<LikesListViewModel> Handle(GetAllLikesQuery request, CancellationToken cancellationToken)
        {
            if (request.CommentId != null)
            {
                return new LikesListViewModel
                {
                    Likes = await this.context.Likes.Where(l => l.CommentId == request.CommentId).ProjectTo<LikeFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }

            return new LikesListViewModel
            {
                Likes = await this.context.Likes.Where(l => l.TopicId == request.TopicId).ProjectTo<LikeFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
