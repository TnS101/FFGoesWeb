namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameContent.Utilities.Validators.Battle;
    using Domain.Base;

    public class AttackOption
    {
        private readonly CritCheck critCheck;

        public AttackOption()
        {
            this.critCheck = new CritCheck();
        }

        public void Attack(Unit caster, Unit target)
        {
            double damage = this.critCheck.Check(caster.CurrentAttackPower, caster.CritChance);

            if (target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue >= damage)
                {
                    double armorPenalty;
                    if (target.Type == "Player")
                    {
                        armorPenalty = 0.30;
                    }
                    else
                    {
                        armorPenalty = 0.70;
                    }

                    target.CurrentArmorValue -= armorPenalty * target.CurrentArmorValue;
                }
                else
                {
                    target.CurrentHP -= damage - target.CurrentArmorValue;
                }
            }
        }
    }
}
