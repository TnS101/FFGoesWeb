namespace Domain.Contracts.Items.AdditionalTypes
{
    public interface IMaterial : IItem
    {
        int Id { get; }

        int SellPrice { get; set; }

        int BuyPrice { get; set; }
    }
}
