namespace Application.CQ.Users.Queries.Panel
{
    using MediatR;

    public class UserPanelQuery : IRequest<UserPanelViewModel>
    {
        public string UserId { get; set; }
    }
}
