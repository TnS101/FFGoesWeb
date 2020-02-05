namespace FinalFantasyTryoutGoesWeb.Data.Contracts
{
    public interface IItem
    {
        string Name { get; }

        int Level { get; }

        string ClassType { get; }

        int Stamina { get; }

        int Strength { get; }

        int Agility { get; }

        int Intellect { get; }

        int Spirit { get; }

        string Slot { get; }
    }
}
