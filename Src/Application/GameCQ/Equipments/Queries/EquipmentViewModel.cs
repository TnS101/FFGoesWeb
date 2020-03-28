namespace Application.GameCQ.Equipment.Queries
{
    using System.Collections.Generic;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;

    public class EquipmentViewModel
    {
        public ICollection<ItemMinViewModel> Items { get; set; }
    }
}
