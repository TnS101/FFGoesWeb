namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Domain.Contracts;

    public class Unit : IUnit
    {
        public Unit()
        {
        }
        public int Id { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public int HealthRegen { get; set; }

        public int CurrentHealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public int ManaRegen { get; set; }

        public int CurrentManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double CurrentAttackPower { get; set; }

        public double MagicPower { get; set; }

        public double CurrentMagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double CurrentArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public double CurrentRessistanceValue { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public int GoldAmount { get; set; }

        public string ImageURL { get; set; }
    }
}
