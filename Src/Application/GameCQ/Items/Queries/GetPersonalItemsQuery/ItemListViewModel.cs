namespace Application.GameCQ.Item.Queries
{
    using System.Collections.Generic;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;

    public class ItemListViewModel
    {
        public IEnumerable<ItemMinViewModel> Items { get; set; }
    }
}
