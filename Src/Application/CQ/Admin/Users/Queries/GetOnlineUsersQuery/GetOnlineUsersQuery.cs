namespace Application.CQ.Admin.Users.Queries
{
    using MediatR;

    public class GetOnlineUsersQuery : IRequest<UserListViewModel>
    {
        public string Role { get; set; }
    }
}
