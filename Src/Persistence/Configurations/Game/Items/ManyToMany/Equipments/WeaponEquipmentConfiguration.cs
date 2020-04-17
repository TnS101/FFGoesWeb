namespace Persistence.Configurations.Game.Items.Equipments.ManyToMany
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WeaponEquipmentConfiguration : IEntityTypeConfiguration<WeaponEquipment>
    {
        public void Configure(EntityTypeBuilder<WeaponEquipment> builder)
        {
            builder.HasKey(we => new { we.WeaponId, we.EquipmentId });

            builder.HasOne(w => w.Weapon)
                .WithMany(we => we.WeaponEquipments)
                .HasForeignKey(w => w.WeaponId);

            builder.HasOne(e => e.Equipment)
                 .WithMany(we => we.WeaponEquipments)
                 .HasForeignKey(e => e.EquipmentId);
        }
    }
}
