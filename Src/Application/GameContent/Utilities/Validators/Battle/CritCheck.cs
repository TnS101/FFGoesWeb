namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;

    public class CritCheck
    {
        public CritCheck()
        {
        }

        public double Check(double power, double critChance)
        {
            Random rng = new Random();

            int critNumber = rng.Next(0, 100);

            if (critNumber >= 0 && critNumber < Math.Floor(critChance))
            {
                return power * 2;
            }
            else
            {
                return power;
            }
        }
    }
}
