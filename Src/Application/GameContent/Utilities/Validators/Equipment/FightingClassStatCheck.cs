namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using Domain.Contracts.Items;

    public class FightingClassStatCheck
    {
        public void Check(IEquipableItem item, int fightingClassNumber, int fightingClassStatNumber, Random rng)
        {
            if (item.Slot == "Weapon")
            {
                this.WeaponCheck(item, fightingClassNumber, rng);
            }
            else if (item.Slot == "Trinket" || item.Slot == "Relic")
            {
                item.ClassType = "Any";
            }
            else
            {
                this.ArmorCheck(item, rng);
            }

            if (item.Slot != "Trinket")
            {
                this.ClassCheck(item, fightingClassStatNumber);
            }
        }

        private void ArmorCheck(IEquipableItem item, Random rng)
        {
            int slotNumber = rng.Next(0, 7);

            int typeNumber = rng.Next(0, 3);

            int usableOrder = rng.Next(0, 3);
            if (slotNumber == 0)
            {
                item.Slot = "Helmet";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/archive/7/75/20180822163637%21Inv_helm_armor_voidelf_d_01.png?version=7de9cbcce2a59bd472985129e6af7e81";
            }
            else if (slotNumber == 1)
            {
                item.Slot = "Chestplate";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/b/bb/Inv_chest_samurai.png?version=f5631859203ea398622deb50e0c95847";
            }
            else if (slotNumber == 2)
            {
                item.Slot = "Shoulder";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/e/e4/Inv_shoulder_13.png?version=87153248a8d840ad34383507d2b11638";
            }
            else if (slotNumber == 3)
            {
                item.Slot = "Bracer";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/8/87/Inv_bracer_22b.png?version=d5d42675bba996ac4daa904874398a4a";
            }
            else if (slotNumber == 4)
            {
                item.Slot = "Boots";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/6/6d/Inv_boots_armor_dwarf_d_01.png?version=47cf645fde9bd16e155aa222da62a49d";
            }
            else if (slotNumber == 5)
            {
                item.Slot = "Leggings";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/7/70/Inv_pant_zandalariclothes_a_01.png?version=d9a4d072389d2349d57517642222169d";
            }
            else if (slotNumber == 6)
            {
                item.Slot = "Gloves";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/c/ca/Inv_glove_mail_draenordungeon_c_01.png?version=30cf3357b49e25c4c79bbdfbf2828de5";
            }

            string firstClassOrder;
            string seccondClassOrder;
            string thirdClassOrder;

            if (typeNumber == 0)
            {
                item.MaterialType = "Cloth";
                firstClassOrder = "Mage,Necroid,Priest";
                seccondClassOrder = "Necroid,Mage,Priest";
                thirdClassOrder = "Priest,Necroid,Priest";
            }
            else if (typeNumber == 1)
            {
                item.MaterialType = "Leather";
                firstClassOrder = "Hunter,Rouge,Naturalist";
                seccondClassOrder = "Rouge,Hunter,Naturalist";
                thirdClassOrder = "Naturalist,Hunter,Rouge";
            }
            else
            {
                item.MaterialType = "Metal";
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

        private void WeaponCheck(IEquipableItem item, int fightingClassNumber, Random rng)
        {
            int classOrder;

            if (fightingClassNumber == 0)
            {
                item.Name = "Bow";
                item.MaterialType = "Wood";
                item.ClassType = "Hunter";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/2/25/Inv_bow_2h_crossbow_pandariaquest_b_01.png?version=39ef329a636b6b20101f58d95b052ae1";
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
                item.MaterialType = "Glass";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/e/e3/Inv_offhand_1h_artifactfelomelorn_d_05.png?version=08259f7865dcd745e1ed25493084ad16";
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
                item.MaterialType = "Wood";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/f/f6/Inv_offhand_1h_panprog_b_01.png?version=813ea93dc3cf6a55ddd2738921e4664f";
            }
            else if (fightingClassNumber == 3)
            {
                item.Name = "Skull";
                item.MaterialType = "Bone";
                item.ClassType = "Necroid";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/6/64/Inv_offhand_1h_artifactskulloferedar_d_05.png?version=dcaafe0c3fede58ec3337af475bf4ebf";
            }
            else if (fightingClassNumber == 4)
            {
                classOrder = rng.Next(0, 3);

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

                item.Name = "Hammer";
                item.MaterialType = "Stone";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/c/ce/Inv_hammer_2h_maul_a_01_hd.png?version=2bfd8096c02f7be3e649a75aaff9e53a";
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
                item.MaterialType = "Wood";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/c/c9/Inv_staff_32.png?version=9c90f83ed280fc5eecf8f4873b9ffa74";
            }
            else if (fightingClassNumber == 6)
            {
                item.Name = "Dagger";
                item.MaterialType = "Metal";
                item.ClassType = "Rogue";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/1/14/Inv_knife_1h_panprog_b_02.png?version=f8ae8095c58b44e82dab6370b441cd67";
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
                item.MaterialType = "Stone";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/0/0b/Inv_mace_15.png?version=c444074b161e67419bdf6d196f576e5a";
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
                item.MaterialType = "Metal";
                item.ImagePath = "https://gamepedia.cursecdn.com/wowpedia/d/d9/Inv_sword_14.png?version=7123f079f5c9c6af52d66e3f835d7c31";
            }
        }

        private void ClassCheck(IEquipableItem item, int fightingClassStatNumber)
        {
            string classUsable = item.ClassType;

            if (item.ClassType.Contains(','))
            {
                classUsable = item.ClassType.Split(',')[0];
            }

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
            else
            {
                item.Strength = fightingClassStatNumber;
            }
        }
    }
}
