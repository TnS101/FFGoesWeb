﻿namespace Persistence.Configurations.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RelicEquipmentConfiguration : IEntityTypeConfiguration<RelicEquipment>
    {
        public void Configure(EntityTypeBuilder<RelicEquipment> builder)
        {
            builder.HasKey(re => new { re.RelicId, re.EquipmentId });

            builder.Property(re => re.RelicId).HasColumnType("bigint");

            builder.Property(re => re.EquipmentId).HasColumnType("bigint");

            builder.HasOne(r => r.Relic)
                .WithMany(r => r.RelicEquipments)
                .HasForeignKey(r => r.RelicId);

            builder.HasOne(e => e.Equipment)
                .WithMany(r => r.RelicEquipments)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
