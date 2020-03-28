namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using global::Application.GameContent.Utilities.Generators;

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
