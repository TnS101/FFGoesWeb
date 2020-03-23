namespace Application.CQ.Admin.Users.Queries
{
    using System.Collections.Generic;

    public class UserListViewModel
    {
        public IEnumerable<UserPartialViewModel> Users { get; set; }
    }
}
