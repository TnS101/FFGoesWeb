namespace Domain.Contracts.Items.AdditionalTypes
{
    public interface IBaseItem : IItem
    {
        string Slot { get; set; }

        int Level { get; set; }

        string ClassType { get; set; }

        string ImagePath { get; set; }

        int Stamina { get; set; }

        int Strength { get; set; }

        int Agility { get; set; }

        int Intellect { get; set; }

        int Spirit { get; set; }

        int BuyPrice { get; set; }

        int SellPrice { get; set; }

        string Type { get; set; }
    }
}
