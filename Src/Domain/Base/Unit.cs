namespace Domain.Base
{
    using global::Domain.Contracts.Units;
    using global::Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public abstract class Unit : IUnit
    {
        public Unit()
        {
            this.Level = 1;
            this.XPCap = 100;
            this.GoldAmount = 100;
            this.IsSelected = false;
            this.Energy = 10;
        }
        public virtual int Id { get; set; }

        public virtual int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual string UserId { get; set; }

        public virtual AppUser User { get; set; }

        public virtual int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual string ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual string Name { get; set; }

        public virtual string Type { get; set; }

        public virtual string ClassType { get; set; }

        public virtual string Race { get; set; }

        public virtual int Level { get; set; }

        public virtual double XP { get; set; }

        public virtual double XPCap { get; set; }

        public virtual double MaxHP { get; set; }

        public virtual double CurrentHP { get; set; }

        public virtual int HealthRegen { get; set; }

        public virtual int CurrentHealthRegen { get; set; }

        public virtual double MaxMana { get; set; }

        public virtual double CurrentMana { get; set; }

        public virtual int ManaRegen { get; set; }

        public virtual int CurrentManaRegen { get; set; }

        public virtual double AttackPower { get; set; }

        public virtual double CurrentAttackPower { get; set; }

        public virtual double MagicPower { get; set; }

        public virtual double CurrentMagicPower { get; set; }

        public virtual double ArmorValue { get; set; }

        public virtual double CurrentArmorValue { get; set; }

        public virtual double RessistanceValue { get; set; }

        public virtual double CurrentRessistanceValue { get; set; }

        public virtual double CritChance { get; set; }

        public virtual double CurrentCritChance { get; set; }

        public virtual int GoldAmount { get; set; }

        public virtual int Mastery { get; set; }

        public virtual string ImageURL { get; set; }

        public virtual bool IsSelected { get; set; }

        public virtual int Energy { get; set; }

        public virtual string Description { get; set; }

        public virtual string IconURL { get; set; }
    }
}
