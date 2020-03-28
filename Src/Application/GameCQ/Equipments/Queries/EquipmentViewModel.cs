namespace Application.GameCQ.Equipments.Queries
{
    using System.Collections.Generic;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;

    public class EquipmentViewModel
    {
        public ICollection<ItemMinViewModel> Items { get; set; }
    }
}
