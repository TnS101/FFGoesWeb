namespace Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentCommentQueryHandler : MapperHandler, IRequestHandler<GetCurrentCommentQuery, CommentMinViewModel>
    {
        public GetCurrentCommentQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<CommentMinViewModel> Handle(GetCurrentCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await this.Context.Comments.FindAsync(request.CommentId);

            return this.Mapper.Map<CommentMinViewModel>(comment);
        }
    }
}
