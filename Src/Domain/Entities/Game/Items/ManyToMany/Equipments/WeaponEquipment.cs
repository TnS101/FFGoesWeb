namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Units;

    public class WeaponEquipment
    {
        public long WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
