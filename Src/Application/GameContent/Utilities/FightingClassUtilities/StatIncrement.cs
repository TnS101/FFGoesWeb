namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using Domain.Entities.Game.Units;

    public class StatIncrement
    {
        public StatIncrement()
        {
        }

        public void Increment(FightingClass fightingClass, Hero hero)
        {
            hero.ClassType = fightingClass.Type;
            hero.MaxHP = fightingClass.MaxHP;
            hero.CurrentHP = fightingClass.MaxHP;
            hero.HealthRegen = fightingClass.HealthRegen;
            hero.CurrentHealthRegen = fightingClass.HealthRegen;
            hero.MaxMana = fightingClass.MaxMana;
            hero.CurrentMana = fightingClass.MaxMana;
            hero.ManaRegen = fightingClass.ManaRegen;
            hero.CurrentManaRegen = fightingClass.ManaRegen;
            hero.AttackPower = fightingClass.AttackPower;
            hero.CurrentAttackPower = fightingClass.AttackPower;
            hero.MagicPower = fightingClass.MagicPower;
            hero.CurrentMagicPower = fightingClass.MagicPower;
            hero.ArmorValue = fightingClass.ArmorValue;
            hero.CurrentArmorValue = fightingClass.ArmorValue;
            hero.ResistanceValue = fightingClass.ResistanceValue;
            hero.CurrentResistanceValue = fightingClass.ResistanceValue;
            hero.CritChance = fightingClass.CritChance;
            hero.CurrentCritChance = fightingClass.CritChance;
            hero.ImagePath = fightingClass.ImagePath.ToString();
            hero.IconPath = fightingClass.IconPath.ToString();
        }

        public void MonsterIncrement(Monster baseMonster, Monster monster)
        {
            int step = this.StepCalculator(monster.Level);

            monster.Id = baseMonster.Id;
            monster.Name = baseMonster.Name;
            monster.MaxHP = baseMonster.MaxHP + (step * 11);
            monster.HealthRegen = baseMonster.HealthRegen + (step * 1.15);
            monster.MaxMana = baseMonster.MaxMana + (step * 11);
            monster.ManaRegen = baseMonster.ManaRegen + (step * 1.1);
            monster.AttackPower = baseMonster.AttackPower + (step * 2.22);
            monster.MagicPower = baseMonster.MagicPower + (step * 2.5);
            monster.ArmorValue = baseMonster.ArmorValue + (step * 1);
            monster.ResistanceValue = baseMonster.ResistanceValue + (step * 1.2);
            monster.CritChance = baseMonster.CritChance + (monster.Level * 0.04);
            monster.Type = baseMonster.Type;
            monster.ImagePath = baseMonster.ImagePath.ToString();

            // Stat Set
            monster.CurrentHP = monster.MaxHP;
            monster.CurrentHealthRegen = monster.HealthRegen;
            monster.CurrentMana = monster.MaxMana;
            monster.CurrentManaRegen = monster.ManaRegen;
            monster.CurrentAttackPower = monster.AttackPower;
            monster.CurrentMagicPower = monster.MagicPower;
            monster.CurrentArmorValue = monster.ArmorValue;
            monster.CurrentResistanceValue = monster.ResistanceValue;
            monster.CurrentCritChance = monster.CritChance;
        }

        private int StepCalculator(int monsterLevel)
        {
            if (monsterLevel == 4)
            {
                return 6;
            }
            else if (monsterLevel == 5)
            {
                return 6 + monsterLevel - 1;
            }
            else if (monsterLevel > 5)
            {
                int repeatSteps = monsterLevel - 1;
                int step = 0;

                for (int i = 1; i <= repeatSteps; i++)
                {
                    step += monsterLevel - i;
                }

                return step;
            }
            else
            {
                return monsterLevel;
            }
        }
    }
}
