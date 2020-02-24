namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Generators
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.TreasureKeys;
    using System;
    using System.Linq;

    public class TreasureGenerator
    {
        public string Generate(Unit player, Random rng, string option)
        {
            int treasureNumber = rng.Next(0, 10);
            string treasureType = "";
            int goldRewards = 0;

            if (treasureNumber >= 0 && treasureNumber < 5)
            {
                treasureType = "Bronze";
                goldRewards = 15;
            }
            else if (treasureNumber >= 5 && treasureNumber < 8)
            {
                treasureType = "Silver";
                goldRewards = 30;
            }
            else
            {
                treasureType = "Gold";
                goldRewards = 100;
            }

            if (option == "open")
            {
                TreasureKey treasureKey = (TreasureKey)player.Items.FirstOrDefault(i => i.Name.Split(' ')[0] == treasureType);
                player.GoldAmount += goldRewards;
                player.Items.Remove(treasureKey);
                return "TreasureOpen";
            }
            else if (option == "pass")
            {
                return "TreasurePass";
            }

            return "";
        }
    }
}
