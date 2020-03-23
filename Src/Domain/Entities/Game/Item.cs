namespace Domain.Entities.Game
{
    using FinalFantasyTryoutGoesWeb.Domain.Contracts;
    using System;

    public class Item : IItem
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intellect { get; set; }

        public int Spirit { get; set; }

        public double AttackPower { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public string Slot { get; set; }

        public int SellingPrice { get; set; }
    }
}
