namespace Application.GameContent.Utilities.Looting
{
    using Application.GameContent.Utilities.Generators;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

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
