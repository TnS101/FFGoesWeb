namespace Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery
{
    public class MonsterFullViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MaxHP { get; set; }

        public int HealthRegen { get; set; }

        public double MaxMana { get; set; }

        public int ManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CritChance { get; set; }

        public string Description { get; set; }

        public string Zone { get; set; }

        public string Type { get; set; }
    }
}
