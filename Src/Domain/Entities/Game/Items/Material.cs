namespace Domain.Entities.Game.Items
{
    using Domain.Base;

    public class Material : Item
    {
        public override int Id { get; set; }

        public override int SellPrice { get; set; }

        public override int BuyPrice { get; set; }

        public override string Name { get; set; }

        public override int InventoryId { get; set; }

        public override Inventory Inventory { get; set; }

        public override int EquipmentId { get; set; }

        public override Equipment Equipment { get; set; }
    }
}
