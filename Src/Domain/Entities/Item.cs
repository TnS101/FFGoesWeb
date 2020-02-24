namespace FinalFantasyTryoutGoesWeb.Domain.Entities
{
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Contracts;

    public class Item : IItem
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public Unit Unit { get; set; }

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
