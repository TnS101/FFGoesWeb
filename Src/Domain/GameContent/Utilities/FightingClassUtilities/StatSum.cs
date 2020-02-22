namespace FinalFantasyTryoutGoesWeb.GameContent.Utilities.FightingClassUtilites
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class StatSum
    {
        public void Sum(Unit player)
        {
            foreach (var item in player.Items)
            {
                player.ArmorValue += item.ArmorValue;
                player.RessistanceValue += item.RessistanceValue;
                player.AttackPower += item.Strength;
                player.AttackPower += item.AttackPower;
                player.AttackPower += item.Agility;
                player.MagicPower += item.Intellect;
                player.ManaRegen += item.Spirit;
                player.MaxHP += item.Stamina * 5;
            }
        }
    }
}
