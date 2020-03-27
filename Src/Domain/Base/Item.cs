namespace Domain.Base
{
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items;

    public abstract class Item : IItem
    {
        public virtual int Id { get; set; }

        public virtual double ArmorValue { get; set; }

        public virtual double RessistanceValue { get; set; }

        public virtual double AttackPower { get; set; }

        public virtual string Name { get; set; }

        public virtual string Slot { get; set; }

        public virtual int Level { get; set; }

        public virtual string ClassType { get; set; }

        public virtual int Stamina { get; set; }

        public virtual int Strength { get; set; }

        public virtual int Agility { get; set; }

        public virtual int Intellect { get; set; }

        public virtual int Spirit { get; set; }

        public virtual int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual int SellPrice { get; set; }

        public virtual int BuyPrice { get; set; }
    }
}
