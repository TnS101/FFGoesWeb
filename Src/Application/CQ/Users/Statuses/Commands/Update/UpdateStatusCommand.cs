namespace Application.CQ.Users.Statuses.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class UpdateStatusCommand : IRequest<string>
    {
        public string UserId { get; set; }

        public int StatusId { get; set; }
    }
}
