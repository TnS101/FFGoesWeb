namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.Equipment
{
    public class WeaponCheck
    {
        public string[] Check(int fightingClassNumber, string fightingClassType, string weaponName)
        {
            if (fightingClassNumber == 0)
            {
                fightingClassType = "Hunter";
                weaponName = "Bow";
            }
            else if (fightingClassNumber == 1)
            {
                fightingClassType = "Mage";
                weaponName = "Orb";
            }
            else if (fightingClassNumber == 2)
            {
                fightingClassType = "Naturalist";
                weaponName = "Branch";
            }
            else if (fightingClassNumber == 3)
            {
                fightingClassType = "Necroid";
                weaponName = "Skull";
            }
            else if (fightingClassNumber == 4)
            {
                fightingClassType = "Paladin";
                weaponName = "Hammer";
            }
            else if (fightingClassNumber == 5)
            {
                fightingClassType = "Priest";
                weaponName = "Staff";
            }
            else if (fightingClassNumber == 6)
            {
                fightingClassType = "Rogue";
                weaponName = "Dagger";
            }
            else if (fightingClassNumber == 7)
            {
                fightingClassType = "Shaman";
                weaponName = "Club";
            }
            else if (fightingClassNumber == 8)
            {
                fightingClassType = "Warrior";
                weaponName = "Sword";
            }

            return new[] { fightingClassType, weaponName };
        }
    }
}
