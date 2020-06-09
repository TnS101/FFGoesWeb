namespace Application.CQ.Users.Statuses.Commands.Update
{
    using MediatR;

    public class UpdateStatusCommand : IRequest<StatusMinViewModel>
    {
        public string UserId { get; set; }

        public int StatusId { get; set; }
    }
}
