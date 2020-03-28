namespace Domain.Entities.Game.Items
{
    using Domain.Base;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(int heroId)
        {
            Items = new HashSet<Item>();
            this.HeroId = heroId;
        }

        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
