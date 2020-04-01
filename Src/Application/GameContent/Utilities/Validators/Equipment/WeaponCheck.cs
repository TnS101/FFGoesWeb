namespace Application.GameContent.Utilities.Validators.Equipment
{
    public class WeaponCheck
    {
        public string[] Check(int fightingClassNumber, string fightingClassType, string weaponName, string imageURL)
        {
            if (fightingClassNumber == 0)
            {
                fightingClassType = "Hunter";
                weaponName = "Bow";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/2/25/Inv_bow_2h_crossbow_pandariaquest_b_01.png?version=39ef329a636b6b20101f58d95b052ae1";
            }
            else if (fightingClassNumber == 1)
            {
                fightingClassType = "Mage";
                weaponName = "Orb";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/e/e3/Inv_offhand_1h_artifactfelomelorn_d_05.png?version=08259f7865dcd745e1ed25493084ad16";

            }
            else if (fightingClassNumber == 2)
            {
                fightingClassType = "Naturalist";
                weaponName = "Branch";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/f/f6/Inv_offhand_1h_panprog_b_01.png?version=813ea93dc3cf6a55ddd2738921e4664f";
            }
            else if (fightingClassNumber == 3)
            {
                fightingClassType = "Necroid";
                weaponName = "Skull";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/6/64/Inv_offhand_1h_artifactskulloferedar_d_05.png?version=dcaafe0c3fede58ec3337af475bf4ebf";
            }
            else if (fightingClassNumber == 4)
            {
                fightingClassType = "Paladin";
                weaponName = "Hammer";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/c/ce/Inv_hammer_2h_maul_a_01_hd.png?version=2bfd8096c02f7be3e649a75aaff9e53a";
            }
            else if (fightingClassNumber == 5)
            {
                fightingClassType = "Priest";
                weaponName = "Staff";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/c/c9/Inv_staff_32.png?version=9c90f83ed280fc5eecf8f4873b9ffa74";
            }
            else if (fightingClassNumber == 6)
            {
                fightingClassType = "Rogue";
                weaponName = "Dagger";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/1/14/Inv_knife_1h_panprog_b_02.png?version=f8ae8095c58b44e82dab6370b441cd67";
            }
            else if (fightingClassNumber == 7)
            {
                fightingClassType = "Shaman";
                weaponName = "Club";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/0/0b/Inv_mace_15.png?version=c444074b161e67419bdf6d196f576e5a";
            }
            else if (fightingClassNumber == 8)
            {
                fightingClassType = "Warrior";
                weaponName = "Sword";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/d/d9/Inv_sword_14.png?version=7123f079f5c9c6af52d66e3f835d7c31";
            }

            return new[] { fightingClassType, weaponName };
        }
    }
}
