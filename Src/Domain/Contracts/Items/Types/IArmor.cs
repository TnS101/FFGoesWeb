namespace Domain.Contracts.Items.Types
{
    using Domain.Contracts.Items.AdditionalTypes;

    public interface IArmor : IBaseItem, ISellableItem
    {
        double ArmorValue { get; }

        double RessistanceValue { get; }
    }
}
