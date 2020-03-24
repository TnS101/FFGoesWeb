namespace Application.CQ.Moderator.Queries.GetCurrentTicketQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Entities.Moderation;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class GetCurrentTicketQueryHandler : IRequestHandler<GetCurrentTicketQuery, TicketFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetCurrentTicketQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TicketFullViewModel> Handle(GetCurrentTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await this.context.Tickets.FindAsync(request.TicketId);

            await this.SetTicketContent(ticket);

            return this.mapper.Map<TicketFullViewModel>(ticket);
        }

        private async Task SetTicketContent(Ticket ticket)
        {
            if (ticket.Type == GConst.CommentType)
            {
                var comment = await this.context.Comments.FindAsync(ticket.CommentId);

                ticket.Content = comment.Content;
            }

            if (ticket.Type == GConst.TopicType)
            {
                var topic = await this.context.Topics.FindAsync(ticket.TopicId);

                ticket.Content = topic.Content;
            }

            if (ticket.Type == GConst.MessageType)
            {
                var message = await this.context.Messages.FindAsync(ticket.MessageId);

                ticket.Content = message.Content;
            }
        }
    }
}
