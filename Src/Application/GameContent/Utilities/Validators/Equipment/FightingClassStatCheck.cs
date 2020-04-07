namespace Application.GameContent.Utilities.Validators.Equipment
{
    using Domain.Contracts.Items.AdditionalTypes;

    public class FightingClassStatCheck
    {
        public void Check(IBaseItem item, string classUsable, int fightingClassStatNumber)
        {
            if (classUsable.Contains(','))
            {
                this.MultipleClassCheck(item, classUsable, fightingClassStatNumber);
            }
            else
            {
                this.SingleClassCheck(item, classUsable, fightingClassStatNumber);
            }
        }

        private void MultipleClassCheck(IBaseItem item, string classUsable, int fightingClassStatNumber)
        {
            string primaryUsable = classUsable.Split(',')[0];

            if (primaryUsable == "Hunter")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (primaryUsable == "Mage")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (primaryUsable == "Naturalist")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (primaryUsable == "Necroid")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (primaryUsable == "Paladin")
            {
                item.Strength = fightingClassStatNumber;
            }
            else if (primaryUsable == "Priest")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (primaryUsable == "Rogue")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (primaryUsable == "Shaman")
            {
                item.Stamina = fightingClassStatNumber;
            }
            else if (primaryUsable == "Warrior")
            {
                item.Strength = fightingClassStatNumber;
            }
        }

        private void SingleClassCheck(IBaseItem item, string classUsable, int fightingClassStatNumber)
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
