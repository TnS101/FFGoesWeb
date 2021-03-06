﻿namespace Domain.Entities.Game.Units.OneToOne
{
    public class MonsterRarity
    {
        public MonsterRarity()
        {
        }

        public int Id { get; set; }

        public string MonsterName { get; set; }

        public double StatAmplifier { get; set; }

        public string Rarity { get; set; }

        public string ImagePath { get; set; }
    }
}
