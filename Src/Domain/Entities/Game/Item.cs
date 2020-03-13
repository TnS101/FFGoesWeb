namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    using FinalFantasyTryoutGoesWeb.Domain.Contracts;

    public class Item : IItem
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

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
    }
}
