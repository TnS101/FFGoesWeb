namespace Application.CQ.Social.Messages.Queries
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

    public class GetPersonalMessagesQueryHandler : MapperHandler, IRequestHandler<GetPersonalMessagesQuery, MessageListViewModel>
    {
        public GetPersonalMessagesQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<MessageListViewModel> Handle(GetPersonalMessagesQuery request, CancellationToken cancellationToken)
        {
            return new MessageListViewModel
            {
                Messages = await this.Context.Messages.Where(m => m.UserId == request.UserId && m.UserId == request.SenderId).OrderByDescending(m => m.SentOn)
                .AsNoTracking().ProjectTo<MessageFullViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
