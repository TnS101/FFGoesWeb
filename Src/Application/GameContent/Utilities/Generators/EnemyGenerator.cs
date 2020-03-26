namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators
{
    using System;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
    using global::Application.GameCQ.Unit.Queries;
    using global::Domain.Entities.Game;

    public class EnemyGenerator
    {
        public EnemyGenerator()
        {
        }

        public async Task<Unit> Generate(int playerLevel)
        {
            Unit enemy = new Unit { Type = "Enemy", Level = playerLevel };
            StatIncrement statIncrement = new StatIncrement();
            var rng = new Random();
            int enemyNumber = rng.Next(0, 26);

            if (enemyNumber >= 0 && enemyNumber <= 5)
            {
                Beast beast = new Beast();
                statIncrement.Increment(beast, enemy);
            }

            if (enemyNumber >= 6 && enemyNumber <= 10)
            {
                Reptile reptile = new Reptile();
                statIncrement.Increment(reptile, enemy);
            }

            if (enemyNumber >= 11 && enemyNumber <= 14)
            {
                Zombie zombie = new Zombie();
                statIncrement.Increment(zombie, enemy);
            }

            if (enemyNumber >= 15 && enemyNumber <= 18)
            {
                Skeleton skeleton = new Skeleton();
                statIncrement.Increment(skeleton, enemy);
            }

            if (enemyNumber == 19 || enemyNumber == 20)
            {
                Wyrm wyrm = new Wyrm();
                statIncrement.Increment(wyrm, enemy);
            }

            if (enemyNumber == 21 || enemyNumber == 22)
            {
                Giant giant = new Giant();
                statIncrement.Increment(giant, enemy);
            }

            if (enemyNumber == 23 || enemyNumber == 24)
            {
                Gryphon gryphon = new Gryphon();
                statIncrement.Increment(gryphon, enemy);
            }

            if (enemyNumber == 25)
            {
                Saint saint = new Saint();
                statIncrement.Increment(saint, enemy);
            }

            if (enemyNumber == 26)
            {
                Demon demon = new Demon();
                statIncrement.Increment(demon, enemy);
            }

            enemy.Name = enemy.ClassType;

            await this.RarityRng(enemy);

            return enemy;
        }

        private async Task RarityRng(Unit enemy)
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
                enemy.Race = string.Empty;
            }
        }
    }
}
