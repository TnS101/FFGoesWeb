﻿namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    public class HeroMinViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public bool IsSelected { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public int Energy { get; set; }

        public int ProfessionEnergy { get; set; }

        public int PvPEnergy { get; set; }

        public string IconURL { get; set; }

        public int Mastery { get; set; }
    }
}
