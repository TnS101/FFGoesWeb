namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootKeyInventoryConfiguration : IEntityTypeConfiguration<LootKeyInventory>
    {
        public void Configure(EntityTypeBuilder<LootKeyInventory> builder)
        {
            builder.HasKey(ti => new { ti.LootKeyId, ti.InventoryId });

            builder.Property(ti => ti.InventoryId).HasColumnType("bigint");

            builder.HasOne(t => t.LootKey)
                .WithMany(ti => ti.LootKeyInventories)
                .HasForeignKey(t => t.LootKeyId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.LootKeyInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
