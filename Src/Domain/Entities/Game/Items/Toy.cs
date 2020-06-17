namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Toy
    {
        public Toy()
        {
            this.ToyInventories = new HashSet<ToyInventory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Charges { get; set; }

        public int HappinessReplenish { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public bool IsCraftable { get; set; }

        public string ImagePath { get; set; }

        public string Slot { get; set; }

        public ICollection<ToyInventory> ToyInventories { get; set; }
    }
}
