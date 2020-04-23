namespace Application.CQ.Moderator.Queries.GetCurrentTicketQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;

    public class GetCurrentTicketQueryHandler : MapperHandler, IRequestHandler<GetCurrentTicketQuery, TicketFullViewModel>
    {
        public GetCurrentTicketQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TicketFullViewModel> Handle(GetCurrentTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await this.Context.Tickets.FindAsync(request.TicketId);

            await this.SetTicketContent(ticket);

            return this.Mapper.Map<TicketFullViewModel>(ticket);
        }

        private async Task SetTicketContent(Ticket ticket)
        {
            if (ticket.Type == GConst.CommentType)
            {
                var comment = await this.Context.Comments.FindAsync(ticket.CommentId);

                ticket.Content = comment.Content;
            }

            if (ticket.Type == GConst.TopicType)
            {
                var topic = await this.Context.Topics.FindAsync(ticket.TopicId);

                ticket.Content = topic.Content;
            }

            if (ticket.Type == GConst.MessageType)
            {
                var message = await this.Context.Messages.FindAsync(ticket.MessageId);

                ticket.Content = message.Content;
            }
        }
    }
}
