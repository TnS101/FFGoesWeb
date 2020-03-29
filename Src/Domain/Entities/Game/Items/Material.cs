namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Material : IMaterial
    {
        public Material()
        {
            this.MaterialInventories = new HashSet<MaterialInventories>();
        }

        public int Id { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public ICollection<MaterialInventories> MaterialInventories { get; set; }
    }
}
