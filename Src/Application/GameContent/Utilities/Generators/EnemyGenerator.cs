namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::Application.GameCQ.Unit.Queries;
    using System;

    public class EnemyGenerator
    {
        public EnemyGenerator()
        {
        }

        public UnitFullViewModel Generate(UnitPartialViewModel player)
        {
            UnitFullViewModel enemy = new UnitFullViewModel { Type = "Enemy", Level = player.Level};
            StatIncrement statIncrement = new StatIncrement();
            var rng = new Random();
            int enemyNumber = rng.Next(0, 26);

            if (enemyNumber >= 0 && enemyNumber <= 5)
            {
                Beast beast = new Beast();
                statIncrement.Increment(beast, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber >= 6 && enemyNumber <= 10)
            {
                Reptile reptile = new Reptile();
                statIncrement.Increment(reptile, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber >= 11 && enemyNumber <= 14)
            {
                Zombie zombie = new Zombie();
                statIncrement.Increment(zombie, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber >= 15 && enemyNumber <= 18)
            {
                Skeleton skeleton = new Skeleton();
                statIncrement.Increment(skeleton, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber == 19 || enemyNumber == 20)
            {
                Wyrm wyrm = new Wyrm();
                statIncrement.Increment(wyrm, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber == 21 || enemyNumber == 22)
            {
                Giant giant = new Giant();
                statIncrement.Increment(giant, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber == 23 || enemyNumber == 24)
            {
                Gryphon gryphon = new Gryphon();
                statIncrement.Increment(gryphon, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber == 25)
            {
                Saint saint = new Saint();
                statIncrement.Increment(saint, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }

            if (enemyNumber == 26)
            {
                Demon demon = new Demon();
                statIncrement.Increment(demon, enemy);
                enemy.Name = enemy.ClassType;
                this.RarityRng(enemy);
            }
            return enemy;
        }

        private void RarityRng(UnitFullViewModel enemy)
        {
            var rng = new Random();
            int number = rng.Next(1, 11);
            if (number == 1)
            {
                enemy.Race = "Heroic";
                enemy.MaxHP += 0.3 * enemy.MaxHP;
                enemy.AttackPower += 0.3 * enemy.AttackPower;
                enemy.MagicPower += 0.3 * enemy.MagicPower;
                enemy.ArmorValue += 0.3 * enemy.ArmorValue;
                enemy.CurrentHP += 0.3 * enemy.CurrentHP;
                enemy.CurrentAttackPower += 0.3 * enemy.CurrentAttackPower;
                enemy.CurrentMagicPower += 0.3 * enemy.CurrentMagicPower;
                enemy.CurrentArmorValue += 0.3 * enemy.CurrentArmorValue;
            }
            else if (number == 2 || number == 3 || number == 4)
            {
                enemy.Race = "Rare";
                enemy.MaxHP += 0.15 * enemy.MaxHP;
                enemy.AttackPower += 0.15 * enemy.AttackPower;
                enemy.MagicPower += 0.15 * enemy.MagicPower;
                enemy.ArmorValue += 0.15 * enemy.ArmorValue;
                enemy.CurrentHP += 0.15 * enemy.CurrentHP;
                enemy.CurrentAttackPower += 0.15 * enemy.CurrentAttackPower;
                enemy.CurrentMagicPower += 0.15 * enemy.CurrentMagicPower;
                enemy.CurrentArmorValue += 0.15 * enemy.CurrentArmorValue;
            }
            else
            {
                enemy.Race = "";
            }
        }
    }
}
