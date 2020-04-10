namespace Application.GameContent.Utilities.BattleOptions
{
    using Domain.Base;

    public class DefendOption
    {
        public void Defend(Unit caster)
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

            caster.CurrentArmorValue += armorBonus * caster.ArmorValue;
        }
    }
}
