namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System;
    using Domain.Contracts.Items.AdditionalTypes;

    public class ArmorCheck
    {
        public void Check(IBaseItem item, Random rng, string classUsable, int regularStatNumber)
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
                classUsable = firstClassOrder;
            }
            else if (usableOrder == 1)
            {
                classUsable = seccondClassOrder;
            }
            else
            {
                classUsable = thirdClassOrder;
            }

            item.Name = $"{classUsable.Split(',')[0]}'s {item.Slot} LVL : {regularStatNumber}";
        }
    }
}
