namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Looting
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class Loot
    {
        private readonly ItemGenerator itemGenerator = new ItemGenerator();
        public Loot()
        {
        }

        public void ItemLoot(Unit player) 
        {
            player.Inventory.Items.Add(itemGenerator.Generate(player));
        }
    }
}
