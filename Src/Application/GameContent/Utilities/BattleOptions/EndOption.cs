namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Looting;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class EndOption
    {
        public void End(Unit player, Unit enemy, Loot loot)
        {
            player.XP += enemy.MaxHP / 10;
            loot.ItemLoot(player);
            //Stat reset
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
