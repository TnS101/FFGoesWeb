namespace Application.CQ.User.Queries
{
    using MediatR;

    public class GetOnlineUsersQuery : IRequest<UserListViewModel>
    {
        public string Role { get; set; }
    }
}
