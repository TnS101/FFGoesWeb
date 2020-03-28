namespace Application.GameContent.Utilities.Validators.SpellChecks.Effects
{
    using Domain.Base;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class PositiveEffectCheck
    {
        public PositiveEffectCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment,
            double possitiveEffect, string possitiveEffectType, ManaCheck manaCheck)
        {
            if (manaCheck.EffectManaCheck(caster, manaRequirment))
            {
                if (possitiveEffectType == "Attack")
                {
                    caster.CurrentAttackPower += possitiveEffect;
                }
                else if (possitiveEffectType == "hRegen")
                {
                    caster.CurrentHealthRegen += (int)possitiveEffect;
                }
                else if (possitiveEffectType == "mRegen")
                {
                    caster.CurrentManaRegen += (int)possitiveEffect;
                }
                else if (possitiveEffectType == "Armor")
                {
                    caster.CurrentArmorValue += possitiveEffect;
                }
                else if (possitiveEffectType == "Res")
                {
                    caster.CurrentArmorValue += possitiveEffect;
                }
                else if (possitiveEffectType == "Crit")
                {
                    caster.CurrentCritChance += possitiveEffect;
                }
                else if (possitiveEffectType == "Mana")
                {
                    if (caster.CurrentMana <= possitiveEffect)
                    {
                        caster.CurrentMana += possitiveEffect;
                    }
                }
                else if (possitiveEffectType == "Magic")
                {
                    caster.CurrentMagicPower += possitiveEffect;
                }
                else if (possitiveEffectType == "Health")
                {
                    if (caster.CurrentHP <= possitiveEffect)
                    {
                        caster.CurrentHP += possitiveEffect;
                    }
                }
            }
        }
    }
}
