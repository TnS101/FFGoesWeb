namespace Domain.GameContent.Utilities.Looting
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Generators;

    public class Loot
    {
        private readonly ItemGenerator itemGenerator = new ItemGenerator();
        public Loot()
        {
        }

        public void ItemLoot(Unit player) 
        {
            player.Items.Add(itemGenerator.Generate(player));
        }
    }
}
