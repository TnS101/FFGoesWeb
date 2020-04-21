namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;

    public class ItemListViewModel
    {
        public IEnumerable<ItemMinViewModel> Items { get; set; }

        public UnitPartialViewModel Hero { get; set; }
    }
}
