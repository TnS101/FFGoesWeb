namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class TreasureKey : ITreasure
    {
        public TreasureKey()
        {
            this.TreasureKeyInventories = new HashSet<TreasureKeyInventory>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public string ImageURL { get; set; }

        public ICollection<TreasureKeyInventory> TreasureKeyInventories { get; set; }
    }
}
