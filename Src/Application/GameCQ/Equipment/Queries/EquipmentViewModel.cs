namespace Application.GameCQ.Equipment.Queries
{
    using Application.GameCQ.Item.Queries;
    using System.Collections.Generic;

    public class EquipmentViewModel
    {
        public ICollection<ItemFullViewModel> Items { get; set; }
    }
}
