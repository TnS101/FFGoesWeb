namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetAllFriendsQuery : IRequest<UserListViewModel>
    {
        public string UserId { get; set; }
    }
}
