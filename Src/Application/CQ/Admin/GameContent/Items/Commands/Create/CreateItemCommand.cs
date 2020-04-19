namespace Application.CQ.Admin.GameContent.Items.Commands.Create
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

        public double ResistanceValue { get; set; }

        public string Slot { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImagePath { get; set; }

        public int FuelCount { get; set; }

        public string RelatedMaterials { get; set; }

        public bool IsRefineable { get; set; }

        public bool IsDisolveable { get; set; }

        public bool IsCraftable { get; set; }

        public int Durability { get; set; }
    }
}
