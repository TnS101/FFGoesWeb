namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items;

    public class Card : IEquipableItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slot { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public string Effect { get; set; }

        public int EffectPower { get; set; }

        public bool IsPositive { get; set; }

        public int Agility { get; set; }

        public int Stamina { get; set; }

        public int Intellect { get; set; }

        public int Strength { get; set; }

        public int Spirit { get; set; }

        public string ImagePath { get; set; }

        public string MaterialType { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }
    }
}
