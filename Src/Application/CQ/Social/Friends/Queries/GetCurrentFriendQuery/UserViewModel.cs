namespace Application.CQ.Social.Friends.Queries.GetCurrentFriendQuery
{
    using System.Collections.Generic;
    using Domain.Entities.Game.Units;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public int Stars { get; set; }

        public int MasteryPoints { get; set; }

        public int ForumPoints { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
