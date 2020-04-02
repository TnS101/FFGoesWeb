namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Collections.Generic;

    public class HeroListViewModel
    {
        public IEnumerable<HeroMinViewModel> Heroes { get; set; }
    }
}
