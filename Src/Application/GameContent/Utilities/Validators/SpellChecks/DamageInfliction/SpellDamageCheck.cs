namespace Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction
{
    using Application.GameContent.Utilities.Validators.Battle;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Contracts.Units;

    public class SpellDamageCheck
    {
        public void Check(IUnit caster, IUnit target, double manaRequirment, double damage, ManaCheck manaCheck, string damageType, double resistanceAffect)
        {
            damage = new CritCheck().Check(damage, caster.CritChance);

            if (manaCheck.SpellManaCheck(caster, manaRequirment))
            {
                switch (damageType)
                {
                    case "Physical": this.TakeDamage(target, damage, target.CurrentArmorValue * resistanceAffect, 0.3, 0); break;
                    case "Magical": this.TakeDamage(target, damage, target.CurrentResistanceValue * resistanceAffect, 0, 0.35); break;
                    case "Mixed": this.TakeDamage(target, damage, (target.CurrentResistanceValue * resistanceAffect / 2) + (target.CurrentArmorValue * resistanceAffect / 2), 0.15, 0.2); break;
                }
            }
        }

        private void TakeDamage(IUnit target, double damage, double protection, double armorReduce, double resistanceReduce)
        {
            if (damage > protection)
            {
                target.CurrentHP -= damage - protection;
            }
            else
            {
                target.CurrentArmorValue -= target.CurrentArmorValue * armorReduce;
                target.CurrentResistanceValue -= target.CurrentResistanceValue * resistanceReduce;
            }
        }
    }
}
