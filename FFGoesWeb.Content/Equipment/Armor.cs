namespace FinalFantasyTryoutGoesWeb.GameContent.Equipment
{
    using FinalFantasyTryoutGoesWeb.Data.Entities;

    public class Armor : Item
    {
        public Armor(string name,string slot, int level
            , string classType, int stamina
            , int strength, int intellect, int agility
            , int spirit, double armorValue, double ressistanceValue)
        {
            this.Name = name;
            this.Slot = slot;
            this.Level = level;
            this.ClassType = classType;
            this.Stamina = stamina;
            this.Strength = strength;
            this.Intellect = intellect;
            this.Agility = agility;
            this.Spirit = spirit;
            this.ArmorValue = armorValue;
            this.RessistanceValue = ressistanceValue;
        }
    }
}
