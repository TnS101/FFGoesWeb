namespace Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery
{
    using System.Collections.Generic;

    public class UserListViewModel
    {
        public IEnumerable<UserPartialViewModel> Users { get; set; }
    }
}
