namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class ArmorCheck
    {
        public void Check(Item item, int slotNumber, string classUsable, int regularStatNumber)
        {
            if (slotNumber == 0)
            {
                item.Slot = "Helmet";
            }
            else if (slotNumber == 1)
            {
                item.Slot = "Chestplate";
            }
            else if (slotNumber == 2)
            {
                item.Slot = "Shoulder";
            }
            else if (slotNumber == 3)
            {
                item.Slot = "Bracer";
            }
            else if (slotNumber == 4)
            {
                item.Slot = "Boots";
            }
            else if (slotNumber == 5)
            {
                item.Slot = "Leggings";
            }
            else if (slotNumber == 6)
            {
                item.Slot = "Gloves";
            }
            item.Name = $"{classUsable}'s {item.Slot} LVL : {regularStatNumber}";
        }
    }
}
