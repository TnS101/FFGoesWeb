namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;

    public class ItemListViewModel
    {
        public ItemListViewModel()
        {
            this.Items = new List<ItemMinViewModel>();
        }

        public string HeroClass { get; set; }

        public int HeroLevel { get; set; }

        public string Time { get; set; }

        public ICollection<ItemMinViewModel> Items { get; set; }
    }
}
