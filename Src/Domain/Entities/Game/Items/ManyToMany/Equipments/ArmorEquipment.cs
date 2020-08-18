namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Units;

    public class ArmorEquipment
    {
        public long ArmorId { get; set; }

        public Armor Armor { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
