namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameContent.Utilities.Looting;
    using global::Application.GameCQ.Unit.Queries;

    public class EndOption
    {
        public void End(UnitFullViewModel player, UnitFullViewModel enemy, Loot loot)
        {
            player.XP += enemy.MaxHP / 10;
            loot.ItemLoot(player);

            // Stat reset
            player.CurrentAttackPower = player.AttackPower;
            player.CurrentMagicPower = player.MagicPower;
            player.CurrentArmorValue = player.ArmorValue;
            player.CurrentRessistanceValue = player.RessistanceValue;
            player.CurrentHealthRegen = player.HealthRegen;
            player.CurrentManaRegen = player.ManaRegen;
            player.CurrentCritChance = player.CritChance;
        }
    }
}
