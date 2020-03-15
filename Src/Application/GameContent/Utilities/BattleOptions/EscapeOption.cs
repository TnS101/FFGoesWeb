namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using global::Application.GameCQ.Unit.Queries;

    public class EscapeOption
    {
        public void Escape(UnitFullViewModel player)
        {
            double xpLoss = player.XP * 0.1;

            if (player.XP < 0)
            {
                player.XP = 0;
            }
            player.XP -= xpLoss;
        }
    }
}
