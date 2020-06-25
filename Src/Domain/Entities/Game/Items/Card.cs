namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Card : IEquipableItem
    {
        public Card()
        {
            this.CardEquipment = new HashSet<CardEquipment>();
            this.CardInventories = new HashSet<CardInventory>();
        }

        public long Id { get; set; }

        public int SpellId { get; set; }

        public Spell Spell { get; set; }

        public string Name { get; set; }

        public string Slot { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public string Condition { get; set; }

        public int Agility { get; set; }

        public int Stamina { get; set; }

        public int Intellect { get; set; }

        public int Strength { get; set; }

        public int Spirit { get; set; }

        public string ImagePath { get; set; }

        public string MaterialType { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public string Description { get; set; }

        public ICollection<CardInventory> CardInventories { get; set; }

        public ICollection<CardEquipment> CardEquipment { get; set; }
    }
}
