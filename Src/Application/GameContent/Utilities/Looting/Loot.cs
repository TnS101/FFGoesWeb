namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Looting
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using global::Application.GameCQ.Unit.Queries;

    public class Loot
    {
        private readonly ItemGenerator itemGenerator;

        public Loot()
        {
            this.itemGenerator = new ItemGenerator();
        }

        public void ItemLoot(UnitFullViewModel player)
        {
            player.Inventory.Items.Add(this.itemGenerator.Generate(player));
        }
    }
}
