namespace Application.CQ.Social.Message.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalMessagesQueryHandler : IRequestHandler<GetPersonalMessagesQuery, MessageListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetPersonalMessagesQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<MessageListViewModel> Handle(GetPersonalMessagesQuery request, CancellationToken cancellationToken)
        {
            var reciever = await this.userManager.GetUserAsync(request.Reciever);

            var sender = await this.context.AppUsers.FindAsync(request.SenderId);

            return new MessageListViewModel
            {
                Messages = await this.context.Messages.Where(m => m.UserId == reciever.Id && m.UserId == sender.Id)
                .ProjectTo<MessageFullViewModel>(this.mapper.ConfigurationProvider).OrderByDescending(m => m.SentOn).ToListAsync(),
            };
        }
    }
}
