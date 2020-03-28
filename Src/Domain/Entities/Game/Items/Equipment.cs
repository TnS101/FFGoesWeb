namespace Domain.Entities.Game.Items
{
    using Domain.Base;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(int heroId)
        {
            this.Items = new HashSet<Item>();
            this.Capacity = 50;
            this.HeroId = heroId;
        }

        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Capacity { get; set; }

        public bool HelmetSlot { get; set; }

        public bool ChestplateSlot { get; set; }

        public bool ShoulderSlot { get; set; }

        public bool BracerSlot { get; set; }

        public bool BootsSlot { get; set; }

        public bool LeggingsSlot { get; set; }

        public bool TrinketSlot { get; set; }

        public bool GlovesSlot { get; set; }

        public bool WeaponSlot { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
