namespace Application.CQ.Admin.Items.Commands.Create
{
    using MediatR;

    public class CreateItemCommand : IRequest<string>
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intellect { get; set; }

        public int Spirit { get; set; }

        public double AttackPower { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public string Slot { get; set; }

        public string Type { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string ImageURL { get; set; }
    }
}
