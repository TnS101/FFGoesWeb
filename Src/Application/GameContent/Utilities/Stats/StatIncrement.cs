namespace Application.GameContent.Utilities.Stats
{
    using Domain.Entities.Game.Units;

    public class StatIncrement
    {
        public void Increment(FightingClass fightingClass, Hero hero)
        {
            hero.FightingClassId = fightingClass.Id;
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
            int step = this.StepCalculation(monster.Level);

            monster.Id = baseMonster.Id;
            monster.Name = baseMonster.Name;
            monster.MaxHP = baseMonster.MaxHP + (step * 15);
            monster.HealthRegen = baseMonster.HealthRegen + (step * 1.5);
            monster.MaxMana = baseMonster.MaxMana + (step * 15.5);
            monster.ManaRegen = baseMonster.ManaRegen + (step * 1.5);
            monster.AttackPower = baseMonster.AttackPower + (step * 2.5);
            monster.MagicPower = baseMonster.MagicPower + (step * 3);
            monster.ArmorValue = baseMonster.ArmorValue + (step * 1.5);
            monster.ResistanceValue = baseMonster.ResistanceValue + (step * 1.8);
            monster.CritChance = baseMonster.CritChance + (monster.Level * 0.025);
            monster.Type = baseMonster.Type;
            monster.ImagePath = baseMonster.ImagePath.ToString();

            // Stat Set
            new StatReset().HardReset(monster);
        }

        private int StepCalculation(int monsterLevel)
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
