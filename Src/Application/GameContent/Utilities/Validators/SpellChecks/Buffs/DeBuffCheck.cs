namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.Buffs
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using global::Domain.Entities.Game;

    public class DeBuffCheck
    {
        public void Check(Unit caster, Unit target, double manaRequirment, double debuffEffect, string spellName, string deBuffType, ManaCheck manaCheck)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment) == true)
            {
                if (deBuffType == "Attack")
                {
                    if (target.CurrentAttackPower < debuffEffect)
                    {
                        target.CurrentAttackPower = 0;
                    }
                    else
                    {
                        target.CurrentAttackPower -= debuffEffect;
                    }
                }
                else if (deBuffType == "hRegen")
                {
                    if (target.CurrentHealthRegen < (int)debuffEffect)
                    {
                        target.CurrentHealthRegen = 0;
                    }
                    else
                    {
                        target.CurrentHealthRegen -= (int)debuffEffect;
                    }
                }
                else if (deBuffType == "mRegen")
                {
                    if (target.CurrentManaRegen < (int)debuffEffect)
                    {
                        target.CurrentManaRegen = 0;
                    }
                    else
                    {
                        target.CurrentManaRegen -= (int)debuffEffect;
                    }
                }
                else if (deBuffType == "Armor")
                {
                    if (target.CurrentArmorValue < debuffEffect)
                    {
                        target.CurrentArmorValue = 0;
                    }
                    else
                    {
                        target.CurrentArmorValue -= debuffEffect;
                    }
                }
                else if (deBuffType == "Res")
                {
                    if (target.CurrentRessistanceValue < debuffEffect)
                    {
                        target.CurrentRessistanceValue = 0;
                    }
                    else
                    {
                        target.CurrentRessistanceValue -= debuffEffect;
                    }
                }
                else if (deBuffType == "SelfHP")
                {
                    if (caster.CurrentHP > debuffEffect)
                    {
                        caster.CurrentHP -= debuffEffect;
                    }
                }
                else if (deBuffType == "Magic")
                {
                    if (target.CurrentMagicPower < debuffEffect)
                    {
                        target.CurrentMagicPower = 0;
                    }
                    else
                    {
                        target.CurrentMagicPower -= debuffEffect;
                    }
                }
            }
        }
    }
}
