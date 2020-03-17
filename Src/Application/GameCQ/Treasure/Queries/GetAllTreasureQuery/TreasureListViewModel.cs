namespace Application.GameCQ.Treasure.Queries
{
    using System.Collections.Generic;

    public class TreasureListViewModel
    {
        public IEnumerable<TreasureFullViewModel> Treasures { get; set; }
    }
}
