namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class EscapeOption
    {
        public EscapeOption()
        {
        }

        public void Escape(UnitFullViewModel hero)
        {
            double xpLoss = hero.XP * 0.1;

            if (hero.XP < 0)
            {
                hero.XP = 0;
            }

            hero.XP -= xpLoss;
        }
    }
}
