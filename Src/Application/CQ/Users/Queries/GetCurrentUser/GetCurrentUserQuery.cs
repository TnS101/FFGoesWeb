namespace Application.CQ.Users.Queries.GetCurrentUser
{
    using System.Security.Claims;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using MediatR;

    public class GetCurrentUserQuery : IRequest<UserPartialViewModel>
    {
        public string UserId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
