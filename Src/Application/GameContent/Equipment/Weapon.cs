namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Equipment
{
    using global::Domain.Entities.Game;

    public class Weapon : Item
    {
        public Weapon(string name, string slot, int level, string classType, double attackPower, int stamina,
            int strength, int intellect, int agility, int spirit)
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
            this.AttackPower = attackPower;
        }
    }
}
