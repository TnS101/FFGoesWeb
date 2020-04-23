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

        public double NewResistanceValue { get; set; }

        public string Slot { get; set; }

        public int NewBuyPrice { get; set; }

        public int NewSellPrice { get; set; }

        public string NewRarity { get; set; }

        public string NewRelatedMaterials { get; set; }

        public string NewMaterialDiversity { get; set; }

        public string NewMaterialType { get; set; }

        public int NewReward { get; set; }

        public int NewDurability { get; set; }

        public int NewFuelCount { get; set; }

        public int NewToolId { get; set; }
    }
}
