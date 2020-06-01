namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    public class UnitPartialViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public double MaxHP { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public bool IsSelected { get; set; }
    }
}
