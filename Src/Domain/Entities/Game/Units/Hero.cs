namespace Domain.Entities.Game.Units
{
    using Domain.Base;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units.ManyToMany;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Hero : Unit
    {
        public Hero()
        {
            this.EnergyChanges = new HashSet<EnergyChange>();
            this.HeroSpells = new HashSet<HeroSpell>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public override string Name { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public override int Level { get; set; }

        public int ProfessionLevel { get; set; }

        public int ProfessionEnergy { get; set; }

        public double ProffesionXP { get; set; }

        public double ProffesionXPCap { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public override double MaxHP { get; set; }

        public override double CurrentHP { get; set; }

        public override double HealthRegen { get; set; }

        public override double CurrentHealthRegen { get; set; }

        public override double MaxMana { get; set; }

        public override double CurrentMana { get; set; }

        public override double ManaRegen { get; set; }

        public override double CurrentManaRegen { get; set; }

        public override double AttackPower { get; set; }

        public override double CurrentAttackPower { get; set; }

        public override double MagicPower { get; set; }

        public override double CurrentMagicPower { get; set; }

        public override double ArmorValue { get; set; }

        public override double CurrentArmorValue { get; set; }

        public override double ResistanceValue { get; set; }

        public override double CurrentResistanceValue { get; set; }

        public override double CritChance { get; set; }

        public override double CurrentCritChance { get; set; }

        public override int GoldAmount { get; set; }

        public int Mastery { get; set; }

        public string IconPath { get; set; }

        public override string ImagePath { get; set; }

        public bool IsSelected { get; set; }

        public int Energy { get; set; }

        public int PvPEnergy { get; set; }

        public int PvPPoints { get; set; }

        public int EquipmentScore { get; set; }

        public ICollection<HeroSpell> HeroSpells { get; set; }

        public ICollection<EnergyChange> EnergyChanges { get; set; }
    }
}
