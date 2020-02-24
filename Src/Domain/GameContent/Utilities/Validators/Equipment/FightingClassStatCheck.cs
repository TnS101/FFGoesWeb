namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class FightingClassStatCheck
    {
        public void Check(Item item, string classUsable, int fightingClassStatNumber)
        {
            if (classUsable == "Hunter")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (classUsable == "Mage")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (classUsable == "Naturalist")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (classUsable == "Necroid")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (classUsable == "Paladin")
            {
                item.Strength = fightingClassStatNumber;
            }
            else if (classUsable == "Priest")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (classUsable == "Rogue")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (classUsable == "Shaman")
            {
                item.Stamina = fightingClassStatNumber;
            }
            else if (classUsable == "Warrior")
            {
                item.Strength = fightingClassStatNumber;
            }
        }
    }
}
