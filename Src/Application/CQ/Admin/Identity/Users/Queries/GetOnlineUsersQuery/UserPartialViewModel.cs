namespace Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery
{
    public class UserPartialViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public int OnlineTime { get; set; }

        public int MasteryPoints { get; set; }

        public int ForumPoints { get; set; }
    }
}
