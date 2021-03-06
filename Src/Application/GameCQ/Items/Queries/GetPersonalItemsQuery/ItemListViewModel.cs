﻿namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Collections.Generic;

    public class ItemListViewModel
    {
        public string HeroClass { get; set; }

        public int HeroLevel { get; set; }

        public ICollection<ItemMinViewModel> Inventory { get; set; }
    }
}
