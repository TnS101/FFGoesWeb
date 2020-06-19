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

        public string BoxType { get; set; }

        public bool RequiresKey { get; set; }

        public int RewardAmplifier { get; set; }

        public int FuelCount { get; set; }

        public string RelatedMaterials { get; set; }

        public string MaterialDiversity { get; set; }

        public int Durability { get; set; }

        public string MaterialType { get; set; }

        public int ToolId { get; set; }
    }
}
