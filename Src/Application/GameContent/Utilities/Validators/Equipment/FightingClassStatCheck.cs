namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using Domain.Contracts.Items.AdditionalTypes;

    public class FightingClassStatCheck
    {
        public FightingClassStatCheck()
        {
        }

        public void Check(IBaseItem item, int fightingClassStatNumber, int fightingClassNumber, Random rng)
        {
            if (item.Type == "Weapon")
            {
                this.WeaponCheck(item, fightingClassNumber, rng);
            }
            else if (item.Type == "Armor")
            {
                this.ArmorCheck(item, rng);
            }
            else
            {
                item.ClassType = "Any";
            }

            if (item.ClassType != "Any")
            {
                if (item.ClassType.Contains(','))
                {
                    this.MultipleClassCheck(item, fightingClassStatNumber);
                }
                else
                {
                    this.SingleClassCheck(item, fightingClassStatNumber);
                }
            }
        }

        private void ArmorCheck(IBaseItem item, Random rng)
        {
            int slotNumber = rng.Next(0, 7);

            int typeNumber = rng.Next(0, 3);

            int usableOrder = rng.Next(0, 3);
            if (slotNumber == 0)
            {
                item.Slot = "Helmet";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/archive/7/75/20180822163637%21Inv_helm_armor_voidelf_d_01.png?version=7de9cbcce2a59bd472985129e6af7e81";
            }
            else if (slotNumber == 1)
            {
                item.Slot = "Chestplate";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/b/bb/Inv_chest_samurai.png?version=f5631859203ea398622deb50e0c95847";
            }
            else if (slotNumber == 2)
            {
                item.Slot = "Shoulder";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/e/e4/Inv_shoulder_13.png?version=87153248a8d840ad34383507d2b11638";
            }
            else if (slotNumber == 3)
            {
                item.Slot = "Bracer";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/8/87/Inv_bracer_22b.png?version=d5d42675bba996ac4daa904874398a4a";
            }
            else if (slotNumber == 4)
            {
                item.Slot = "Boots";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/6/6d/Inv_boots_armor_dwarf_d_01.png?version=47cf645fde9bd16e155aa222da62a49d";
            }
            else if (slotNumber == 5)
            {
                item.Slot = "Leggings";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/7/70/Inv_pant_zandalariclothes_a_01.png?version=d9a4d072389d2349d57517642222169d";
            }
            else if (slotNumber == 6)
            {
                item.Slot = "Gloves";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/c/ca/Inv_glove_mail_draenordungeon_c_01.png?version=30cf3357b49e25c4c79bbdfbf2828de5";
            }

            string thirdClassOrder;
            string firstClassOrder;
            string seccondClassOrder;

            if (typeNumber == 0)
            {
                item.Type = "Cloth";
                firstClassOrder = "Mage,Necroid,Priest";
                seccondClassOrder = "Necroid,Mage,Priest";
                thirdClassOrder = "Priest,Necroid,Priest";
            }
            else if (typeNumber == 1)
            {
                item.Type = "Leather";
                firstClassOrder = "Hunter,Rouge,Naturalist";
                seccondClassOrder = "Rouge,Hunter,Naturalist";
                thirdClassOrder = "Naturalist,Hunter,Rouge";
            }
            else
            {
                item.Type = "Metal";
                firstClassOrder = "Warrior,Paladin,Shaman";
                seccondClassOrder = "Paladin,Shaman,Warrior";
                thirdClassOrder = "Shaman,Warrior,Paladin";
            }

            if (usableOrder == 0)
            {
                item.ClassType = firstClassOrder;
            }
            else if (usableOrder == 1)
            {
                item.ClassType = seccondClassOrder;
            }
            else
            {
                item.ClassType = thirdClassOrder;
            }

            item.Name = $"{item.ClassType.Split(',')[0]}'s {item.Slot}";
        }

        private void WeaponCheck(IBaseItem item, int fightingClassNumber, Random rng)
        {
            int classOrder;

            if (fightingClassNumber == 0)
            {
                item.Name = "Bow";
                item.ClassType = "Hunter";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/2/25/Inv_bow_2h_crossbow_pandariaquest_b_01.png?version=39ef329a636b6b20101f58d95b052ae1";
            }
            else if (fightingClassNumber == 1)
            {
                classOrder = rng.Next(0, 3);

                if (classOrder == 0)
                {
                    item.ClassType = "Mage,Necroid,Naturalist";
                }
                else if (classOrder == 1)
                {
                    item.ClassType = "Necroid,Mage,Naturalist";
                }
                else
                {
                    item.ClassType = "Naturalist,Mage,Naturalist";
                }

                item.Name = "Orb";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/e/e3/Inv_offhand_1h_artifactfelomelorn_d_05.png?version=08259f7865dcd745e1ed25493084ad16";
            }
            else if (fightingClassNumber == 2)
            {
                classOrder = rng.Next(0, 2);

                if (classOrder == 0)
                {
                    item.ClassType = "Naturalist,Priest";
                }
                else
                {
                    item.ClassType = "Priest,Naturalist";
                }

                item.Name = "Branch";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/f/f6/Inv_offhand_1h_panprog_b_01.png?version=813ea93dc3cf6a55ddd2738921e4664f";
            }
            else if (fightingClassNumber == 3)
            {
                item.Name = "Skull";
                item.ClassType = "Necroid";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/6/64/Inv_offhand_1h_artifactskulloferedar_d_05.png?version=dcaafe0c3fede58ec3337af475bf4ebf";
            }
            else if (fightingClassNumber == 4)
            {
                classOrder = rng.Next(0, 3);

                item.Name = "Hammer";
                if (classOrder == 0)
                {
                    item.ClassType = "Paladin,Warrior,Shaman";
                }
                else if (classOrder == 1)
                {
                    item.ClassType = "Shaman,Warrior,Paladin";
                }
                else
                {
                    item.ClassType = "Warrior,Shaman,Paladin";
                }

                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/c/ce/Inv_hammer_2h_maul_a_01_hd.png?version=2bfd8096c02f7be3e649a75aaff9e53a";
            }
            else if (fightingClassNumber == 5)
            {
                classOrder = rng.Next(0, 4);

                if (classOrder == 0)
                {
                    item.ClassType = "Priest,Mage,Necroid,Naturalist";
                }
                else if (classOrder == 1)
                {
                    item.ClassType = "Mage,Priest,Necroid,Naturalist";
                }
                else if (classOrder == 2)
                {
                    item.ClassType = "Necroid,Mage,Priest,Naturalist";
                }
                else
                {
                    item.ClassType = "Naturalist,Mage,Necroid,Priest";
                }

                item.Name = "Staff";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/c/c9/Inv_staff_32.png?version=9c90f83ed280fc5eecf8f4873b9ffa74";
            }
            else if (fightingClassNumber == 6)
            {
                item.Name = "Dagger";
                item.ClassType = "Rogue";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/1/14/Inv_knife_1h_panprog_b_02.png?version=f8ae8095c58b44e82dab6370b441cd67";
            }
            else if (fightingClassNumber == 7)
            {
                classOrder = rng.Next(0, 2);

                if (classOrder == 0)
                {
                    item.ClassType = "Shaman,Warrior";
                }
                else
                {
                    item.ClassType = "Warrior,Shaman";
                }

                item.Name = "Club";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/0/0b/Inv_mace_15.png?version=c444074b161e67419bdf6d196f576e5a";
            }
            else if (fightingClassNumber == 8)
            {
                classOrder = rng.Next(0, 2);

                if (classOrder == 0)
                {
                    item.ClassType = "Warrior,Paladin";
                }
                else
                {
                    item.ClassType = "Paladin,Warrior";
                }

                item.Name = "Sword";
                item.ImageURL = "https://gamepedia.cursecdn.com/wowpedia/d/d9/Inv_sword_14.png?version=7123f079f5c9c6af52d66e3f835d7c31";
            }
        }

        private void MultipleClassCheck(IBaseItem item, int fightingClassStatNumber)
        {
            string primaryUsable = item.ClassType.Split(',')[0];

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

        private void SingleClassCheck(IBaseItem item, int fightingClassStatNumber)
        {
            if (item.ClassType == "Hunter")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (item.ClassType == "Mage")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (item.ClassType == "Naturalist")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (item.ClassType == "Necroid")
            {
                item.Intellect = fightingClassStatNumber;
            }
            else if (item.ClassType == "Paladin")
            {
                item.Strength = fightingClassStatNumber;
            }
            else if (item.ClassType == "Priest")
            {
                item.Spirit = fightingClassStatNumber;
            }
            else if (item.ClassType == "Rogue")
            {
                item.Agility = fightingClassStatNumber;
            }
            else if (item.ClassType == "Shaman")
            {
                item.Stamina = fightingClassStatNumber;
            }
            else
            {
                item.Strength = fightingClassStatNumber;
            }
        }
    }
}
