namespace Domain.Entities.Game.Units
{
    using Domain.Contracts.Units;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units.ManyToMany;
    using System.Collections.Generic;

    public class Hero : IUnit
    {
        public Hero()
        {
            this.Hunger = 10;
            this.Thirst = 10;
            this.Happiness = 10;
            this.Level = 1;
            this.Type = "Player";
            this.InventoryCapacity = 50;

            this.EnergyChanges = new HashSet<EnergyChange>();
            this.HeroTalents = new HashSet<HeroTalents>();

            this.ArmorEquipment = new HashSet<ArmorEquipment>();
            this.WeaponEquipment = new HashSet<WeaponEquipment>();
            this.TrinketEquipment = new HashSet<TrinketEquipment>();
            this.RelicEquipment = new HashSet<RelicEquipment>();
            this.CardEquipment = new HashSet<CardEquipment>();

            this.ArmorInventories = new HashSet<ArmorInventory>();
            this.WeaponInventories = new HashSet<WeaponInventory>();
            this.TrinketInventories = new HashSet<TrinketInventory>();
            this.RelicInventories = new HashSet<RelicInventory>();
            this.CardInventories = new HashSet<CardInventory>();
            this.ConsumeableInventories = new HashSet<ConsumeableInventory>();
            this.LootBoxInventories = new HashSet<LootBoxInventory>();
            this.LootKeyInventories = new HashSet<LootKeyInventory>();
            this.MaterialInventories = new HashSet<MaterialInventory>();
            this.ToolInventories = new HashSet<ToolInventory>();
            this.ToyInventories = new HashSet<ToyInventory>();
        }

        public long Id { get; set; }

        public int FightingClassId { get; set; }

        public FightingClass FightingClass { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int? ProfessionId { get; set; }

        public Profession Profession { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public int InventoryCapacity { get; set; }

        public bool WeaponSlot { get; set; }

        public bool TrinketSlot { get; set; }

        public bool RelicSlot { get; set; }

        public bool HelmetSlot { get; set; }

        public bool ShoulderSlot { get; set; }

        public bool BracerSlot { get; set; }

        public bool BootsSlot { get; set; }

        public bool LeggingsSlot { get; set; }

        public bool ChestplateSlot { get; set; }

        public bool GlovesSlot { get; set; }

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

        public int ConfusionDuration { get; set; }

        public int ProvokeDuration { get; set; }

        public int SilenceDuration { get; set; }

        public int StunDuration { get; set; }

        public int BlindDuration { get; set; }

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

        public string Type { get; set; }

        public ICollection<EnergyChange> EnergyChanges { get; set; }

        public ICollection<HeroTalents> HeroTalents { get; set; }

        public ICollection<ArmorEquipment> ArmorEquipment { get; set; }

        public ICollection<WeaponEquipment> WeaponEquipment { get; set; }

        public ICollection<TrinketEquipment> TrinketEquipment { get; set; }

        public ICollection<RelicEquipment> RelicEquipment { get; set; }

        public ICollection<CardEquipment> CardEquipment { get; set; }

        public ICollection<ArmorInventory> ArmorInventories { get; set; }

        public ICollection<WeaponInventory> WeaponInventories { get; set; }

        public ICollection<TrinketInventory> TrinketInventories { get; set; }

        public ICollection<RelicInventory> RelicInventories { get; set; }

        public ICollection<CardInventory> CardInventories { get; set; }

        public ICollection<ConsumeableInventory> ConsumeableInventories { get; set; }

        public ICollection<LootBoxInventory> LootBoxInventories { get; set; }

        public ICollection<LootKeyInventory> LootKeyInventories { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }

        public ICollection<ToolInventory> ToolInventories { get; set; }

        public ICollection<ToyInventory> ToyInventories { get; set; }
    }
}
