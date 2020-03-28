namespace Application.CQ.Admin.GameContent.Items.Commands.Update
{
    using MediatR;

    public class UpdateItemCommand : IRequest<string>
    {
        public string Id { get; set; }

        public string NewName { get; set; }

        public int NewLevel { get; set; }

        public string NewClassType { get; set; }

        public int NewStamina { get; set; }

        public int NewStrength { get; set; }

        public int NewAgility { get; set; }

        public int NewIntellect { get; set; }

        public int NewSpirit { get; set; }

        public double NewAttackPower { get; set; }

        public double NewArmorValue { get; set; }

        public double NewRessistanceValue { get; set; }

        public string Slot { get; set; }

        public int NewBuyPrice { get; set; }

        public int NewSellPrice { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }
    }
}
