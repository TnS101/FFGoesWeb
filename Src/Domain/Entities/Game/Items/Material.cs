﻿namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Material : IMaterial
    {
        public Material()
        {
            this.MaterialInventories = new HashSet<MaterialInventory>();
        }

        public int Id { get; set; }

        public int? ToolId { get; set; }

        public Tool Tool { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public int FuelCount { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string RelatedMaterials { get; set; }

        public string ImageURL { get; set; }

        public bool IsRefineable { get; set; }

        public bool IsDisolveable { get; set; }

        public bool IsCraftable { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }
    }
}
