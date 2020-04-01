namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class DefendOption
    {
        public void Defend(UnitFullViewModel caster)
        {
            double armorBonus = 0;
            if (caster.ClassType == null)
            {
                armorBonus += 0.30;
            }
            else
            {
                armorBonus += 0.40;
            }

            if (caster.CurrentHP <= 0)
            {
                caster.CurrentHP = 0;
            }

            caster.CurrentArmorValue += armorBonus * caster.CurrentArmorValue;
        }
    }
}
