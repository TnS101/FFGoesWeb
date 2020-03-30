namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System;
    using System.Collections.Generic;

    public class Material : IMaterial
    {
        public Material()
        {
            this.MaterialInventories = new HashSet<MaterialInventory>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }
    }
}
