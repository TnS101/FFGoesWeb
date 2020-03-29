namespace Application.GameContent.Handlers
{
    using Application.GameContent.Utilities.Generators;

    public class GeneratorHandler
    {
        public GeneratorHandler()
        {
        }

        public EnemyGenerator EnemyGenerator { get; set; } = new EnemyGenerator();

        public ItemGenerator ItemGenerator { get; set; } = new ItemGenerator();
    }
}
