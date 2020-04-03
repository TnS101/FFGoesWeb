namespace Domain.Entities.Game.Units
{
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using System;
    using System.Collections.Generic;

    public class Hero
    {
        public Hero()
        {
            this.Level = 1;
            this.XPCap = 100;
            this.GoldAmount = 100;
            this.Energy = 30;
            this.ProfessionEnergy = 10;
            this.PvPEnergy = 15;
            this.Id = Guid.NewGuid().ToString();
            this.IsSelected = false;
            this.EnergyChanges = new HashSet<EnergyChange>();
        }

        public string Id { get; set; }

        public int FightingClassId { get; set; }

        public FightingClass FightingClass { get; set; }

        public string EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int? ProfessionId { get; set; }

        public Profession Profession { get; set; }

        public string Name { get; set; }

        public string ClassType { get; set; }

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

        public double ResistanceValue { get; set; }

        public double CurrentResistanceValue { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public int GoldAmount { get; set; }

        public int Mastery { get; set; }

        public string ImageURL { get; set; }

        public bool IsSelected { get; set; }

        public int Energy { get; set; }

        public int PvPEnergy { get; set; }

        public int PvPPoints { get; set; }

        public string IconURL { get; set; }

        public int GearScore { get; set; }

        public ICollection<EnergyChange> EnergyChanges { get; set; }
    }
}
