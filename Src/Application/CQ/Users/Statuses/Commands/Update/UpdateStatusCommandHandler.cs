namespace Application.CQ.Users.Statuses.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Social;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateStatusCommandHandler : MapperHandler, IRequestHandler<UpdateStatusCommand, StatusMinViewModel>
    {
        public UpdateStatusCommandHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<StatusMinViewModel> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var userStatus = await this.Context.UserStatuses.SingleOrDefaultAsync(us => us.UserId == user.Id);

            this.Context.UserStatuses.Remove(userStatus);

            this.Context.UserStatuses.Add(new UserStatus
            {
                StatusId = request.StatusId,
                UserId = user.Id,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            var status = await this.Context.Statuses.FindAsync(request.StatusId);

            return this.Mapper.Map<StatusMinViewModel>(status);
        }
    }
}
