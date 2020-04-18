namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Tool
    {
        public Tool()
        {
            this.ToolInventories = new HashSet<ToolInventory>();
            this.Materials = new HashSet<Material>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public int BuyPrice { get; set; }

        public int Durability { get; set; }

        public bool IsCraftable { get; set; }

        public ICollection<ToolInventory> ToolInventories { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
