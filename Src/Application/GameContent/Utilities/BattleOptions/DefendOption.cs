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
            if (caster.Type == "Player")
            {
                caster.CurrentArmorValue += 0.2 * caster.ArmorValue;
            }
            else
            {
                caster.CurrentArmorValue += 0.4 * caster.ArmorValue;
            }

            if (caster.CurrentHP <= 0)
            {
                caster.CurrentHP = 0;
            }
        }
    }
}
