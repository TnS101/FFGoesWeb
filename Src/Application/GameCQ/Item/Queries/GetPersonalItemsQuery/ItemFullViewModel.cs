namespace Application.GameCQ.Item.Queries
{
    using Application.Common.Mappings;
    using AutoMapper;

    public class ItemFullViewModel : IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Item, ItemFullViewModel>();
        }
    }
}
