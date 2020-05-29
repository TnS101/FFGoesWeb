namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;

    public class CritCheck
    {
        public double Check(double damage, double critChance)
        {
            int critNumber = new Random().Next(0, 100);

            if (critNumber >= 0 && critNumber < Math.Floor(critChance))
            {
                return damage *= 2;
            }

            return damage;
        }
    }
}
