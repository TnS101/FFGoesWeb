namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Generators;

    public class GeneratorHandler
    {
        public GeneratorHandler()
        {
        }

        public EnemyGenerator EnemyGenerator { get; set; } = new EnemyGenerator();

        public ItemGenerator ItemGenerator { get; set; } = new ItemGenerator();

        public TreasureGenerator TreasureGenerator { get; set; } = new TreasureGenerator();

        public TreasureKeyGenerator TreasureKeyGenerator { get; set; } = new TreasureKeyGenerator();
    }
}
