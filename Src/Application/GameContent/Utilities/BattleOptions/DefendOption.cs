namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using global::Application.GameCQ.Unit.Queries;

    public class DefendOption
    {
        public void Defend(UnitFullViewModel target)
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
