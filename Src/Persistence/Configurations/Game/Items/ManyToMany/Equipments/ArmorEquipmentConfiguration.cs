namespace Persistence.Configurations.Game.Items.Equipments.ManyToMany
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArmorEquipmentConfiguration : IEntityTypeConfiguration<ArmorEquipment>
    {
        public void Configure(EntityTypeBuilder<ArmorEquipment> builder)
        {
            builder.HasKey(ae => new { ae.ArmorId, ae.EquipmentId });

            builder.Property(ae => ae.ArmorId).HasColumnType("bigint");

            builder.Property(ae => ae.EquipmentId).HasColumnType("bigint");

            builder.HasOne(a => a.Armor)
                .WithMany(ae => ae.ArmorEquipment)
                .HasForeignKey(a => a.ArmorId);

            builder.HasOne(e => e.Equipment)
                .WithMany(ae => ae.ArmorEquipment)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
