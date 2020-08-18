﻿namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArmorInventoryConfiguration : IEntityTypeConfiguration<ArmorInventory>
    {
        public void Configure(EntityTypeBuilder<ArmorInventory> builder)
        {
            builder.HasKey(ai => new { ai.ArmorId, ai.InventoryId });

            builder.Property(ai => ai.ArmorId).HasColumnType("bigint");

            builder.Property(ai => ai.InventoryId).HasColumnType("bigint");

            builder.HasOne(a => a.Armor)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(a => a.ArmorId);

            builder.HasOne(i => i.Hero)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
                .HasDefaultValue(1);
        }
    }
}
