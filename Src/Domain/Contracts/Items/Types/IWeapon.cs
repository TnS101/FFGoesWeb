namespace Domain.Contracts.Items.Types
{
    using global::Domain.Contracts.Items.AdditionalTypes;

    public interface IWeapon : IBaseItem, ISellableItem
    {
        double AttackPower { get; }
    }
}
