namespace Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery
{
    using MediatR;

    public class GetOnlineUsersQuery : IRequest<UserListViewModel>
    {
        public string Role { get; set; }
    }
}
