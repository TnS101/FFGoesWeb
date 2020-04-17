﻿namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WeaponInventoryConfiguration : IEntityTypeConfiguration<WeaponInventory>
    {
        public void Configure(EntityTypeBuilder<WeaponInventory> builder)
        {
            builder.HasKey(wi => new { wi.WeaponId, wi.InventoryId });

            builder.HasOne(w => w.Weapon)
                .WithMany(w => w.WeaponInventories)
                .HasForeignKey(w => w.WeaponId);

            builder.HasOne(i => i.Inventory)
                .WithMany(wi => wi.WeaponInventories)
                .HasForeignKey(i => i.InventoryId);
        }
    }
}
