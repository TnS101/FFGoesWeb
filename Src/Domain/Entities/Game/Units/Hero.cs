namespace Domain.Entities.Game.Units
{
    using Domain.Contracts.Units;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using System.Collections.Generic;

    public class Hero : IUnit
    {
        public Hero()
        {
            this.EnergyChanges = new HashSet<EnergyChange>();
            this.Hunger = 10;
            this.Thirst = 10;
            this.Happiness = 10;
            this.Level = 1;
            this.Type = "Player";
        }

        public long Id { get; set; }

        public int FightingClassId { get; set; }

        public FightingClass FightingClass { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int? ProfessionId { get; set; }

        public Profession Profession { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public int ProfessionLevel { get; set; }

        public int ProfessionEnergy { get; set; }

        public double ProffesionXP { get; set; }

        public double ProffesionXPCap { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double HealthRegen { get; set; }

        public double CurrentHealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double ManaRegen { get; set; }

        public double CurrentManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double CurrentAttackPower { get; set; }

        public double MagicPower { get; set; }

        public double CurrentMagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double CurrentArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CurrentResistanceValue { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public bool IsConfused { get; set; }

        public bool IsProvoked { get; set; }

        public bool IsSilenced { get; set; }

        public bool IsStunned { get; set; }

        public bool IsBlinded { get; set; }

        public int CoinAmount { get; set; }

        public int Mastery { get; set; }

        public int Hunger { get; set; }

        public int Thirst { get; set; }

        public int Happiness { get; set; }

        public string IconPath { get; set; }

        public string ImagePath { get; set; }

        public bool IsSelected { get; set; }

        public int Energy { get; set; }

        public int PvPEnergy { get; set; }

        public int PvPPoints { get; set; }

        public int EquipmentScore { get; set; }

        public ICollection<EnergyChange> EnergyChanges { get; set; }

        public string Type { get; set; }
    }
}
