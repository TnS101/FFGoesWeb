namespace Persistence.Configurations.Game.Items.Equipments.ManyToMany
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WeaponEquipmentConfiguration : IEntityTypeConfiguration<WeaponEquipment>
    {
        public void Configure(EntityTypeBuilder<WeaponEquipment> builder)
        {
            builder.HasKey(we => new { we.WeaponId, we.HeroId });

            builder.Property(we => we.WeaponId).HasColumnType("bigint");

            builder.Property(we => we.HeroId).HasColumnType("bigint");

            builder.HasOne(w => w.Weapon)
                .WithMany(we => we.WeaponEquipment)
                .HasForeignKey(w => w.WeaponId);

            builder.HasOne(e => e.HeroId)
                 .WithMany(we => we.WeaponEquipment)
                 .HasForeignKey(e => e.EquipmentId);
        }
    }
}
