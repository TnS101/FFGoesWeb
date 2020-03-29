namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Treasure : ITreasure
    {
        public Treasure()
        {
            this.TreasureInventories = new HashSet<TreasureInventories>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }

        public ICollection<TreasureInventories> TreasureInventories { get; set; }
    }
}
