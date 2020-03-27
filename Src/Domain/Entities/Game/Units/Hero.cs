namespace Domain.Entities.Game.Units
{
    using Domain.Base;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;

    public class Hero : Unit
    {
        public override int Id { get; set; }

        public override int EquipmentId { get; set; }

        public override Equipment Equipment { get; set; }

        public override string UserId { get; set; }

        public override AppUser User { get; set; }

        public override int InventoryId { get; set; }

        public override Inventory Inventory { get; set; }

        public override string ProfessionId { get; set; }

        public override Profession Profession { get; set; }

        public override string Name { get; set; }

        public override string Type { get; set; }

        public override string ClassType { get; set; }

        public override string Race { get; set; }

        public override int Level { get; set; }

        public override double XP { get; set; }

        public override double XPCap { get; set; }

        public override double MaxHP { get; set; }

        public override double CurrentHP { get; set; }

        public override int HealthRegen { get; set; }

        public override int CurrentHealthRegen { get; set; }

        public override double MaxMana { get; set; }

        public override double CurrentMana { get; set; }

        public override int ManaRegen { get; set; }

        public override int CurrentManaRegen { get; set; }

        public override double AttackPower { get; set; }

        public override double CurrentAttackPower { get; set; }

        public override double MagicPower { get; set; }

        public override double CurrentMagicPower { get; set; }

        public override double ArmorValue { get; set; }

        public override double CurrentArmorValue { get; set; }

        public override double RessistanceValue { get; set; }

        public override double CurrentRessistanceValue { get; set; }

        public override double CritChance { get; set; }

        public override double CurrentCritChance { get; set; }

        public override int GoldAmount { get; set; }

        public override int Mastery { get; set; }

        public override string ImageURL { get; set; }

        public override bool IsSelected { get; set; }

        public override int Energy { get; set; }
    }
}
