namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Security.Claims;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using MediatR;

    public class GetAllFriendsQuery : IRequest<UserListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
