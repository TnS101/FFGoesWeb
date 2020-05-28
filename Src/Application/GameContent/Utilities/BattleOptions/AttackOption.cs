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
                    if (target.Type == "Player")
                    {
                        target.CurrentArmorValue -= 0.3 * target.CurrentArmorValue;
                    }
                    else
                    {
                        target.CurrentArmorValue -= 0.7 * target.CurrentArmorValue;
                    }
                }
                else
                {
                    target.CurrentHP -= damage - target.CurrentArmorValue;
                }
            }
        }
    }
}
