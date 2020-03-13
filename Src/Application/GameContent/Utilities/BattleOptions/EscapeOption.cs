namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using System;

    public class EscapeOption
    {
        public void Escape(Unit player)
        {
            var escapeRNG = new Random();
            double goldLoss = player.GoldAmount * 0.2;

            if (player.GoldAmount < 0)
            {
                player.GoldAmount = 0;
            }
            player.GoldAmount -= (int)goldLoss;
        }
    }
}
