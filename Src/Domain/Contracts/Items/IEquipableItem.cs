namespace Domain.Contracts.Items
{
    public interface IEquipableItem
    {
        ulong Id { get; set; }

        string Name { get; set; }

        string Slot { get; set; }

        int Level { get; set; }

        string ClassType { get; set; }

        int Agility { get; set; }

        int Stamina { get; set; }

        int Intellect { get; set; }

        int Strength { get; set; }

        int Spirit { get; set; }

        string ImagePath { get; set; }

        string Type { get; set; }

        int BuyPrice { get; set; }

        int SellPrice { get; set; }
    }
}
