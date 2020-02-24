namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class DefendOption
    {
        public void Defend(Unit target)
        {
            double armorBonus = 0;
            if (target.Type == "Enemy")
            {
                armorBonus += 0.22;
            }
            else
            {
                armorBonus += 0.40;
            }
            if (target.CurrentHP <= 0)
            {
                target.CurrentHP = 0;
            }
            target.CurrentArmorValue += armorBonus * target.CurrentArmorValue;
        }
    }
}
