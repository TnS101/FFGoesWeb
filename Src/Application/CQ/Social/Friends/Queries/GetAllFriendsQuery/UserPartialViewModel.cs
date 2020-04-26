namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Collections.Generic;
    using Domain.Entities.Social;

    public class UserPartialViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public int ForumPoints { get; set; }

        public int MasteryPoints { get; set; }

        public ICollection<Friend> Friends { get; set; }
    }
}
