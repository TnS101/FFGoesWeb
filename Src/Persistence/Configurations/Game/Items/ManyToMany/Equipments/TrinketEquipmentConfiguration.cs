﻿namespace Persistence.Configurations.Game.Items.Equipments.ManyToMany
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrinketEquipmentConfiguration : IEntityTypeConfiguration<TrinketEquipment>
    {
        public void Configure(EntityTypeBuilder<TrinketEquipment> builder)
        {
            builder.HasKey(te => new { te.TrinketId, te.EquipmentId });

            builder.HasOne(t => t.Trinket)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(t => t.TrinketId);

            builder.HasOne(e => e.Equipment)
                .WithMany(te => te.TrinketEquipments)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}