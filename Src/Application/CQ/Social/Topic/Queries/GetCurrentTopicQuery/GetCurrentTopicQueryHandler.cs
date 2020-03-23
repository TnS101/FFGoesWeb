namespace Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery
{
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCurrentTopicQueryHandler : IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetCurrentTopicQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async  Task<TopicFullViewModel> Handle(GetCurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await this.context.Topics.FindAsync(request.TopicId);

            return this.mapper.Map<TopicFullViewModel>(topic);
        }
    }
}
