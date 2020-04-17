namespace Application.CQ.Social.FriendRequests.Queries
{
    using System.Collections.Generic;

    public class FriendRequestListViewModel
    {
        public IEnumerable<FriendRequestFullViewModel> FriendRequests { get; set; }
    }
}
