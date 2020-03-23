namespace Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery
{
    using System.Collections.Generic;
    using Application.GameCQ.Treasure.Queries;

    public class TreasureListViewModel
    {
        public IEnumerable<TreasureFullViewModel> Treasures { get; set; }
    }
}
