namespace Application.CQ.User.Queries
{
    using System.Collections.Generic;

    public class UserListViewModel
    {
        public IEnumerable<UserPartialViewModel> Users { get; set; }
    }
}
