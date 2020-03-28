namespace Application.GameCQ.Equipment.Queries
{
    using System.Collections.Generic;
    using Application.GameCQ.Item.Queries;

    public class EquipmentViewModel
    {
        public ICollection<ItemFullViewModel> Items { get; set; }
    }
}
