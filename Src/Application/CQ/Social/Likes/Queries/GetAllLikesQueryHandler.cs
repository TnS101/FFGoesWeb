namespace Application.CQ.Social.Likes.Queries
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

    public class GetAllLikesQueryHandler : MapperHandler, IRequestHandler<GetAllLikesQuery, LikesListViewModel>
    {
        public GetAllLikesQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<LikesListViewModel> Handle(GetAllLikesQuery request, CancellationToken cancellationToken)
        {
            if (request.CommentId != null)
            {
                return new LikesListViewModel
                {
                    Likes = await this.Context.Likes.Where(l => l.CommentId == request.CommentId).ProjectTo<LikeFullViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
                };
            }

            return new LikesListViewModel
            {
                Likes = await this.Context.Likes.Where(l => l.TopicId == request.TopicId).ProjectTo<LikeFullViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
