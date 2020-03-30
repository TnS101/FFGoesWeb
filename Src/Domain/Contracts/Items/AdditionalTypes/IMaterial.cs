namespace Domain.Contracts.Items.AdditionalTypes
{
    public interface IMaterial : IItem
    {
        int SellPrice { get; set; }

        int BuyPrice { get; set; }
    }
}
