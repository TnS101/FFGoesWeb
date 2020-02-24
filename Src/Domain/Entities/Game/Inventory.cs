namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        public int UnitId { get; set; }

        public Unit Unit { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
