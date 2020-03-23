namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using global::Application.GameCQ.Unit.Queries;

    public class AttackOption
    {
        public void Attack(UnitFullViewModel caster, UnitFullViewModel target)
        {
            if (target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue >= caster.CurrentAttackPower)
                {
                    double armorPenalty = 0;
                    if (target.Type == "Enemy")
                    {
                        armorPenalty += 0.80;
                    }
                    else
                    {
                        armorPenalty += 0.50;
                    }

                    target.CurrentArmorValue -= armorPenalty * target.CurrentArmorValue;
                }
                else
                {
                    target.CurrentHP -= caster.CurrentAttackPower - target.CurrentArmorValue;
                }
            }
            else
            {
                target.CurrentHP = 0;
            }
        }
    }
}
