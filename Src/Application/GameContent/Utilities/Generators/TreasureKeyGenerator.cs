namespace Application.GameContent.Utilities.Generators
{
    using System;
    using Domain.Entities.Game.Items;

    public class TreasureKeyGenerator
    {
        public TreasureKey GenerateTreasureKey(TreasureKey templateKey)
        {
            var rng = new Random();
            int generationNumber = rng.Next(0, 10);
            if (generationNumber >= 0 && generationNumber < 5)
            {
                templateKey.Name = "Bronze";
                return templateKey;
            }
            else if (generationNumber >= 5 && generationNumber < 8)
            {
                templateKey.Name = "Silver";
                return templateKey;
            }
            else
            {
                templateKey.Name = "Gold";
                return templateKey;
            }
        }
    }
}
