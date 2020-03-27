namespace Domain.Contracts.Items.AdditionalTypes
{
    public interface ISellableItem
    {
        int Id { get; }

        string Name { get; }

        int SellPrice { get; }

        int BuyPrice { get; }
    }
}
