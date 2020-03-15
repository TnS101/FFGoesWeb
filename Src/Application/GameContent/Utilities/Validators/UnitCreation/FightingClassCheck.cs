namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.UnitCreation
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
    using global::Application.GameCQ.Unit.Queries;

    public class FightingClassCheck
    {
        public UnitFullViewModel Check(UnitFullViewModel player, string fightingClass)
        {
            StatIncrement statIncrement = new StatIncrement();

            if (fightingClass == "Warrior")
            {
                Warrior warrior = new Warrior();
                statIncrement.Increment(warrior, player);
            }

            if (fightingClass == "Mage")
            {
                Mage mage = new Mage();
                statIncrement.Increment(mage, player);
            }

            if (fightingClass == "Paladin")
            {
                Paladin paladin = new Paladin();
                statIncrement.Increment(paladin, player);
            }

            if (fightingClass == "Necroid")
            {
                Necroid necroid = new Necroid();
                statIncrement.Increment(necroid, player);
            }

            if (fightingClass == "Hunter")
            {
                Hunter hunter = new Hunter();
                statIncrement.Increment(hunter, player);
            }

            if (fightingClass == "Rogue")
            {
                Rogue rogue = new Rogue();
                statIncrement.Increment(rogue, player);
            }

            if (fightingClass == "Naturalist")
            {
                Naturalist naturalist = new Naturalist();
                statIncrement.Increment(naturalist, player);
            }

            if (fightingClass == "Priest")
            {
                Priest priest = new Priest();
                statIncrement.Increment(priest, player);
            }

            if (fightingClass == "Shaman")
            {
                Shaman shaman = new Shaman();
                statIncrement.Increment(shaman, player);
            }
            return player;
        }
    }
}
