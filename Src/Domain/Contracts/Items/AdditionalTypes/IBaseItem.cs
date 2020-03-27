namespace Domain.Contracts.Items.AdditionalTypes
{
    using Domain.Entities.Game.Items;

    public interface IBaseItem
    {
        int Id { get; }

        string Name { get; }

        string Slot { get; }

        int Level { get; }

        string ClassType { get; }

        int Stamina { get; }

        int Strength { get; }

        int Agility { get; }

        int Intellect { get; }

        int Spirit { get; }

        int InventoryId { get; }

        Inventory Inventory { get; }

        int EquipmentId { get; }

        Equipment Equipment { get; }
    }
}
