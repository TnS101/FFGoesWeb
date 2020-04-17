namespace Persistence.Configurations.Game.Items.Equipments.ManyToMany
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArmorEquipmentsConfiguration : IEntityTypeConfiguration<ArmorEquipment>
    {
        public void Configure(EntityTypeBuilder<ArmorEquipment> builder)
        {
            builder.HasKey(ae => new { ae.ArmorId, ae.EquipmentId });

            builder.HasOne(a => a.Armor)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(a => a.ArmorId);

            builder.HasOne(e => e.Equipment)
                .WithMany(a => a.ArmorEquipments)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
