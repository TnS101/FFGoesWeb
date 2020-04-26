namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Collections.Generic;

    public class UserListViewModel
    {
        public IEnumerable<UserPartialViewModel> Users { get; set; }
    }
}
