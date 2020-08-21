namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Collections.Generic;

    public class HeroListViewModel
    {
        public ICollection<HeroMinViewModel> Heroes { get; set; }
    }
}
