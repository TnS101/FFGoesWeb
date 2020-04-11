namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;

    public class WeaponCheck
    {
        public WeaponCheck()
        {
        }

        public string[] Check(int fightingClassNumber, string fightingClassType, string weaponName, string imageURL, Random rng)
        {
            int classOrder;

            if (fightingClassNumber == 0)
            {
                weaponName = "Bow";
                fightingClassType = "Hunter";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/2/25/Inv_bow_2h_crossbow_pandariaquest_b_01.png?version=39ef329a636b6b20101f58d95b052ae1";
            }
            else if (fightingClassNumber == 1)
            {
                classOrder = rng.Next(0, 3);

                if (classOrder == 0)
                {
                    fightingClassType = "Mage,Necroid,Naturalist";
                }
                else if (classOrder == 1)
                {
                    fightingClassType = "Necroid,Mage,Naturalist";
                }
                else
                {
                    fightingClassType = "Naturalist,Mage,Naturalist";
                }

                weaponName = "Orb";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/e/e3/Inv_offhand_1h_artifactfelomelorn_d_05.png?version=08259f7865dcd745e1ed25493084ad16";

            }
            else if (fightingClassNumber == 2)
            {
                classOrder = rng.Next(0, 2);

                weaponName = "Branch";
                if (classOrder == 0)
                {
                    fightingClassType = "Naturalist,Priest";
                }
                else
                {
                    fightingClassType = "Priest,Naturalist";
                }

                imageURL = "https://gamepedia.cursecdn.com/wowpedia/f/f6/Inv_offhand_1h_panprog_b_01.png?version=813ea93dc3cf6a55ddd2738921e4664f";
            }
            else if (fightingClassNumber == 3)
            {
                weaponName = "Skull";
                fightingClassType = "Necroid";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/6/64/Inv_offhand_1h_artifactskulloferedar_d_05.png?version=dcaafe0c3fede58ec3337af475bf4ebf";
            }
            else if (fightingClassNumber == 4)
            {
                classOrder = rng.Next(0, 3);

                weaponName = "Hammer";
                if (classOrder == 0)
                {
                    fightingClassType = "Paladin,Warrior,Shaman";
                }
                else if (classOrder == 1)
                {
                    fightingClassType = "Shaman,Warrior,Paladin";
                }
                else
                {
                    fightingClassType = "Warrior,Shaman,Paladin";
                }

                imageURL = "https://gamepedia.cursecdn.com/wowpedia/c/ce/Inv_hammer_2h_maul_a_01_hd.png?version=2bfd8096c02f7be3e649a75aaff9e53a";
            }
            else if (fightingClassNumber == 5)
            {
                classOrder = rng.Next(0, 4);

                if (classOrder == 0)
                {
                    fightingClassType = "Priest,Mage,Necroid,Naturalist";
                }
                else if (classOrder == 1)
                {
                    fightingClassType = "Mage,Priest,Necroid,Naturalist";
                }
                else if (classOrder == 2)
                {
                    fightingClassType = "Necroid,Mage,Priest,Naturalist";
                }
                else
                {
                    fightingClassType = "Naturalist,Mage,Necroid,Priest";
                }

                weaponName = "Staff";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/c/c9/Inv_staff_32.png?version=9c90f83ed280fc5eecf8f4873b9ffa74";
            }
            else if (fightingClassNumber == 6)
            {
                weaponName = "Dagger";
                fightingClassType = "Rogue";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/1/14/Inv_knife_1h_panprog_b_02.png?version=f8ae8095c58b44e82dab6370b441cd67";
            }
            else if (fightingClassNumber == 7)
            {
                classOrder = rng.Next(0, 2);

                if (classOrder == 0)
                {
                    fightingClassType = "Shaman,Warrior";
                }
                else
                {
                    fightingClassType = "Warrior,Shaman";
                }

                weaponName = "Club";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/0/0b/Inv_mace_15.png?version=c444074b161e67419bdf6d196f576e5a";
            }
            else if (fightingClassNumber == 8)
            {
                classOrder = rng.Next(0, 2);

                if (classOrder == 0)
                {
                    fightingClassType = "Warrior,Paladin";
                }
                else
                {
                    fightingClassType = "Paladin,Warrior";
                }

                weaponName = "Sword";
                imageURL = "https://gamepedia.cursecdn.com/wowpedia/d/d9/Inv_sword_14.png?version=7123f079f5c9c6af52d66e3f835d7c31";
            }

            return new[] { fightingClassType, weaponName };
        }
    }
}
