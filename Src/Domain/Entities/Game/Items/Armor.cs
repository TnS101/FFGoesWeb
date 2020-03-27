namespace Domain.Entities.Game.Items
{
    using Domain.Base;

    public class Armor : Item
    {
        public override int Id { get; set; }

        public override double ArmorValue { get; set; }

        public override double RessistanceValue { get; set; }

        public override string Name { get; set; }

        public override string Slot { get; set; }

        public override int Level { get; set; }

        public override string ClassType { get; set; }

        public override int Stamina { get; set; }

        public override int Strength { get; set; }

        public override int Agility { get; set; }

        public override int Intellect { get; set; }

        public override int Spirit { get; set; }

        public override int InventoryId { get; set; }

        public override Inventory Inventory { get; set; }

        public override int EquipmentId { get; set; }

        public override Equipment Equipment { get; set; }

        public override int SellPrice { get; set; }

        public override int BuyPrice { get; set; }
    }
}
