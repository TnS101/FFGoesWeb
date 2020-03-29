namespace Domain.Contracts.Items.AdditionalTypes
{
    public interface ITreasure : IItem
    {
        string Rarity { get; set; }
    }
}
