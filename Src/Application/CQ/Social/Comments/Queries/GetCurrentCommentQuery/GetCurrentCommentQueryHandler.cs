namespace Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentCommentQueryHandler : IRequestHandler<GetCurrentCommentQuery, CommentMinViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetCurrentCommentQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CommentMinViewModel> Handle(GetCurrentCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await this.context.Comments.FindAsync(request.CommentId);

            return this.mapper.Map<CommentMinViewModel>(comment);
        }
    }
}
