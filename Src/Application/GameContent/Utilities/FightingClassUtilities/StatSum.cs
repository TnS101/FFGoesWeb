namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class StatSum
    {
        public void Sum(Unit player)
        {
            foreach (var item in player.Inventory.Items)
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
