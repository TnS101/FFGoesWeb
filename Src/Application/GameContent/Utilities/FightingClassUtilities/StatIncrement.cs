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
            hero.ClassType = fightingClass.ClassType;
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
            hero.ImageURL = fightingClass.ImageURL.ToString();
            hero.IconURL = fightingClass.IconURL.ToString();
        }

        public void MonsterIncrement(Monster baseMonster, Monster monster)
        {
            int step = 0;

            if (monster.Level == 4)
            {
                step = monster.Level + 2;
            }
            else if (monster.Level == 5)
            {
                step = 2 * monster.Level;
            }
            else if (monster.Level > 5)
            {
                int lastStep = 6 + monster.Level - 1;
                step = monster.Level - 1 + lastStep;
            }
            else if (monster.Level > 6)
            {
                int lastStep = ;
            }
            else
            {
                step = monster.Level;
            }

            monster.Id = baseMonster.Id;
            monster.Name = baseMonster.Name;
            monster.MaxHP = baseMonster.MaxHP + (step * 11);
            monster.HealthRegen = baseMonster.HealthRegen + (step * 1.2);
            monster.MaxMana = baseMonster.MaxMana + (step * 11);
            monster.ManaRegen = baseMonster.ManaRegen + (step * 1.2);
            monster.AttackPower = baseMonster.AttackPower + (step * 2.22);
            monster.MagicPower = baseMonster.MagicPower + (step * 2.82);
            monster.ArmorValue = baseMonster.ArmorValue + (step * 1.15);
            monster.ResistanceValue = baseMonster.ResistanceValue + (step * 1.35);
            monster.CritChance = baseMonster.CritChance + (monster.Level * 0.04);

            monster.ImageURL = baseMonster.ImageURL.ToString();

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
    }
}
