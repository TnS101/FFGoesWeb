namespace Application.CQ.Forum.FriendRequest.Queries
{
    using System.Collections.Generic;

    public class FriendRequestListViewModel
    {
        public IEnumerable<FriendRequestFullViewModel> FriendRequests { get; set; }
    }
}
