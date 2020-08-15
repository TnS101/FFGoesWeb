namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Material
    {
        public Material()
        {
            this.MaterialInventories = new HashSet<MaterialInventory>();
        }

        public int Id { get; set; }

        public int? ToolId { get; set; }

        public Tool Tool { get; set; }

        public int FuelCount { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string RelatedMaterials { get; set; }

        public bool IsRefineable { get; set; }

        public bool IsDisolveable { get; set; }

        public bool IsCraftable { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public string Slot { get; set; }

        public string DroppedFrom { get; set; }

        public bool RequiresProfession { get; set; }

        public int Rarity { get; set; }

        public string ImagePath { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }
    }
}
