namespace Application.CQ.User.Status.Queries
{
    using System.Collections.Generic;

    public class StatusListViewModel
    {
        public IEnumerable<StatusFullViewModel> Statuses { get; set; }
    }
}
