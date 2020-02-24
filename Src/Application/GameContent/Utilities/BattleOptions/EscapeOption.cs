namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using System;

    public class EscapeOption
    {
        public void Escape(Unit player)
        {
            var escapeRNG = new Random();
            double goldLoss = player.GoldAmount * 0.2;
            player.GoldAmount -= (int)goldLoss;
        }
    }
}
