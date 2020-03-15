namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Looting
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::Application.GameCQ.Unit.Queries;

    public class Loot
    {
        private readonly ItemGenerator itemGenerator;
        public Loot(ItemGenerator itemGenerator)
        {
            this.itemGenerator = itemGenerator;
        }

        public void ItemLoot(UnitFullViewModel player) 
        {
            player.Inventory.Items.Add(itemGenerator.Generate(player));
        }
    }
}
