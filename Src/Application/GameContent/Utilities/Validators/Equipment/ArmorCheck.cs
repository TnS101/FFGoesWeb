namespace Application.GameContent.Utilities.Validators.Equipment
{
    using Domain.Contracts.Items.AdditionalTypes;

    public class ArmorCheck
    {
        public void Check(IBaseItem item, int slotNumber, string classUsable, int regularStatNumber)
        {
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

            item.Name = $"{classUsable}'s {item.Slot} LVL : {regularStatNumber}";
        }
    }
}
