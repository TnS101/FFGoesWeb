namespace Application.CQ.Users.Queries.Panel
{
    using System.Security.Claims;
    using MediatR;

    public class UserPanelQuery : IRequest<UserPanelViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
