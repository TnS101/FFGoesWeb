namespace Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentTopicQueryHandler : IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetCurrentTopicQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TopicFullViewModel> Handle(GetCurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await this.context.Topics.FindAsync(request.TopicId);

            topic.Comments = await this.context.Comments.Where(c => c.TopicId == topic.Id).ToListAsync();

            this.context.Topics.Update(topic);

            await this.context.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<TopicFullViewModel>(topic);
        }
    }
}
