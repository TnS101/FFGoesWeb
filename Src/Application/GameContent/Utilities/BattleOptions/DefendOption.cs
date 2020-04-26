namespace Application.GameContent.Utilities.BattleOptions
{
    using Domain.Base;

    public class DefendOption
    {
        public DefendOption()
        {
        }

        public void Defend(Unit caster)
        {
            double armorBonus = 0;
            if (caster.Type == "Player")
            {
                armorBonus += 0.2;
            }
            else
            {
                armorBonus += 0.3;
            }

            if (caster.CurrentHP <= 0)
            {
                caster.CurrentHP = 0;
            }

            caster.CurrentArmorValue += armorBonus * caster.ArmorValue;
        }
    }
}
