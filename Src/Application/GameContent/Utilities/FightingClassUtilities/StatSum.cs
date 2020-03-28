namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using Domain.Base;

    public class StatSum
    {
        public StatSum()
        {
        }

        public void Sum(Unit player)
        {
            foreach (var item in player.Equipment.Items)
            {
                player.AttackPower += item.Agility;
                player.MagicPower += item.Intellect;
                player.ManaRegen += item.Spirit;
                player.MaxHP += item.Stamina * 5;
                player.AttackPower += item.Strength;

                if (item.Slot == "Weapon")
                {
                    player.AttackPower += item.AttackPower;
                }
                else if (item.Slot != "Trinket")
                {
                    player.ArmorValue += item.ArmorValue;
                    player.RessistanceValue += item.RessistanceValue;
                }
            }
        }
    }
}
