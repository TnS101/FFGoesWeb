namespace Application.CQ.Social.Friends.Queries.GetCurrentFriendQuery
{
    using MediatR;

    public class GetCurrentFriendQuery : IRequest<UserViewModel>
    {
        public string FriendId { get; set; }
    }
}
