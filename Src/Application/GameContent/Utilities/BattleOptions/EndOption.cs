namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class EndOption
    {
        public void End(UnitFullViewModel player, UnitFullViewModel enemy)
        {
            player.XP += enemy.MaxHP / 10;

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
